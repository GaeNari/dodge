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

        public void moveLeft(float elapsed)
        {
            this.X -= (int)(200 * elapsed);
        }
        public void moveRight(float elapsed)
        {
            this.X += (int)(200 * elapsed);
        }
        public void moveUp(float elapsed)
        {
            this.Y -= (int)(200 * elapsed);
        }
        public void moveDown(float elapsed)
        {
            this.Y += (int)(200 * elapsed);
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
