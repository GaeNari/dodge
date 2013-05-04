using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dodge
{
    public partial class MainForm : Form
    {
        OdukKing[] odukKings = new OdukKing[80];

        int odukCount = 0;

        bool movingLeft = false;
        bool movingRight = false;
        bool movingUp = false;
        bool movingDown = false;

        Player player = new Player();

        
        public MainForm()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
        }

        public void UpdateWorld(float elapsed, int frame)
        {
            int new_X;
            int new_Y;
            int new_X_Speed;
            int new_Y_Speed;

            foreach (OdukKing oduk in odukKings)
            {
                if (oduk == null) continue;
                if (((oduk.X - player.X) * (oduk.X - player.X) + (oduk.Y - player.Y) * (oduk.Y - player.Y)) <= 841)
                {
                    MessageBox.Show("당신은 오덕왕에게 잡혔습니다. 오덕왕이 당신을 먹어버렸습니다 ㅠㅠ");
                    this.Close();
                }
            }
            #region 새로운 오덕왕을 생성하는 부분
            if (frame % 30 == 0)
            {
                if (odukCount > 70)
                {
                }
                else
                {
                    Random r = new Random();
                    if (frame % 2 == 0)
                    {
                        if (frame % 4 == 0)
                        {
                            new_X = r.Next(0, 1280);
                            new_Y = 0;
                            new_X_Speed = 2 * ((player.X - new_X) / Math.Abs(player.X - new_X));
                            new_Y_Speed = 2 * ((player.Y - new_Y) / Math.Abs(player.Y - new_Y));
                        }
                        else
                        {
                            new_X = r.Next(0, 1280);
                            new_Y = 720;
                            new_X_Speed = 2 * ((player.X - new_X) / Math.Abs(player.X - new_X));
                            new_Y_Speed = 2 * ((player.Y - new_Y) / Math.Abs(player.Y - new_Y));
                        }
                    }
                    else
                    {
                        if (frame % 4 == 1)
                        {
                            new_X = 0;
                            new_Y = r.Next(0, 720);
                            new_X_Speed = 2 * ((player.X - new_X) / Math.Abs(player.X - new_X));
                            new_Y_Speed = 2 * ((player.Y - new_Y) / Math.Abs(player.Y - new_Y));
                        }
                        else
                        {
                            new_X = 1280;
                            new_Y = r.Next(0, 720);
                            new_X_Speed = 2 * ((player.X - new_X) / Math.Abs(player.X - new_X));
                            new_Y_Speed = 2 * ((player.Y - new_Y) / Math.Abs(player.Y - new_Y));
                        }
                    }
                    odukKings[odukCount] = new OdukKing(new_X, new_Y, new_X_Speed, new_Y_Speed);
                    odukCount++;
                }
            }
            #endregion

            foreach (OdukKing oduk in odukKings)
            {
                if (oduk == null) continue;
                oduk.move();
            }
            #region 플레이어 이동
            if (movingLeft)
            {
                player.moveLeft();
            }
            if (movingRight)
            {
                player.moveRight();
            }
            if (movingUp)
            {
                player.moveUp();
            }
            if (movingDown)
            {
                player.moveDown();
            }
            #endregion
        }
     
        public void MainForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.Black);
            
            foreach(OdukKing oduk in odukKings)
            {
                if (oduk == null) continue;
                oduk.Draw(g);
            }

            player.Draw(g);
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    movingLeft = true; break;
                case Keys.Right:
                    movingRight = true; break;
                case Keys.Up:
                    movingUp = true; break;
                case Keys.Down:
                    movingDown = true; break;
            }
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    movingLeft = false; break;
                case Keys.Right:
                    movingRight = false; break;
                case Keys.Up:
                    movingUp = false; break;
                case Keys.Down:
                    movingDown = false; break;
            }
        }
    }
}
