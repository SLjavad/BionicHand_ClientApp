using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class TcpConfig : Form
    {

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
                        (
                             int nLeftRect,     // x-coordinate of upper-left corner
                             int nTopRect,      // y-coordinate of upper-left corner
                             int nRightRect,    // x-coordinate of lower-right corner
                             int nBottomRect,   // y-coordinate of lower-right corner
                             int nWidthEllipse, // height of ellipse
                             int nHeightEllipse // width of ellipse
                        );

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();


        public TcpConfig()
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void txtIP_Enter(object sender, EventArgs e)
        {
            if (txtIP.Text == "IP" && txtIP.ForeColor == Color.Silver)
            {
                txtIP.Clear();
                ipLbl.Visible = true;
            }
            //PortLine.Visible = false;
            PortLine.BackColor = Color.FromArgb(224, 224, 224);
            ipLine.Visible = true;
            ipLine.BackColor = Color.Navy;
            txtIP.ForeColor = Color.Black;
        }

        private void txtPort_Enter(object sender, EventArgs e)
        {
            if (txtPort.Text == "Port" && txtPort.ForeColor == Color.Silver)
            {
                txtPort.Clear();
                PortLbl.Visible = true;
            }
            //ipLine.Visible = false;
            ipLine.BackColor = Color.FromArgb(224, 224, 224);
            PortLine.Visible = true;
            PortLine.BackColor = Color.Navy;
            txtPort.ForeColor = Color.Black;
        }

        private void TcpConfig_Load(object sender, EventArgs e)
        {
            txtIP.Focus();
        }

        private void txtIP_Leave(object sender, EventArgs e)
        {
            if (txtIP.Text == string.Empty)
            {
                txtIP.ForeColor = Color.Silver;
                txtIP.Text = "IP";
                ipLbl.Visible = false;
            }
            ipLine.BackColor = Color.FromArgb(224, 224, 224);
        }

        private void txtPort_Leave(object sender, EventArgs e)
        {
            if (txtPort.Text == string.Empty)
            {
                txtPort.ForeColor = Color.Silver;
                txtPort.Text = "Port";
                PortLbl.Visible = false;
            }
            PortLine.BackColor = Color.FromArgb(224, 224, 224);

        }

        private void TcpConfig_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {

        }
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
