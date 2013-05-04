using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace dodge
{
    class OdukKing
    {
        public int X;
        public int Y;

        public int X_speed;
        public int Y_speed;

        public OdukKing(int X, int Y, int X_speed, int Y_speed)
        {
            this.X = X;
            this.Y = Y;
            this.X_speed = X_speed;
            this.Y_speed = Y_speed;
        }

        public void move()
        {
            X += X_speed;
            Y += Y_speed;
        }

        public void X_reflect()
        {
            this.Y_speed = -this.Y_speed;
        }

        public void Y_reflect()
        {
            this.X_speed = -this.X_speed;
        }

        public void Draw(Graphics g)
        {
            Image im = Properties.Resources.odukking;
            g.DrawImage(im,new Point(X - im.Width / 2, Y - im.Height / 2));
        }
    }
}
