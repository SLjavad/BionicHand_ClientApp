using System.IO;
using System.Net.Sockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Documents;

namespace WindowsFormsApplication1.Models
{
    public enum HandRFIDs
    {
        
    }

    class Hand : TCP_Communication
    {
        Finger thumb = new Finger() , index  = new Finger() , middle = new Finger(), ring = new Finger(), pinky = new Finger();
        HandRFIDs handRFID;
        bool rFIDEnabled;
        Int16 currentGesture;
        Int16 chargeBattery;
        NetworkStream ns;

        private void HandleMessage(string message)
        {
            //fhget : thumbPos , indexPos , middlePos , ringPos , pinkyPos ,
            //         """ Cur ,  """ Cur ,  """ Cur  , """ Cur ,  """ Cur ,
            //         """ Fsr ,  """ Fsr ,  """ Fsr  , """ Fsr ,  """ Temp,
            //        RFID

            if (message.StartsWith("fhget:"))
            {
                string[] values = message.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    for (int i = 0; i < (values.Length); i++)
                    {
                        string data = values[i].Split(':')[1];
                        MessageReceiveEventArgs receiveEventArgs = new MessageReceiveEventArgs();
                        receiveEventArgs.Parameter = null;
                        receiveEventArgs.Message = data;
                        base.OnMessageReceived(receiveEventArgs);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.GetBaseException().ToString() + "\n\nfrom Hand Handle message");
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
        public HandRFIDs HandRFID { get => handRFID; set => handRFID = value; }
        public bool RFIDEnabled { get => rFIDEnabled; set => rFIDEnabled = value; }

        public override void StartReceiveMessage()
        {
            try
            {
                ns = GetStream();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("non-connected"))
                {
                    MessageBox.Show("Module is disconnected \nPlease Connect at first", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    MessageBox.Show(ex.GetBaseException().ToString() + "\n\nHand Class");
                }
                return;
            }
            
            flag = true;
            Task.Run(() => {
                while (flag)
                {
                    try
                    {
                        if (IsConnected())
                        {
                            if (Available<10)
                                continue;
                            int temp = Available;
                            byte[] messageByte = new byte[temp];
                            int a = ns.Read(messageByte, 0, temp);
                            //byte[] Result = new byte[a];
                            //Array.Copy(messageByte, Result, a);
                            string message = Encoding.ASCII.GetString(messageByte);
                            HandleMessage(message);
                        }
                        else
                        {
                            MessageBox.Show("Connection terminated");
                            base.OnConnectionTerminated();
                            break;
                        }
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show(ex.Message.Contains("existing connection was forcibly closed") ? "Connection terminated" : ex.GetBaseException().ToString());
                        base.OnConnectionTerminated();
                        break;
                    }

                }
            });

        }


    }
}
