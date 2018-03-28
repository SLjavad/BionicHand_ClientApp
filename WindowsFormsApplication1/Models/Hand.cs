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
        NetworkStream ns;

        private void HandleMessage(string message)
        {
            if (message.StartsWith("fhget:"))
            {
                string values = message.Split(':')[1].Split(new [] {Environment.NewLine},StringSplitOptions.None)[0];
                for (int i = 0; i < values.Length; i++)
                {
                    MessageReceiveEventArgs receiveEventArgs = new MessageReceiveEventArgs();
                    receiveEventArgs.Parameter = null;
                    receiveEventArgs.Message = values;
                    base.OnMessageReceived(receiveEventArgs);
                }
            }
        }

        public void StopReceiveMessage()
        {
            flag = false;
        }

        bool flag = false;

        public Finger Thumb { get => thumb; set => thumb = value; }
        public Finger Index { get => index; set => index = value; }
        public Finger Middle { get => middle; set => middle = value; }
        public Finger Ring { get => ring; set => ring = value; }
        public Finger Pinky { get => pinky; set => pinky = value; }
        public short CurrentGesture { get => currentGesture; set => currentGesture = value; }
        public short ChargeBattery { get => chargeBattery; set => chargeBattery = value; }

        public override void StartReceiveMessage()
        {
            ns = GetStream();
            flag = true;
            Task.Run(() => {
                while (flag)
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
