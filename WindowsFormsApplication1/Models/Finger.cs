using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Models
{
    class Finger
    {
        Int16 position;
        Int16 desiredPos;
        Int16 current;
        Int16 pressure;

        public short Position { get => position; set => position = value; }
        public short DesiredPos { get => desiredPos; set => desiredPos = value; }
        public short Current { get => current; set => current = value; }
        public short Pressure { get => pressure; set => pressure = value; }
    }
}
