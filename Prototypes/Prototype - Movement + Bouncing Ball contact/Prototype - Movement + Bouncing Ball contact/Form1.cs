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

namespace Prototype___Movement___Bouncing_Ball_contact
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Vector2 velocity = new Vector2();
        Vector2 location = new Vector2();
        bool moveLeft, moveRight;


        private void Form1_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
            this.WindowState = FormWindowState.Maximized;

            player.Size = new Size(40, 60);
            player.BackColor = Color.Blue;
            player.Top = this.Height - 100;
            player.Left = this.Width / 2;

            ball.Size = new Size(120, 120);
            ball.BackColor = Color.DarkRed;
            location.X = 100;
            location.Y = this.Width / 2;
            ball.Top = (int)location.X;
            ball.Left = (int)location.Y;
            


            velocity.X = 10;
            velocity.Y = 2;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            location.X = ball.Left;
            location.Y = ball.Top;

            if (location.X > this.Width - 140 || location.X < 0)
            {
                velocity.X *= -1;
            }
            if (location.Y < (this.Height - 170))
            {
                velocity.Y += 1;
            }
            else
            {
                velocity.Y *= -1;
            }

            location.X += velocity.X;
            location.Y += velocity.Y;
            ball.Top = (int)location.Y;
            ball.Left = (int)location.X;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if(moveLeft && player.Left > 0)
            {
                player.Left -= 12;
            }
            if(moveRight && player.Left < this.Width - 80)
            {
                player.Left += 12;
            }
            if (player.Bounds.IntersectsWith(ball.Bounds))
            {
                label1.Text = "Hit";
            }
            else
            {
                label1.Text = "Not hit";
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                moveLeft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                moveRight = true;
            }
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
    }
}