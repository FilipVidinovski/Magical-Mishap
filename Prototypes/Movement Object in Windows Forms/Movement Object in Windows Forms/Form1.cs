using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Movement_Object_in_Windows_Forms
{
    public partial class Form1 : Form
    {

        bool moveRight, moveLeft, moveUp, moveDown;

        int speed = 5;

        public Form1()
        {
            InitializeComponent();
        }

        private void moveTimerEvent(object sender, EventArgs e)
        {
            if (moveLeft && pictureBox1.Left > 0)
            {
                pictureBox1.Left -= speed;
            }
            if (moveRight && pictureBox1.Left < 380)
            {
                pictureBox1.Left += speed;
            }
            if (moveUp && pictureBox1.Top > 0)
            {
                pictureBox1.Top -= speed;
            }
            if (moveDown && pictureBox1.Top < 380)
            {
                pictureBox1.Top += speed;
            }
        }

        private void keyIsDown(object sender, KeyEventArgs e)
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
                moveUp = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                moveDown = true;
            }
        }

        private void keyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                moveLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                moveRight = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                moveUp = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                moveDown = false;
            }
        }
    }
}
