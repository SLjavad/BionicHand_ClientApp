using System;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.Models
{
    public enum EMGGestureEnum
    {
        first = 1, second, third, forth, fifth, sixth, seventh, eighth
    }
    class EMG : TCP_Communication
    {
        //Int16[] channels = new Int16[8];
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
            // EMG:int,int,int\r\nGES:int\r\n
            try
            {
                if (message.StartsWith("EMG:"))
                {
                    //string[] data = message.Split(':')[1].Split('#');
                    string[] data = message.Split(new[] { "EMG:", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < data.Length; i++)
                    {
                        if (data[i].Contains("GES"))
                        {
                            string[] temp = data[i].Split(new[] { "GES:" }, StringSplitOptions.RemoveEmptyEntries);
                            emgGesture = (EMGGestureEnum)int.Parse(temp[0]);
                        }
                        else
                        {
                            base.OnMessageReceived(new MessageReceiveEventArgs
                            {
                                Message = data[i],
                                Parameter = "EMG"
                            });
                        }
                    }
                }
                else if (message.StartsWith("GES:"))
                {
                    emgGesture = (EMGGestureEnum)int.Parse(message.Substring(4, 1));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetBaseException().ToString() + "\n\n" + "From EMG Handle Message");
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
                            if (Available < 5)
                            {
                                continue;
                            }
                            int cont = Available;
                            //Console.WriteLine(Available.ToString() + "sdf");
                            byte[] messageByte = new byte[cont];
                            int a = ns.Read(messageByte, 0, cont);
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
                    catch (Exception e)
                    {
                        MessageBox.Show(e.GetBaseException().ToString());
                    }


                }
            });

        }
    }
}
