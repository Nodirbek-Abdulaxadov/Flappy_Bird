using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Media;

namespace Uchedigan_Qush
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            timer.Stop();
        }

        int tezlik = -3, gravity = 3, ochko = 0;
        bool b = true, aa = true, key = true;

        SoundPlayer splayer;
        private void timeEvent(object sender, EventArgs e)
        {
            if (ochko == 5) tezlik = -4;
            if (ochko == 10) tezlik = -5;
            if (ochko == 20) tezlik = -6;
            if (ochko == 30) tezlik = -7;
            if (ochko == 50) tezlik = -10;

            if (((qush.Left > tepapip1.Left + 50) || (qush.Left > tepapip2.Left + 50)) && (b))
            {
                ochko++;
                tablo.Text = "Score: " + ochko.ToString();
                b = false;
                splayer = new SoundPlayer("PlayerCoin.wav");
                splayer.Play();
            }

            Random random = new Random();
            qush.Top += gravity;
            tepapip1.Left += tezlik;
            pastpip1.Left += tezlik;
            tepapip2.Left += tezlik;
            pastpip2.Left += tezlik;

            if (tepapip1.Left < 162)
            {
                tepapip1.Left = tepapip2.Left + 360;
                pastpip1.Left = pastpip2.Left + 360;

                int a = random.Next(-250, -50);
                tepapip1.Top = a;
                pastpip1.Top = a + 500;
                b = true;
            }
            if (tepapip2.Left < 162)
            {
                tepapip2.Left = tepapip1.Left + 360;
                pastpip2.Left = pastpip1.Left + 360;
                int a = random.Next(-250, -50);
                tepapip2.Top = a;
                pastpip2.Top = a + 500;
                b = true;
            }

            if (qush.Bounds.IntersectsWith(pastpip1.Bounds) ||
                qush.Bounds.IntersectsWith(pastpip2.Bounds) ||
                qush.Bounds.IntersectsWith(tepapip1.Bounds) ||
                qush.Bounds.IntersectsWith(tepapip2.Bounds) ||
                qush.Top < 0 || qush.Top > 442)
            {
                Tugadi();
                gameover.Text = "GAME OVER!";
                start_button.Text = "RESTART";
                checkpause = false;
                key = false;
                splayer = new SoundPlayer("PlayerDie.wav");
                splayer.Play();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        
        private void start_button_Click(object sender, EventArgs e)
        {
            if (aa)
            {
                timer.Start();
                aa = false;
                key = true;
            }
            else
            {
                restart();
                start_button.Text = "START";
            }
        }

        private void exit_button_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        bool checkpause = true;
        private void pause_button_Click(object sender, EventArgs e)
        {
            if ((checkpause)&&(key))
            {
                timer.Stop();
                checkpause = false;
                pause_button.Text = "PLAY";
            }
            else if(key)
            {
                timer.Start();
                checkpause = true;
                pause_button.Text = "PAUSE";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.instagram.com/nodirbek_09052000/");
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 'A')
            {
                ochko += 100;
            }
        }

        private void pastga(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                if (ochko < 21) gravity = 3;
                else gravity = 4;
            }
        }

        private void tepaga(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (ochko < 21) gravity = -3;
                else gravity = -4;
            }
        }

        private void Tugadi()
        {
            timer.Stop();
        }
        public void restart()
        {
            qush.Top = 167;
            tepapip1.Left = 730;
            pastpip1.Left = 730;
            tepapip2.Left = tepapip1.Left + 360;
            pastpip2.Left = pastpip1.Left + 360;
            ochko = 0;
            tablo.Text = "Score: " + ochko.ToString();
            gravity = 3;
            tezlik = -3;
            gameover.Text = "";
            aa = true;
        }
    }
}
