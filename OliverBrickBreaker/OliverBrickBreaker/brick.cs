using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OliverBrickBreaker
{
    class Brick
    {
        public int x;
        public int y;
        public int width;
        public int height;
        public Brush brush;
        public Rectangle hitbox
        {
            get { return new Rectangle(x, y, width, height); }
        }

        public Brick(int x, int y, int width, int height, Brush brush)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.brush = brush;
        }

        public void draw(Graphics gfx)
        {
            gfx.FillRectangle(brush, x, y, width, height);
        }
    }
}
