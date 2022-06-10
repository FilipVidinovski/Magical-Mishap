using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Movement___Shooting._1
{
    internal class MagicBolt
    {
        PictureBox magicBolt = new PictureBox();
        Timer magicBoltTimer = new Timer();

        public int magicBoltPoz;

        public void Bolt(Form form)
        {
            magicBolt.BackColor = Color.Gold;
            magicBolt.Size = new Size(20, 30);
            magicBolt.Tag = "bolt";
            magicBolt.Left = magicBoltPoz;
            magicBolt.Top = Form1.ActiveForm.Height - 150;
            magicBolt.BringToFront();
            form.Controls.Add(magicBolt);

            magicBoltTimer.Interval = 20;
            magicBoltTimer.Tick += new EventHandler(magicBoltTimer_tick);
            magicBoltTimer.Start();
        }

        public void magicBoltTimer_tick(object sender, EventArgs e)
        {
            magicBolt.Top -= 10;

            if(magicBolt.Top < -30)
            {
                magicBoltTimer.Stop();
                magicBoltTimer.Dispose();
                magicBolt.Dispose();
                magicBoltTimer = null;
                magicBolt = null;
            }
        }

    }
}
