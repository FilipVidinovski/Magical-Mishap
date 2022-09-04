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

namespace Magical_Mishap
{
    public partial class Form1 : Form
    {
        #region Menu Items
        PictureBox magicalMishapLogo = new PictureBox();
        List<PictureBox> buttonList = new List<PictureBox>();
        /*
         0-Levels
         1-Quit
         2-Level1
         3-Level2
         4-Level3
         5-Level4
         6-Level5
         7-Level6
         8-Level7
         9-Level8
        10-Level9
        11-Level10
        12-Endless Mode
        13-Test Level
        14-Unlock all level
        15-Back
        16-Pause
        17-Restart Level
        18-Next Level
        19-Back to levels
         */
        PictureBox PictureBoxEndScreen = new PictureBox();
        PictureBox lives = new PictureBox();

        //WindowsMediaPlayer mediaPlayer = new WindowsMediaPlayer();
        #endregion

        #region Game Items
        bool gameIsInProgress = false, gameIsPaused = false;
        int levelProgress=1, currentLevel = 0;

        PictureBox player = new PictureBox();
        Timer playerTimer = new Timer();
        byte playerHP, damageTakenCD;
        bool playerMovingLeft, playerMovingRight;

        PictureBox bolt = new PictureBox();
        Timer boltTimer = new Timer();
        bool boltShot;

        List<Balloon> balloonList = new List<Balloon>();
        int numberOfBalloons = 0;

        Timer endlessModeTimer = new Timer();
        int numberOfBalloonsPopped, balloonCD;
        Random random = new Random();
        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
            this.BackColor = Color.DarkGray;
            //this.BackgroundImage = Properties.Resources.MagicalMishapBackground;

            generateMenu();
            generatePlayer();
            generateBolt();
            generateEndlessTimer();
        }

        //Defining & styling menu Buttons/PictureBoxes
        #region Menu + Buttons generation
        private void generateMenu()
        {
            magicalMishapLogo.Size = new Size(300, 200);
            magicalMishapLogo.Location = new Point(540 - (magicalMishapLogo.Width / 2), 80);
            magicalMishapLogo.BackColor = Color.White;
            magicalMishapLogo.Image = Properties.Resources.MagicalMishapLogo;
            this.Controls.Add(magicalMishapLogo);

            PictureBoxEndScreen.Size = new Size(300, 30);
            PictureBoxEndScreen.Location = new Point(magicalMishapLogo.Left, magicalMishapLogo.Height + magicalMishapLogo.Top - PictureBoxEndScreen.Height);
            PictureBoxEndScreen.BackColor = Color.White;
            PictureBoxEndScreen.Image = Properties.Resources.PausedLevel;
            PictureBoxEndScreen.Hide();
            this.Controls.Add(PictureBoxEndScreen);

            PictureBox buttonLevels = new PictureBox();
            styleButton(buttonLevels);
            buttonLevels.Image = Properties.Resources.ButtonLevels;
            buttonLevels.Location = new Point(540 - (buttonLevels.Width / 2), magicalMishapLogo.Top + magicalMishapLogo.Height + 50);
            buttonLevels.Click += new EventHandler(buttonLevels_Click);
            implementPictureBox(buttonLevels);

            PictureBox buttonQuit = new PictureBox();
            styleButton(buttonQuit);
            buttonQuit.Image = Properties.Resources.ButtonQuit;
            buttonQuit.Location = new Point(540 - (buttonQuit.Width / 2), buttonLevels.Top + buttonLevels.Height + 50);
            buttonQuit.Click += new EventHandler(buttonQuit_Click);
            implementPictureBox(buttonQuit);

            PictureBox buttonLevel1 = new PictureBox();
            styleButton(buttonLevel1);
            buttonLevel1.Image = Properties.Resources.ButtonLevel1;
            buttonLevel1.Location = new Point(180 - (buttonLevel1.Width / 2), buttonLevels.Top);
            buttonLevel1.Click += new EventHandler(buttonLevel1_Click);
            implementPictureBox(buttonLevel1);

            PictureBox buttonLevel2 = new PictureBox();
            styleButton(buttonLevel2);
            buttonLevel2.Image = Properties.Resources.ButtonLevel2Locked;
            buttonLevel2.Location = new Point(360 - (buttonLevel2.Width / 2), buttonLevels.Top);
            buttonLevel2.Click += new EventHandler(buttonLevel2_Click);
            implementPictureBox(buttonLevel2);

            PictureBox buttonLevel3 = new PictureBox();
            styleButton(buttonLevel3);
            buttonLevel3.Image = Properties.Resources.buttonLevel3Locked;
            buttonLevel3.Location = new Point(540 - (buttonLevel3.Width / 2), buttonLevels.Top);
            buttonLevel3.Click += new EventHandler(buttonLevel3_Click);
            implementPictureBox(buttonLevel3);

            PictureBox buttonLevel4 = new PictureBox();
            styleButton(buttonLevel4);
            buttonLevel4.Image = Properties.Resources.ButtonLevel4Locked;
            buttonLevel4.Location = new Point(720 - (buttonLevel4.Width / 2), buttonLevels.Top);
            buttonLevel4.Click += new EventHandler(buttonLevel4_Click);
            implementPictureBox(buttonLevel4);

            PictureBox buttonLevel5 = new PictureBox();
            styleButton(buttonLevel5);
            buttonLevel5.Image = Properties.Resources.ButtonLevel5Locked;
            buttonLevel5.Location = new Point(900 - (buttonLevel5.Width / 2), buttonLevels.Top);
            buttonLevel5.Click += new EventHandler(buttonLevel5_Click);
            implementPictureBox(buttonLevel5);

            PictureBox buttonLevel6 = new PictureBox();
            styleButton(buttonLevel6);
            buttonLevel6.Image = Properties.Resources.ButtonLevel6Locked;
            buttonLevel6.Location = new Point(180 - (buttonLevel6.Width / 2), buttonQuit.Top);
            buttonLevel6.Click += new EventHandler(buttonLevel6_Click);
            implementPictureBox(buttonLevel6);

            PictureBox buttonLevel7 = new PictureBox();
            styleButton(buttonLevel7);
            buttonLevel7.Image = Properties.Resources.ButtonLevel7Locked;
            buttonLevel7.Location = new Point(360 - (buttonLevel7.Width / 2), buttonQuit.Top);
            buttonLevel7.Click += new EventHandler(buttonLevel7_Click);
            implementPictureBox(buttonLevel7);

            PictureBox buttonLevel8 = new PictureBox();
            styleButton(buttonLevel8);
            buttonLevel8.Image = Properties.Resources.ButtonLevel8Locked;
            buttonLevel8.Location = new Point(540 - (buttonLevel8.Width / 2), buttonQuit.Top);
            buttonLevel8.Click += new EventHandler(buttonLevel8_Click);
            implementPictureBox(buttonLevel8);

            PictureBox buttonLevel9 = new PictureBox();
            styleButton(buttonLevel9);
            buttonLevel9.Image = Properties.Resources.ButtonLevel9Locked;
            buttonLevel9.Location = new Point(720 - (buttonLevel9.Width / 2), buttonQuit.Top);
            buttonLevel9.Click += new EventHandler(buttonLevel9_Click);
            implementPictureBox(buttonLevel9);

            PictureBox buttonLevel10 = new PictureBox();
            styleButton(buttonLevel10);
            buttonLevel10.Image = Properties.Resources.ButtonLevel10Locked;
            buttonLevel10.Location = new Point(900 - (buttonLevel10.Width / 2), buttonQuit.Top);
            buttonLevel10.Click += new EventHandler(buttonLevel10_Click);
            implementPictureBox(buttonLevel10);

            PictureBox buttonLevelEndlessMode = new PictureBox();
            styleButton(buttonLevelEndlessMode);
            buttonLevelEndlessMode.Image = Properties.Resources.ButtonLevelEndlessLocked;
            buttonLevelEndlessMode.Location = new Point(180 - (buttonLevelEndlessMode.Width / 2), buttonQuit.Top + buttonQuit.Height + 50);
            buttonLevelEndlessMode.Click += new EventHandler(buttonLevelEndlessMode_Click);
            implementPictureBox(buttonLevelEndlessMode);

            PictureBox buttonTestLevel = new PictureBox();
            styleButton(buttonTestLevel);
            buttonTestLevel.Image = Properties.Resources.ButtonLevelTest;
            buttonTestLevel.Location = new Point(360 - (buttonTestLevel.Width / 2), buttonLevelEndlessMode.Top);
            buttonTestLevel.Click += new EventHandler(buttonTestLevel_Click);
            implementPictureBox(buttonTestLevel);

            PictureBox buttonLevelUnlockAll = new PictureBox();
            styleButton(buttonLevelUnlockAll);
            buttonLevelUnlockAll.Image = Properties.Resources.ButtonUnlockAll;
            buttonLevelUnlockAll.Location = new Point(720 - (buttonLevelUnlockAll.Width / 2), buttonLevelEndlessMode.Top);
            buttonLevelUnlockAll.Click += new EventHandler(buttonLevelUnlockAll_Click);
            implementPictureBox(buttonLevelUnlockAll);

            PictureBox buttonBack = new PictureBox();
            styleButton(buttonBack);
            buttonBack.Image = Properties.Resources.ButtonBack;
            buttonBack.Location = new Point(900 - (buttonBack.Width / 2), buttonLevelUnlockAll.Top);
            buttonBack.Click += new EventHandler(buttonBack_Click);
            implementPictureBox(buttonBack);

            PictureBox buttonPause = new PictureBox();
            styleButton(buttonPause);
            buttonPause.Location = new Point(1050- buttonPause.Width, 30);
            buttonPause.Image = Properties.Resources.ButtonPause;
            buttonPause.Click += new EventHandler(buttonPause_Click);
            implementPictureBox(buttonPause);
            
            PictureBox buttonRestartLevel = new PictureBox();
            styleButton(buttonRestartLevel);
            buttonRestartLevel.Location = new Point(480 - buttonRestartLevel.Width / 2, buttonQuit.Top);
            buttonRestartLevel.Image = Properties.Resources.ButtonRestart;
            buttonRestartLevel.Click += new EventHandler(buttonRestartLevel_Click);
            implementPictureBox(buttonRestartLevel);

            PictureBox buttonNextLevel = new PictureBox();
            styleButton(buttonNextLevel);
            buttonNextLevel.Location = new Point(480 - buttonNextLevel.Width / 2, buttonQuit.Top);
            buttonNextLevel.Image = Properties.Resources.ButtonNextLevel;
            buttonNextLevel.Click += new EventHandler(buttonNextLevel_Click);
            implementPictureBox(buttonNextLevel);

            PictureBox buttonBackToLevels = new PictureBox();
            styleButton(buttonBackToLevels);
            buttonBackToLevels.Image = Properties.Resources.ButtonLevels;
            buttonBackToLevels.Location = new Point(600 - buttonBackToLevels.Width / 2, buttonQuit.Top);
            buttonBackToLevels.Click += new EventHandler(buttonBackToLevels_Click);
            implementPictureBox(buttonBackToLevels);

            for (int i = 2; i < buttonList.Count; i++)
            {
                buttonList[i].Hide();
            }

        }

        private void styleButton(PictureBox p)
        {
            p.Size = new Size(100, 30);
            p.BackColor = Color.White;
        }
        private void implementPictureBox(PictureBox p)
        {
            this.Controls.Add(p);
            buttonList.Add(p);
        }

        #endregion

        //Button / PictureBox Click Events
        #region Button/PictureBox clicks

        private void buttonLevels_Click(object sender, EventArgs e)
        {
            menuVisability(false);
            levelsVisability(true);
        }
        private void buttonQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void buttonLevel1_Click(object sender, EventArgs e)
        {
            level1();
        }
        private void buttonLevel2_Click(object sender, EventArgs e)
        {
            if (levelProgress >= 2)
            {
                level2();
            }
        }
        private void buttonLevel3_Click(object sender, EventArgs e)
        {
            if (levelProgress >= 3)
            {
                level3();
            }
        }
        private void buttonLevel4_Click(object sender, EventArgs e)
        {
            if (levelProgress >= 4)
            {
                level4();
            }
        }
        private void buttonLevel5_Click(object sender, EventArgs e)
        {
            if (levelProgress >= 5)
            {
                level5();
            }
        }
        private void buttonLevel6_Click(object sender, EventArgs e)
        {
            if (levelProgress >= 6)
            {
                level6();
            }
        }
        private void buttonLevel7_Click(object sender, EventArgs e)
        {
            if (levelProgress >= 7)
            {
                level7();
            }
        }
        private void buttonLevel8_Click(object sender, EventArgs e)
        {
            if (levelProgress >= 8)
            {
                level8();
            }
        }
        private void buttonLevel9_Click(object sender, EventArgs e)
        {
            if (levelProgress >= 9)
            {
                level9();
            }
        }
        private void buttonLevel10_Click(object sender, EventArgs e)
        {
            if (levelProgress >= 10)
            {
                level10();
            }
        }
        private void buttonLevelEndlessMode_Click(object sender, EventArgs e)
        {
            if (levelProgress >= 11)
            {
                endlessLevel();
            }
        }
        private void buttonTestLevel_Click(object sender, EventArgs e)
        {
            Level_testLevel();
        }
        private void buttonLevelUnlockAll_Click(object sender, EventArgs e)
        {
            levelProgress = 12;
            updateLevels(levelProgress);
        }
        private void updateLevels(int progress)
        {
            if (progress >= 2)
            {
                buttonList[3].Image = Properties.Resources.ButtonLevel2;
            }
            if (progress >= 3)
            {
                buttonList[4].Image = Properties.Resources.buttonLevel3;
            }
            if (progress >= 4)
            {
                buttonList[5].Image = Properties.Resources.ButtonLevel4;
            }
            if (progress >= 5)
            {
                buttonList[6].Image = Properties.Resources.ButtonLevel5;
            }
            if (progress >= 6)
            {
                buttonList[7].Image = Properties.Resources.ButtonLevel6;
            }
            if (progress >= 7)
            {
                buttonList[8].Image = Properties.Resources.ButtonLevel7;
            }
            if (progress >= 8)
            {
                buttonList[9].Image = Properties.Resources.ButtonLevel8;
            }
            if (progress >= 9)
            {
                buttonList[10].Image = Properties.Resources.ButtonLevel9;
            }
            if (progress >= 10)
            {
                buttonList[11].Image = Properties.Resources.ButtonLevel10;
            }
            if (progress >= 11)
            {
                buttonList[12].Image = Properties.Resources.ButtonLevelEndless;
            }

        }
        private void buttonBack_Click(object sender, EventArgs e)
        {
            levelsVisability(false);
            menuVisability(true);
        }
        private void buttonPause_Click(object sender, EventArgs e)
        {
            gamePauseScreen(true);
        }
        private void buttonNextLevel_Click(object sender, EventArgs e)
        {
            gameEndLoseScreen(false);
            gameEndWinScreen(false);
            forceEndLevel();
            switch (currentLevel+1)
            {
                case 1:
                    level1();
                    break;
                case 2:
                    level2();
                    break;
                case 3:
                    level3();
                    break;
                case 4:
                    level4();
                    break;
                case 5:
                    level5();
                    break;
                case 6:
                    level6();
                    break;
                case 7:
                    level7();
                    break;
                case 8:
                    level8();
                    break;
                case 9:
                    level9();
                    break;
                case 10:
                    level10();
                    break;
                default:
                    backToLevels();
                    break;
            }
        }
        private void buttonRestartLevel_Click(object sender, EventArgs e)
        {
            gameEndLoseScreen(false);
            gameEndWinScreen(false);
            forceEndLevel();
            switch (currentLevel)
            {
                case 1:
                    level1();
                    break;
                case 2:
                    level2();
                    break;
                case 3:
                    level3();
                    break;
                case 4:
                    level4();
                    break;
                case 5:
                    level5();
                    break;
                case 6:
                    level6();
                    break;
                case 7:
                    level7();
                    break;
                case 8:
                    level8();
                    break;
                case 9:
                    level9();
                    break;
                case 10:
                    level10();
                    break;
                default:
                    backToLevels();
                    break;
            }
        }
        private void buttonBackToLevels_Click(object sender, EventArgs e)
        {
            backToLevels();
        }
        private void backToLevels()
        {
            gameEndLoseScreen(false);
            gameEndWinScreen(false);
            forceEndLevel();
            magicalMishapLogo.Show();
            levelsVisability(true);
        }
        private void menuVisability(bool visible)
        {
            for (int i = 0; i < 2; i++)
            {
                if (visible)
                {
                    buttonList[i].Show();
                }
                else
                {
                    buttonList[i].Hide();
                }
            }
        }
        private void levelsVisability(bool visible)
        {
            for (int i = 2; i < 16; i++)
            {
                if (visible)
                {
                    buttonList[i].Show();
                }
                else
                {
                    buttonList[i].Hide();
                }
            }
            buttonList[16].Hide();
        }
        private void gameEndWinScreen(bool visible)
        {
            if (visible==true)
            {
                buttonList[18].Show();
                buttonList[19].Show();
                PictureBoxEndScreen.Image = Properties.Resources.EndLevelWin;
                PictureBoxEndScreen.Show();
                if (levelProgress<12)
                {
                    levelProgress++;
                    updateLevels(levelProgress);
                }
            }
            else
            {
                buttonList[18].Hide();
                buttonList[19].Hide();
                PictureBoxEndScreen.Hide();
            }
        }
        private void gameEndLoseScreen(bool visible)
        {
            if (visible)
            {
                buttonList[17].Show();
                buttonList[19].Show();
                PictureBoxEndScreen.Image = Properties.Resources.EndLevelLoss;
                PictureBoxEndScreen.Show();
            }
            else
            {
                buttonList[17].Hide();
                buttonList[19].Hide();
                PictureBoxEndScreen.Hide();
            }
        }
        private void gamePauseScreen(bool visible)
        {
            if (visible)
            {
                buttonList[17].Show();
                buttonList[19].Show();
                PictureBoxEndScreen.Image = Properties.Resources.PausedLevel;
                PictureBoxEndScreen.Show();
                playerTimer.Stop();
                boltTimer.Stop();
                if (currentLevel==11)
                {
                    endlessModeTimer.Stop();
                }
                foreach (Balloon item in balloonList.ToList())
                {
                    item.pauseTimer();
                }
                gameIsPaused = true;

            }
            if (visible == false)
            {
                buttonList[17].Hide();
                buttonList[19].Hide();
                PictureBoxEndScreen.Hide();
                playerTimer.Start();
                boltTimer.Start();
                if (currentLevel == 11)
                {
                    endlessModeTimer.Start();
                }
                foreach (Balloon item in balloonList.ToList())
                {
                    item.startTimer();
                }
                gameIsPaused = false;
            }
        }

        #endregion

        //Player + playerTimer + logic behind player
        #region Player
        private void generatePlayer()
        {
            player.Size = new Size(40, 60);
            player.Location = new Point(540 - player.Width / 2, 650-player.Height);
            player.BackColor = Color.Transparent;
            player.Image = Properties.Resources.PlayerMovementRight;
            playerHP = 5;
            this.Controls.Add(player);

            lives.Size = new Size(100, 30);
            lives.Location = new Point(10, 10);
            lives.Image = Properties.Resources.ButtonLives5;
            this.Controls.Add(lives);

            playerTimer.Interval = 20;
            playerTimer.Tick += new EventHandler(playerTimer_Tick);

            playerVisibility(false);
        }

        private void playerTimer_Tick(object sender, EventArgs e)
        {
            if (playerMovingLeft && !playerMovingRight && player.Left > 0)
            {
                player.Image = Properties.Resources.PlayerMovementRight;
                player.Left -= 10;
            }
            if (playerMovingRight && !playerMovingLeft && (player.Left < 1080 - player.Width))
            {
                player.Image = Properties.Resources.PlayerMovementLeft;
                player.Left += 10;
            }
            foreach (Balloon item in balloonList)
            {
                if (item.returnBalloon().Bounds.IntersectsWith(player.Bounds) && damageTakenCD==0)
                {
                    playerHP--;
                    damageTakenCD = 50;
                    switch (playerHP)
                    {
                        case 1:
                            lives.Image = Properties.Resources.ButtonLives1;
                            break;
                        case 2:
                            lives.Image = Properties.Resources.ButtonLives2;
                            break;
                        case 3:
                            lives.Image = Properties.Resources.ButtonLives3;
                            break;
                        case 4:
                            lives.Image = Properties.Resources.ButtonLives4;
                            break;
                        default:
                            lives.Image = Properties.Resources.ButtonLives5;
                            break;
                    }
                }
            }
            if (damageTakenCD>0)
            {
                damageTakenCD--;
            }
            if (playerHP==0)
            {
                forceEndLevel();
                gameEndLoseScreen(true);
            }
            if (numberOfBalloons==0 && currentLevel!=11 && currentLevel!=12)
            {
                forceEndLevel();
                gameEndWinScreen(true);
            }
        }

        private void playerVisibility(bool visible)
        {
            if (visible)
            {
                player.Show();
                lives.Show();
                playerTimer.Start();
            }
            else
            {
                player.Hide();
                lives.Hide();
                playerTimer.Stop();
            }
        }

        #endregion

        //Bolt + Bolt timer
        #region Bolt
        private void generateBolt()
        {
            bolt.Size = new Size(20, 60);
            hideBolt();
            bolt.BackColor = Color.Transparent;
            bolt.Image = Properties.Resources.Bolt;
            this.Controls.Add(bolt);

            boltTimer.Interval = 20;
            boltTimer.Tick += new EventHandler(boltTimer_Tick);

            boltVisibility(false);
            
        }

        private void boltTimer_Tick(object sender, EventArgs e)
        {
            if (boltShot)
            {
                boltShot = false;
                bolt.Location = new Point((player.Left + player.Width / 2 - bolt.Width / 2), player.Top);
            }
            if (bolt.Top > 0)
            {
                bolt.Height += 7;
                bolt.Top -= 7;
            }
            else if (bolt.Top <= 0)
            {
                hideBolt();
            }

            foreach (Balloon item in balloonList.ToList())
            {
                if (bolt.Bounds.IntersectsWith(item.returnBalloon().Bounds)&& item.returnSize()!=5)
                {
                    hideBolt();
                    generateBalloon(item.returnSize()-1, item.returnBalloon().Left, item.returnBalloon().Top, -1);
                    generateBalloon(item.returnSize()-1, item.returnBalloon().Left, item.returnBalloon().Top, 1);
                    item.destroyBalloon();
                    balloonList.Remove(item);
                    numberOfBalloons--;
                }
                else if (bolt.Bounds.IntersectsWith(item.returnBalloon().Bounds) && item.returnSize() == 5)
                {
                    hideBolt();
                    generateBalloon(item.returnSize() - 3, item.returnBalloon().Left - 100, item.returnBalloon().Top, -1);
                    generateBalloon(item.returnSize() - 2, item.returnBalloon().Left - 50, item.returnBalloon().Top, -1);
                    generateBalloon(item.returnSize() - 1, item.returnBalloon().Left, item.returnBalloon().Top, 0);
                    generateBalloon(item.returnSize() - 2, item.returnBalloon().Left + 50, item.returnBalloon().Top, 1);
                    generateBalloon(item.returnSize() - 3, item.returnBalloon().Left + 100, item.returnBalloon().Top, 1);
                    item.destroyBalloon();
                    balloonList.Remove(item);
                    numberOfBalloons--;
                }
            }
        }

        private void hideBolt()
        {
            bolt.Height = 61;
            bolt.Location = new Point(0, -100);
        }

        private void boltVisibility(bool visible)
        {
            if (visible)
            {
                bolt.Show();
                boltTimer.Start();
            }
            else
            {
                bolt.Hide();
                boltTimer.Stop();
            }
        }
        #endregion

        //Balloon Generation
        #region Balloon

        private void generateBalloon(int balloonSize, int positionLeft, int positionTop, int movement)
        {
            if (balloonSize >= 2)
            {
                Balloon balloon = new Balloon();
                balloon.size = balloonSize;
                balloon.balloonLeft = positionLeft+((balloonSize*25)/4);
                balloon.balloonTop = positionTop+((balloonSize*25)/4);
                balloon.movement = movement;

                numberOfBalloons++;
                balloon.generateBalloon(this);
                balloonList.Add(balloon);
            }
        }

        #endregion

        //KeyDown + KeyUp events
        #region KeyDown / KeyUp events

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                playerMovingLeft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                playerMovingRight = true;
            }
            if (e.KeyCode == Keys.Up && bolt.Top < 0)
            {
                boltShot = true;
            }
            if (gameIsInProgress == true && gameIsPaused==false && e.KeyCode == Keys.Escape)
            {
                gamePauseScreen(true);

            }
            if (gameIsInProgress == true && gameIsPaused==true && e.KeyCode == Keys.Escape)
            {
                gamePauseScreen(false);

            }
            if (e.KeyCode == Keys.Space && currentLevel == 12)
            {
                generateBalloon(4, 540, 300, 0);
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                playerMovingLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                playerMovingRight = false;
            }
        }

        #endregion

        //Levels
        #region Levels

        private void startLevel(int playerLocation)
        {
            setUpPlayerBolt(playerLocation);
            levelsVisability(false);
            buttonList[16].Show();
            gameIsInProgress = true;
            gameIsPaused = false;
        }

        private void setUpPlayerBolt(int playerLeft)
        {
            magicalMishapLogo.Hide();
            playerHP = 5; 
            damageTakenCD = 0;
            playerVisibility(true);
            boltVisibility(true);
            player.Location = new Point(playerLeft, 620);
        }

        private void forceEndLevel()
        {
            playerVisibility(false);
            boltVisibility(false);
            foreach (Balloon item in balloonList.ToList())
            {
                item.destroyBalloon();
                balloonList.Remove(item);
            }
            endlessModeTimer.Stop();
            numberOfBalloons = 0;
            playerHP = 5;
            lives.Image = Properties.Resources.ButtonLives5;
        }

        private void level1()
        {
            currentLevel = 1;
            startLevel(200);
            generateBalloon(3, 540, 300, 1);
        }
        private void level2()
        {
            currentLevel = 2;
            startLevel(540-player.Width/2);
            generateBalloon(3, 360, 300, -1);
            generateBalloon(3, 720, 300, 1);
        }
        private void level3()
        {
            currentLevel = 3;
            startLevel(200);
            generateBalloon(3, 540, 200, 0);
            generateBalloon(2, 360, 300, 1);
            generateBalloon(2, 720, 300, -1);
        }
        private void level4()
        {
            currentLevel = 4;
            startLevel(200);
            generateBalloon(3, 360, 200, 0);
            generateBalloon(3, 720, 200, 0);
            generateBalloon(2, 500, 400, 1);
            generateBalloon(2, 580, 400, -1);
        }
        private void level5()
        {
            currentLevel = 5;
            startLevel(200);
            generateBalloon(2, 300, 400, 1);
            generateBalloon(2, 400, 400, 1);
            generateBalloon(2, 500, 400, 1);
            generateBalloon(2, 600, 400, 1);
            generateBalloon(2, 700, 400, 1);
            generateBalloon(2, 800, 400, 1);
            generateBalloon(2, 900, 400, 1);
        }
        private void level6()
        {
            currentLevel = 6;
            startLevel(200);
            generateBalloon(4, 540, 200, 0);

        }
        private void level7()
        {
            currentLevel = 7;
            startLevel(200);
            generateBalloon(4, 360, 200, 0);
            generateBalloon(4, 720, 200, 0);
            generateBalloon(3, 500, 400, 1);
            generateBalloon(3, 580, 400, -1);
        }
        private void level8()
        {
            currentLevel = 8;
            startLevel(100);
            generateBalloon(3, 180, 400, 0);
            generateBalloon(3, 360, 400, 0);
            generateBalloon(3, 540, 400, 0);
            generateBalloon(3, 720, 400, 0);
            generateBalloon(3, 900, 400, 0);
        }
        private void level9()
        {
            currentLevel = 9;
            startLevel(200);
            generateBalloon(5, 490, 100, 0);
        }
        private void level10()
        {
            currentLevel = 10;
            startLevel(200);
            generateBalloon(4, 360, 400, 1);
            generateBalloon(4, 720, 400, -1);
            generateBalloon(5, 490, 100, 0);
        }

        private void endlessLevel()
        {
            currentLevel = 11;
            startLevel(200);
            startEndlessMode();
        }
        private void startEndlessMode()
        {
            balloonCD = 10;
            numberOfBalloonsPopped = 0;

            endlessModeTimer.Start();
        }
        private void generateEndlessTimer()
        {
            endlessModeTimer.Interval = 5000;
            endlessModeTimer.Tick += new EventHandler(endlessModeTimer_Tick);
        }
        private void endlessModeTimer_Tick(object sender, EventArgs e)
        {
            if (balloonCD>=0)
            {
                int temp = random.Next(1, 10);
                if (player.Left > 540)
                {
                    switch (temp)
                    {
                        case 1:
                            generateBalloon(2, 360, 400, -1);
                            generateBalloon(2, 180, 400, -1);
                            balloonCD = 5;
                            break;
                        case 2:
                            generateBalloon(3, 300, 300, 0);
                            balloonCD = 9;
                            break;
                        case 3:
                            generateBalloon(4, 100, 100, 0);
                            balloonCD = 15;
                            break;
                        case 4:
                            generateBalloon(5, 460, 50, 0);
                            balloonCD = 60;
                            break;
                        case 5:
                            generateBalloon(3, 250, 300, 1);
                            balloonCD = 9;
                            break;        
                        case 6:
                            generateBalloon(4, 150, 400, 1);
                            balloonCD = 15;
                            break;
                        case 7:
                            generateBalloon(4, 200, 100, 0);
                            generateBalloon(4, 880, 100, 0);
                            balloonCD = 30;
                            break;
                        case 8:
                            generateBalloon(3, 180, 400, 0);
                            generateBalloon(3, 360, 400, 0);
                            generateBalloon(3, 540, 400, 0);
                            generateBalloon(3, 720, 400, 0);
                            generateBalloon(3, 900, 400, 0);
                            balloonCD = 60;
                            break;
                        case 9:
                            generateBalloon(5, 300, 50, 0);
                            generateBalloon(5, 780, 50, 0);
                            balloonCD = 90;
                            break;
                        default:
                            balloonCD += 1;
                            break;
                    }
                }
                else
                {
                    switch (temp)
                    {
                        case 1:
                            generateBalloon(2, 1080 - 360, 400, -1);
                            generateBalloon(2, 1080 - 180, 400, -1);
                            balloonCD = 5;
                            break;
                        case 2:
                            generateBalloon(3, 1080 - 300, 300, 0);
                            balloonCD = 9;
                            break;
                        case 3:
                            generateBalloon(4, 1080 - 100, 100, 0);
                            balloonCD = 15;
                            break;
                        case 4:
                            generateBalloon(5, 1080 - 460, 50, 0);
                            balloonCD = 60;
                            break;
                        case 5:
                            generateBalloon(3, 1080 - 250, 300, 1);
                            balloonCD = 9;
                            break;
                        case 6:
                            generateBalloon(4, 1080 - 150, 400, 1);
                            balloonCD = 15;
                            break;
                        case 7:
                            generateBalloon(4, 200, 100, 0);
                            generateBalloon(4, 880, 100, 0);
                            balloonCD = 30;
                            break;
                        case 8:
                            generateBalloon(3, 180, 400, 0);
                            generateBalloon(3, 360, 400, 0);
                            generateBalloon(3, 540, 400, 0);
                            generateBalloon(3, 720, 400, 0);
                            generateBalloon(3, 900, 400, 0);
                            balloonCD = 60;
                            break;
                        case 9:
                            generateBalloon(5, 300, 50, 0);
                            generateBalloon(5, 780, 50, 0);
                            balloonCD = 90;
                            break;
                        default:
                            balloonCD += 1;
                            break;
                    }
                }
            }
            balloonCD--;
        }

        private void Level_testLevel()
        {
            startLevel(540 - player.Width / 2);
            currentLevel = 12;
        }
        #endregion

    }
}
