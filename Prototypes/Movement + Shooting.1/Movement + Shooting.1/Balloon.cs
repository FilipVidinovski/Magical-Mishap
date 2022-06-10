using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Drawing;
using System.Windows.Forms;

namespace Movement___Shooting._1
{
    internal class Balloon
    {
        PictureBox balloon = new PictureBox();
        Timer balloonTimer = new Timer();

        public int golemina;
        public bool balloonLeft;
        public int windowHeight;
        public int windowWidth;


        Vector2 velocity = new Vector2();
        Vector2 position = new Vector2();

        public void generateBalloon(Form form)
        {
            //balloon.BackColor = Color.Coral;

            switch (golemina)
            {
                case 2:
                    balloon.Image = Image.FromFile("../Images/BallSmall.png");
                    break;
                case 3:
                    balloon.Image = Image.FromFile("../Images/BallMedium.png");
                    break;
                case 4:
                    balloon.Image = Image.FromFile("../Images/BallLarge.png");
                    break;
                default:
                    balloon.BackColor = Color.Coral;
                    break;
            }

            if (golemina > 0)
            {
                balloon.Size = new Size(golemina * 25, golemina * 25);
            }
            balloon.Tag = "balloon";

            position.X = (windowWidth / 2) - (golemina * 25);
            position.Y = ((windowHeight / 6) * (5-golemina)) + (golemina * 25);

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
            velocity.Y = 0;

            
            balloonTimer.Interval = 25;
            balloonTimer.Tick += new EventHandler(balloonTimer_tick);
            balloonTimer.Start();
        }

        public void balloonTimer_tick(object sender, EventArgs e)
        {
            position.X = balloon.Left;
            position.Y = balloon.Top;

            if(position.Y > windowHeight - (45 + golemina * 25))
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
    }
}
