using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlyingBirdGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int gravity = 10;
        int speed = 25;
        int score = 0;

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                gravity = 20;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                gravity = -20;
            else if (e.KeyCode == Keys.Enter)
                timer1.Start();
        }

        Random rnd = new Random();

        private void timer1_Tick(object sender, EventArgs e)
        {
            bird.Top += gravity;
            pipeDown.Left -= speed;
            pipeTop.Left -= speed;
            weather.Left -= speed;
            lblScore.Text = $"Score: {score}";
            if(pipeDown.Left<-170)
            {
                pipeDown.Left = rnd.Next(100, 600);
                score++;
            }
            if(pipeTop.Left<-170)
            {
                int top= rnd.Next(100, 600);
                pipeTop.Left = top;
                weather.Left = rnd.Next(top + 50, 800);
                score++;
            }
            if(bird.Bounds.IntersectsWith(pipeDown.Bounds)||bird.Bounds.IntersectsWith(pipeTop.Bounds)||bird.Bounds.IntersectsWith(ground.Bounds))
            {
                timer1.Stop();
                lblScore.Text += "Game over!";
            }
            if (score > 10)
                speed += 5;
        }
    }
}
