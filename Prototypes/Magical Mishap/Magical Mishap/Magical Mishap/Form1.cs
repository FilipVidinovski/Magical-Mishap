using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
using WMPLib;

namespace Magical_Mishap
{
    public partial class Form1 : Form
    {
        bool isGameinProgress = false;

        #region Menu Items
        PictureBox menuLogo = new PictureBox();
        WindowsMediaPlayer music = new WindowsMediaPlayer();
        List<Button> buttonList = new List<Button>();
        // 0 - 2 main menu buttons
        // 3 - 14 levels 1-10 + Endless Mode
        // 15 - Test Level 
        // 16 - Unlock All levels button
        // 17 - back to main menu button
        // 18 - pause button
        Label languageLabel = new Label();
        PictureBox langMkd = new PictureBox();
        PictureBox langEng = new PictureBox();
        Label volumeLabel = new Label();
        TrackBar musicVolume = new TrackBar();
        PictureBox volumeIndicator = new PictureBox();
        //ComboBox windowSize = new ComboBox();
        #endregion

        #region Game Items
        List<Balloon> balloonList = new List<Balloon>();
        
        #region Player
        PictureBox player = new PictureBox();
        bool moveLeft, moveRight;
        byte playerHP = 0;
        byte playerDamagedCD = 50;

        Timer playerTimer = new Timer();

        #endregion

        #region Bolt
        PictureBox Bolt = new PictureBox();

        #endregion

        #endregion


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1080, 720);
            this.DoubleBuffered = true;
            this.BackColor = Color.Gray;
            this.KeyPreview = true;

            this.MaximumSize = new Size(1080, 720);
            this.MinimumSize = new Size(1080, 720);

            generateRest();
            generateButtons();
            generatePlayer();
        }

        //Generates the items used in the menues
        #region Generate Buttons & Menu Components
        private void generateButtons()
        {
            Button buttonLevels = new Button();
            StyleButton(buttonLevels, "Levels", true);
            buttonLevels.Location = new Point((int)(540 - (buttonLevels.Width/2)), (menuLogo.Top + menuLogo.Height)+50);
            buttonLevels.Click += new EventHandler(buttonLevels_Click);
            ImplementButton(buttonLevels);

            Button buttonSettings = new Button();
            StyleButton(buttonSettings, "Settings", true);
            buttonSettings.Location = new Point((int)540 - (int)(buttonSettings.Width / 2), (buttonLevels.Top + buttonLevels.Height) + 25);
            buttonSettings.Click += new EventHandler(buttonSettings_Click);
            ImplementButton(buttonSettings);

            Button buttonQuit = new Button();
            StyleButton(buttonQuit, "Quit", true);
            buttonQuit.Location = new Point(540 - (int)(buttonQuit.Width / 2), (buttonSettings.Top + buttonSettings.Height) + 25);
            buttonQuit.Click += new EventHandler(buttonQuit_Click);
            ImplementButton(buttonQuit);

            Button buttonLevel1 = new Button();
            StyleButton(buttonLevel1, "Level 1", true);
            buttonLevel1.Location = new Point(180 - (int)(buttonLevel1.Width / 2), buttonLevels.Top);
            buttonLevel1.Click += new EventHandler(buttonLevel1_Click);
            buttonLevel1.Hide();
            ImplementButton(buttonLevel1);

            Button buttonLevel2 = new Button();
            StyleButton(buttonLevel2, "Level 2", false);
            buttonLevel2.Location = new Point (360 - (int)(buttonLevel2.Width / 2), buttonLevels.Top);
            buttonLevel2.Click += new EventHandler(buttonLevel2_Click);
            buttonLevel2.Hide();
            ImplementButton(buttonLevel2);

            Button buttonLevel3 = new Button();
            StyleButton(buttonLevel3, "Level 3", false);
            buttonLevel3.Location = new Point(540 - (int)(buttonLevel3.Width / 2), buttonLevels.Top);
            buttonLevel3.Click += new EventHandler(buttonLevel3_Click);
            buttonLevel3.Hide();
            ImplementButton(buttonLevel3);

            Button buttonLevel4 = new Button();
            StyleButton(buttonLevel4, "Level 4", false);
            buttonLevel4.Location = new Point(720 - (int)(buttonLevel4.Width / 2), buttonLevels.Top);
            buttonLevel4.Click += new EventHandler(buttonLevel4_Click);
            buttonLevel4.Hide();
            ImplementButton(buttonLevel4);

            Button buttonLevel5 = new Button();
            StyleButton(buttonLevel5, "Level 5", false);
            buttonLevel5.Location = new Point(900 - (int)(buttonLevel5.Width / 2), buttonLevels.Top);
            buttonLevel5.Click += new EventHandler(buttonLevel5_Click);
            buttonLevel5.Hide();
            ImplementButton(buttonLevel5);

            Button buttonLevel6 = new Button();
            StyleButton(buttonLevel6, "Level 6", false);
            buttonLevel6.Location = new Point(buttonLevel1.Left, buttonSettings.Top);
            buttonLevel6.Click += new EventHandler(buttonLevel6_Click);
            buttonLevel6.Hide();
            ImplementButton(buttonLevel6);

            Button buttonLevel7 = new Button();
            StyleButton(buttonLevel7, "Level 7", false);
            buttonLevel7.Location = new Point(buttonLevel2.Left, buttonSettings.Top);
            buttonLevel7.Click += new EventHandler(buttonLevel7_Click);
            buttonLevel7.Hide();
            ImplementButton(buttonLevel7);

            Button buttonLevel8 = new Button();
            StyleButton(buttonLevel8, "Level8", false);
            buttonLevel8.Location = new Point(buttonLevel3.Left, buttonSettings.Top);
            buttonLevel8.Click += new EventHandler(buttonLevel8_Click);
            buttonLevel8.Hide();
            ImplementButton(buttonLevel8);

            Button buttonLevel9 = new Button();
            StyleButton(buttonLevel9, "Level9", false);
            buttonLevel9.Location = new Point(buttonLevel4.Left, buttonSettings.Top);
            buttonLevel9.Click += new EventHandler(buttonLevel9_Click);
            buttonLevel9.Hide();
            ImplementButton(buttonLevel9);

            Button buttonLevel10 = new Button();
            StyleButton(buttonLevel10, "Level 10", false);
            buttonLevel10.Location = new Point(buttonLevel5.Left, buttonSettings.Top);
            buttonLevel10.Click += new EventHandler(buttonLevel10_Click);
            buttonLevel10.Hide();
            ImplementButton(buttonLevel10);

            Button buttonEndlessMode = new Button();
            StyleButton(buttonEndlessMode, "Endless Mode", false);
            buttonEndlessMode.Location = new Point(buttonLevel1.Left, buttonQuit.Top);
            buttonEndlessMode.Click += new EventHandler(buttonEndlessMode_Click);
            buttonEndlessMode.Hide();
            ImplementButton(buttonEndlessMode);

            Button buttonTestLevel = new Button();
            StyleButton(buttonTestLevel, "Test Level", true);
            buttonTestLevel.Location = new Point(buttonLevel2.Left, buttonQuit.Top);
            buttonTestLevel.Click += new EventHandler(buttonTestLevel_Click);
            buttonTestLevel.Hide();
            ImplementButton(buttonTestLevel);

            Button buttonUnlockAll = new Button();
            StyleButton(buttonUnlockAll, "Unlock All", true);
            buttonUnlockAll.Location = new Point(buttonLevel4.Left, buttonQuit.Top);
            buttonUnlockAll.Click += new EventHandler(buttonUnlockAll_Click);
            buttonUnlockAll.Hide();
            ImplementButton(buttonUnlockAll);

            Button buttonBack = new Button();
            StyleButton(buttonBack, "Back", true);
            buttonBack.Location = new Point(buttonLevel5.Left, buttonQuit.Top);
            buttonBack.Click += new EventHandler(buttonBack_Click);
            buttonBack.Hide();
            ImplementButton(buttonBack);

            Button buttonPause = new Button();
            StyleButton(buttonPause, "Pause", true);
            buttonPause.Location = new Point(1080 - (buttonPause.Width + 25), 5);
            buttonPause.Click += new EventHandler(buttonPause_Click);
            buttonPause.Hide();
            ImplementButton(buttonPause);

            /*Button buttonRestartLevel = new Button();
            StyleButton(buttonRestartLevel, "Restart Level", true);
            buttonRestartLevel.Location = */
        }

        private void StyleButton(Button b, string name, bool isEnabled)
        {
            b.Text = name;
            b.Size = new Size(100, 30);
            b.BackColor = Color.Black;
            b.Enabled = true;
            if (isEnabled)
            {
                b.ForeColor = Color.White;
            }
            else
            {
                b.ForeColor = Color.Gray;
            }

        }

        private void ImplementButton(Button b)
        {
            this.Controls.Add(b);
            buttonList.Add(b);
        }

        private void generateRest()
        {
            menuLogo.Size = new Size(250, 200);
            menuLogo.Location = new Point((this.Width / 2) - (menuLogo.Width / 2), 100);
            menuLogo.BackColor = Color.White;
            this.Controls.Add(menuLogo);

            languageLabel.Size = new Size(63, 13);
            languageLabel.Text = "Languages:";
            languageLabel.Location = new Point(540 - (int)((languageLabel.Width / 2) + 75), menuLogo.Top + menuLogo.Height + 50);
            languageLabel.Hide();
            this.Controls.Add(languageLabel);

            langMkd.Size = new Size(100, 75);
            langMkd.Location = new Point(languageLabel.Left, languageLabel.Top + languageLabel.Height + 5);
            langMkd.BackColor = Color.Red;
            langMkd.Click += new EventHandler(langMkd_Click);
            langMkd.Hide();
            this.Controls.Add(langMkd);

            langEng.Size = new Size(100, 75);
            langEng.Location = new Point(langMkd.Left + langMkd.Width + 5, langMkd.Top);
            langEng.BackColor = Color.Blue;
            langEng.Click += new EventHandler(langEng_Click);
            langEng.Hide();
            this.Controls.Add(langEng);


        }

        #endregion

        //click events for all buttons
        #region Button Events
        private void buttonLevels_Click(object sender, EventArgs e)
        {
            hideMainMenu();
            showLevels();
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            hideMainMenu();
            showSettings();
        }

        private void buttonQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonLevel1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        private void buttonLevel2_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        private void buttonLevel3_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        private void buttonLevel4_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        private void buttonLevel5_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        private void buttonLevel6_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        private void buttonLevel7_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        private void buttonLevel8_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        private void buttonLevel9_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        private void buttonLevel10_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void buttonEndlessMode_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        private void buttonTestLevel_Click(object sender, EventArgs e)
        {
            hideLevels();
            player.Show();
        }

        private void buttonUnlockAll_Click(object sender, EventArgs e)
        {
            UnlockLevels(14);
        }
        private void buttonBack_Click(object sender, EventArgs e)
        {
            hideLevels();
            hideSettings();
            showMainMenu();
        }

        private void buttonPause_Click(object sender, EventArgs e)
        {
            PauseMenu();
        }

        private void langMkd_Click(object sender, EventArgs e)
        {
            setLanguageMkd();
        }
        private void langEng_Click(object sender, EventArgs e)
        {
            setLanguageEng();
        }
        #endregion

        //Control over the main menu items (logo, buttons etc)
        #region Menu Visability & Accessibility Control

        private void showMainMenu()
        {
            for (int i = 0; i < 3; i++)
            {
                buttonList[i].Show();
            }
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
            for (int i = 3; i < 17; i++)
            {
                buttonList[i].Show();
            }
        }
        private void hideLevels()
        {
            for (int i = 3; i < 17; i++)
            {
                buttonList[i].Hide();
            }
        }

        private void UnlockLevels(int a)
        {
            for (int i = 3; i < a; i++)
            {
                buttonList[i].Enabled = true;
                buttonList[i].ForeColor = Color.White;
            }
        }

        private void showSettings()
        {
            languageLabel.Show();
            langMkd.Show();
            langEng.Show();
            buttonList[16].Show();
        }

        private void hideSettings()
        {
            languageLabel.Hide();
            langMkd.Hide();
            langEng.Hide();
            buttonList[16].Hide();
        }

        private void setLanguageMkd()
        {
            buttonList[0].Text = "Нивоа";
            buttonList[1].Text = "Поставки";
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
            buttonList[13].Text = "Бесконечно ниво";
            buttonList[14].Text = "Тест Ниво";
            buttonList[15].Text = "Отклучи се";
            buttonList[16].Text = "Назад";
            buttonList[17].Text = "Пауза";
            languageLabel.Text = "Јазик:";
        }

        private void setLanguageEng()
        {
            buttonList[0].Text = "Levels";
            buttonList[1].Text = "Settings";
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
            buttonList[13].Text = "Endless Mode";
            buttonList[14].Text = "Test Level";
            buttonList[15].Text = "Unlock All";
            buttonList[16].Text = "Back";
            buttonList[17].Text = "Pause";
            languageLabel.Text = "Language:";
        }


        private void PauseMenu()
        {

        }
        #endregion

        //game Items & generation
        #region Game Componenets

        private void generatePlayer()
        {
            player.Size = new Size(40, 60);
            player.BackColor = Color.Blue;
            setUpPlayer();
            this.Controls.Add(player);
            player.BringToFront();
            //player.Hide();

            playerTimer.Interval = 20;
            playerTimer.Tick += new EventHandler(playerTimer_Tick);
            playerTimer.Enabled = true;
        }

        private void setUpPlayer()
        {
            player.Location = new Point(520, 620);
            playerHP = 3;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                moveLeft = true;
            }
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                moveRight = true;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.D)
            {
                moveLeft = false;
            }
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.A)
            {
                moveRight = false;
            }
        }

        private void playerTimer_Tick(object sender, EventArgs e)
        {
            if (moveLeft && !moveRight && player.Left > 0)
            {
                player.Left -= 10;
            }
            if (moveRight && !moveLeft && player.Left < 1080)
            {
                player.Left += 10;
            }
            foreach (Balloon item in balloonList)
            {
                if (item.returnBalloon().Bounds.IntersectsWith(player.Bounds))
                {
                    playerHP--;
                    playerDamagedCD = 26;
                    player.BackColor = Color.Red;
                }
            }

            if (playerDamagedCD > 1)
            {
                playerDamagedCD--;
            }

            if (playerDamagedCD == 1)
            {
                playerDamagedCD = 0;
                player.BackColor = Color.Blue;
            }
        }

        #endregion
    }
}
