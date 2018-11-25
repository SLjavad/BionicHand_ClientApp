using LiveCharts;
using LiveCharts.Configurations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApplication1.Models;
using WindowsFormsApplication1.Properties;
using System.Linq;
using LiveCharts.Wpf;
using WindowsFormsApplication1.Network;
using System.Text;
using System.Threading;
using System.Text.RegularExpressions;
using System.IO;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;

namespace WindowsFormsApplication1
{
    public partial class MainPage : Form
    {

        EMG emg = new EMG();
        EMG1C emg1c = new EMG1C();
        RFID rfid = new RFID();
        Glove glove = new Glove();
        Hand hand = new Hand();
        frmLog frmLog = new frmLog();

        bool handManualState = true;

        //ChartValues<ChartModel> EmgChartValues = new ChartValues<ChartModel>();



        List<Panel> panelLists = new List<Panel>();
        List<ChartValues<ChartModel>> EmgChartValues = new List<ChartValues<ChartModel>>()
        {
            new ChartValues<ChartModel>(),new ChartValues<ChartModel>(),
            new ChartValues<ChartModel>(),new ChartValues<ChartModel>(),
            new ChartValues<ChartModel>(),new ChartValues<ChartModel>(),
            new ChartValues<ChartModel>(),new ChartValues<ChartModel>()
        };
        List<LineSeries> lineSeries = new List<LineSeries>
        {
            new LineSeries(),new LineSeries(),new LineSeries(),
            new LineSeries(),new LineSeries(),new LineSeries(),
            new LineSeries(),new LineSeries()
        };

        ChartValues<ChartModel> emg1cChartValue = new ChartValues<ChartModel>();
        LineSeries emg1cLineseries = new LineSeries();

        enum ActivePanel { PanelEMG, PanelRFID, PanelGlove, PanelHand, PanelControls, PanelCharts }
        ActivePanel activePanel;

        public MainPage()
        {
            InitializeComponent();
            panelLists.AddRange(new List<Panel>() { PanelRFID, PanelEMG, PanelHAND, PanelGLOVE, panelConnect, panelControls, panelCharts });

            // EMG 8 Channel
            emg.ConnectionTerminateHandler += Emg_ConnectionTerminateHandler;
            //emg.ReceiveMessageHandler += Emg_ReceiveMessageHandler;
            emg.ConnectionEstablishHandler += Emg_ConnectionEstablishHandler;

            // EMG 1 Channel
            emg1c.ConnectionEstablished += Emg1c_ConnectionEstablished;
            //emg1c.MessageReceived += Emg1c_MessageReceived;
            emg1c.ConnectionFailed += Emg1c_ConnectionFailed;

            // Image Processing :D
            rfid.ConnectionTerminateHandler += Rfid_ConnectionTerminateHandler;
            //rfid.ReceiveMessageHandler += Rfid_ReceiveMessageHandler;
            rfid.ConnectionEstablishHandler += Rfid_ConnectionEstablishHandler;

            // Hand
            hand.ConnectionTerminateHandler += Hand_ConnectionTerminateHandler;
            //hand.ReceiveMessageHandler += Hand_ReceiveMessageHandler;
            hand.ConnectionEstablishHandler += Hand_ConnectionEstablishHandler;

            // Deprecated
            glove.ConnectionTerminateHandler += Glove_ConnectionTerminateHandler;
            //glove.ReceiveMessageHandler += Glove_ReceiveMessageHandler;

            // Set Model of data shown in chart
            var mapper = Mappers.Xy<ChartModel>().X(a => a.Time.Ticks).Y(a => a.Data);
            Charting.For<ChartModel>(mapper);
        }



        private void InitialEmg1CChart()
        {
            emg1cLineseries.Values = emg1cChartValue;
            emg1cLineseries.StrokeThickness = 2;
            emg1cLineseries.Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(107, 185, 69));
            emg1cLineseries.Fill = System.Windows.Media.Brushes.Transparent;
            emg1cLineseries.LineSmoothness = 0;
            emg1cLineseries.PointGeometry = null;

            emg1cChart.DisableAnimations = true;
            emg1cChart.Hoverable = false;
            emg1cChart.DataTooltip = null;
            emg1cChart.AxisX[0].MaxValue = DateTime.Now.Ticks + TimeSpan.FromSeconds(0).Ticks;
            emg1cChart.AxisX[0].MinValue = DateTime.Now.Ticks - TimeSpan.FromSeconds(10).Ticks;
            emg1cChart.AxisX[0].LabelFormatter = a => new DateTime((long)a).ToString("mm:ss");
            emg1cChart.AxisX[0].Separator = new Separator() { IsEnabled = true, StrokeThickness = 3, Step = TimeSpan.FromSeconds(1).Ticks };
            emg1cChart.Zoom = ZoomingOptions.Xy;

            emg1cChart.Series.Add(emg1cLineseries);
        }

        private void InitialEmgChart()
        {
            for (int i = 0; i < 8; i++)
            {
                lineSeries[i].Values = EmgChartValues[i];
                lineSeries[i].StrokeThickness = 2;
                lineSeries[i].Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(107, 185, 69));
                lineSeries[i].Fill = System.Windows.Media.Brushes.Transparent;
                lineSeries[i].LineSmoothness = 0;
                lineSeries[i].PointGeometry = null;
            }
            foreach (LiveCharts.WinForms.CartesianChart item in PanelEMG.Controls.OfType<LiveCharts.WinForms.CartesianChart>())
            {
                item.DisableAnimations = true;
                item.Hoverable = false;
                item.DataTooltip = null;
                item.AxisX[0].MaxValue = DateTime.Now.Ticks + TimeSpan.FromSeconds(0).Ticks;
                item.AxisX[0].MinValue = DateTime.Now.Ticks - TimeSpan.FromSeconds(10).Ticks;
                item.AxisX[0].LabelFormatter = a => new DateTime((long)a).ToString("mm:ss");
                item.AxisX[0].Separator = new Separator() { IsEnabled = true, StrokeThickness = 3, Step = TimeSpan.FromSeconds(1).Ticks };
                item.Zoom = ZoomingOptions.X;
            }
            EmgChart.Series.Add(lineSeries[0]);
            EmgChart1.Series.Add(lineSeries[1]);
            EmgChart2.Series.Add(lineSeries[2]);
            EmgChart3.Series.Add(lineSeries[3]);
            EmgChart4.Series.Add(lineSeries[4]);
            EmgChart5.Series.Add(lineSeries[5]);
            EmgChart6.Series.Add(lineSeries[6]);
            EmgChart7.Series.Add(lineSeries[7]);

            //EmgChart.DisableAnimations = true;
            //EmgChart.Hoverable = false;
            //EmgChart.DataTooltip = null;
            //EmgChart.AxisX[0].MaxValue = DateTime.Now.Ticks + TimeSpan.FromSeconds(0).Ticks;
            //EmgChart.AxisX[0].MinValue = DateTime.Now.Ticks - TimeSpan.FromSeconds(10).Ticks;
            //EmgChart.AxisX[0].LabelFormatter = a => new DateTime((long)a).ToString("mm:ss");
            //EmgChart.AxisX[0].Separator = new Separator() { IsEnabled = true, StrokeThickness = 3, Step = TimeSpan.FromSeconds(1).Ticks };
            //EmgChart.ScrollMode = ScrollMode.X;
        }

        private void SelectAllTextBoxes()
        {
            txtThumbPos.SelectAll();
            txtIndexPos.SelectAll();
            txtMiddlePos.SelectAll();
            txtRingPos.SelectAll();
            txtPinkyPos.SelectAll();
        }

        private void resetTab_ClearConnectionTexts()
        {
            btnControls.ForeColor = Color.Black;
            btnCharts.ForeColor = Color.Black;
            txtIP.Clear();
            txtPort.Clear();
        }

        private void SetActivePanel(Panel panel)
        {
            foreach (Panel item in panelLists)
            {
                if (item == panel)
                {
                    item.Show();
                    item.BringToFront();
                }
                else
                {
                    item.Hide();
                    item.SendToBack();
                }
            }
        }

        private Color setTempColor(int value)
        {

            if (Enumerable.Range(0, 12).Contains(value))
            {
                return Color.FromArgb(0, 0, 255);
            }
            else if (Enumerable.Range(11, 12).Contains(value))
            {
                return Color.FromArgb(100, 100, 255);
            }
            else if (Enumerable.Range(22, 12).Contains(value))
            {
                return Color.White;
            }
            else if (Enumerable.Range(33, 12).Contains(value))
            {
                return Color.Yellow;
            }
            else
            {
                return Color.Red;
            }
        }

        #region Glove
        private void Glove_ReceiveMessageHandler(object sender, MessageReceiveEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Glove_ConnectionTerminateHandler(object sender, EventArgs e)
        {
            pnlGLOVE.BackColor = Color.FromArgb(198, 40, 40);
        }
        #endregion

        #region Hand
        private void Hand_ConnectionEstablishHandler(object sender, EventArgs e)
        {
            Invoke(new Action(() =>
            {
                pnlHAND.BackColor = Color.FromArgb(46, 125, 50);
                SetActivePanel(PanelHAND);
                MessageBox.Show("Bionic Hand Connected Successfully", "Connection Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }));
        }

        private void Hand_ReceiveMessageHandler(object sender, MessageReceiveEventArgs e)
        {
            int[] values = Array.ConvertAll(e.Message.Split(','), int.Parse);
            if (hand.RFIDEnabled)
            {
                if (values[15] != 0)
                {
                    hand.HandRFID = (HandRFIDs)values[15];
                    Console.WriteLine(SendMessageConfig.SendRFIDFeedback((HandRFIDs)values[15]));
                }
            }

            Invoke(new Action(() =>
            {
                try
                {
                    // How to run these codes as parallel

                    hand.Thumb.Position = values[0];
                    hand.Index.Position = values[1];
                    hand.Middle.Position = values[2];
                    hand.Ring.Position = values[3];
                    hand.Pinky.Position = values[4];
                    if (!handManualState)
                    {
                        trThumb.Value = values[0] > trThumb.Maximum ? trThumb.Maximum : (values[0] < trThumb.Minimum ? trThumb.Minimum : values[0]);
                        trIndex.Value = values[1] > trIndex.Maximum ? trIndex.Maximum : (values[1] < trIndex.Minimum ? trIndex.Minimum : values[1]);
                        trMiddle.Value = values[2] > trMiddle.Maximum ? trIndex.Maximum : (values[2] < trMiddle.Minimum ? trMiddle.Minimum : values[2]);
                        trRing.Value = values[3] > trRing.Maximum ? trRing.Maximum : (values[3] < trRing.Minimum ? trRing.Minimum : values[3]);
                        trPinky.Value = values[4] > trPinky.Maximum ? trPinky.Maximum : (values[4] < trPinky.Minimum ? trPinky.Minimum : values[4]);
                        txtThumbPos.Text = trThumb.Value.ToString();
                        txtIndexPos.Text = trIndex.Value.ToString();
                        txtMiddlePos.Text = trMiddle.Value.ToString();
                        txtRingPos.Text = trRing.Value.ToString();
                        txtPinkyPos.Text = trPinky.Value.ToString();
                        SelectAllTextBoxes();
                    }
                    thumbCur.Text = values[5].ToString();
                    indexCur.Text = values[6].ToString();
                    middleCur.Text = values[7].ToString();
                    ringCur.Text = values[8].ToString();
                    pinkyCur.Text = values[9].ToString();
                    lblThumbFsr.Text = values[10].ToString();
                    lblIndexFsr.Text = values[11].ToString();
                    lblMiddleFsr.Text = values[12].ToString();
                    lblRingFsr.Text = values[13].ToString();
                    lblTemppinky.Text = $"Temperature: {values[14]}";
                    panelTemp.BackColor = setTempColor(values[14]);
                    lblRfid.Text = $"RFID : {values[15]}";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.GetBaseException().ToString() + "\n\n" + "Receiving from hand");
                }

            }));

        }

        private void Hand_ConnectionTerminateHandler(object sender, EventArgs e)
        {
            pnlHAND.BackColor = Color.FromArgb(198, 40, 40);
            Invoke(new Action(() =>
            {
                btnPanelHand_Click(null, null);
            }));
        }
        #endregion

        #region Image Processing
        private void Rfid_ConnectionEstablishHandler(object sender, EventArgs e)
        {
            Invoke(new Action(() =>
            {
                pnlRFID.BackColor = Color.FromArgb(46, 125, 50);
                SetActivePanel(PanelRFID);
                MessageBox.Show("Image Process Device Connected Successfully", "Connection Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }));

        }

        private void Rfid_ReceiveMessageHandler(object sender, MessageReceiveEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Rfid_ConnectionTerminateHandler(object sender, EventArgs e)
        {
            pnlRFID.BackColor = Color.FromArgb(198, 40, 40);
        }

        #endregion

        #region EMG 1 Channel
        private void Emg1c_ConnectionEstablished(object sender, EventArgs e)
        {
            Invoke(new Action(() =>
            {
                btnConnect1ChannelEmg.Text = "Connected";
                btnConnect1ChannelEmg.BackColor = Color.Green;
                btnStart1ChannelEmg.Enabled = true;
                InitialEmg1CChart();
            }));

            MessageBox.Show("Bluetooth Connected", "Connected", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
        }

        private void Emg1c_ConnectionFailed(object sender, MessageReceiveEventArgs e)
        {
            Invoke(new Action(() =>
            {
                switch (e.Message)
                {
                    case "Reconnect":
                        btnConnect1ChannelEmg.Text = "Connect";
                        break;
                    default:
                        break;
                }
            }));

        }
        bool emg1cThresholdReach = false;
        private void Emg1c_MessageReceived(object sender, MessageReceiveEventArgs e)
        {
            //string[] values = e.Message.Split(new[] {':','#'}, StringSplitOptions.None);
            Match[] values = Regex.Matches(e.Message, @":+[0-9]+#").Cast<Match>().ToArray();
            try
            {
                for (int i = 0; i < values.Length; i++)
                {
                    string temp1 = values[i].Value;
                    string temp = temp1.Substring(1, temp1.IndexOf('#') - 1);
                    // threshold
                    if (emg1cThresholdCheck.Checked)
                    {
                        if (int.Parse(temp) > numEmg1cThreshold.Value && !emg1cThresholdReach)
                        {
                            Console.WriteLine(SendMessageConfig.HandFist());
                            hand.SendMessage(SendMessageConfig.HandFist());
                            emg1cThresholdReach = true;
                        }
                        else if (int.Parse(temp) < numEmg1cThreshold.Value && emg1cThresholdReach)
                        {
                            Console.WriteLine(SendMessageConfig.HandOpen());
                            hand.SendMessage(SendMessageConfig.HandOpen());
                            emg1cThresholdReach = false;
                        }
                    }

                    //Thread.Sleep(emg1c.Delay);
                    if (int.TryParse(temp, out int j))
                    {
                        emg1cChartValue.Add(new ChartModel()
                        {
                            Data = double.Parse(temp),
                            Time = DateTime.Now
                        });
                        Invoke(new Action(() =>
                        {
                            emg1cChart.AxisX[0].MaxValue = DateTime.Now.Ticks + TimeSpan.FromSeconds(2).Ticks;
                            emg1cChart.AxisX[0].MinValue = DateTime.Now.Ticks - TimeSpan.FromSeconds(10).Ticks;
                        }));
                        if (emg1cChartValue.Count > 100)
                        {
                            emg1cChartValue.RemoveAt(0);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetBaseException().ToString() + "\n\nFROM EMG1C RECEIVE");
            }
        }
        #endregion

        #region EMG 8 Channels
        private void Emg_ConnectionEstablishHandler(object sender, EventArgs e)
        {
            Invoke(new Action(() =>
            {
                pnlEMG.BackColor = Color.FromArgb(46, 125, 50);
                SetActivePanel(PanelEMG);
                MessageBox.Show("EMG Connected Successfully", "Connection Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }));
        }
        bool Emg8ThresholdReach = false;
        private void Emg_ReceiveMessageHandler(object sender, MessageReceiveEventArgs e)
        {
            double SumOfChannels = 0;
            if (e.Parameter == "EMG")
            {
                double[] values = Array.ConvertAll(e.Message.Split(','), double.Parse);
                try
                {
                    
                    for (int i = 0; i < 3; i++)
                    {
                        EmgChartValues[i].Add(new ChartModel
                        {
                            Data = (values[i]),
                            Time = DateTime.Now
                        });
                        //SumOfChannels += (values[i] * 100);
                        
                    }
                    //double Threshold = (SumOfChannels / 3);

                    //if (checkBox1.Checked)
                    //{
                    //    if ((decimal)Threshold > numMax.Value)
                    //    {
                    //        Console.WriteLine(SendMessageConfig.SendFromEmg8ToHand(emg.EmgGesture));
                    //        hand.SendMessage(SendMessageConfig.SendFromEmg8ToHand(emg.EmgGesture));
                    //        //Emg8ThresholdReach = true;
                    //    }
                    //    else if ((decimal)Threshold < numMax.Value)
                    //    {
                    //        Console.WriteLine(SendMessageConfig.SendFromEmg8ToHand(emg.EmgGesture));
                    //        hand.SendMessage(SendMessageConfig.SendFromEmg8ToHand(emg.EmgGesture));
                    //        //Emg8ThresholdReach = false;
                    //    }
                    //}


                    Invoke(new Action(() =>
                    {
                        lblEMGgesture.Text = emg.EmgGesture.ToString();
                        EmgChart.AxisX[0].MaxValue = DateTime.Now.Ticks + TimeSpan.FromSeconds(1).Ticks;
                        EmgChart.AxisX[0].MinValue = DateTime.Now.Ticks - TimeSpan.FromSeconds(3).Ticks;
                        EmgChart1.AxisX[0].MaxValue = DateTime.Now.Ticks + TimeSpan.FromSeconds(1).Ticks;
                        EmgChart1.AxisX[0].MinValue = DateTime.Now.Ticks - TimeSpan.FromSeconds(3).Ticks;
                        EmgChart2.AxisX[0].MaxValue = DateTime.Now.Ticks + TimeSpan.FromSeconds(1).Ticks;
                        EmgChart2.AxisX[0].MinValue = DateTime.Now.Ticks - TimeSpan.FromSeconds(3).Ticks;
                        //    EmgChart3.AxisX[0].MaxValue = DateTime.Now.Ticks + TimeSpan.FromSeconds(1).Ticks;
                        //    EmgChart3.AxisX[0].MinValue = DateTime.Now.Ticks - TimeSpan.FromSeconds(3).Ticks;
                        //    EmgChart4.AxisX[0].MaxValue = DateTime.Now.Ticks + TimeSpan.FromSeconds(1).Ticks;
                        //    EmgChart4.AxisX[0].MinValue = DateTime.Now.Ticks - TimeSpan.FromSeconds(3).Ticks;
                        //    EmgChart5.AxisX[0].MaxValue = DateTime.Now.Ticks + TimeSpan.FromSeconds(1).Ticks;
                        //    EmgChart5.AxisX[0].MinValue = DateTime.Now.Ticks - TimeSpan.FromSeconds(3).Ticks;
                        //    EmgChart6.AxisX[0].MaxValue = DateTime.Now.Ticks + TimeSpan.FromSeconds(1).Ticks;
                        //    EmgChart6.AxisX[0].MinValue = DateTime.Now.Ticks - TimeSpan.FromSeconds(3).Ticks;
                        //    EmgChart7.AxisX[0].MaxValue = DateTime.Now.Ticks + TimeSpan.FromSeconds(1).Ticks;
                        //    EmgChart7.AxisX[0].MinValue = DateTime.Now.Ticks - TimeSpan.FromSeconds(3).Ticks;
                        if (EmgChartValues[0].Count > 100)
                        {
                            EmgChartValues[0].RemoveAt(0);
                        }
                        if (EmgChartValues[1].Count > 100)
                        {
                            EmgChartValues[1].RemoveAt(0);
                        }
                        if (EmgChartValues[2].Count > 100)
                        {
                            EmgChartValues[2].RemoveAt(0);
                        }
                    }));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.GetBaseException().ToString());
                }
            }
        }

        private void Emg_ConnectionTerminateHandler(object sender, EventArgs e)
        {
            pnlEMG.BackColor = Color.FromArgb(198, 40, 40);
            Invoke(new Action(() =>
            {
                btnPanelEMG_Click(null, null);
            }));
            foreach (var item in EmgChartValues)
            {
                item.Clear();
            }
        }

        #endregion



        #region UI Design Codes

        // Green ==> 46, 125, 50
        //Red ==> 198, 40, 40

        private void panel5_MouseEnter(object sender, EventArgs e)
        {
            btnRFID.ForeColor = Color.FromArgb(233, 30, 99);
            btnPanelRFID.BackColor = Color.FromArgb(45, 45, 45);
            btnRFID.Image = Resources.RFIDMouseEnter;
        }

        private void panel5_MouseLeave(object sender, EventArgs e)
        {
            btnRFID.ForeColor = Color.White;
            btnPanelRFID.BackColor = Color.Transparent;
            btnRFID.Image = (Image)new ComponentResourceManager(typeof(MainPage)).GetObject("btnRFID.Image");

        }

        private void btnPanelEMG_MouseEnter(object sender, EventArgs e)
        {
            btnEMG.ForeColor = Color.FromArgb(233, 30, 99);
            btnPanelEMG.BackColor = Color.FromArgb(45, 45, 45);
            btnEMG.Image = Resources.emgMouseEnter;
        }

        private void btnPanelEMG_MouseLeave(object sender, EventArgs e)
        {
            btnEMG.ForeColor = Color.White;
            btnPanelEMG.BackColor = Color.Transparent;
            btnEMG.Image = (Image)new ComponentResourceManager(typeof(MainPage)).GetObject("btnEMG.Image");
        }

        private void btnPanelHand_MouseEnter(object sender, EventArgs e)
        {
            btnHand.ForeColor = Color.FromArgb(233, 30, 99);
            btnPanelHand.BackColor = Color.FromArgb(45, 45, 45);
            btnHand.Image = Resources.HandMouseEnter;
        }

        private void btnPanelHand_MouseLeave(object sender, EventArgs e)
        {
            btnHand.ForeColor = Color.White;
            btnPanelHand.BackColor = Color.Transparent;
            btnHand.Image = (Image)new ComponentResourceManager(typeof(MainPage)).GetObject("btnHand.Image");
        }

        private void btnPanelGlove_MouseEnter(object sender, EventArgs e)
        {
            btnGlove.ForeColor = Color.FromArgb(233, 30, 99);
            btnPanelGlove.BackColor = Color.FromArgb(45, 45, 45);
            btnGlove.Image = Resources.GloveMouseEnter;
        }

        private void btnPanelGlove_MouseLeave(object sender, EventArgs e)
        {
            btnGlove.ForeColor = Color.White;
            btnPanelGlove.BackColor = Color.Transparent;
            btnGlove.Image = (Image)new ComponentResourceManager(typeof(MainPage)).GetObject("btnGlove.Image");
        }

        private void btnControls_MouseEnter(object sender, EventArgs e)
        {
            if (btnControls.ForeColor != Color.FromArgb(25, 118, 210))
            {
                btnControls.ForeColor = Color.FromArgb(100, 181, 246);
            }
        }

        private void btnControls_MouseLeave(object sender, EventArgs e)
        {
            if (btnControls.ForeColor != Color.FromArgb(25, 118, 210))
            {
                btnControls.ForeColor = Color.Black;
            }
        }

        private void btnControls_MouseDown(object sender, MouseEventArgs e)
        {
            btnControls.ForeColor = Color.FromArgb(25, 118, 210);
        }

        private void btnCharts_MouseEnter(object sender, EventArgs e)
        {
            if (btnCharts.ForeColor != Color.FromArgb(25, 118, 210))
            {
                btnCharts.ForeColor = Color.FromArgb(100, 181, 246);
            }

        }

        private void btnCharts_MouseLeave(object sender, EventArgs e)
        {
            if (btnCharts.ForeColor != Color.FromArgb(25, 118, 210))
            {
                btnCharts.ForeColor = Color.Black;
            }
        }

        private void btnCharts_MouseDown(object sender, MouseEventArgs e)
        {
            btnCharts.ForeColor = Color.FromArgb(25, 118, 210);
        }

        #endregion

        private void btnPanelEMG_Click(object sender, EventArgs e)
        {
            resetTab_ClearConnectionTexts();
            if (!emg.IsConnected())
            {
                SetActivePanel(panelConnect);
                linkSwitchEmg1c.Visible = true;
                panel8.Enabled = true;
                lblConnectionTitle.Text = "EMG Connection";
                InitialEmgChart();
            }
            else
            {
                SetActivePanel(PanelEMG);
            }
            activePanel = ActivePanel.PanelEMG;

        }

        private void btnPanelRFID_Click(object sender, EventArgs e)
        {
            resetTab_ClearConnectionTexts();
            if (!rfid.IsConnected())
            {
                SetActivePanel(panelConnect);
                panel8.Enabled = true;
                linkSwitchEmg1c.Visible = false;
                lblConnectionTitle.Text = "Image Processing Connection";
            }
            else
            {
                SetActivePanel(PanelRFID);
            }
            activePanel = ActivePanel.PanelRFID;
        }

        private void btnPanelHand_Click(object sender, EventArgs e)
        {
            resetTab_ClearConnectionTexts();
            if (!hand.IsConnected())
            {
                SetActivePanel(panelConnect);
                panel8.Enabled = true;
                linkSwitchEmg1c.Visible = false;
                lblConnectionTitle.Text = "Hand Connection";
            }
            else
            {
                SetActivePanel(PanelHAND);
            }
            activePanel = ActivePanel.PanelHand;
        }

        private void btnPanelGlove_Click(object sender, EventArgs e)
        {
            resetTab_ClearConnectionTexts();
            if (!glove.IsConnected())
            {
                SetActivePanel(panelConnect);
                panel8.Enabled = true;
                linkSwitchEmg1c.Visible = false;
                lblConnectionTitle.Text = "Glove Connection";
            }
            else
            {
                SetActivePanel(PanelGLOVE);
            }
            activePanel = ActivePanel.PanelGlove;
        }

        private void btnControls_Click(object sender, EventArgs e)
        {
            btnCharts.ForeColor = Color.Black;
            SetActivePanel(panelControls);
            activePanel = ActivePanel.PanelControls;
        }

        private void btnCharts_Click(object sender, EventArgs e)
        {
            btnControls.ForeColor = Color.Black;
            SetActivePanel(panelCharts);
            activePanel = ActivePanel.PanelCharts;
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            foreach (Panel item in panelLists)
            {
                item.Dock = DockStyle.Fill;
            }
            panelConnect.BringToFront();
            panelTemp.BackColor = setTempColor(16);

        }

        private void btnTcpConnect_Click(object sender, EventArgs e)
        {
            if (txtIP.Text.Trim() == string.Empty || txtPort.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Inputs are incomplete");
                return;
            }
            try
            {
                switch (activePanel)
                {
                    case ActivePanel.PanelEMG:
                        emg.TCPConnect(txtIP.Text.Trim(), int.Parse(txtPort.Text.Trim()));
                        pnlEMG.BackColor = Color.FromArgb(46, 125, 50);
                        SetActivePanel(PanelEMG);
                        break;
                    case ActivePanel.PanelRFID:
                        rfid.TCPConnect(txtIP.Text.Trim(), int.Parse(txtPort.Text.Trim()));
                        pnlEMG.BackColor = Color.FromArgb(46, 125, 50);
                        SetActivePanel(PanelRFID);
                        break;
                    case ActivePanel.PanelGlove:
                        glove.TCPConnect(txtIP.Text.Trim(), int.Parse(txtPort.Text.Trim()));
                        pnlGLOVE.BackColor = Color.FromArgb(46, 125, 50);
                        SetActivePanel(PanelGLOVE);
                        break;
                    case ActivePanel.PanelHand:
                        hand.TCPConnect(txtIP.Text.Trim(), int.Parse(txtPort.Text.Trim()));
                        pnlHAND.BackColor = Color.FromArgb(46, 125, 50);
                        SetActivePanel(PanelHAND);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetBaseException().ToString());
            }

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (btnStart.Text == "Start")
            {
                emg.ReceiveMessageHandler += Emg_ReceiveMessageHandler;
                emg.StartReceiveMessage();
                btnStart.Text = "Stop";
            }
            else
            {
                emg.ReceiveMessageHandler -= Emg_ReceiveMessageHandler;
                btnStart.Text = "Start";
            }
        }

        private void btnChartAdd_Click(object sender, EventArgs e)
        {
            ChartAll.Series.Add(new LineSeries()
            {
                LineSmoothness = 1,
                Fill = System.Windows.Media.Brushes.Transparent,
                PointGeometry = null
            });
        }

        private void btnRefreshCharts_Click(object sender, EventArgs e)
        {
            ChartAll.Series.Clear();
        }

        private void btnStartChart_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (btnStartHand.Text == "AutoReceive")
            {
                hand.ReceiveMessageHandler += Hand_ReceiveMessageHandler;
                hand.StartReceiveMessage();
                btnStartHand.Text = "ManualSend";
                handManualState = false;
            }
            else
            {
                hand.ReceiveMessageHandler -= Hand_ReceiveMessageHandler;
                hand.StopReceiveMessage();
                handManualState = true;
                btnStartHand.Text = "AutoReceive";
            }
            //Console.WriteLine(SendMessageConfig.SendToHand(5,55,100,32,100,54,9,17,100,12));
        }

        private void setScrollTextBoxes()
        {
            txtThumbPos.Text = trThumb.Value.ToString();
            txtIndexPos.Text = trIndex.Value.ToString();
            txtMiddlePos.Text = trMiddle.Value.ToString();
            txtRingPos.Text = trRing.Value.ToString();
            txtPinkyPos.Text = trPinky.Value.ToString();
        }

        private void trThumb_Scroll(object sender, EventArgs e)
        {
            if (btnStartHand.Text == "AutoReceive")
            {
                hand.SendMessage(SendMessageConfig.SendToHand((Int16)trThumb.Value, (Int16)trIndex.Value, (Int16)trMiddle.Value, (Int16)trRing.Value, (Int16)trPinky.Value, 100, 100, 100, 100, 100));
                Console.WriteLine(SendMessageConfig.SendToHand((Int16)trThumb.Value, (Int16)trIndex.Value, (Int16)trMiddle.Value, (Int16)trRing.Value, (Int16)trPinky.Value, 100, 100, 100, 100, 100));
                setScrollTextBoxes();
            }
        }

        private void trIndex_Scroll(object sender, EventArgs e)
        {
            if (btnStartHand.Text == "AutoReceive")
            {
                hand.SendMessage(SendMessageConfig.SendToHand((Int16)trThumb.Value, (Int16)trIndex.Value, (Int16)trMiddle.Value, (Int16)trRing.Value, (Int16)trPinky.Value, 100, 100, 100, 100, 100));
                Console.WriteLine(SendMessageConfig.SendToHand((Int16)trThumb.Value, (Int16)trIndex.Value, (Int16)trMiddle.Value, (Int16)trRing.Value, (Int16)trPinky.Value, 100, 100, 100, 100, 100));
                setScrollTextBoxes();
            }
        }

        private void trMiddle_Scroll(object sender, EventArgs e)
        {
            if (btnStartHand.Text == "AutoReceive")
            {
                hand.SendMessage(SendMessageConfig.SendToHand((Int16)trThumb.Value, (Int16)trIndex.Value, (Int16)trMiddle.Value, (Int16)trRing.Value, (Int16)trPinky.Value, 100, 100, 100, 100, 100));
                Console.WriteLine(SendMessageConfig.SendToHand((Int16)trThumb.Value, (Int16)trIndex.Value, (Int16)trMiddle.Value, (Int16)trRing.Value, (Int16)trPinky.Value, 100, 100, 100, 100, 100));
                setScrollTextBoxes();
            }
        }

        private void trRing_Scroll(object sender, EventArgs e)
        {
            if (btnStartHand.Text == "AutoReceive")
            {
                hand.SendMessage(SendMessageConfig.SendToHand((Int16)trThumb.Value, (Int16)trIndex.Value, (Int16)trMiddle.Value, (Int16)trRing.Value, (Int16)trPinky.Value, 100, 100, 100, 100, 100));
                Console.WriteLine(SendMessageConfig.SendToHand((Int16)trThumb.Value, (Int16)trIndex.Value, (Int16)trMiddle.Value, (Int16)trRing.Value, (Int16)trPinky.Value, 100, 100, 100, 100, 100));
                setScrollTextBoxes();
            }
        }

        private void trPinky_Scroll(object sender, EventArgs e)
        {
            if (btnStartHand.Text == "AutoReceive")
            {
                hand.SendMessage(SendMessageConfig.SendToHand((Int16)trThumb.Value, (Int16)trIndex.Value, (Int16)trMiddle.Value, (Int16)trRing.Value, (Int16)trPinky.Value, 100, 100, 100, 100, 100));
                Console.WriteLine(SendMessageConfig.SendToHand((Int16)trThumb.Value, (Int16)trIndex.Value, (Int16)trMiddle.Value, (Int16)trRing.Value, (Int16)trPinky.Value, 100, 100, 100, 100, 100));
                setScrollTextBoxes();
            }
        }

        private void txtThumbPos_KeyDown(object sender, KeyEventArgs e)
        {
            if (handManualState)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Console.WriteLine(SendMessageConfig.SendToHand(Int16.Parse(txtThumbPos.Text == string.Empty ? "0" : txtThumbPos.Text), Int16.Parse(txtIndexPos.Text == string.Empty ? "0" : txtIndexPos.Text)
                        , Int16.Parse(txtMiddlePos.Text == string.Empty ? "0" : txtMiddlePos.Text), Int16.Parse(txtRingPos.Text == string.Empty ? "0" : txtRingPos.Text), Int16.Parse(txtPinkyPos.Text == string.Empty ? "0" : txtPinkyPos.Text)
                        , 100, 100, 100, 100, 100));
                }
                if (e.KeyCode == Keys.Enter && hand.IsConnected())
                {
                    hand.SendMessage(SendMessageConfig.SendToHand(Int16.Parse(txtThumbPos.Text == string.Empty ? "0" : txtThumbPos.Text), Int16.Parse(txtIndexPos.Text == string.Empty ? "0" : txtIndexPos.Text)
                        , Int16.Parse(txtMiddlePos.Text == string.Empty ? "0" : txtMiddlePos.Text), Int16.Parse(txtRingPos.Text == string.Empty ? "0" : txtRingPos.Text), Int16.Parse(txtPinkyPos.Text == string.Empty ? "0" : txtPinkyPos.Text)
                        , 100, 100, 100, 100, 100));

                    trThumb.Value = Int16.Parse(txtThumbPos.Text == string.Empty ? "0" : txtThumbPos.Text);
                    trIndex.Value = Int16.Parse(txtIndexPos.Text == string.Empty ? "0" : txtIndexPos.Text);
                    trMiddle.Value = Int16.Parse(txtMiddlePos.Text == string.Empty ? "0" : txtMiddlePos.Text);
                    trRing.Value = Int16.Parse(txtRingPos.Text == string.Empty ? "0" : txtRingPos.Text);
                    trPinky.Value = Int16.Parse(txtPinkyPos.Text == string.Empty ? "0" : txtPinkyPos.Text);
                    Console.WriteLine(SendMessageConfig.SendToHand((Int16)trThumb.Value, (Int16)trIndex.Value, (Int16)trMiddle.Value, (Int16)trRing.Value, (Int16)trPinky.Value, 100, 100, 100, 100, 100));
                }
            }
        }

        private void txtThumbPos_KeyPress(object sender, KeyPressEventArgs e)
        {
            byte[] a = Encoding.ASCII.GetBytes(e.KeyChar.ToString());
            if (a[0] == 8) return;
            if (a[0] < 48 || a[0] > 57) { e.Handled = true; }
        }

        int clicking = 0;
        //private void btnConnect1ChannelEmg_Click(object sender, EventArgs e)
        //{
        //    if (btnConnect1ChannelEmg.Text == "Connect" && !emg1c.Connected)
        //    {
        //        btnConnect1ChannelEmg.Text = "Waiting ...";
        //        emg1c.Pair_Connect();
        //    }
        //    else if (emg1c.Connected)
        //    {
        //        if (++clicking >= 3)
        //        {
        //            MessageBox.Show($"Come On :| \nYou Are Connected To {emg1c.RemoteMachineName}\nDo your work Bro :|", "It's Connected ... Enough D:", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
        //        }
        //        else
        //        {
        //            MessageBox.Show($"Bluetooth was Connected to {emg1c.RemoteMachineName}\nKeep Going :D", "Connected Successfully", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
        //        }
        //    }
        //}

        //private void btnStart1ChannelEmg_Click(object sender, EventArgs e)
        //{
        //    if (emg1c.Connected && btnStart1ChannelEmg.Text == "Start") // TODO COnneccted
        //    {
        //        emg1c.MessageReceived += Emg1c_MessageReceived;
        //        emg1c.StartReceiveData();
        //        btnStart1ChannelEmg.Text = "Stop";
        //    }
        //    else if (btnStart1ChannelEmg.Text == "Stop")
        //    {
        //        emg1c.StopReceiveData();
        //        emg1c.MessageReceived -= Emg1c_MessageReceived;
        //        btnStart1ChannelEmg.Text = "Start";
        //    }
        //}

        private void linkSwitchEmg1c_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SetActivePanel(PanelEMG);
            panelEmg1c.Show();
            panelEmg1c.Dock = DockStyle.Fill;
            panelEmg1c.BringToFront();
        }

        private void btnEmg1C_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panelEmg1c.Show();
            panelEmg1c.Dock = DockStyle.Fill;
            panelEmg1c.BringToFront();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            btnPanelEMG_Click(null, null);
            panelEmg1c.Hide();
        }

        private void txtThumbPos_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtThumbPos.Text != string.Empty && int.Parse(txtThumbPos.Text) > 100)
                {
                    txtThumbPos.Text = "100";

                }
            }
            catch (FormatException)
            {

            }
        }
        bool demoFlag = false;
        private void btnDemoHand_Click(object sender, EventArgs e)
        {
            if (!demoFlag)
            {
                hand.SendMessage(SendMessageConfig.SendToHand(100, 100, 100, 100, 100, 100, 100, 100, 100, 100));
                demoFlag = true;
                btnDemoHand.Text = "StopDemo";
                Task.Run(() =>
                {
                    Thread.Sleep(1000);
                    while (demoFlag)
                    {
                        Thread.Sleep(450);
                        hand.SendMessage(SendMessageConfig.SendToHand(100, 70, 80, 100, 100, 100, 100, 100, 100, 100));
                        Thread.Sleep(450);
                        hand.SendMessage(SendMessageConfig.SendToHand(70, 30, 40, 100, 70, 100, 100, 100, 100, 100));
                        Thread.Sleep(450);
                        hand.SendMessage(SendMessageConfig.SendToHand(30, 60, 20, 70, 40, 100, 100, 100, 100, 100));
                        Thread.Sleep(450);
                        hand.SendMessage(SendMessageConfig.SendToHand(60, 90, 50, 40, 20, 100, 100, 100, 100, 100));
                        Thread.Sleep(450);
                        hand.SendMessage(SendMessageConfig.SendToHand(90, 100, 100, 20, 50, 100, 100, 100, 100, 100));
                        Thread.Sleep(450);
                        hand.SendMessage(SendMessageConfig.SendToHand(100, 100, 100, 60, 80, 100, 100, 100, 100, 100));
                    }

                });
            }
            else
            {
                btnDemoHand.Text = "Demo";
                demoFlag = false;
            }

        }

        private void txtIndexPos_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtIndexPos.Text != string.Empty && int.Parse(txtIndexPos.Text) > 100)
                {
                    txtIndexPos.Text = "100";

                }
            }
            catch (FormatException)
            {

            }
        }

        private void txtMiddlePos_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtMiddlePos.Text != string.Empty && int.Parse(txtMiddlePos.Text) > 100)
                {
                    txtMiddlePos.Text = "100";

                }
            }
            catch (FormatException)
            {

            }
        }

        private void txtPinkyPos_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtPinkyPos.Text != string.Empty && int.Parse(txtPinkyPos.Text) > 100)
                {
                    txtPinkyPos.Text = "100";

                }
            }
            catch (FormatException)
            {

            }
        }

        private void txtRingPos_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtRingPos.Text != string.Empty && int.Parse(txtRingPos.Text) > 100)
                {
                    txtRingPos.Text = "100";
                }
            }
            catch (FormatException)
            {

            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
