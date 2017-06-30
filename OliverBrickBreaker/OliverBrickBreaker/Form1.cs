using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OliverBrickBreaker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Bitmap map;
        Graphics gfx;
        Ball ball1 = new Ball(3, 425, 250, 20, 6, 6, Brushes.Cyan);
        Paddle paddle1 = new Paddle(400, 420, 120, 25, 15, Brushes.Red);
        public int score = 0;
        List<Brick> bricks = new List<Brick>();

        private void Form1_Load(object sender, EventArgs e)
        {
            map = new Bitmap(drawBox.Width, drawBox.Height);
            gfx = Graphics.FromImage(map);
            
            //gfx.Clear(Color.White);
            //drawBox.Image = map;
            timer1.Start();
            
            for(int i = 0; i < 16; i++)
            {
                bricks.Add(new Brick(i*50+20, 100, 40, 20, Brushes.Purple));
                bricks.Add(new Brick(i * 50 + 20, 150, 40, 20, Brushes.Yellow));
                bricks.Add(new Brick(i * 50 + 20, 200, 40, 20, Brushes.Green));
            }
          

        }


        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
                       
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(paddle1.x > 0 && e.KeyCode == Keys.Left)
            {
                paddle1.x -= paddle1.speed;
            }

            if(paddle1.x < ClientSize.Width && e.KeyCode == Keys.Right)
            {
                paddle1.x += paddle1.speed;
            }
        }
        
        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            gfx.Clear(BackColor);
            drawBox.Image = map;
            paddle1.Draw(gfx);
            ball1.Update(ClientSize);
            ball1.Draw(gfx);
            
            for(int drawBrick = 0; drawBrick < bricks.Count; drawBrick++)
            {
                bricks[drawBrick].draw(gfx);
            }


            if(paddle1.hitbox.IntersectsWith(ball1.hitbox))
            {
                ball1.speedY *= -1;
            }

            for (int hit = 0; hit < bricks.Count; hit++)
            {
                if (bricks[hit].hitbox.IntersectsWith(ball1.hitbox))
                {
                    ball1.speedY *= -1;
                    bricks.RemoveAt(hit);
                    score++;
                    label2.Text = $"Score = {score}";
                }
            }

            if (ball1.lives == 0)
            {
                label1.Text = "Game Over";
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {

        }

      
    }
}
