﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Sockets;
namespace FlightSimulatorApp.Telnet
{
    public class MyTelnetClient : ITelnetClient
    {
        private string ip;
        private int port;
        private Socket socket;

        public MyTelnetClient()
        {
            this.ip = "127.0.0.1";
            this.port = 6400;
        }

        public bool connect()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                socket.Connect(this.ip, this.port);
            }
            catch (SocketException)
            {
                System.Windows.MessageBox.Show("Connection Error - please open FlightGear and press 'fly'.\n" +
                    "Make sure you follow the instructions under the 'Show Instructions' button.");
                return false;
            }
            return true;
        }

        public void disconnect()
        {
            socket.Disconnect(true);
        }

        public void write(string command)
        {
            var commandInBytes = Encoding.ASCII.GetBytes(command + "\r\n");
            socket.Send(commandInBytes);
        }
    }
}