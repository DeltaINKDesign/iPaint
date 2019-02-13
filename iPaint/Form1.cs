using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iPaint
{
    public partial class Form1 : Form
    {
        Graphics g;
        int x = -1;
        int y = -1;
        bool moving = false;
        Pen pen;

        public Form1()
        {
            InitializeComponent();
            panel1.BackColor = Color.White;
            g = panel1.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            pen = new Pen(Color.Black,5);
            pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }

        

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

       
    private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
         if(moving && x != -1 && y != -1)
            {

                g.DrawLine(pen, new Point(x, y), e.Location);
                x = e.X;
                y = e.Y;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(this.panel1.Width, this.panel1.Height);

            this.panel1.DrawToBitmap(bmp, new Rectangle(0, 0, this.panel1.Width, this.panel1.Height));

            bmp.Save("panel.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            pen.Color = p.BackColor;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            moving = true;
            x = e.X;
            y = e.Y;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            moving = false;
            x = -1;
            y = -1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pen = new Pen(Color.Black, 3);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pen = new Pen(Color.Black, 10);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pen = new Pen(Color.Black, 28);
        }
    }
}
