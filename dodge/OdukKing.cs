using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace dodge
{
    class OdukKing
    {
        public float X;
        public float Y;

        public float X_speed;
        public float Y_speed;

        public OdukKing(float X, float Y, float X_speed, float Y_speed)
        {
            this.X = X;
            this.Y = Y;
            this.X_speed = X_speed;
            this.Y_speed = Y_speed;
        }

        public void move(float elapsed)
        {
            X += (X_speed * elapsed);
            Y += (Y_speed * elapsed);
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
            g.DrawImage(im,new Point((int)(X - im.Width / 2), (int)(Y - im.Height / 2)));
        }
    }
}
