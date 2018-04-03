using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.Models
{
    public enum EMGGestureEnum
    {
        Fist = 1, Open, ToOut, ToIn, Unknown
    }
    class EMG : TCP_Communication
    {
        Int16[] channels = new Int16[8];
        EMGGestureEnum emgGesture;

        NetworkStream ns;


        public EMGGestureEnum EmgGesture { get => emgGesture; }

        public void StopReceiveMessage()
        {
            flag = false;
            ns.Close();
        }

        private void HandleMessage(string message)
        {
            if (message.StartsWith("EMG8:"))
            {
                string value = message.Split(':')[1].Split('#')[0];
                MessageReceiveEventArgs receiveEventArgs = new MessageReceiveEventArgs
                {
                    Parameter = "EMG8",
                    Message = value
                };
                base.OnMessageReceived(receiveEventArgs);
            }
            else if (message.StartsWith("GES:"))
            {
                emgGesture = (EMGGestureEnum)int.Parse(message.Split(':')[1]);
                //switch (EmgGesture)
                //{
                //    case EMGGestureEnum.Fist:
                        
                //        break;
                //    case EMGGestureEnum.Open:
                        
                //        break;
                //    case EMGGestureEnum.ToOut:
                        
                //        break;
                //    case EMGGestureEnum.ToIn:
                        
                //        break;
                //    case EMGGestureEnum.Unknown:
                        
                //        break;
                //    default:
                //        break;
                //}
            }
        }
        bool flag = false;
        
        
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
                    MessageBox.Show("EMG Module is disconnected \nPlease Connect first", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    MessageBox.Show(ex.GetBaseException().ToString() + "\n\nHand Class");
                }
                return;
            }
            //cancellationTokenSource = new CancellationTokenSource();
            //cancellationToken = cancellationTokenSource.Token;
            flag = true;
            Task.Run(() =>
            {
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

                            //Process();
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
