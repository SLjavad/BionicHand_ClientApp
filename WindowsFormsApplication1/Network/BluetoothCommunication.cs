using InTheHand.Net;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Network
{
    abstract class BluetoothCommunication : BluetoothClient
    {
        private BluetoothDeviceInfo bluetoothDevice;
        
        public BluetoothDeviceInfo BluetoothDevice { get => bluetoothDevice; set => bluetoothDevice = value; }

        public event EventHandler ConnectionEstablished;
        public event EventHandler<MessageReceiveEventArgs> MessageReceived;
        public event EventHandler<MessageReceiveEventArgs> ConnectionFailed;

        protected virtual void OnConnectionEstablished()
        {
            ConnectionEstablished?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnMessageReceived(MessageReceiveEventArgs eventArgs)
        {
            MessageReceived?.Invoke(this, eventArgs);
        }

        protected virtual void OnConnectionFailed(MessageReceiveEventArgs eventArgs)
        {
            ConnectionFailed?.Invoke(this, eventArgs);
        }

        public abstract void Pair_Connect();
        public abstract void StartReceiveData();
        public abstract void StopReceiveData();
    }
}
