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

namespace Prototype___Vertical_Bouncing_Ball
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        Vector2 location = new Vector2();
        Vector2 velocity = new Vector2();
        public void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            location.X = this.Width / 2;
            location.Y = this.Height / 2;
            velocity.X = 1;
            velocity.Y = 4;

            this.DoubleBuffered = true;
            Timer timer = new Timer();
            timer.Interval = 10;
            timer.Tick += Timer_Tick;
            timer.Enabled = true;





        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            location = location + velocity;
            if (location.Y < 0 || location.Y > this.Height - 160)
            {
                velocity.Y *= -1;
            }
            if (location.X < 0 || location.X > this.Width - 140)
            {
                velocity.X *= -1;
            }
            e.Graphics.FillEllipse(Brushes.BlueViolet, location.X, location.Y, 120, 120);
        }

        
    }
}
