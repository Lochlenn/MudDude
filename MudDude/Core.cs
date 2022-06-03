using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudDude
{
    public class Core
    {

        MainForm mainForm;
        TelnetClient netClient;
        Parser parser;

        private EventHandler<TextReceivedEventArgs> RaiseTextReceivedEvent;
        private EventHandler<DisconnectedEventArgs> RaiseDisconnectedEvent;

        public Core(MainForm _MainForm)
        {
            mainForm = _MainForm;
            netClient = new TelnetClient(this);
            parser = new Parser(this);

            if (RaiseTextReceivedEvent == null)
                RaiseTextReceivedEvent += OnRaiseTextReceived;
            if (RaiseDisconnectedEvent == null)
                RaiseDisconnectedEvent += OnRaiseDisconnectEvent;
        }

        public async Task ConnectToServer()
        {
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

        private void OnRaiseTextReceived(object sender, TextReceivedEventArgs trea)
        {

        }

        private void OnRaiseDisconnectEvent(object sender, DisconnectedEventArgs dcea)
        {

        }
    }
}
