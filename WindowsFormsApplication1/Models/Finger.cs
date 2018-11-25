using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Models
{
    class Finger
    {
        int position;
        int desiredPos;
        int current;
        int pressure;

        public int Position { get => position; set => position = value; }
        public int DesiredPos { get => desiredPos; set => desiredPos = value; }
        public int Current { get => current; set => current = value; }
        public int Pressure { get => pressure; set => pressure = value; }
    }
}
