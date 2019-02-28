using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WhatsMyPhoneNumber
{
    public partial class frmMain : Form
    {
        protected bool isRightNumberCheck = false;

        public frmMain()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            //controling
            if (isRightNumberCheck == false)
            {
                PhoneEditor();
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics pic = e.Graphics;
            pic.Clear(Color.SandyBrown);
            pictureBox1.Image = Properties.Resources.phonebackGround1;
            pictureBox1.BackColor = Color.Transparent;
        }

        private void btn_DoSomthing(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (isRightNumberCheck == false)
            {
                if (lblRightPhoneNum.Text.Length > 15)
                {   //prevents more numbers in phone.
                }
                else
                {
                    //lblPhoneDis.Text += b.Text.ToString();
                   
                }
                lblRightPhoneNum.Text += b.Text.ToString();
                if (lblRightPhoneNum.Text.Length == 3)
                {
                    //lblPhoneDis.Text += " - ";
                    lblRightPhoneNum.Text += " - ";
                }
                if (lblRightPhoneNum.Text.Length == 9)
                {
                    //lblPhoneDis.Text += " - ";
                    lblRightPhoneNum.Text += " - ";
                }
                if (lblRightPhoneNum.Text.Length > 15)
                {
                    string maxLegth = lblPhoneDis.Text;
                    lblPhoneDis.Text = maxLegth;
                    isRightNumberCheck = true;
                }
                
            }
            
        }
        protected void PhoneEditor()
        {
            lblPhoneDis.Text = "";
            lblRightPhoneNum.Text = "";
            Font f = new Font(FontFamily.GenericMonospace, 15, FontStyle.Bold);
            lblPhoneDis.Font = f;
            lblRightPhoneNum.Font = f;
            //MessageBox.Show("Top:"+lblPhoneDis.Top.ToString()+", Left:"+lblPhoneDis.Left.ToString());
            lblPhoneDis.Left = 125;
            lblPhoneDis.BackColor = Color.SandyBrown;
            lblRightPhoneNum.BackColor = Color.SandyBrown;
            Random rnd = new Random();
            
            for (int i = 0; i < 10; i++)
            {
                if(i==3)
                {
                    lblPhoneDis.Text += " - ";
                }
                if(i==6)
                {
                    lblPhoneDis.Text += " - ";
                }
                lblPhoneDis.Text += rnd.Next(0, 9);
            }
         }

     }
    
    //create buttons
    //  there is a screen
    //have two fields
    //to the right we have a field 
}
