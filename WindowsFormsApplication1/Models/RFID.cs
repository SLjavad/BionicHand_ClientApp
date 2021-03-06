﻿using System.IO;
using System.Net.Sockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Models
{
    class RFID : TCP_Communication
    {
        public enum RFIDGestureEnum
        {
            
        }

        //RFIDGestureEnum RFIDgesture;

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
                            ns.Read(messageByte, 0, ReceiveBufferSize);
                            string message = Encoding.ASCII.GetString(messageByte);
                            MessageReceiveEventArgs receiveEventArgs = new MessageReceiveEventArgs();
                            receiveEventArgs.Parameter = "RFID";
                            receiveEventArgs.Message = message;
                            //Process();
                            base.OnMessageReceived(receiveEventArgs);
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
