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

namespace Object_interaction_prototype
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        bool moveLeft, moveRight, fire, firing, takenDamage;
        byte playerHP = 3, takenDamageCooldown;
        List<Balloon> balloonList = new List<Balloon>();
        Random random = new Random();

        private void Form1_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = Color.DarkGray;
            player.Top = this.Height - 100;
            player.Left = (this.Width / 2) - 20;
            positionMagicBolt();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
            if(e.KeyCode == Keys.Left)
            {
                moveLeft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                moveRight = true;
            }
            if(e.KeyCode == Keys.Up && !firing)
            {
                fire = true;
            }
            if (e.KeyCode == Keys.Space)
            {
                if(random.Next(0, 2) == 1)
                {
                    int temp = random.Next(2, 5);
                    generateBalloon(temp, true, this.Width / 2, (this.Height / 6) * (5 - temp));
                }
                else
                {
                    int temp = random.Next(2, 5);
                    generateBalloon(temp, false, this.Width / 2, (this.Height / 6) * (5 - temp));
                }
            }
        }

        public void generateBalloon(int balloonSize, bool movementLeft, int positionLeft, int positionTop)
        {
            if (balloonSize >= 2){
                Balloon balloon = new Balloon();
                balloon.golemina = balloonSize;
                balloon.balloonLeft = movementLeft;
                balloon.positionLeft = positionLeft;
                balloon.positionTop = positionTop;
                balloon.windowHeight = this.Height;
                balloon.windowWidth = this.Width;
                balloon.generateBalloon(this);
                balloonList.Add(balloon);
            }
        }

        private void playerTimer_Tick(object sender, EventArgs e)
        {
            if (moveLeft && player.Left > 10)
            {
                player.Left -= 10;
            }
            if (moveRight && player.Right < this.Width - 20)
            {
                player.Left += 10;
            }
            foreach (Balloon item in balloonList.ToList())
            {
                if (player.Bounds.IntersectsWith(item.returnBaloon().Bounds) && !takenDamage)
                {
                    label1.Text = "Player HP = " + --playerHP;
                    takenDamage = true;
                    takenDamageCooldown = 50;
                    player.BackColor = Color.Red;
                }
                if (magicBolt.Bounds.IntersectsWith(item.returnBaloon().Bounds))
                {
                    generateBalloon((item.returnBaloon().Width / 25) - 1, true, item.returnBaloon().Left - 25, item.returnBaloon().Top + 25);
                    generateBalloon((item.returnBaloon().Width / 25) - 1, false, item.returnBaloon().Left - 25, item.returnBaloon().Top + 25);
                    item.destroyBalloon();
                    balloonList.Remove(item);
                    positionMagicBolt();
                }
            }
            if(takenDamageCooldown > 0)
            {
                takenDamageCooldown--;
            }
            if (takenDamageCooldown == 0)
            {
                takenDamage = false;
                player.BackColor = Color.Cyan;
            }
        }

        private void magicBoltTimer_Tick(object sender, EventArgs e)
        {
            if (fire && !firing)
            {
                fire = false;
                magicBolt.Top = this.Height - 40;
                magicBolt.Left = player.Left + 10;
                firing = true;
            }
            if (firing)
            {
                magicBolt.Top -= 10;
                magicBolt.Height += 10;
            }
            if (magicBolt.Top < 0)
            {
                firing = false;
                positionMagicBolt();
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left)
            {
                moveLeft = false;
            }
            if(e.KeyCode == Keys.Right)
            {
                moveRight = false;
            }
        }

        private void positionMagicBolt()
        {
            magicBolt.Height = 60;
            magicBolt.Top = this.Height + 250;
            magicBolt.Left = this.Width + 250;
            firing = false;
        }
        
    }
}
