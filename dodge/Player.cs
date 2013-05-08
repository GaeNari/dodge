using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace dodge
{
    class Player
    {
        public float X = 640;
        public float Y = 360;

        public void moveLeft(float elapsed)
        {
            this.X -= (200 * elapsed);
        }
        public void moveRight(float elapsed)
        {
            this.X += (200 * elapsed);
        }
        public void moveUp(float elapsed)
        {
            this.Y -= (200 * elapsed);
        }
        public void moveDown(float elapsed)
        {
            this.Y += (200 * elapsed);
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
            g.DrawImage(im, new Point((int)(X - im.Width / 2), (int)(Y - im.Height / 2)));
        }
    }
}
