using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;


namespace MudDude
{
    public class TelnetClient
    {
        IPAddress ServerIPAddress = null;
        int ServerPort = -1;
        TcpClient MainClient = null;
        public char[] ReadData = new char[64];

        Core MainCore;

        public EventHandler<TextReceivedEventArgs> RaiseTextReceivedEvent;
        public EventHandler<DisconnectedEventArgs> RaiseDisconnectEvent;
        public EventHandler<SendTextEventArgs> RaiseSendTextEvent;

        StreamWriter ClientStreamWriter;

        public TelnetClient(Core _MainCore)
        {
            MainCore = _MainCore;
        }

        public IPAddress GetServerIPAddress { get { return ServerIPAddress; } }
        public int GetServerPort() { return ServerPort; }

        public bool SetServerIPAddress(string _ServerIPAddress)
        {
            IPAddress ipAddress;

            // check if raw IP
            if (!IPAddress.TryParse(_ServerIPAddress, out ipAddress))
            {
                // not IP address, check if domain name
                if (DoDNSLookup(_ServerIPAddress, out ipAddress))
                {
                    ServerIPAddress = ipAddress;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                ServerIPAddress = ipAddress;
                return true;
            }
        }

        public bool SetServerPort(int _ServerPort)
        {
            if (_ServerPort <= 65535 || _ServerPort > 0)
            {
                ServerPort = _ServerPort;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DoDNSLookup(string hostname, out IPAddress ipAddress)
        {
            try
            {
                ipAddress = Dns.GetHostAddresses(hostname)[0];
                Debug.WriteLine("DNS Lookup success!  " + hostname + " resolves to " + ipAddress.ToString());
                return true;
            }
            catch (Exception)
            {
                ipAddress = null;
                Debug.WriteLine("DNS Lookup failure!");
                return false;
            }
        }

        public void CloseAndDisconnect()
        {
            if (MainClient != null)
                MainClient.Close();
        }
        
        public async Task ConnectToServer()
        {
            if (MainClient == null)
                MainClient = new TcpClient();

            try
            {
                if (ServerIPAddress == null)
                {
                    
                    return;
                }
                Debug.WriteLine("Connecting to: " + ServerIPAddress.ToString() + "...");
                await MainClient.ConnectAsync(ServerIPAddress, ServerPort);
                ClientStreamWriter = new StreamWriter(MainClient.GetStream());
                ReadDataAsync(MainClient);
            }
            catch (Exception excp)
            {
                Debug.WriteLine("ConnectToServer Error: "+ excp.ToString());
                ProcessConnectionProblem(excp);
                throw;
            }
        }

        public void SendCharToServer(char CharToSend)
        {
            ClientStreamWriter.Write(CharToSend);
            ClientStreamWriter.Flush();
        }

        private async Task ReadDataAsync(TcpClient client)
        {
            try
            {
                StreamReader ClientStreamReader = new StreamReader(MainClient.GetStream());
                char[] buffer = new char[1024];
                int ReadByteCount = 0;

                MainClient.ReceiveTimeout = 5000;
                if (MainClient == null)
                    return;

                while (true)
                {
                    ReadByteCount = await ClientStreamReader.ReadAsync(buffer, 0, buffer.Length);

                    // TODO make sure this is needed
                    if (ReadByteCount == 0)
                    {
                        string[] reason = { "connection", "dropped" };
                        OnDisconnectEvent(this, new DisconnectedEventArgs(reason));
                        MainClient.Close();
                        break;
                    }
                    //Debug.WriteLine("Text received");
                    OnRaiseTextReceivedEvent(this, new TextReceivedEventArgs(MainClient.Client.RemoteEndPoint.ToString(), buffer));
                    Array.Clear(buffer, 0, buffer.Length);
                }
            }
            catch(Exception excp)
            {
                ProcessConnectionProblem(excp);
                throw;
            }
        }

        public void ProcessConnectionProblem(Exception excp)
        {
            if (excp.ToString().ToLower().Contains("actively refused"))
            {
                string[] reason = { "connection", "refused" };
                CloseAndDisconnect();
                OnDisconnectEvent(this, new DisconnectedEventArgs(reason));
            }
            if (excp.ToString().ToLower().Contains("aborted"))
            {
                string[] reason = { "host", "disconnected" };
                CloseAndDisconnect();
                OnDisconnectEvent(this, new DisconnectedEventArgs(reason));
            }
            else
            {
                CloseAndDisconnect();
                string[] reason = { "unknown", "reason" };
                OnDisconnectEvent(this, new DisconnectedEventArgs(reason));
            }
        }

        public void OnRaiseTextReceivedEvent(object sender, TextReceivedEventArgs trea)
        {
            EventHandler<TextReceivedEventArgs> handler = RaiseTextReceivedEvent;
            Debug.WriteLine("Event triggered!");
            if (handler != null)
            {
                handler(this, trea);
            }
        }

        public void OnDisconnectEvent(object sender, DisconnectedEventArgs dcea)
        {
            EventHandler<DisconnectedEventArgs> handler = RaiseDisconnectEvent;

            if (handler != null)
            {
                handler(this, dcea);
            }
        }
    }
    
}
