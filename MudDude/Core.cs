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

        public Core(MainForm _MainForm)
        {

            mainForm = _MainForm;
            netClient = new TelnetClient(this);
            parser = new Parser(this);
        }

        public void ConnectToServer()
        {
            netClient.SetServerIPAddress("10.0.100.125");
            netClient.SetServerPort(23);
            netClient.ConnectToServer();
        }
    }
}
