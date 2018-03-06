using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class MessageReceiveEventArgs : EventArgs
    {
        public string Message { get; set; }
        public string DeviceType { get; set; }
    }
}
