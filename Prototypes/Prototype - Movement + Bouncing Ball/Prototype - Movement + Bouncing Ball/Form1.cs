using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prototype___Movement___Bouncing_Ball
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Vector2 location = new Vector2();
        Vector2 velocity = new Vector2();

        bool moveLeft, moveRight;
        int movementHorisontal = 5;

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.DoubleBuffered = true;

            location.X = this.Width / 2;
            location.Y = this.Height - 600;
            velocity.X = (float)2;
            velocity.Y = 5;

            pictureBox1.Top = this.Height - 100;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            location += velocity;
            if (location.Y > this.Height - 160)
            {
                velocity.Y *= -1;
            }
            if (location.Y < this.Height - 160)
            {
                velocity.Y += (float)0.5;
            }
            if (location.X < 0 || location.X > this.Width - 140)
            {
                velocity.X *= -1;
            }
            e.Graphics.FillEllipse(Brushes.DarkRed, location.X, location.Y, 120, 120);

            
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                moveLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                moveRight = false;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (moveLeft && pictureBox1.Left > 0)
            {
                pictureBox1.Left -= movementHorisontal;
            }
            if (moveRight && pictureBox1.Left < this.Width - 140)
            {
                pictureBox1.Left += movementHorisontal;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left)
            {
                moveLeft = true;
            }
            if(e.KeyCode == Keys.Right)
            {
                moveRight = true;
            }
        }
    }
}
