using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Windows.Forms;

namespace Prototype___Movement___Shooting
{

    internal class Strela
    {
        PictureBox strela = new PictureBox();
        Timer strelaTimer = new Timer();

        public int strelaPoz;

        public void Bullet(Form form)
        {
            strela.BackColor = System.Drawing.Color.Green;
            strela.Size = new Size(20, 20);
            strela.Tag = "strela";
            strela.Left = strelaPoz;
            strela.Top = Form1.ActiveForm.Height - 140;
            strela.BringToFront();
            form.Controls.Add(strela);

            strelaTimer.Interval = 10;
            strelaTimer.Tick += new EventHandler(strelaTimer_tick);
            strelaTimer.Start();
        }

        public void strelaTimer_tick(object sender, EventArgs e)
        {
            strela.Top -= 10;

            if (strela.Top < 0)
            {
                strelaTimer.Stop();
                strelaTimer.Dispose();
                strela.Dispose();
                strelaTimer = null;
                strela = null;
            }
        }
    }
}
