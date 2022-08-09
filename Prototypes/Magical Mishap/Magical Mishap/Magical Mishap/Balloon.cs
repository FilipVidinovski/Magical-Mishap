using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
using System.Drawing;

namespace Magical_Mishap
{
    internal class Balloon
    {
        PictureBox balloon = new PictureBox();
        Timer balloonTimer = new Timer();

        //byte windowScale;
        int positionLeft, positionTop;
        bool movementLeft;
        byte size, type;
        bool isSpawned;
        byte spawningAnimationCounter = 0; 

        Vector2 location = new Vector2();
        Vector2 velocity = new Vector2();


        private void generateBalloon(Form form)
        {
            
            balloon.Size = new Size(25 * size, 25 * size);
            balloon.Location = new Point(positionLeft, positionTop);
            form.Controls.Add(balloon);

            balloonTimer.Interval = 10;
            balloonTimer.Tick += new EventHandler(balloonTimer_Tick);
            balloonTimer.Enabled = false;

            location.X = balloon.Left;
            location.Y = balloon.Top;

            if (movementLeft)
            {
                velocity.X = -4;
            }
            else
            {
                velocity.X = 4;
            }
            velocity.Y = 0;
        }

        private void balloonTimer_Tick(object sender, EventArgs e)
        {
            if (!isSpawned)
            {
                if ((spawningAnimationCounter > 5) && (spawningAnimationCounter < 10) || 
                    ((spawningAnimationCounter > 20)&&(spawningAnimationCounter < 25)) || 
                    ((spawningAnimationCounter > 30)))
                {
                    balloon.Hide();
                }
                else
                {
                    balloon.Show();
                }
                spawningAnimationCounter++;
            }
            if (spawningAnimationCounter == 31 && !isSpawned)
            {
                isSpawned = true;
            }

            if (isSpawned)
            {
                location.X = balloon.Left;
                location.Y = balloon.Top;

                if (location.X < 0 || location.X > 1080)
                {
                    velocity.X *= -1;
                }
                if (location.Y < 720)
                {
                    velocity.Y = size;
                }

                velocity.Y -= (float)0.1;

                location += velocity;

                balloon.Left = (int)location.X;
                balloon.Top = (int)location.Y;
            }

        }
        public PictureBox returnBalloon()
        {
            return balloon;
        }

        public byte returnSize()
        {
            return size;
        }

        public void destroyBalloon()
        {
            balloon.Dispose();
            balloon = null;
            balloonTimer.Stop();
            balloonTimer.Dispose();
            balloonTimer = null;
        }
    }
}
