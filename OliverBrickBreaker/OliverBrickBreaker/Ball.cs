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
        public float x;
        public float y;
        public int size;
        public float speedX;
        public float speedY;
        public Brush brush;
        public Rectangle hitbox
        {
            get { return new Rectangle((int)x, (int)y, size, size); }
        }

        public Ball(int lives, int x, int y, int size, int speedX, int speedY, Brush brush)
        {
            this.lives = lives;
            this.x = x;
            this.y = y;
            this.size = size;
            this.speedX = speedX;
            this.speedY = speedY;
            this.brush = brush;
        }

        public void Update(Size ClientSize)
        {
            x += speedX;
            y += speedY;

            if(x + size > ClientSize.Width)
            {
                speedX *= -1;
            }
            if(x < 0)
            {
                speedX *= -1;
            }
            if(y < 0)
            {
                speedY *= -1;
            }
            if(y + size > ClientSize.Height)
            {
                x = ClientSize.Width / 2;
                y = ClientSize.Height / 2;

                lives--;
            }
        }

        public void Draw(Graphics gfx)
        {
            gfx.FillEllipse(brush, x, y, size, size);
        }
    }
}
