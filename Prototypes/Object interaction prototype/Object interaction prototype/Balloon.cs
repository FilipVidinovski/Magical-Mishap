using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Numerics;

namespace Object_interaction_prototype
{
    internal class Balloon
    {
        PictureBox balloon = new PictureBox();
        Timer balloonTimer = new Timer();

        public int golemina;
        public bool balloonLeft;
        public int windowHeight, windowWidth, positionLeft, positionTop;

        Vector2 velocity = new Vector2();
        Vector2 position = new Vector2();

        public void generateBalloon(Form form)
        {
            balloon.BackColor = Color.Coral;

            if (golemina > 0)
            {
                balloon.Size = new Size(golemina * 25, golemina * 25);
            }
            balloon.Tag = "balloon";

            position.X = positionLeft - (golemina * 25);
            position.Y = (positionTop) - (golemina * 25);

            balloon.Left = (int)position.X;
            balloon.Top = (int)position.Y;
            balloon.BringToFront();
            form.Controls.Add(balloon);

            if (balloonLeft)
            {
                velocity.X = 20 - (3 * golemina);
            }
            else
            {
                velocity.X = -20 - (-3 * golemina);
            }
            velocity.Y = -10;


            balloonTimer.Interval = 20;
            balloonTimer.Tick += new EventHandler(balloonTimer_tick);
            balloonTimer.Start();
        }

        public void balloonTimer_tick(object sender, EventArgs e)
        {
            position.X = balloon.Left;
            position.Y = balloon.Top;

            if (position.Y > windowHeight - (45 + golemina * 25))
            {
                velocity.Y = golemina - 35;
            }
            else
            {
                velocity.Y += 5 - golemina;
            }
            if (position.X < 0 || position.X > windowWidth - (20 + golemina * 25))
            {
                velocity.X *= -1;
            }

            position.X += velocity.X;
            position.Y += velocity.Y;
            balloon.Top = (int)position.Y;
            balloon.Left = (int)position.X;

            
        }

        public PictureBox returnBaloon()
        {
            return balloon;
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
