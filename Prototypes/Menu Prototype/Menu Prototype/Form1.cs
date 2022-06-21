using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace Menu_Prototype
{
    public partial class Form1 : Form
    {

        List<Button> buttonList = new List<Button>();
        PictureBox magicalMishapLogo = new PictureBox();
        PictureBox languageEnglish = new PictureBox();
        PictureBox languageMakedonski = new PictureBox();
        PictureBox soundToggle = new PictureBox();
        TrackBar volumeSlider = new TrackBar();
        WindowsMediaPlayer mediaPlayer = new WindowsMediaPlayer();
        bool playMusic = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            magicalMishapLogo.BackColor = Color.White;
            magicalMishapLogo.Image = Properties.Resources.MagicalMishapLogo;
            magicalMishapLogo.Size = new Size(300, 200);
            magicalMishapLogo.Location = new Point((1280 / 2) - (magicalMishapLogo.Width / 2), 120);
            this.Controls.Add(magicalMishapLogo);

            languageEnglish.BackColor = Color.Blue;
            languageEnglish.Image = Properties.Resources.BritanskoZname;
            languageEnglish.Size = new Size(100, 75);
            languageEnglish.Location = new Point(1280 - (languageEnglish.Width + 20), 5);
            languageEnglish.Click += new EventHandler(languageEnglish_Click);
            this.Controls.Add(languageEnglish);

            languageMakedonski.BackColor = Color.Red;
            languageMakedonski.Image = Properties.Resources.MakedonskoZname;
            languageMakedonski.Size = new Size(100, 75);
            languageMakedonski.Location = new Point(languageEnglish.Left - (languageMakedonski.Width + 5), 5);
            languageMakedonski.Click += new EventHandler(languageMakedonski_Click);
            this.Controls.Add(languageMakedonski);

            soundToggle.BackColor = Color.Brown;
            soundToggle.Image = Properties.Resources.SoundPlay;
            soundToggle.Size = new Size(75, 75);
            soundToggle.Location = new Point(languageMakedonski.Left - (soundToggle.Width + 5), 5);
            soundToggle.Click += new EventHandler(soundToggle_Click);
            this.Controls.Add(soundToggle);

            mediaPlayer.URL = @"D:\Visual Studio Repository\Magical-Mishap Proekt\Prototypes\Menu Prototype\Menu Prototype\Music\Temple of the Crater _ CrossCode Original Soundtrack EX.mp3";
            mediaPlayer.settings.volume = 1;
            mediaPlayer.controls.play();

            generateButtons();
        }

        //Generiranje Kopcinja
        #region Buttons
        private void generateButtons()
        {

            Button buttonLevels = new Button();
            styleButton(buttonLevels, "Levels");
            buttonLevels.Location = new Point((1280 / 2) - (buttonLevels.Width / 2), (magicalMishapLogo.Top + magicalMishapLogo.Height + 50));
            buttonLevels.Click += new EventHandler(buttonLevels_Click);
            this.Controls.Add(buttonLevels);
            buttonList.Add(buttonLevels);

            Button buttonEndlessMode = new Button();
            styleButton(buttonEndlessMode, "Endless Mode");
            buttonEndlessMode.Enabled = false;
            buttonEndlessMode.Location = new Point((1280 / 2) - (buttonEndlessMode.Width / 2), (buttonLevels.Top + buttonLevels.Height + 25));
            buttonEndlessMode.Click += new EventHandler(buttonEndlessMode_Click);

            this.Controls.Add(buttonEndlessMode);
            buttonList.Add(buttonEndlessMode);            

            Button buttonQuit = new Button();
            styleButton(buttonQuit, "Quit");
            buttonQuit.Location = new Point((1280 / 2) - (buttonQuit.Width / 2), (buttonEndlessMode.Top + buttonEndlessMode.Height + 25));
            buttonQuit.Click += new EventHandler(buttonQuit_Click);
            this.Controls.Add(buttonQuit);
            buttonList.Add(buttonQuit);

            Button buttonLevel1 = new Button();
            styleButton(buttonLevel1, "Level 1");
            buttonLevel1.Location = new Point(((1280 / 6) * 1) - (buttonLevel1.Width / 2), (magicalMishapLogo.Top + magicalMishapLogo.Height + 25));
            buttonLevel1.Click += new EventHandler(buttonLevel1_Click);
            buttonLevel1.Hide();
            this.Controls.Add(buttonLevel1);
            buttonList.Add(buttonLevel1);

            Button buttonLevel2 = new Button();
            styleButton(buttonLevel2, "Level 2");
            buttonLevel2.Location = new Point(((1280 / 6) * 2) - (buttonLevel1.Width / 2), (magicalMishapLogo.Top + magicalMishapLogo.Height + 25));
            buttonLevel2.Click += new EventHandler(buttonLevel2_Click);
            buttonLevel2.Enabled = false;
            buttonLevel2.Hide();
            this.Controls.Add(buttonLevel2);
            buttonList.Add(buttonLevel2);

            Button buttonLevel3 = new Button();
            styleButton(buttonLevel3, "Level 3");
            buttonLevel3.Location = new Point(((1280 / 6) * 3) - (buttonLevel1.Width / 2), (magicalMishapLogo.Top + magicalMishapLogo.Height + 25));
            buttonLevel3.Click += new EventHandler(buttonLevel3_Click);
            buttonLevel3.Enabled = false;
            buttonLevel3.Hide();
            this.Controls.Add(buttonLevel3);
            buttonList.Add(buttonLevel3);
            
            Button buttonLevel4 = new Button();
            styleButton(buttonLevel4, "Level 4");
            buttonLevel4.Location = new Point(((1280 / 6) * 4) - (buttonLevel1.Width / 2), (magicalMishapLogo.Top + magicalMishapLogo.Height + 25));
            buttonLevel4.Click += new EventHandler(buttonLevel4_Click);
            buttonLevel4.Enabled = false;
            buttonLevel4.Hide();
            this.Controls.Add(buttonLevel4);
            buttonList.Add(buttonLevel4);
            
            Button buttonLevel5 = new Button();
            styleButton(buttonLevel5, "Level 5");
            buttonLevel5.Location = new Point(((1280 / 6) * 5) - (buttonLevel1.Width / 2), (magicalMishapLogo.Top + magicalMishapLogo.Height + 25));
            buttonLevel5.Click += new EventHandler(buttonLevel5_Click);
            buttonLevel5.Enabled = false;
            buttonLevel5.Hide();
            this.Controls.Add(buttonLevel5);
            buttonList.Add(buttonLevel5);
            
            Button buttonLevel6 = new Button();
            styleButton(buttonLevel6, "Level 6");
            buttonLevel6.Location = new Point(((1280 / 6) * 1) - (buttonLevel1.Width / 2), (buttonLevel1.Top + buttonLevel1.Height + 25));
            buttonLevel6.Click += new EventHandler(buttonLevel6_Click);
            buttonLevel6.Enabled = false;
            buttonLevel6.Hide();
            this.Controls.Add(buttonLevel6);
            buttonList.Add(buttonLevel6);
            
            Button buttonLevel7 = new Button();
            styleButton(buttonLevel7, "Level 7");
            buttonLevel7.Location = new Point(((1280 / 6) * 2) - (buttonLevel1.Width / 2), (buttonLevel1.Top + buttonLevel1.Height + 25));
            buttonLevel7.Click += new EventHandler(buttonLevel7_Click);
            buttonLevel7.Enabled = false;
            buttonLevel7.Hide();
            this.Controls.Add(buttonLevel7);
            buttonList.Add(buttonLevel7);
            
            Button buttonLevel8 = new Button();
            styleButton(buttonLevel8, "Level 8");
            buttonLevel8.Location = new Point(((1280 / 6) * 3) - (buttonLevel1.Width / 2), (buttonLevel1.Top + buttonLevel1.Height + 25));
            buttonLevel8.Click += new EventHandler(buttonLevel8_Click);
            buttonLevel8.Enabled = false;
            buttonLevel8.Hide();
            this.Controls.Add(buttonLevel8);
            buttonList.Add(buttonLevel8);
            
            Button buttonLevel9 = new Button();
            styleButton(buttonLevel9, "Level 9");
            buttonLevel9.Location = new Point(((1280 / 6) * 4) - (buttonLevel1.Width / 2), (buttonLevel1.Top + buttonLevel1.Height + 25));
            buttonLevel9.Click += new EventHandler(buttonLevel9_Click);
            buttonLevel9.Enabled = false;
            buttonLevel9.Hide();
            this.Controls.Add(buttonLevel9);
            buttonList.Add(buttonLevel9);

            Button buttonLevel10 = new Button();
            styleButton(buttonLevel10, "Level 10");
            buttonLevel10.Location = new Point(((1280 / 6) * 5) - (buttonLevel1.Width / 2), (buttonLevel1.Top + buttonLevel1.Height + 25));
            buttonLevel10.Click += new EventHandler(buttonLevel10_Click);
            buttonLevel10.Enabled = false;
            buttonLevel10.Hide();
            this.Controls.Add(buttonLevel10);
            buttonList.Add(buttonLevel10);

            Button buttonBack = new Button();
            styleButton(buttonBack, "Back");
            buttonBack.Location = new Point(((1280 / 6) * 5) - (buttonLevel1.Width / 2), (buttonLevel10.Top + buttonLevel10.Height + 25));
            buttonBack.Click += new EventHandler(buttonBack_Click);
            buttonBack.Hide();
            this.Controls.Add(buttonBack);
            buttonList.Add(buttonBack);
        }

        private void styleButton(Button b, string name)
        {
            b.Size = new Size(85, 25);
            b.BackColor = Color.LightBlue;
            b.Text = name;
        }

        #endregion

        private void languageEnglish_Click(object sender, EventArgs e)
        {
            setLanguageEnglish();
        }

        private void languageMakedonski_Click(object sender, EventArgs e)
        {
            setLanguageMakedonski();
        }

        private void soundToggle_Click(object sender, EventArgs e)
        {
            if (playMusic)
            {
                mediaPlayer.settings.volume = 0;
                playMusic = false;
                soundToggle.Image = Properties.Resources.SoundStop;
            }
            else
            {
                mediaPlayer.settings.volume = 1;
                playMusic = true;
                soundToggle.Image = Properties.Resources.SoundPlay;
            }
        }

        private void buttonLevels_Click(object sender, EventArgs e)
        {
            hideMainMenu();
            showLevels();
        }

        private void buttonQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonEndlessMode_Click(object sender, EventArgs e)
        {

        }

        private void buttonLevel1_Click(object sender, EventArgs e)
        {

        }
        private void buttonLevel2_Click(object sender, EventArgs e)
        {

        }
        private void buttonLevel3_Click(object sender, EventArgs e)
        {

        }
        private void buttonLevel4_Click(object sender, EventArgs e)
        {

        }
        private void buttonLevel5_Click(object sender, EventArgs e)
        {

        }
        private void buttonLevel6_Click(object sender, EventArgs e)
        {

        }
        private void buttonLevel7_Click(object sender, EventArgs e)
        {

        }
        private void buttonLevel8_Click(object sender, EventArgs e)
        {

        }
        private void buttonLevel9_Click(object sender, EventArgs e)
        {

        }
        private void buttonLevel10_Click(object sender, EventArgs e)
        {

        }
        private void buttonBack_Click(object sender, EventArgs e)
        {
            hideLevels();
            showMainMenu();
        }
        
        private void hideMainMenu()
        {
            for (int i = 0; i < 3; i++)
            {
                buttonList[i].Hide();
            }
        }

        private void showLevels()
        {
            for (int i = 3; i < 14; i++)
            {
                buttonList[i].Show();
            }
        }

        private void showMainMenu()
        {
            for (int i = 0; i < 3; i++)
            {
                buttonList[i].Show();
            }
        }
        
        private void hideLevels()
        {
            for (int i = 3; i < 14; i++)
            {
                buttonList[i].Hide();
            }
        }

        private void setLanguageEnglish()
        {
            buttonList[0].Text = "Levels";
            buttonList[1].Text = "Endless Mode";
            buttonList[2].Text = "Quit";
            buttonList[3].Text = "Level 1";
            buttonList[4].Text = "Level 2";
            buttonList[5].Text = "Level 3";
            buttonList[6].Text = "Level 4";
            buttonList[7].Text = "Level 5";
            buttonList[8].Text = "Level 6";
            buttonList[9].Text = "Level 7";
            buttonList[10].Text = "Level 8";
            buttonList[11].Text = "Level 9";
            buttonList[12].Text = "Level 10";
            buttonList[13].Text = "Back";
        }

        private void setLanguageMakedonski()
        {
            buttonList[0].Text = "Нивоа";
            buttonList[1].Text = "Бесконечно ниво";
            buttonList[2].Text = "Излез";
            buttonList[3].Text = "Ниво 1";
            buttonList[4].Text = "Ниво 2";
            buttonList[5].Text = "Ниво 3";
            buttonList[6].Text = "Ниво 4";
            buttonList[7].Text = "Ниво 5";
            buttonList[8].Text = "Ниво 6";
            buttonList[9].Text = "Ниво 7";
            buttonList[10].Text = "Ниво 8";
            buttonList[11].Text = "Ниво 9";
            buttonList[12].Text = "Ниво 10";
            buttonList[13].Text = "Назад";
        }
    }
}
