using System.IO;
using System.Net.Sockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Models
{
    class Hand : TCP_Communication
    {
        Finger thumb , index , middle , ring , pinky;
        Int16 currentGesture;
        Int16 chargeBattery;

        private void HandleMessage(string message)
        {
            if (message.StartsWith("fhget:"))
            {
                string[] values = message.Split(':')[1].Split(',');
                MessageReceiveEventArgs receiveEventArgs = new MessageReceiveEventArgs();
                receiveEventArgs.DeviceType = "Hand";
                receiveEventArgs.Message = message;
                base.OnMessageReceived(receiveEventArgs);
            }
            //TODO
            
        }

        public override void StartReceiveMessage()
        {
            NetworkStream ns = GetStream();
            Task.Run(() => {
                while (true)
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
                        }
                        else
                        {
                            System.Windows.Forms.MessageBox.Show("Connection terminated");
                            base.OnConnectionTerminated();
                        }
                    }
                    catch (IOException ex)
                    {
                        System.Windows.Forms.MessageBox.Show(ex.Message.Contains("existing connection was forcibly closed") ? "Connection terminated" : ex.GetBaseException().ToString());
                        base.OnConnectionTerminated();
                    }

                }
            });

        }


    }
}
