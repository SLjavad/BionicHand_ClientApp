using System.Threading;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    abstract class TCP_Communication : TcpClient
    {
        public event EventHandler<MessageReceiveEventArgs> ReceiveMessageHandler;
        public event EventHandler ConnectionTerminateHandler;

        protected virtual void OnMessageReceived(MessageReceiveEventArgs args)
        {
            ReceiveMessageHandler?.Invoke(this, args);
        }

        protected virtual void OnConnectionTerminated()
        {
            ConnectionTerminateHandler?.Invoke(this,EventArgs.Empty);
        }

        public void TCPConnect(string IP , int port)
        {
            Task.Run(() =>
            {
                try
                {
                    Connect(IPAddress.Parse(IP), port);
                    NoDelay = true;
                    MessageBox.Show("Connected");
                }
                catch (Exception e)
                {
                    MessageBox.Show("Connection Failed");
                }
            });
            
        }
        // Send TCP
        public void SendMessage(string message)
        {
            byte[] messageBuffer = Encoding.ASCII.GetBytes(message);
            NetworkStream networkStream = GetStream();
            networkStream.Write(messageBuffer, 0, message.Length);
        }
        // Receive TCP
        public abstract void StartReceiveMessage();

        //Process Method
        //protected abstract void Process();

        public bool IsConnected()
        {
            return Connected;
        }


    }
}
