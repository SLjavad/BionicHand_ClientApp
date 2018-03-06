using WindowsFormsApplication1.Models;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;  // for get availabe ports
using System.Runtime.InteropServices;
using System.Threading;
using System.Timers;
using System.Management;
using System.Threading;
using System.Diagnostics;
using CustomUIControls.Graphing; 

namespace WindowsFormsApplication1
{

    public partial class Form1 : Form
    {
        // Network Communication
        TCP_Communication tcpConnection;
        private string IP;
        private int Port;

        private const int WM_VSCROLL = 0x115;
        private const int SB_BOTTOM = 7;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam,
        IntPtr lParam);
        ToolStripDropDown popup = new ToolStripDropDown();
        const int vthumb = 0;
        const int vindex = 1;
        const int vmiddle = 2;
        const int vring = 3;
        const int vpinky = 4;
        bool PINGFlag = false;
        Queue SerialQueue = new Queue();
        string LastSerialData = "";
        int Pinky_Current = 0, Ring_Current = 0, Middle_Current = 0, Index_Current = 0, Thumb_Current = 0;
        Stopwatch sw = new Stopwatch();
        Stopwatch MotionTimer = new Stopwatch();
        Stopwatch MotionTimer2 = new Stopwatch();

        private AutoResetEvent BufferWaitHandle = new AutoResetEvent(false);
        private C2DPushGraph.LineHandle EMGLine;
        int EMGSignal = -5;
        int EMGSignalLOW = 0;
        int EMGSignalHIGH= 0;
        int EMGSignalPulse = 0;
        bool ControlHandFlag = false;
        int LastGesture = Gest_ALLOpen;

        int interthread_ThumbValue=0;
        int interthread_IndexValue=0;
        int interthread_MiddleValue=0;
        int interthread_RingValue=0;
        int interthread_PinkyValue=0;



        //----------Gesture Table
        private const int FullCloseDelay = 1500;
        private const int FullOpenDelay = 1500;



        private const int Gest_ALLOpen = 0;
        private const int Gest_ALLClose = 1;
        private const int Gest_PenMode = 2;
        private const int Gest_IndexUp = 3;
        private const int Gest_ThreeGrip = 4;



        public static int[,] FingerLockTable = new int[5, 5]
                      {{0,0,0,0,0}      //Gest_ALLOpen
                      ,{1,1,1,1,1}      //Gest_ALLClose
                      ,{0,0,1,1,1}      //Gest_PenMode
                      ,{1,0,1,1,1}      //Gest_IndexUp
                      ,{0,0,0,1,1}};    //Gest_ThreeGrip

        public static int[,] FingerMoveTable = new int[5, 5]
                      {{FullOpenDelay,FullOpenDelay,FullOpenDelay,FullOpenDelay,FullOpenDelay}              //Gest_ALLOpen
                      ,{FullCloseDelay,FullCloseDelay,FullCloseDelay,FullCloseDelay,FullCloseDelay}         //Gest_ALLClose
                      ,{0,0,FullCloseDelay,FullCloseDelay,FullCloseDelay}                                   //Gest_PenMode
                      ,{FullCloseDelay,0,FullCloseDelay,FullCloseDelay,FullCloseDelay}                      //Gest_IndexUp
                      ,{0,0,0,FullCloseDelay,FullCloseDelay}};                                              //Gest_ThreeGrip
        


        private Thread ParseThread = null;       

        public Form1()
        {
            InitializeComponent();
        }
        private void RefreshComports()
        {
            cmb_ports.Items.Clear();
            cmb_EMGPorts.Items.Clear();
            cmb_MotionPorts.Items.Clear();
            foreach (string s in SerialPort.GetPortNames())
            {
                cmb_ports.Items.Add(s);
                cmb_EMGPorts.Items.Add(s);
                cmb_MotionPorts.Items.Add(s);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshComports();
            logtxt.AppendText("FumBionic Controller V1.0\r\n");
            logtxt.AppendText("Ready to connect...\r\n");
            m_PushGraphCtrl.BackColor = Color.Black;
            m_PushGraphCtrl.LineInterval = 2;
            EMGLine = m_PushGraphCtrl.AddLine("EMGLine", Color.Yellow);
            EMGLine.Thickness = 2;

            //TcpConfig frmConnect = new TcpConfig();
            //if (frmConnect.ShowDialog() == DialogResult.OK)
            //{
            //    if (frmConnect.txtIP.Text != string.Empty && frmConnect.txtPort.Text != string.Empty)
            //    {
            //        IP = frmConnect.txtIP.Text;
            //        Port = int.Parse(frmConnect.txtPort.Text);
            //        tcpConnection = new TCP_Communication();
            //    }
            //    else
            //    {
            //        MessageBox.Show("One or more inputs are Empty");
            //    }
            //}
            //else
            //{
            //    logtxt.AppendText("Connection Failed !! \r\n");
            //}
        }
        public bool isConnected()
        {
            //int TimeoutCounter = 0;
            //if (SerialPortHandler.IsOpen == true)
            //{
            //    PINGFlag = false;
            //    dbg("Open OK .");
            //    SerialPortHandler.DiscardInBuffer();
            //    dbg("Step before sending ping.");
                 if(MainBoardSerial.IsOpen == true) MainBoardSerial.Write("PCPing#");
            //    dbg("PingBoard");
            //    sw.Reset();
            //    sw.Start();
            //    while(PINGFlag == false && sw.ElapsedMilliseconds < 2000){}

            //    if (sw.ElapsedMilliseconds > 2000)
            //    {
            //        dbg("Ping TimeOut");
            //    }
            //    sw.Stop();
            //    if (PINGFlag == true)
            //    {
                    dbg("PING OK !");
                    ParseThread = new Thread(new ThreadStart(this.ParseBuffer));
                    ParseThread.Start();
                    return true;
            //    }
            //    else
            //    {
            //        dbg("PingStatement Not Found,Ping string recieved :" + LastSerialData);
            //    }
                
            //    SerialPortHandler.Close();
            //    dbg("Serial Port has been closed , because the Hand didn't reply successfly");
            //    tabControl1.SelectedTab = tabPage1;
            //    return false;
            //}
            //else
            //{
            //    // ToolStripControlHost host = new ToolStripControlHost("HelloWorld");
            //    dbg("Serial Port is closed , please connect to hand first.");
            //}

            //return false;
        }
        private void dbg(string dbgstr)
        {
            CheckForIllegalCrossThreadCalls = false;
            logtxt.AppendText(dbgstr + "\r\n");
            //SendMessage(logtxt.Handle, WM_VSCROLL, (IntPtr)SB_BOTTOM, IntPtr.Zero);
        }
        private void cmd_connect_Click(object sender, EventArgs e)
        {
            dbg("Trying to connect ...");
            try
            {
                if (cmd_connect.Text == "Disconnect")
                {
                    cmd_connect.Text = "Connect";
                    MainBoardSerial.Close();
                }
                else
                {
                    MainBoardSerial.BaudRate = 115200;
                    if (MainBoardSerial.IsOpen == true) MainBoardSerial.Close();
                    MainBoardSerial.PortName = cmb_ports.Text;
                    dbg("Just before connect ...");
                    MainBoardSerial.Open();
                    dbg("First stage of connection is OK ...");
                    if (isConnected() == true)
                    {
                        dbg("Connected to Bionic Hand");
                        dbg("Controller is ready...");
                        tabControl1.SelectedTab = tabPage2;
                        cmd_connect.Text = "Disconnect";
                    }
                    else
                    {
                        dbg("No Data from MCU");
                    }
                }

            }
            catch (Exception ex)
            {
                dbg("Error in Connection : " + ex.Message);
            }
            
        }
        private void SendFingerData(int fingername, int fingervalue)
        {
            //Packet : FingerNumber,FingerDirection,FingerSpeedValue
            int TempDir=0, TempSpeed=0;
            if(fingervalue < 0)
            {
                TempDir = 1;
            }
            TempSpeed = (Math.Abs(fingervalue));
            // if(SerialPortHandler.IsOpen == true ) SerialPortHandler.Write("@SM:" + TempDir + "," + TempSpeed + "," + (TempDir+TempSpeed) + "#\r\n");
            //if (isConnected() == true)
            //{
                dbg(String.Format("Sending:{0},{1},{2},{3}#", TempDir.ToString().PadLeft(1, '0'), fingername.ToString().PadLeft(3), TempSpeed.ToString().PadLeft(3, '0'), (TempDir + TempSpeed + fingername).ToString().PadLeft(3, '0')));
              if(MainBoardSerial.IsOpen==true)  MainBoardSerial.Write(String.Format("@SM:{0},{1},{2},{3}#", TempDir.ToString().PadLeft(1, '0'), fingername.ToString().PadLeft(3), TempSpeed.ToString().PadLeft(3, '0'), (TempDir + TempSpeed + fingername).ToString().PadLeft(3, '0')));
            //}
        }
        bool FindString(string MainStr, string FindStr)
        {
            bool res;
            if (MainStr.IndexOf(FindStr) == -1) res = false;
            else res = true;
            return res;
        }
        public void ParseBuffer()
        {
            while (true)
            {
                try
                {
                    BufferWaitHandle.WaitOne();
                    //dbg("<>Parsing");
                    //dbg("<> RawRCVDATA : " + RawReceivedData.ToString());
                    lock (this)
                    {
                        while (SerialQueue.Count > 0)
                        {
                            string TempDataString;
                            string[] ParseBufferArray;
                            TempDataString = SerialQueue.Dequeue().ToString();
                            TempDataString = TempDataString.Replace("\r\n", "");
                            if (FindString(TempDataString, "Currents") == true)
                            {
                                TempDataString = TempDataString.Substring(9, TempDataString.Length - 9);
                                ParseBufferArray = TempDataString.Split(',');
                                Thumb_Current = Convert.ToInt16(Double.Parse(ParseBufferArray[0]));
                                Index_Current = Convert.ToInt16(Double.Parse(ParseBufferArray[1]));
                                Middle_Current = Convert.ToInt16(Double.Parse(ParseBufferArray[2]));
                                Ring_Current = Convert.ToInt16(Double.Parse(ParseBufferArray[3]));
                                Pinky_Current = Convert.ToInt16(Double.Parse(ParseBufferArray[4]));
                                lbl_thumb_c.Text = Thumb_Current.ToString();
                                lbl_index_c.Text = Index_Current.ToString();
                                lbl_middle_c.Text = Middle_Current.ToString();
                                lbl_ring_c.Text = Ring_Current.ToString();
                                lbl_pinky_c.Text = Pinky_Current.ToString();
                            }
                            else if (FindString(TempDataString, "EMG") == true)
                            {
                                TempDataString = TempDataString.Substring(4, TempDataString.Length - 4);
                                EMGSignal = Convert.ToInt16(TempDataString);
                            }
                            //ProcessWaitHandle.Set();
                        }
                    }
                }
            catch{

            }
            }
        }

        
        
        private void SendALLFingersValue()
        {
            MainBoardSerial.Write(String.Format("@ALLF:{0},{1},{2},{3},{4},{5}#", interthread_ThumbValue.ToString().PadLeft(4, ' ')
                                                                              , interthread_IndexValue.ToString().PadLeft(4, ' ')
                                                                              , interthread_MiddleValue.ToString().PadLeft(4, ' ')
                                                                              , interthread_RingValue.ToString().PadLeft(4, ' ')
                                                                              , interthread_PinkyValue.ToString().PadLeft(4, ' ')
                                                                              , (interthread_ThumbValue + interthread_IndexValue + interthread_MiddleValue + interthread_PinkyValue + interthread_RingValue).ToString().PadLeft(3, '0')));
            dbg(String.Format("@ALLF:{0},{1},{2},{3},{4},{5}#", interthread_ThumbValue.ToString().PadLeft(4, ' ')
                                                                               , interthread_IndexValue.ToString().PadLeft(4, ' ')
                                                                               , interthread_MiddleValue.ToString().PadLeft(4, ' ')
                                                                               , interthread_RingValue.ToString().PadLeft(4, ' ')
                                                                               , interthread_PinkyValue.ToString().PadLeft(4, ' ')
                                                                               , (interthread_ThumbValue + interthread_IndexValue + interthread_MiddleValue + interthread_PinkyValue + interthread_RingValue).ToString().PadLeft(4, '0')));
        
        }
        #region Scrollers




        private void scroll_index_Scroll(object sender, EventArgs e)
        {
            SendFingerData(vindex, scroll_index.Value);
        }

        private void scroll_middle_Scroll(object sender, EventArgs e)
        {
            SendFingerData(vmiddle, scroll_middle.Value);
        }

        private void scroll_ring_Scroll(object sender, EventArgs e)
        {
            SendFingerData(vring, scroll_ring.Value);
        }

        private void scroll_pinky_Scroll(object sender, EventArgs e)
        {
            SendFingerData(vpinky, scroll_pinky.Value);
        }

        private void scroll_index_MouseUp(object sender, MouseEventArgs e)
        {
            scroll_index.Value = 0;
            SendFingerData(vindex, scroll_index.Value);
        }

        private void scroll_middle_MouseUp(object sender, MouseEventArgs e)
        {
            scroll_middle.Value = 0;
            SendFingerData(vmiddle, scroll_middle.Value);
        }

        private void scroll_ring_MouseUp(object sender, MouseEventArgs e)
        {
            scroll_ring.Value = 0;
            SendFingerData(vring, scroll_ring.Value);
        }

        private void scroll_pinky_MouseUp(object sender, MouseEventArgs e)
        {
            scroll_pinky.Value = 0;
            SendFingerData(vpinky, scroll_pinky.Value);
        }

        private void scroll_thumb_MouseUp(object sender, MouseEventArgs e)
        {
            scroll_thumb.Value = 0;
            SendFingerData(vthumb, scroll_thumb.Value);
        }

        private void scroll_middle_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void scroll_ring_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void scroll_pinky_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void scroll_index_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void scroll_thumb_ValueChanged(object sender, EventArgs e)
        {
            
        }

        #endregion
        private void TimeOutWorker_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabControl1.SelectedTab.Text == "EMG Analysis")
            {
                dbg("PlotTimerEnable");
                PlotTimer.Enabled = true;
            }
            else
            {
                dbg("PlotTimerDisable");
                PlotTimer.Enabled = false;
            }
        }

        private void PlotTimer_Tick(object sender, EventArgs e)
        {
            m_PushGraphCtrl.Push(Convert.ToInt16(EMGSignal), "EMGLine");
            m_PushGraphCtrl.UpdateGraph();
        }

        private void MainBoardSerial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            bool SpecialCommand = false;
            string SerialRXData = MainBoardSerial.ReadTo("#");
            if (SerialRXData == "PingOK#")
            {
                PINGFlag = true;
                SerialRXData = "";
                SpecialCommand = true;
                dbg("Special RX:" + SerialRXData);
            }
            if (SpecialCommand == false)
            {
                SerialQueue.Enqueue(SerialRXData);
                BufferWaitHandle.Set();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RefreshComports();
        }

        private void cmd_EMGConnect_Click(object sender, EventArgs e)
        {
            dbg("Trying to connect ...");
            try
            {
                if (cmd_EMGConnect.Text == "Disconnect")
                {
                    cmd_EMGConnect.Text = "Connect";
                    EMGSerial.Close();
                }
                else
                {
                    EMGSerial.BaudRate = 115200;
                    if (EMGSerial.IsOpen == true) EMGSerial.Close();
                    EMGSerial.PortName = cmb_EMGPorts.Text;
                    dbg("Just before connect ...");
                    EMGSerial.Open();
                    dbg("First stage of connection is OK ...");
                    if (isConnected() == true)
                    {
                        dbg("Connected to Bionic Hand-EMG");
                        dbg("Controller is ready...");
                        tabControl1.SelectedTab = tabPage3;
                        cmd_EMGConnect.Text = "Disconnect";
                    }
                    else
                    {
                        dbg("No Data from EMG");
                    }
                }

            }
            catch (Exception ex)
            {
                dbg("Error in Connection : " + ex.Message);
            }
            
        }

        private void EMGSerial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string SerialRXData = EMGSerial.ReadTo("#");
            //dbg("DataRX");
                SerialQueue.Enqueue(SerialRXData);
                BufferWaitHandle.Set();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
            EMGSignalHIGH = EMGSignal;
            dbg("EMGSignalHigh Set to " + EMGSignal);

        }

        private void button8_Click(object sender, EventArgs e)
        {
            EMGSignalLOW = EMGSignal;
            dbg("EMGSignalLOW Set to " + EMGSignal);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if(ControlHandFlag == true)
            {
                button9.Text = "Enable EMG Control";
                dbg("ControlOFF");
                ControlHandFlag = false;
                EMGTimer.Enabled = false;
            }
            else
            {
                if ((EMGSignalHIGH > 0 && EMGSignalLOW > 0) || chk_StimulateEMG.Checked == true)
                {
                    dbg("ControlON");
                    ControlHandFlag = true;
                    EMGTimer.Enabled = true;
                    button9.Text = "Disable EMG Control";
                }
            }
        }
        private void FairDemo()
        {

        }
        private void MotionProcess(int EMGSignal)
        {
            if (EMGSignal < -100) EMGSignal = -100;
            if (EMGSignal > +100) EMGSignal = 100;


            if (Math.Abs(EMGSignal) > numeric_GripTHR.Value)
            {
                if (FingerLockTable[LastGesture, 0] == 0)       { scroll_thumb.Value = EMGSignal;       interthread_ThumbValue  = EMGSignal+30; }
                if (FingerLockTable[LastGesture, 1] == 0)  { scroll_index.Value = EMGSignal;  interthread_IndexValue  = EMGSignal+30; }
                if (FingerLockTable[LastGesture, 2] == 0)  { scroll_middle.Value = EMGSignal; interthread_MiddleValue = EMGSignal+30; }
                if (FingerLockTable[LastGesture, 3] == 0)  { scroll_ring.Value = EMGSignal;   interthread_RingValue   = EMGSignal+30; }
                if (FingerLockTable[LastGesture, 4] == 0)  { scroll_pinky.Value = EMGSignal;  interthread_PinkyValue  = EMGSignal+30; }
                if (FingerLockTable[LastGesture, 0] == 1)  { scroll_thumb.Value = 0; interthread_ThumbValue = 0; }
                if (FingerLockTable[LastGesture, 1] == 1)  { scroll_index.Value = 0; interthread_IndexValue  = 0; }
                if (FingerLockTable[LastGesture, 2] == 1)  { scroll_middle.Value = 0; interthread_MiddleValue = 0; }
                if (FingerLockTable[LastGesture, 3] == 1)  { scroll_ring.Value = 0; interthread_RingValue = 0; }
                if (FingerLockTable[LastGesture, 4] == 1)  { scroll_pinky.Value = 0; interthread_PinkyValue = 0; }
                SendALLFingersValue();
                MotionTimer.Restart();
            }
            else if (Math.Abs(EMGSignal) < numeric_GripTHR.Value && Math.Abs(EMGSignal) > numeric_ReleaseTHR.Value)
            {
                scroll_thumb.Value  = interthread_ThumbValue    = 0;
                scroll_index.Value  = interthread_IndexValue    = 0;
                scroll_middle.Value = interthread_MiddleValue   = 0;
                scroll_ring.Value   = interthread_RingValue     = 0;
                scroll_pinky.Value  = interthread_PinkyValue    = 0;
                SendALLFingersValue();
                MotionTimer.Restart();
            }
            else
            {
                if (MotionTimer.IsRunning == true && MotionTimer.ElapsedMilliseconds < FullOpenDelay)
                {
                    if (FingerLockTable[LastGesture, 0] == 0) { scroll_thumb.Value = interthread_ThumbValue =      +60; }
                    if (FingerLockTable[LastGesture, 1] == 0) { scroll_index.Value =  interthread_IndexValue =     +60; }
                    if (FingerLockTable[LastGesture, 2] == 0) { scroll_middle.Value = interthread_MiddleValue =    +60; }
                    if (FingerLockTable[LastGesture, 3] == 0) { scroll_ring.Value =  interthread_RingValue =       +60; }
                    if (FingerLockTable[LastGesture, 4] == 0) { scroll_pinky.Value = interthread_PinkyValue =      +60; }
                    if (FingerLockTable[LastGesture, 0] == 1) { scroll_thumb.Value = interthread_ThumbValue = 0; }
                    if (FingerLockTable[LastGesture, 1] == 1) { scroll_index.Value = interthread_IndexValue = 0; }
                    if (FingerLockTable[LastGesture, 2] == 1) { scroll_middle.Value =  interthread_MiddleValue = 0; }
                    if (FingerLockTable[LastGesture, 3] == 1) { scroll_ring.Value = interthread_RingValue = 0; }
                    if (FingerLockTable[LastGesture, 4] == 1) { scroll_pinky.Value = interthread_PinkyValue = 0; }
                    SendALLFingersValue();
 
                }
                else if (MotionTimer.IsRunning == true && MotionTimer.ElapsedMilliseconds < FullOpenDelay+200)
                {
                    scroll_thumb.Value = interthread_ThumbValue = 0;
                    scroll_index.Value = interthread_IndexValue = 0;
                    scroll_middle.Value = interthread_MiddleValue = 0;
                    scroll_ring.Value = interthread_RingValue = 0;
                    scroll_pinky.Value = interthread_PinkyValue = 0;
                    SendALLFingersValue();
                }
                else
                {
                    
                }

            }
        }
        private void EMGTimer_Tick(object sender, EventArgs e)
        {
            if ((EMGSignalHIGH > 0 && EMGSignalLOW > 0) || chk_StimulateEMG.Checked == true)
            {
                double temp;
                if (chk_StimulateEMG.Checked == false)
                {
                    temp = (double)((double)(EMGSignal - EMGSignalLOW) / ((double)EMGSignalHIGH - EMGSignalLOW));
                    if (temp > 100) temp = 0;
                    if (temp < 0) temp = 0;
                    //dbg("Float is " + (double)temp);
                    EMGSignalPulse = (int)(temp * 100);

                }
                lbl_EMGPulse.Text = EMGSignalPulse.ToString();
                if(ControlHandFlag == true)
                {
                    MotionProcess(-EMGSignalPulse);
                }
            }
        }

        private void EMGStimulatorTrackBar_Scroll(object sender, EventArgs e)
        {
            if(chk_StimulateEMG.Checked == true)
            {
                EMGSignal = EMGStimulatorTrackBar.Value;
                EMGSignalPulse = EMGStimulatorTrackBar.Value;
            }
        }
        private void GestProcess(int GestMode)
        {
            //OpenALL
            if (GestMode == Gest_ALLOpen)
            {
                scroll_thumb.Value = interthread_ThumbValue = +60;
                scroll_index.Value = interthread_IndexValue = +60;
                scroll_middle.Value = interthread_MiddleValue = +60;
                scroll_ring.Value = interthread_RingValue = +60;
                scroll_pinky.Value = interthread_PinkyValue = +60;
                SendALLFingersValue();
                MotionTimer2.Restart();
                while (MotionTimer2.ElapsedMilliseconds < FullOpenDelay)
                {

                }
                MotionTimer2.Stop();

                scroll_thumb.Value = interthread_ThumbValue = 0;
                scroll_index.Value = interthread_IndexValue = 0;
                scroll_middle.Value = interthread_MiddleValue = 0;
                scroll_ring.Value = interthread_RingValue = 0;
                scroll_pinky.Value = interthread_PinkyValue = 0;
                SendALLFingersValue();
            }
            if(GestMode == Gest_ALLClose || GestMode == Gest_IndexUp || GestMode == Gest_PenMode)
            {
                scroll_thumb.Value = interthread_ThumbValue = -60;
                scroll_index.Value = interthread_IndexValue = -60;
                scroll_middle.Value = interthread_MiddleValue = -60;
                scroll_ring.Value = interthread_RingValue = -60;
                scroll_pinky.Value = interthread_PinkyValue = -60;
                SendALLFingersValue();
                MotionTimer2.Restart();
                while (MotionTimer2.ElapsedMilliseconds < FullOpenDelay)
                {

                }
                MotionTimer2.Stop();

                scroll_thumb.Value = interthread_ThumbValue = 0;
                scroll_index.Value = interthread_IndexValue = 0;
                scroll_middle.Value = interthread_MiddleValue = 0;
                scroll_ring.Value = interthread_RingValue = 0;
                scroll_pinky.Value = interthread_PinkyValue = 0;
                SendALLFingersValue();
            }

            //Set Speeds

            //SetGestureSpeeds


            //Waiting for timeout


        }
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btn_GestPenMode_Click(object sender, EventArgs e)
        {
            //GestProcess(Gest_PenMode);
            LastGesture = Gest_PenMode;
        }
        EMG eMG = new EMG();
        private void button11_Click(object sender, EventArgs e)
        {
            
            eMG.TCPConnect("127.0.0.1", 1234);
            eMG.ReceiveMessage();
            eMG.ReceiveMessageHandler += EMG_ReceiveMessageHandler;
        }

        private void EMG_ReceiveMessageHandler(object sender, MessageReceiveEventArgs e)
        {
            MessageBox.Show(e.Message);
        }

        private void logtxt_TextChanged(object sender, EventArgs e)
        {
            logtxt.SelectionStart = logtxt.Text.Length;
            logtxt.ScrollToCaret();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            eMG.SendMessage("Hello dear");
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void cmb_ports_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmb_EMGPorts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chk_StimulateEMG_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btn_GestOpenAll_Click(object sender, EventArgs e)
        {
            GestProcess(Gest_ALLOpen);
            LastGesture = Gest_ALLOpen;
        }

        private void chk_GestCloseAll_Click(object sender, EventArgs e)
        {
            GestProcess(Gest_ALLClose);
            LastGesture = Gest_ALLClose;
        }

        private void chk_GestIndexUp_Click(object sender, EventArgs e)
        {
            //GestProcess(Gest_IndexUp);
            LastGesture = Gest_IndexUp;
        }

        private void scroll_thumb_Scroll(object sender, EventArgs e)
        {
            SendFingerData(vthumb, scroll_thumb.Value);
        }



    }
}
