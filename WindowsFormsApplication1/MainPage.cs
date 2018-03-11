using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApplication1.Models;
using WindowsFormsApplication1.Properties;

namespace WindowsFormsApplication1
{
    public partial class MainPage : Form
    {
        EMG emg = new EMG();
        RFID rfid = new RFID();
        Glove glove = new Glove();
        Hand hand = new Hand();

        List<Panel> panelLists = new List<Panel>();
        enum ActivePanel { PanelEMG, PanelRFID, PanelGlove, PanelHand, PanelControls, PanelCharts }
        ActivePanel activePanel;

        public MainPage()
        {
            InitializeComponent();
            panelLists.AddRange(new List<Panel>() { PanelRFID, PanelEMG, PanelHAND, PanelGLOVE, panelConnect, panelControls, panelCharts });
            emg.ConnectionTerminateHandler += Emg_ConnectionTerminateHandler;
            rfid.ConnectionTerminateHandler += Rfid_ConnectionTerminateHandler;
            hand.ConnectionTerminateHandler += Hand_ConnectionTerminateHandler;
            glove.ConnectionTerminateHandler += Glove_ConnectionTerminateHandler;
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
        }

        private void btnTcpConnect_Click(object sender, EventArgs e)
        {
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
    }
}
