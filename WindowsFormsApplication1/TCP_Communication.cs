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
        
        protected virtual void OnMessageReceived(MessageReceiveEventArgs args)
        {
            ReceiveMessageHandler?.Invoke(this, args);
        }

        public void TCPConnect(string IP , int port)
        {
            try
            { 
                Connect(IPAddress.Parse(IP), port);
                NoDelay = true;
                Console.WriteLine("Connected");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace + "\n" + e.Message);
            }
        }
        // Send TCP
        public void SendMessage(string message)
        {
            byte[] messageBuffer = Encoding.ASCII.GetBytes(message);
            NetworkStream networkStream = GetStream();
            networkStream.Write(messageBuffer, 0, message.Length);
        }
        // Receive TCP
        public abstract void ReceiveMessage();

        // Process Method
        //protected abstract void Process();

        public bool IsConnected()
        {
            return Connected;
        }


    }
}
