using System;
using WindowsFormsApplication1.Models;

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

        public static string SendFromEmg8ToHand(EMGGestureEnum emgGesture)
        {
            switch (emgGesture)
            {
                case EMGGestureEnum.first:
                    return SendToHand(0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                case EMGGestureEnum.second:
                    return SendToHand(100, 0, 0, 0, 0, 100, 0, 0, 0, 0);
                case EMGGestureEnum.third:
                    return SendToHand(0, 100, 0, 0, 0, 0, 100, 0, 0, 0);
                case EMGGestureEnum.forth:
                    return SendToHand(100, 100, 0, 0, 0, 100, 100, 0, 0, 0);
                case EMGGestureEnum.fifth:
                    return SendToHand(0, 0, 0, 100, 0, 0, 0, 0, 100, 0);
                case EMGGestureEnum.sixth:
                    return SendToHand(100, 0, 0, 100, 0, 100, 0, 0, 100, 0);
                case EMGGestureEnum.seventh:
                    return SendToHand(0, 100, 0, 100, 0, 0, 100, 0, 100, 0);
                case EMGGestureEnum.eighth:
                    return SendToHand(100, 100, 0, 100, 0, 100, 100, 0, 100, 0);
                default:
                    return null;
            }
        }

        public static string HandOpen()
        {
            return SendToHand(100, 100, 100, 100, 100, 100, 100, 100, 100, 100);
        }

        public static string HandFist()
        {
            return SendToHand(0, 0, 0, 15, 15, 100, 100, 100, 100, 100);
        }

        public static string SendRFIDFeedback(HandRFIDs handRFIDs)
        {
            //switch (handRFIDs)
            //{
            //    case HandRFIDs.thumb:
            //        return SendToHand(0, 100, 100, 100, 100, 100, 100, 100, 100, 100);
            //    case HandRFIDs.index:
            //        return SendToHand(100, 0, 100, 100, 100, 100, 100, 100, 100, 100);
            //    case HandRFIDs.middle:
            //        return SendToHand(100, 100, 0, 100, 100, 100, 100, 100, 100, 100);
            //    case HandRFIDs.ring:
            //        return SendToHand(100, 100, 100, 100, 0, 100, 100, 100, 100, 100);
            //    case HandRFIDs.pinky:
            //        return SendToHand(100, 100, 100, 0, 100, 100, 100, 100, 100, 100);
            //    default:
            return null;
            
        }
    }
}
