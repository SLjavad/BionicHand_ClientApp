﻿using System.IO;
using System.Diagnostics;
using System.Net.Sockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Models
{
    class EMG : TCP_Communication
    {
        public enum EMGGestureEnum
        {
            
        }

        Int16[] channels = new Int16[9];
        EMGGestureEnum emgGesture;

        public override void ReceiveMessage()
        {
            NetworkStream ns = GetStream();
            Task.Run(() => {
                while (true)
                {
                    try
                    {

                    }
                    catch (IOException ex)
                    {
                        System.Windows.Forms.MessageBox.Show(ex.Message.Contains("existing connection was forcibly closed") ? "Connection terminated" : ex.GetBaseException().ToString());
                    }
                    if (IsConnected())
                    {
                        byte[] messageByte = new byte[ReceiveBufferSize];
                        ns.Read(messageByte, 0, ReceiveBufferSize);
                        string message = Encoding.ASCII.GetString(messageByte);
                        MessageReceiveEventArgs receiveEventArgs = new MessageReceiveEventArgs();
                        receiveEventArgs.DeviceType = "EMG";
                        receiveEventArgs.Message = message;
                        //Process();
                        base.OnMessageReceived(receiveEventArgs);
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("Connection terminated");
                    }
                    
                }
            });
            
        }
    }
}