using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudDude
{
    //public class ClientConnectedEventArgs : EventArgs
    //{
    //    public string NewClient { get; set; }

    //    public ClientConnectedEventArgs(string _newClient)
    //    {
    //        NewClient = _newClient;
    //    }
    //}


    public class TextReceivedEventArgs : EventArgs
    {
        public string ClientWhoSentText { get; set; }
        public char[] TextReceived { get; set; }

        public TextReceivedEventArgs(string _clientWhoSentText, char[] _textReceived)
        {
            ClientWhoSentText = _clientWhoSentText;
            TextReceived = _textReceived;
        }
    }

    public class DisconnectedEventArgs : EventArgs
    {
        public string[] DisconnectReason { get; set; }

        public DisconnectedEventArgs(string[] _disconnectReason)
        {
            DisconnectReason = _disconnectReason;
        }
    }

    public class SendTextEventArgs : EventArgs
    {
        public char CharToSend { get; set; }

        public SendTextEventArgs(char _charToSend)
        {
            CharToSend = _charToSend;
        }
    }
}
