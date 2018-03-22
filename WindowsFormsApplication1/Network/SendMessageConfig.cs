using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Network
{
    class SendMessageConfig
    {
        public static string SendToHand(Int16 thumbPos, Int16 indexPos, Int16 middlePos, Int16 ringPos,
                                        Int16 pinkyPos, Int16 thumbCur, Int16 indexCur, Int16 middleCur,
                                        Int16 ringCur, Int16 pinkyCur)
        {
           string message = $"fhset:{thumbPos.ToString().PadLeft(3, ' ')},{indexPos.ToString().PadLeft(3, ' ')}," +
                $"{middlePos.ToString().PadLeft(3, ' ')},{ringPos.ToString().PadLeft(3, ' ')},{pinkyPos.ToString().PadLeft(3, ' ')}," +
                $"{thumbCur.ToString().PadLeft(3, ' ')},{indexCur.ToString().PadLeft(3, ' ')},{middleCur.ToString().PadLeft(3, ' ')}," +
                $"{ringCur.ToString().PadLeft(3, ' ')},{pinkyCur.ToString().PadLeft(3, ' ')}\r\n";
            return message;
        }
    }
}
