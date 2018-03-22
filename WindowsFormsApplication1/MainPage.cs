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

        //LineSeries EmgChartSeries = new LineSeries();
        //LineSeries EmgChartSeries1 = new LineSeries();
        //LineSeries EmgChartSeries2 = new LineSeries();
        //LineSeries EmgChartSeries3 = new LineSeries();
        //LineSeries EmgChartSeries4 = new LineSeries();
        //LineSeries EmgChartSeries5 = new LineSeries();
        //LineSeries EmgChartSeries6 = new LineSeries();
        //LineSeries EmgChartSeries7 = new LineSeries();
        
        ChartValues<ChartModel> EmgChartValues = new ChartValues<ChartModel>();

        

        List<Panel> panelLists = new List<Panel>();
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
            foreach (LineSeries item in lineSeries)
            {
                item.Values = EmgChartValues;
                item.StrokeThickness = 2;
                item.Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(107, 185, 69));
                item.Fill = System.Windows.Media.Brushes.Transparent;
                item.LineSmoothness = 0;
                item.PointGeometry = null;
            }
            //EmgChartSeries.Values = EmgChartValues;
            //EmgChartSeries.StrokeThickness = 2;
            //EmgChartSeries.Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(107, 185, 69));
            //EmgChartSeries.Fill = System.Windows.Media.Brushes.Transparent;
            //EmgChartSeries.LineSmoothness = 0;
            //EmgChartSeries.PointGeometry = null;
            foreach (LiveCharts.WinForms.CartesianChart item in PanelEMG.Controls.OfType<LiveCharts.WinForms.CartesianChart>())
            {
                item.DisableAnimations = true;
                item.Hoverable = false;
                item.DataTooltip = null;
                item.AxisX[0].MaxValue = DateTime.Now.Ticks + TimeSpan.FromSeconds(0).Ticks;
                item.AxisX[0].MinValue = DateTime.Now.Ticks - TimeSpan.FromSeconds(10).Ticks;
                item.AxisX[0].LabelFormatter = a => new DateTime((long)a).ToString("mm:ss");
                item.AxisX[0].Separator = new Separator() { IsEnabled = true, StrokeThickness = 3, Step = TimeSpan.FromSeconds(1).Ticks };
                item.Zoom = ZoomingOptions.Xy;
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
            Console.WriteLine(e.Message);
        }

        private void Rfid_ReceiveMessageHandler(object sender, MessageReceiveEventArgs e)
        {
            throw new NotImplementedException();
        }
        //int a = 0;
        private void Emg_ReceiveMessageHandler(object sender, MessageReceiveEventArgs e)
        {
            if (EmgChart.InvokeRequired)
            {
                try
                {

                    EmgChartValues.Add(new ChartModel
                    {
                        Data = Convert.ToInt16(e.Message),
                        Time = DateTime.Now
                    });
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
                        EmgChartValues.CollectGarbage(lineSeries[0]);
                        EmgChartValues.CollectGarbage(lineSeries[1]);
                        EmgChartValues.CollectGarbage(lineSeries[2]);
                        EmgChartValues.CollectGarbage(lineSeries[3]);
                        EmgChartValues.CollectGarbage(lineSeries[4]);
                        EmgChartValues.CollectGarbage(lineSeries[5]);
                        EmgChartValues.CollectGarbage(lineSeries[6]);
                        EmgChartValues.CollectGarbage(lineSeries[7]);
                        if (EmgChartValues.Count > 100)
                        {
                            EmgChartValues.RemoveAt(0);
                        }
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

        private void resetTabs()
        {
            btnControls.ForeColor = Color.Black;
            btnCharts.ForeColor = Color.Black;
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
            resetTabs();
            if (!emg.IsConnected())
            {
                SetActivePanel(panelConnect);
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
            resetTabs();
            if (!rfid.IsConnected())
            {
                SetActivePanel(panelConnect);
            }
            else
            {
                SetActivePanel(PanelRFID);
            }
            activePanel = ActivePanel.PanelRFID;
        }

        private void btnPanelHand_Click(object sender, EventArgs e)
        {
            resetTabs();
            if (!hand.IsConnected())
            {
                SetActivePanel(panelConnect);
            }
            else
            {
                SetActivePanel(PanelHAND);
            }
            activePanel = ActivePanel.PanelHand;
        }

        private void btnPanelGlove_Click(object sender, EventArgs e)
        {
            resetTabs();
            if (!glove.IsConnected())
            {
                SetActivePanel(panelConnect);
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
            Console.WriteLine(SendMessageConfig.SendToHand(5,55,100,32,100,54,9,17,100,12));
        }
    }
}
