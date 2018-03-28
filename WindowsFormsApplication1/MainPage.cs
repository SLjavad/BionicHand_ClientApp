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

namespace WindowsFormsApplication1
{ 
    public partial class MainPage : Form
    {

        EMG emg = new EMG();
        RFID rfid = new RFID();
        Glove glove = new Glove();
        Hand hand = new Hand();
        frmLog frmLog = new frmLog();
        
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

        enum ActivePanel { PanelEMG, PanelRFID, PanelGlove, PanelHand, PanelControls, PanelCharts }
        ActivePanel activePanel;

        public MainPage()
        {
            InitializeComponent();
            panelLists.AddRange(new List<Panel>() { PanelRFID, PanelEMG, PanelHAND, PanelGLOVE, panelConnect, panelControls, panelCharts });
            emg.ConnectionTerminateHandler += Emg_ConnectionTerminateHandler;
            //emg.ReceiveMessageHandler += Emg_ReceiveMessageHandler;
            rfid.ConnectionTerminateHandler += Rfid_ConnectionTerminateHandler;
            //rfid.ReceiveMessageHandler += Rfid_ReceiveMessageHandler;
            hand.ConnectionTerminateHandler += Hand_ConnectionTerminateHandler;
            //hand.ReceiveMessageHandler += Hand_ReceiveMessageHandler;
            glove.ConnectionTerminateHandler += Glove_ConnectionTerminateHandler;
            //glove.ReceiveMessageHandler += Glove_ReceiveMessageHandler;

            // Set Model of data shown in 
            var mapper = Mappers.Xy<ChartModel>().X(a => a.Time.Ticks).Y(a => a.Data);
            Charting.For<ChartModel>(mapper);
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

        private void Glove_ReceiveMessageHandler(object sender, MessageReceiveEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Hand_ReceiveMessageHandler(object sender, MessageReceiveEventArgs e)
        {
            int[] values = Array.ConvertAll(e.Message.Split(','),int.Parse);
            this.Invoke(new Action(() =>
            {
                try
                {
                    trThumb.Value = values[0] > trThumb.Maximum ? trThumb.Maximum : (values[0] < trThumb.Minimum ? trThumb.Minimum : values[0]);
                    trIndex.Value = values[1] > trIndex.Maximum ? trIndex.Maximum : (values[1] < trIndex.Minimum ? trIndex.Minimum : values[1]);
                    trMiddle.Value = values[2] > trMiddle.Maximum ? trIndex.Maximum : (values[2] < trMiddle.Minimum ? trMiddle.Minimum : values[2]);
                    trRing.Value = values[3] > trRing.Maximum ? trRing.Maximum : (values[3] < trRing.Minimum ? trRing.Minimum : values[3]);
                    trPinky.Value = values[4] > trPinky.Maximum ? trPinky.Maximum : (values[4] < trPinky.Minimum ? trPinky.Minimum : values[4]);
                    thumbCur.Text = values[5].ToString();
                    indexCur.Text = values[6].ToString();
                    middleCur.Text = values[7].ToString();
                    ringCur.Text = values[8].ToString();
                    pinkyCur.Text = values[9].ToString();
                    lblThumbFsr.Text = values[10].ToString();
                    lblIndexFsr.Text = values[11].ToString();
                    lblMiddleFsr.Text = values[12].ToString();
                    lblRingFsr.Text = values[13].ToString();
                    lblTemppinky.Text = values[14].ToString();
                    lblRfid.Text = $"RFID : {values[15].ToString()}";
                }
                catch (Exception ex)
                {
                MessageBox.Show(ex.GetBaseException().ToString()+"\n\n"+"Receiving from hand");
                }
                
            }));
            
        }

        private void Rfid_ReceiveMessageHandler(object sender, MessageReceiveEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Emg_ReceiveMessageHandler(object sender, MessageReceiveEventArgs e)
        {
            if (e.Parameter == "EMG8")
            {
                double[] values = Array.ConvertAll(e.Message.Split(','), double.Parse);
                try
                {
                    for (int i = 0; i < 8; i++)
                    {
                        EmgChartValues[i].Add(new ChartModel
                        {
                            Data = (values[i] * 100),
                            Time = DateTime.Now
                        });
                    }
                    
                    this.Invoke(new Action(() =>
                    {
                        EmgChart.AxisX[0].MaxValue = DateTime.Now.Ticks + TimeSpan.FromSeconds(1).Ticks;
                        EmgChart.AxisX[0].MinValue = DateTime.Now.Ticks - TimeSpan.FromSeconds(3).Ticks;
                        EmgChart1.AxisX[0].MaxValue = DateTime.Now.Ticks + TimeSpan.FromSeconds(1).Ticks;
                        EmgChart1.AxisX[0].MinValue = DateTime.Now.Ticks - TimeSpan.FromSeconds(3).Ticks;
                        EmgChart2.AxisX[0].MaxValue = DateTime.Now.Ticks + TimeSpan.FromSeconds(1).Ticks;
                        EmgChart2.AxisX[0].MinValue = DateTime.Now.Ticks - TimeSpan.FromSeconds(3).Ticks;
                        EmgChart3.AxisX[0].MaxValue = DateTime.Now.Ticks + TimeSpan.FromSeconds(1).Ticks;
                        EmgChart3.AxisX[0].MinValue = DateTime.Now.Ticks - TimeSpan.FromSeconds(3).Ticks;
                        EmgChart4.AxisX[0].MaxValue = DateTime.Now.Ticks + TimeSpan.FromSeconds(1).Ticks;
                        EmgChart4.AxisX[0].MinValue = DateTime.Now.Ticks - TimeSpan.FromSeconds(3).Ticks;
                        EmgChart5.AxisX[0].MaxValue = DateTime.Now.Ticks + TimeSpan.FromSeconds(1).Ticks;
                        EmgChart5.AxisX[0].MinValue = DateTime.Now.Ticks - TimeSpan.FromSeconds(3).Ticks;
                        EmgChart6.AxisX[0].MaxValue = DateTime.Now.Ticks + TimeSpan.FromSeconds(1).Ticks;
                        EmgChart6.AxisX[0].MinValue = DateTime.Now.Ticks - TimeSpan.FromSeconds(3).Ticks;
                        EmgChart7.AxisX[0].MaxValue = DateTime.Now.Ticks + TimeSpan.FromSeconds(1).Ticks;
                        EmgChart7.AxisX[0].MinValue = DateTime.Now.Ticks - TimeSpan.FromSeconds(3).Ticks;
                        //EmgChartValues.CollectGarbage(lineSeries[0]);
                        //EmgChartValues.CollectGarbage(lineSeries[1]);
                        //EmgChartValues.CollectGarbage(lineSeries[2]);
                        //EmgChartValues.CollectGarbage(lineSeries[3]);
                        //EmgChartValues.CollectGarbage(lineSeries[4]);
                        //EmgChartValues.CollectGarbage(lineSeries[5]);
                        //EmgChartValues.CollectGarbage(lineSeries[6]);
                        //EmgChartValues.CollectGarbage(lineSeries[7]);
                        //for (int i = 0; i < 8; i++)
                        //{
                        //    if (EmgChartValues[i].Count > 100)
                        //    {
                        //        EmgChartValues[i].RemoveAt(0);
                        //    }
                        //}
                        
                    }));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.GetBaseException().ToString());
                }
            }


            //MessageBox.Show(e.Message);
            //Console.WriteLine(e.Message);
            //if (richTextBox1.InvokeRequired)
            //{
            //    richTextBox1.Invoke(new Action(() => {
            //        richTextBox1.AppendText(e.Message);
            //        label9.Text = (++a).ToString();
            //    }));
            //}
            //else
            //{
            //    richTextBox1.AppendText(e.Message);
            //}
        }

        #region Connection Terminates
        private void Glove_ConnectionTerminateHandler(object sender, EventArgs e)
        {
            pnlGLOVE.BackColor = Color.FromArgb(198, 40, 40);
        }

        private void Hand_ConnectionTerminateHandler(object sender, EventArgs e)
        {
            pnlHAND.BackColor = Color.FromArgb(198, 40, 40);
        }

        private void Rfid_ConnectionTerminateHandler(object sender, EventArgs e)
        {
            pnlRFID.BackColor = Color.FromArgb(198, 40, 40);
        }

        private void Emg_ConnectionTerminateHandler(object sender, EventArgs e)
        {
            pnlEMG.BackColor = Color.FromArgb(198, 40, 40);
        } 
        #endregion

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
                lblConnectionTitle.Text = "RFID Connection";
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
                        pnlRFID.BackColor = Color.FromArgb(46, 125, 50);
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

        private void PanelEMG_VisibleChanged(object sender, EventArgs e)
        {
            if (activePanel == ActivePanel.PanelEMG)
            {
                
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
            }
            else
            {
                hand.ReceiveMessageHandler -= Hand_ReceiveMessageHandler;
                hand.StopReceiveMessage();
                btnStartHand.Text = "AutoReceive";
            }
            //Console.WriteLine(SendMessageConfig.SendToHand(5,55,100,32,100,54,9,17,100,12));
        }

        private void trThumb_Scroll(object sender, EventArgs e)
        {
            if (btnStartHand.Text == "AutoReceive")
            {
                hand.SendMessage(SendMessageConfig.SendToHand((Int16)trThumb.Value, (Int16)trIndex.Value, (Int16)trMiddle.Value, (Int16)trRing.Value, (Int16)trPinky.Value, 100, 100, 100, 100, 100));
                Console.WriteLine(SendMessageConfig.SendToHand((Int16)trThumb.Value, (Int16)trIndex.Value, (Int16)trMiddle.Value, (Int16)trRing.Value, (Int16)trPinky.Value, 100, 100, 100, 100, 100));
            }
        }

        private void trIndex_Scroll(object sender, EventArgs e)
        {
            if (btnStartHand.Text == "AutoReceive")
            {
                hand.SendMessage(SendMessageConfig.SendToHand((Int16)trThumb.Value, (Int16)trIndex.Value, (Int16)trMiddle.Value, (Int16)trRing.Value, (Int16)trPinky.Value, 100, 100, 100, 100, 100));
                Console.WriteLine(SendMessageConfig.SendToHand((Int16)trThumb.Value, (Int16)trIndex.Value, (Int16)trMiddle.Value, (Int16)trRing.Value, (Int16)trPinky.Value, 100, 100, 100, 100, 100));
            }
        }

        private void trMiddle_Scroll(object sender, EventArgs e)
        {
            if (btnStartHand.Text == "AutoReceive")
            {
                hand.SendMessage(SendMessageConfig.SendToHand((Int16)trThumb.Value, (Int16)trIndex.Value, (Int16)trMiddle.Value, (Int16)trRing.Value, (Int16)trPinky.Value, 100, 100, 100, 100, 100));
                Console.WriteLine(SendMessageConfig.SendToHand((Int16)trThumb.Value, (Int16)trIndex.Value, (Int16)trMiddle.Value, (Int16)trRing.Value, (Int16)trPinky.Value, 100, 100, 100, 100, 100)); 
            }
        }

        private void trRing_Scroll(object sender, EventArgs e)
        {
            if (btnStartHand.Text == "AutoReceive")
            {
                hand.SendMessage(SendMessageConfig.SendToHand((Int16)trThumb.Value, (Int16)trIndex.Value, (Int16)trMiddle.Value, (Int16)trRing.Value, (Int16)trPinky.Value, 100, 100, 100, 100, 100));
                Console.WriteLine(SendMessageConfig.SendToHand((Int16)trThumb.Value, (Int16)trIndex.Value, (Int16)trMiddle.Value, (Int16)trRing.Value, (Int16)trPinky.Value, 100, 100, 100, 100, 100)); 
            }
        }

        private void trPinky_Scroll(object sender, EventArgs e)
        {
            if (btnStartHand.Text == "AutoReceive")
            {
                hand.SendMessage(SendMessageConfig.SendToHand((Int16)trThumb.Value, (Int16)trIndex.Value, (Int16)trMiddle.Value, (Int16)trRing.Value, (Int16)trPinky.Value, 100, 100, 100, 100, 100));
                Console.WriteLine(SendMessageConfig.SendToHand((Int16)trThumb.Value, (Int16)trIndex.Value, (Int16)trMiddle.Value, (Int16)trRing.Value, (Int16)trPinky.Value, 100, 100, 100, 100, 100)); 
            }
        }
    }
}
