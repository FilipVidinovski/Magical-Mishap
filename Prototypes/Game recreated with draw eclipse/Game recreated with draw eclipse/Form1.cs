using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Numerics;

namespace Game_recreated_with_draw_eclipse
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(Form1_Paint);
        }

        Timer ballTimer = new Timer();
        bool ballAlive = true;
        Vector2 ballPosition = new Vector2();
        Vector2 ballVelocity = new Vector2();

        PictureBox player = new PictureBox();
        Timer playerTimer = new Timer();
        bool moveLeft, moveRight, Fired, Firing;
        int playerHitCD = 0;
        PictureBox bolt = new PictureBox();
        Timer boltTimer = new Timer();

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1280, 720);
            this.MaximumSize = new Size(1280, 720);
            this.MinimumSize = new Size(1280, 720);
            this.DoubleBuffered = true;
            this.BackColor = Color.DarkGray;

            #region Set ball & ball timer properties

            ballPosition.X = 400;
            ballPosition.Y = 400;

            ballVelocity.X = 6;
            ballVelocity.Y = 10;
            
            ballTimer.Interval = 20;
            ballTimer.Tick += new EventHandler(ballTimer_tick);
            ballTimer.Enabled = true;

            #endregion

            #region Set up player

            player.Size = new Size(40, 60);
            player.Location = new Point(620, 620);
            player.BackColor = Color.LightBlue;
            player.BringToFront();
            this.Controls.Add(player);

            playerTimer.Interval = 20;
            playerTimer.Tick += new EventHandler(playerTimer_tick);
            playerTimer.Enabled = true;

            #endregion

            #region Set up Bolt

            bolt.Size = new Size(20, 1);
            bolt.Location = new Point(0, 800);
            bolt.BackColor = Color.Gold;
            bolt.SendToBack();
            this.Controls.Add(bolt);

            boltTimer.Interval = 20;
            boltTimer.Tick += new EventHandler(boltTimer_tick);
            boltTimer.Enabled = true;

            #endregion

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
            if (e.KeyCode == Keys.Up && !Firing)
            {
                Firing = true;
                Fired = true;
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

        private void ballTimer_tick(object sender, EventArgs e)
        {
            if (ballAlive)
            {
                if(ballPosition.Y > 560)
                {
                    ballVelocity.Y = -25;
                    ballPosition.Y = 560;
                } else
                {
                    ballVelocity.Y += 1;
                }
                if(ballPosition.X < 0 || ballPosition.X > 1160)
                {
                    ballVelocity.X *= -1;
                }

                ballPosition.X += ballVelocity.X;
                ballPosition.Y += ballVelocity.Y;

                Invalidate();
            }

        }

        private void playerTimer_tick(object sender, EventArgs e)
        {
            if (moveLeft && !moveRight && player.Left > 0)
            {
                player.Left -= 12;
            }
            if (!moveLeft && moveRight && player.Left < 1220)
            {
                player.Left += 12;
            }
            if (Math.Sqrt((Math.Pow((ballPosition.X + 60) - (player.Left + (player.Width/2)), 2) + Math.Pow((ballPosition.Y + 60) - (player.Top + player.Width/2), 2)) ) < 75)
            {
                player.BackColor = Color.Red;
                playerHitCD = 25;
            }
            if (playerHitCD > 0)
            {
                playerHitCD--;
            }
            if (playerHitCD == 0)
            {
                player.BackColor = Color.LightBlue;
            }



        }

        private void boltTimer_tick(object sender, EventArgs e)
        {
            if (Fired)
            {
                bolt.Left = player.Left + 10;
                bolt.Top = this.Height;
                Fired = false;
            }
            if (Firing)
            {
                bolt.Height += 5;
                bolt.Top -= 5;
            }
            if (bolt.Top < 0)
            {
                Firing = false;
                bolt.Height = 1;
                bolt.Top = 800;
            }
            if (bolt.Top < ballPosition.Y+60 && (bolt.Left - 60 > ballPosition.X || bolt.Left + bolt.Width + 60 < ballPosition.X))
            {
                ballAlive = false;
                Firing = false;
                bolt.Height = 1;
                bolt.Top = 800;
            }

        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (ballAlive)
            {
                Pen P = new Pen(new SolidBrush(Color.Coral), 0);
                SolidBrush b = new SolidBrush(Color.Coral);
                e.Graphics.DrawEllipse(P, (int)ballPosition.X, (int)ballPosition.Y, 120, 120);
                e.Graphics.FillEllipse(b, (int)ballPosition.X, (int)ballPosition.Y, 120, 120);
            }

        }
    }
}
