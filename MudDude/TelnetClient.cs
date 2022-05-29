using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.IO;

namespace MudDude
{
    public class TelnetClient
    {
        IPAddress ServerIPAddress;
        int ServerPort;
        TcpClient MainClient;
        public char[] ReadData;

        public EventHandler<TextReceivedEventArgs> RaiseTextReceivedEvent;
        public EventHandler<DisconnectedEventArgs> RaiseDisconnectEvent;

        public TelnetClient()
        {
            ServerIPAddress = null;
            ServerPort = -1;
            MainClient = null;
            ReadData = new char[64];
        }

        public IPAddress GetServerIPAddress { get { return ServerIPAddress; } }
        public int GetServerPort() { return ServerPort; }

        public bool SetServerIPAddress(string _ServerIPAddress)
        {
            IPAddress ipAddress = null;
            if (!IPAddress.TryParse(_ServerIPAddress, out ipAddress))
            {
                return false;
            }

            ServerIPAddress = ipAddress;
            return true;
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
                await MainClient.ConnectAsync(ServerIPAddress, ServerPort);
                ReadDataAsync(MainClient);
            }
            catch (Exception excp)
            {
                Console.WriteLine("ConnectToServer Error: "+ excp.ToString());
                ProcessConnectionProblem(excp);
                throw;
            }
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
                        // TODO add disconnect event
                        MainClient.Close();
                        break;
                    }

                    // TODO text received event
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
                //OnDisconnectEvent(this, new DisconnectedEventArgs(reason));
            }
            if (excp.ToString().ToLower().Contains("aborted"))
            {
                string[] reason = { "host", "disconnected" };
                CloseAndDisconnect();
                //OnDisconnectEvent(this, new DisconnectedEventArgs(reason));
            }
            else
            {
                CloseAndDisconnect();
                string[] reason = { "unknown", "reason" };
                //OnDisconnectEvent(this, new DisconnectedEventArgs(reason));
            }
        }

        public void OnRaiseTextReceivedEvent(object sender, TextReceivedEventArgs trea)
        {
            EventHandler<TextReceivedEventArgs> handler = RaiseTextReceivedEvent;

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
