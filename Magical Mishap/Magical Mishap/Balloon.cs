using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;

namespace Magical_Mishap
{
    internal class Balloon
    {
        PictureBox balloon = new PictureBox();
        Timer balloonTimer = new Timer();

        // size - golemina na balonot
        // balloonLeft, balloonTop - pozicija na balonot
        // movement - nasoka na dvizenje - -1 levo, 0 vo mesto, 1 desno
        public int size, balloonLeft, balloonTop, movement;
        Vector2 location = new Vector2();
        Vector2 velocity = new Vector2();

        public void generateBalloon(Form form)
        {
            switch (size)
            {
                case 2:
                    balloon.Image = Properties.Resources.Balloon50x50;
                    balloon.BackColor = Color.Transparent;
                    break;
                case 3:
                    balloon.Image = Properties.Resources.Balloon75x75;
                    balloon.BackColor = Color.Transparent;
                    break;
                case 4:
                    balloon.Image = Properties.Resources.Balloon100x100;
                    balloon.BackColor = Color.Transparent;
                    break;
                case 5:
                    balloon.Image = Properties.Resources.Balloon125x125;
                    balloon.BackColor = Color.Transparent;
                    break;
                default:
                    balloon.BackColor = Color.Coral; break;
            }
            balloon.Size = new Size(size * 25, size * 25);
            balloon.Tag = "balloon";

            if (balloonLeft < balloon.Width/2)
            {
                balloonLeft += balloon.Width / 2;
            }
            if (balloonLeft > 1080 - (balloon.Width+20))
            {
                balloonLeft -= balloon.Width;
            }
            location.X = (float)(balloonLeft - balloon.Width*0.5);
            location.Y = (float)(balloonTop - balloon.Height*0.5);

            balloon.Location = new Point((int)location.X, (int)location.Y);

            balloon.BringToFront();
            form.Controls.Add(balloon);

            if (movement == -1)
            {
                velocity.X = -7;
            }
            else if (movement == 0)
            {
                velocity.X = 0;
            }
            else
            {
                velocity.X = 7;
            }
            if (size!=5)
            {
                velocity.Y = -5;
            }
            else
            {
                velocity.Y = 0;
            }
            balloonTimer.Interval = 20;
            balloonTimer.Tick += new EventHandler(balloonTimer_Tick);
            balloonTimer.Start();
        }

        private void balloonTimer_Tick(object sender, EventArgs e)
        {
            location.X = balloon.Left;
            location.Y = balloon.Top;

            if (location.X > 1080 - (balloon.Width+20) || location.X < 0)
            {
                velocity.X *= -1;
            }
            if (size !=5)
            {
                if (location.Y < 650 - balloon.Height)
                {
                    velocity.Y += 5 - size;
                }
                else
                {
                    velocity.Y = -7 * size;
                }
            }
            
            
            
            
            location.X += velocity.X;
            location.Y += velocity.Y;

            balloon.Left = (int)location.X;
            balloon.Top = (int)location.Y;
        }

        public PictureBox returnBalloon()
        {
            return balloon;
        }

        public int returnSize()
        {
            return size;
        }

        public void pauseTimer()
        {
            balloonTimer.Stop();
        }

        public void startTimer()
        {
            balloonTimer.Start();
        }

        public void destroyBalloon()
        {
            balloonTimer.Stop();
            balloonTimer.Dispose();
            balloon.Dispose();
            balloon = null;
            balloonTimer = null;
        }
    }
}
