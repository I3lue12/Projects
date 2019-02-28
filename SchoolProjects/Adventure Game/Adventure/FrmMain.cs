using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adventure
{
    public partial class FrmMain : Form
    {
        protected const int WM_KEYDOWN = 0x100;
        protected Game g;
        protected GameInfo gi;
        protected FrmInventory fInv;

        public FrmMain()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            SetStyle(ControlStyles.AllPaintingInWmPaint
                | ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.UserPaint, true);
            UpdateStyles();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            g = new Game(Width, Height);
            g.Update += g_Update;
            g.Play();// begin the simulatioin
        }

        void g_Update(GameInfo gi)
        {
            this.gi = gi;
            if (gi.Msg.Length > 0)
            {
                Text = gi.Msg;
            }
            Invalidate();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (msg.Msg == WM_KEYDOWN)
            {
                if (keyData == Keys.Space)
                {
                    g.Pause();
                    fInv = new FrmInventory(gi.Link);
                    fInv.UseItem += fInv_UseItem;
                    fInv.FormClosed += fInv_FormClosed;
                    fInv.Show();// make Toolbar visible
                }
                return true;
            }
            else
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        void fInv_FormClosed(object sender, FormClosedEventArgs e)
        {
            g.Play();
        }

        void fInv_UseItem(Item i)
        {
            g.UseItem(i);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics bob = e.Graphics;
            bob.Clear(Color.Black);
            if (true)
            {
                if (gi.Link != null)
                {
                    foreach (Locateable loc in gi.Map)
                    {   // paint the trees
                        bob.TranslateTransform((float)loc.Position.X, (float)loc.Position.Y);
                        bob.TranslateTransform(-loc.Width / 2, -loc.Height / 2);
                        bob.DrawImage(loc.Img, new Point());
                        bob.ResetTransform();
                    }

                    Image mobImg;
                    foreach (Mob m in gi.Monsters)
                    {
                        bob.TranslateTransform((float)m.Position.X, (float)m.Position.Y);
                        mobImg = m.Img;
                        if (m.Type == MobType.Orc)
                        {
                            bob.RotateTransform((float)(m.Angle - 180));
                        }
                        else
                        {
                            bob.RotateTransform((float)m.Angle);
                        }
                        bob.TranslateTransform(-m.Width / 2, -m.Height / 2);
                        bob.DrawImage(mobImg, new Point());
                        bob.ResetTransform();
                    }

                    bob.TranslateTransform((float)gi.Link.Position.X, (float)gi.Link.Position.Y);
                    bob.RotateTransform((float)(gi.Link.Angle));
                    bob.TranslateTransform(-gi.Link.Width / 2, -gi.Link.Height / 2);
                    bob.DrawImage(gi.Link.Img, new Point());
                    bob.ResetTransform();

                    foreach (Projectile proj in gi.Projectiles)
                    {
                        bob.TranslateTransform((float)proj.Position.X, (float)proj.Position.Y);
                        bob.RotateTransform((float)proj.Angle);
                        bob.TranslateTransform(-proj.Width / 2, -proj.Height / 2);
                        bob.DrawImage(proj.Img, new Point());
                        bob.ResetTransform();
                    }
                }
            }
        }

        private void FrmMain_MouseUp(object sender, MouseEventArgs e)
        {
            PlayerInput pi = new PlayerInput();
            pi.MouseLoc = new Vector(e.X, e.Y);
            if(e.Button == MouseButtons.Right)
            {
                pi.Choice = PlayerChoice.MouseRightUp;
            }
            
            if(e.Button == MouseButtons.Left)
            {
                pi.Choice = PlayerChoice.MouseLeftUp;
            }
            g.PlayerInput(pi);
        }
    }
}
