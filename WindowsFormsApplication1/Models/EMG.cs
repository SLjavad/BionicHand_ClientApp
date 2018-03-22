using System.IO;
using System.Diagnostics;
using System.Net.Sockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.InteropServices.ComTypes;

namespace WindowsFormsApplication1.Models
{
    class EMG : TCP_Communication
    {
        public enum EMGGestureEnum
        {
            OpenAll , CloseAll , IndexUp , Pinch
        }

        Int16[] channels = new Int16[8];
        EMGGestureEnum emgGesture;

        CancellationTokenSource cancellationTokenSource;
        CancellationToken cancellationToken;
        NetworkStream ns;

         EMGGestureEnum EmgGesture { get => emgGesture; }

        public void StopReceiveMessage()
        {
            cancellationTokenSource.Cancel();
            ns.Close();
        }

        private void HandleMessage(string message)
        {
            if (message.StartsWith("EMG8:"))
            {
                string[] value = message.Split(':')[1].Split(',');
                MessageReceiveEventArgs receiveEventArgs = new MessageReceiveEventArgs
                {
                    DeviceType = "EMG",
                    Message = message
                };
                base.OnMessageReceived(receiveEventArgs);
            }
            else if (message.StartsWith("gesture:"))
            {
                emgGesture = (EMGGestureEnum)int.Parse(message.Split(':')[1]);
            }
        }

        public override void StartReceiveMessage()
        {
            ns = GetStream();
            cancellationTokenSource = new CancellationTokenSource();
            cancellationToken = cancellationTokenSource.Token;

            Task.Run(() => {
                while (!cancellationToken.IsCancellationRequested)
                {
                    try
                    {
                        if (IsConnected())
                        {
                            byte[] messageByte = new byte[ReceiveBufferSize];
                            int a = ns.Read(messageByte, 0, ReceiveBufferSize);
                            byte[] Result = new byte[a];
                            Array.Copy(messageByte, Result, a);
                            string message = Encoding.ASCII.GetString(Result);
                            HandleMessage(message);
                            //string[] message = Encoding.ASCII.GetString(Result).Split(new [] {','}, StringSplitOptions.RemoveEmptyEntries);
                            //Process();
                        }
                        else
                        {
                            System.Windows.Forms.MessageBox.Show("Connection terminated");
                            base.OnConnectionTerminated();
                            break;
                        }
                    }
                    catch (IOException ex)
                    {
                        System.Windows.Forms.MessageBox.Show(ex.Message.Contains("existing connection was forcibly closed") ? "Connection terminated" : ex.GetBaseException().ToString());
                        base.OnConnectionTerminated();
                        break;
                    }
                    
                    
                }
            },cancellationToken);
            
        }
    }
}
