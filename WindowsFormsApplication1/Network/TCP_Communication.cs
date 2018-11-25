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
        public event EventHandler ConnectionEstablishHandler;

        protected virtual void OnMessageReceived(MessageReceiveEventArgs args)
        {
            ReceiveMessageHandler?.Invoke(this, args);
        }

        protected virtual void OnConnectionTerminated()
        {
            ConnectionTerminateHandler?.Invoke(this,EventArgs.Empty);
        }

        protected virtual void OnConnectionEstablished()
        {
            ConnectionEstablishHandler?.Invoke(this, EventArgs.Empty);
        }

        public void TCPConnect(string IP , int port)
        {
            Task.Run(() =>
            {
                try
                {
                    // BeginConnect(IPAddress.Parse(IP), port, new AsyncCallback((result) =>
                    //{
                    //    if (result.IsCompleted)
                    //    {
                    //        EndConnect(result);
                    //        OnConnectionEstablished();
                    //    }
                    //}), this);
                    Connect(IPAddress.Parse(IP), port);
                    NoDelay = true;
                    OnConnectionEstablished();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Connection Failed\n\n{ex.GetBaseException().ToString()}");
                }
            });
            
        }
        // Send TCP
        public void SendMessage(string message)
        {
            try
            {
                byte[] messageBuffer = Encoding.ASCII.GetBytes(message);
                NetworkStream networkStream = GetStream();
                networkStream.Write(messageBuffer, 0, message.Length);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("non-connected"))
                {
                    MessageBox.Show("Module is disconnected \nPlease Connect at first","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning,MessageBoxDefaultButton.Button1);
                }
            }
            
        }
        // Receive TCP
        public abstract void StartReceiveMessage();
        

        public bool IsConnected()
        {
            return Connected;
        }


    }
}
