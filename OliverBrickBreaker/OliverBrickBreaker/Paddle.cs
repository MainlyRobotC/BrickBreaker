using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OliverBrickBreaker
{
    public class Paddle
    {
        public int x;
        public int y;
        public int width;
        public int height;
        public int speed;
        public Brush brush;
        public Rectangle hitbox
        {
            get { return new Rectangle(x, y, width, height); }
        }        

        public Paddle(int x, int y, int width, int height, int speed, Brush brush)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.speed = speed;
            this.brush = brush;            
        } 

        public void Update()
        {            
        }

        public void Draw(Graphics gfx)
        {
            gfx.FillRectangle(brush, x, y, width, height);
        }
    }
}
