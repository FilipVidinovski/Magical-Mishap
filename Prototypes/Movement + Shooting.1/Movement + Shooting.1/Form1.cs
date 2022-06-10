using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Movement___Shooting._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool moveLeft, moveRight;
        byte movement = 10;
        byte playerHP = 3;
        Random random = new Random();

        private void Form1_Load(object sender, EventArgs e)
        {
            //pozicioniranje igracot
            player.Top = this.Height - 100;
            player.Left = this.Width / 2 - 20;


        }

        //Dvizenje
        private void playerTimer_Tick(object sender, EventArgs e)
        {
            if (playerHP > 0)
            {
                if (moveLeft == true && moveRight == false)
                {
                    player.Left -= movement;
                }
                if (moveRight == true && moveLeft == false)
                {
                    player.Left += movement;
                }
            }
        }

        //Testiranje za pritisnato kopce
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left)
            {
                moveLeft = true;
                player.Image = Image.FromFile("../Images/MoveLeft.png");
            }
            if (e.KeyCode == Keys.Right)
            {
                moveRight = true;
                player.Image = Image.FromFile("../Images/MoveRight.png");
            }
            if (e.KeyCode == Keys.Up)
            {
                shoot(player.Left + 10);
            }
            if (e.KeyCode == Keys.Down)
            {
                if (random.Next(1, 3) == 1)
                    balloon(random.Next(2, 5), false);
                else
                {
                    balloon(random.Next(2, 5), true);
                }
            }
            if (e.KeyCode == Keys.Space)
            {
                //balloon(1, true);
                balloon(2, true);
                balloon(3, true);
                balloon(4, true);

            }
        }

        //Testiranje za otpusteno kopce
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                moveLeft = false;
                player.Image = Image.FromFile("../Images/MoveShoot.png");
            }
            if (e.KeyCode == Keys.Right)
            {
                moveRight = false;
                player.Image = Image.FromFile("../Images/MoveShoot.png");
            }
        }

        //Povikuvanje za generiranje vertikalen bolt
        public void shoot (int pozicija)
        {
            MagicBolt bolt = new MagicBolt();
            bolt.magicBoltPoz = pozicija;
            bolt.Bolt(this);
        }


        //Generiranje Balon
        public void balloon(int golemina, bool balloonLeft)
        {
            Balloon ball = new Balloon();
            ball.golemina = golemina;
            ball.balloonLeft = balloonLeft;
            ball.windowWidth = this.Width;
            ball.windowHeight = this.Height;
            ball.generateBalloon(this);
        }
    }
}
