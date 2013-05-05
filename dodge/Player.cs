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
            this.X -= 2;
        }
        public void moveRight()
        {
            this.X += 2;
        }
        public void moveUp()
        {
            this.Y -= 2;
        }
        public void moveDown()
        {
            this.Y += 2;
        }
        public void skill(OdukKing[] odukKings)
        {
            for (int i = 0; i < 100; i++)
            {
                if (odukKings[i] == null) continue;
                odukKings[i] = null;
            }
        }
        public void Draw(Graphics g)
        {
            Image im = Properties.Resources.munchul;
            g.DrawImage(im, new Point(X - im.Width / 2, Y - im.Height / 2));
        }
    }
}
