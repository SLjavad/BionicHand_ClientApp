using InTheHand.Net;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Bluetooth.Factory;
using InTheHand.Net.Sockets;
using InTheHand.Windows.Forms;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.Network;

namespace WindowsFormsApplication1.Models
{
    class EMG1C : BluetoothCommunication
    {
        NetworkStream ns;
        private int delay;
        public int Delay { get => delay; set => delay = value; }


        public override void Pair_Connect()
        {
            BeginDiscoverDevices(255, false, true, true, false, new AsyncCallback((result) =>
            {
                if (result.IsCompleted)
                {
                    try
                    {
                        BluetoothDevice = EndDiscoverDevices(result).FirstOrDefault(a => a.DeviceName == "FumBionicHand");
                        if (!BluetoothDevice.Authenticated)
                        {
                            BluetoothSecurity.PairRequest(BluetoothDevice.DeviceAddress, "2688");
                        }
                        SetPin("2688");
                        Connect(BluetoothDevice.DeviceAddress, BluetoothService.SerialPort);
                        //BeginConnect(BluetoothDevice.DeviceAddress, BluetoothService.SerialPort, new AsyncCallback((result2) =>
                        // {
                        //     if (result2.IsCompleted)
                        //     {
                        //         EndConnect(result2);
                        //         OnConnectionEstablished();
                        //     }
                        // }),this);
                        OnConnectionEstablished();
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.Contains("failed to respond"))
                        {
                            MessageBox.Show("Device Cannot respod to Connection request\nPlease Try later", "Connection Failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                        }
                        else if (ex is NullReferenceException)
                        {
                            MessageBox.Show("FumBionicHand Not Found\nPlease Try later", "Connection Failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                        }
                        else
                        {
                            MessageBox.Show(ex.Message);
                        }
                        OnConnectionFailed(new MessageReceiveEventArgs()
                        {
                            Message = "Reconnect",
                            Parameter = null
                        });
                    }

                }
            }), this);
        }

        bool flag = false;



        public override void StartReceiveData()
        {
            try
            {
                ns = GetStream();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetBaseException().ToString() + "\n\nEMG1C Class");
                return;
            }
            flag = true;
            delay = 0;
            Task.Run(() =>
            {
                while (flag)
                {
                    try
                    {
                        if (Connected)
                        {
                            if (Available < 9)
                                continue;
                            byte[] byteReceive = new byte[Available];
                            string value;
                            int a = ns.Read(byteReceive, 0, Available);
                            //if (a < 5)
                            //    delay += 25;
                            value = Encoding.ASCII.GetString(byteReceive);
                            Console.WriteLine(value);
                            base.OnMessageReceived(new MessageReceiveEventArgs
                            {
                                Message = value,
                                Parameter = null
                            });
                        }
                        else
                        {
                            MessageBox.Show("Device is not Connected", "Connection Failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.GetBaseException().ToString() + "\n\nEMG1C Class Connection");
                    }
                }
            });
        }

        public override void StopReceiveData()
        {
            flag = false;
        }
    }
}
