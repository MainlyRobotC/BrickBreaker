using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OliverBrickBreaker
{
    public class Ball
    {
        public int lives;
        public float X;
        public float Y;
        public int size;
        public float speedX;
        public float speedY;
        public Brush brush;
        public Rectangle hitbox
        {
            get { return new Rectangle((int)X, (int)Y, size, size); }
        }

        public Ball(int lives, int x, int y, int size, int speedX, int speedY, Brush brush)
        {
            this.lives = lives;
            this.X = x;
            this.Y = y;
            this.size = size;
            this.speedX = speedX;
            this.speedY = speedY;
            this.brush = brush;
        }

        public void Update(Size ClientSize)
        {
            X += speedX;
            Y += speedY;

            if(X + size > ClientSize.Width || X < 0)
            {
                speedX *= -1;
            }
            if(Y < 0)
            {
                speedY *= -1;
            }
            
        }

        public void Draw(Graphics gfx)
        {
            gfx.FillEllipse(brush, X, Y, size, size);
        }
    }
}
