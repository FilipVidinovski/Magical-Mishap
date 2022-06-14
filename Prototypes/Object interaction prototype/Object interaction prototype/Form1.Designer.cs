namespace Object_interaction_prototype
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.player = new System.Windows.Forms.PictureBox();
            this.playerTimer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.magicBolt = new System.Windows.Forms.PictureBox();
            this.magicBoltTimer = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.magicBolt)).BeginInit();
            this.SuspendLayout();
            // 
            // player
            // 
            this.player.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.player.Location = new System.Drawing.Point(173, 100);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(40, 60);
            this.player.TabIndex = 0;
            this.player.TabStop = false;
            // 
            // playerTimer
            // 
            this.playerTimer.Enabled = true;
            this.playerTimer.Interval = 20;
            this.playerTimer.Tick += new System.EventHandler(this.playerTimer_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Player HP: 3";
            // 
            // magicBolt
            // 
            this.magicBolt.BackColor = System.Drawing.Color.Yellow;
            this.magicBolt.Location = new System.Drawing.Point(341, 39);
            this.magicBolt.Name = "magicBolt";
            this.magicBolt.Size = new System.Drawing.Size(20, 1);
            this.magicBolt.TabIndex = 2;
            this.magicBolt.TabStop = false;
            // 
            // magicBoltTimer
            // 
            this.magicBoltTimer.Enabled = true;
            this.magicBoltTimer.Interval = 20;
            this.magicBoltTimer.Tick += new System.EventHandler(this.magicBoltTimer_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(132, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(448, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Движење со лево десно, пукање со нагоре, генерирање балони со space, Esc за крај";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.magicBolt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.player);
            this.Name = "Form1";
            this.Text = "Object interaction prototype";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.magicBolt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox player;
        private System.Windows.Forms.Timer playerTimer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox magicBolt;
        private System.Windows.Forms.Timer magicBoltTimer;
        private System.Windows.Forms.Label label2;
    }
}

