using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MudDude
{
    public class Core
    {
        // Forms
        Settings SettingsForm;
        DebugWindow DebugForm;
        MainForm mainForm;

        // Classes
        TelnetClient netClient;
        Parser parser;

        private EventHandler<TextReceivedEventArgs> RaiseTextReceivedEvent;
        private EventHandler<DisconnectedEventArgs> RaiseDisconnectedEvent;
        public EventHandler<SendTextEventArgs> RaiseSendTextEvent;

        public Core(MainForm _MainForm)
        {
            // Forms
            mainForm = _MainForm;
            DebugForm = new DebugWindow(this);
            SettingsForm = new Settings();

            // Classes
            netClient = new TelnetClient(this);
            parser = new Parser(this);

            if (netClient.RaiseTextReceivedEvent == null)
                netClient.RaiseTextReceivedEvent += OnRaiseTextReceived;
            if (netClient.RaiseDisconnectEvent == null)
                netClient.RaiseDisconnectEvent += OnRaiseDisconnectEvent;
        }

        public async Task ConnectToServer()
        {
            RaiseTextReceivedEvent += OnRaiseTextReceived;
            // TODO magic numbers
            if (netClient.SetServerIPAddress(MudDude.Default.ServerAddress) && netClient.SetServerPort(MudDude.Default.ServerPort))
            {
                await netClient.ConnectToServer();
            }
            else
            {
                // failed to set ip address, likely dns lookup failure
                mainForm.ShowErrorMessage("host/port failure, check entries");
            }
            
        }

        public void OpenSettingsForm()
        {
            SettingsForm.Show();
        }

        public void OpenDebugWindows()
        {
            DebugForm.Show();
        }

        public void SendCharToServer(char charToSend)
        {
            netClient.SendCharToServer(charToSend);
        }

        private void OnRaiseTextReceived(object sender, TextReceivedEventArgs trea)
        {
            foreach (char textChar in trea.TextReceived)
            {
                DebugForm.AddTextToScreen(textChar);
            }
            
        }

        private void OnRaiseDisconnectEvent(object sender, DisconnectedEventArgs dcea)
        {

        }

        public void OnSendTextEvent(object sender, SendTextEventArgs stea)
        {
            EventHandler<SendTextEventArgs> handler = RaiseSendTextEvent;
            if (handler != null)
            {
                handler(this, stea);
            }
        }
    }
}
