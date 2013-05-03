using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace dodge
{
    class Player
    {
        public int X = 640;
        public int Y = 360;

        public void moveLeft()
        {
            this.X -= 1;
        }
        public void moveRight()
        {
            this.X += 1;
        }
        public void moveUp()
        {
            this.Y -= 1;
        }
        public void moveDown()
        {
            this.Y += 1;
        }

        public void Draw(Graphics g)
        {
            Image im = Properties.Resources.munchul;
            g.DrawImage(im, new Point(X - im.Width / 2, Y - im.Height / 2));
        }
    }
}
