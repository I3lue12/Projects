using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zoo_Animal_Big_Small
{
    public partial class frmMain : Form
    {
        protected int MouseDownX, MouseDownY;
        protected Point firstPoint = new Point();
        protected bool leftClick=false;
        protected List<PictureBox> PicBox;
        protected int ID;

        //click event for draging key down and drag to destination
        
        public frmMain()
        {
            InitializeComponent();
            PicBox = new List<PictureBox>();
            PicBox.Add(pbLgElephant);
            PicBox.Add(pbLGGiraf);
            PicBox.Add(pbLGMonkey);
            PicBox.Add(pbLGZebra);
            PicBox.Add(pbLGLion);
            PicBox.Add(pbSmElephant);
            PicBox.Add(pbSmGir);
            PicBox.Add(pbSmLion);
            PicBox.Add(pbSmZebra);
            PicBox.Add(pbSmMonkey);

        }

        private void pbLgElephant_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("you clicked it");
        }

        private void pbLgElephant_MouseMove(object sender, MouseEventArgs e)
        {
            if (leftClick)
            {
                //create move posistions from old to new
                Point temp = Control.MousePosition;
                Point res = new Point(firstPoint.X - temp.X, firstPoint.Y - temp.Y);
                //pbLgElephant.Location = new Point(pbLgElephant.Location.X - res.X, pbLgElephant.Location.Y - res.Y); 
                //only for eliphent
                //if(pbLgElephant == )
                //{
                //   pbLgElephant.Location = new Point(pbLgElephant.Location.X - res.X, pbLgElephant.Location.Y - res.Y)
                //}

                //does it so fast it catches all of them
                foreach (PictureBox pb in PicBox)
                { //how to only grab that one picture box.
                    if (pb == pbLgElephant && pb.Image == Properties.Resources.LargeElephant)
                    {
                        pb.Location = new Point(pbLgElephant.Location.X - res.X, pbLgElephant.Location.Y - res.Y);
                    }
                    else if (pb == pbLGGiraf && pb.Image == Properties.Resources.LargeGiraffe)
                    {
                        pb.Location = new Point(pbLGGiraf.Location.X - res.X, pbLGGiraf.Location.Y - res.Y);

                    }
                    else if (pb == pbLGLion)
                    {
                        pb.Location = new Point(pbLGLion.Location.X - res.X, pbLGLion.Location.Y - res.Y);
                    }
                    else if (pb == pbLGMonkey)
                    {
                        pbLGMonkey.Location = new Point(pbLGMonkey.Location.X - res.X, pbLGMonkey.Location.Y - res.Y);
                    }
                    else if (pb == pbLGZebra)
                    {
                        pb.Location = new Point(pbLGZebra.Location.X - res.X, pbLGZebra.Location.Y - res.Y);
                    }
                    else if (pb == pbSmElephant)
                    {
                        pb.Location = new Point(pbSmElephant.Location.X - res.X, pbSmElephant.Location.Y - res.Y);
                    }
                    else if (pb == pbSmGir)
                    {
                        pb.Location = new Point(pbSmGir.Location.X - res.X, pbSmGir.Location.Y - res.Y);
                    }
                    else if (pb == pbSmLion)
                    {
                        pb.Location = new Point(pbSmLion.Location.X - res.X, pbSmLion.Location.Y - res.Y);
                    }
                    else if (pb == pbSmMonkey)
                    {
                        pb.Location = new Point(pbSmMonkey.Location.X - res.X, pbSmMonkey.Location.Y - res.Y);
                    }
                    else if (pb == pbSmZebra)
                    {
                        pb.Location = new Point(pbSmZebra.Location.X - res.X, pbSmZebra.Location.Y - res.Y);
                    }
                    else
                    {

                    }
                }


                //update old location
                firstPoint = temp;
            }
            else
            {

            }
        }

        private void pbLgElephant_MouseUp(object sender, MouseEventArgs e)
        {
            leftClick = false;
        }

        private void pbLgElephant_MouseDown(object sender, MouseEventArgs e)
        {

            //when I click I need the picture image centered on my curser
            //want the pb that I clicked
            //int offsetX = pbLgElephant.Image.Width/2;
            //int offsetY = pbLgElephant.Image.Height/2;
            //MouseDownX = pbLgElephant.Left + offsetX;
            //MouseDownY = pbLgElephant.Top + offsetY;
            //we have the image corrdnets we now need to simmulate attaching.
            //MessageBox.Show("x:"+ MouseDownX.ToString()+ ", y:" + MouseDownY.ToString());
            // Point p = new Point(MouseDownX, MouseDownY);//gets x and y and puts it into a point

            //send to move what was clicked
            //foreach(PictureBox pb in this.Controls)
            //{
            //    //pass in what the image and a bool.
            //    bool ThisOne;
            //    if(e.Button == MouseButtons.Left)
            //    //WhatImage(pb.Image,true);
            //}

            firstPoint = Control.MousePosition;   
            if(leftClick == false)
            { leftClick = true; }     
        }
    }

}
