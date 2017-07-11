﻿using System;
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
        Ball ball1 = new Ball(3, 425, 250, 20, 0, 0, Brushes.Cyan);
        Paddle paddle1 = new Paddle(400, 420, 120, 25, 15, Brushes.Red);
        public int score = 0;

        bool lost = false;

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
                bricks.Add(new Brick(i*50+20, 100, 40, 20, 1, Brushes.Purple));
                bricks.Add(new Brick(i * 50 + 20, 150, 40, 20, 2, Brushes.Yellow));
                bricks.Add(new Brick(i * 50 + 20, 200, 40, 20, 3, Brushes.Green));
            }
          

        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 16; i++)
            {
                bricks.Add(new Brick(i * 50 + 20, 100, 40, 20, 3, Brushes.Purple));
                bricks.Add(new Brick(i * 50 + 20, 150, 40, 20, 2, Brushes.Yellow));
                bricks.Add(new Brick(i * 50 + 20, 200, 40, 20, 1, Brushes.Green));
            }
            score = 0;
            ball1.lives = 3;
            ball1.speedX = 4;
            ball1.speedY = 4;
            ball1.x = ClientSize.Width/2;
            ball1.y = ClientSize.Height/2;
            label1.Text = " ";
            button1.Enabled = false;
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

            if(paddle1.x + paddle1.width < ClientSize.Width && e.KeyCode == Keys.Right)
            {
                paddle1.x += paddle1.speed;
            }

            if (lost == true)
            {
                if (e.KeyCode == Keys.Space)
                {
                    ball1.speedX = 4;
                    ball1.speedY = 4;   
                }
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


            if(paddle1.hitbox.IntersectsWith(ball1.hitbox) && ball1.speedY > 0)
            {
                ball1.speedY *= -1;
            }

            for (int hit = 0; hit < bricks.Count; hit++)
            {
                if (bricks[hit].hitbox.IntersectsWith(ball1.hitbox))
                {
                    ball1.speedY = Math.Abs(ball1.speedY);
                    bricks[hit].lives--;
                    if(bricks[hit].lives == 1)
                    {
                        bricks[hit].brush = Brushes.Green;
                    }
                    if (bricks[hit].lives == 2)
                    {
                        bricks[hit].brush = Brushes.Yellow;
                    }
                    if (bricks[hit].lives == 3)
                    {
                        bricks[hit].brush = Brushes.Purple;
                    }
                    if (bricks[hit].lives == 0)
                    {
                        bricks.RemoveAt(hit);
                        score++;
                        label2.Text = $"Score = {score}";
                    }
                    
                }

                if (ball1.y + ball1.size > ClientSize.Height)
                {
                    ball1.x = paddle1.x + paddle1.width/2;
                    ball1.y = paddle1.y;
                    ball1.speedX = 0;
                    ball1.speedY = 0;
                    lost = true;
                    ball1.lives--;
                }
            }
            
            if(ball1.lives > 0 && score >= 48)
            {
                label1.Text = $"YOU WIN! Final Score: {ball1.lives * score}";
                ball1.speedX = 0;
                ball1.speedY = 0;
                button1.Enabled = true;
            }

            if (ball1.lives == 0)
            {
                label1.Text = "Game Over";
                ball1.speedX = 0;
                ball1.speedY = 0;
                button1.Enabled = true;
            }

            label3.Text = $"Lives = {ball1.lives}";
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ball1.speedX = 6;
            ball1.speedY = 6;
            button3.Enabled = false;
            button3.Visible = false;
            button2.Enabled = false;
            button2.Visible = false;
            button4.Enabled = false;
            button4.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ball1.speedX = 4;
            ball1.speedY = 4;
            button3.Enabled = false;
            button3.Visible = false;
            button2.Enabled = false;
            button2.Visible = false;
            button4.Enabled = false;
            button4.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ball1.speedX = 8;
            ball1.speedY = 8;
            button3.Enabled = false;
            button3.Visible = false;
            button2.Enabled = false;
            button2.Visible = false;
            button4.Enabled = false;
            button4.Visible = false;
        }
    }
}
