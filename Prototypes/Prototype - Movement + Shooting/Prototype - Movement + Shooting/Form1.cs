using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool moveLeft, moveRight;
        int movementHorisontal = 10;

        private void Form1_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
            this.WindowState = FormWindowState.Maximized;

            pictureBox1.Top = this.Height - 100;
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
            if (e.KeyCode == Keys.Up)
            {
                shoot(pictureBox1.Left + 10);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
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

        public void shoot(int pozicija)
        {
            Strela shoot = new Strela();
            shoot.strelaPoz = pozicija;
            shoot.Bullet(this);
        }
    }
}
