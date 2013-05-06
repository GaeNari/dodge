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
        OdukKing[] odukKings = new OdukKing[100];

        int odukCount = 0;
        int skillCount = 0;

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

            #region Collision Check
            foreach (OdukKing oduk in odukKings)
            {
                if (oduk == null) continue;
                if (((oduk.X - player.X) * (oduk.X - player.X) + (oduk.Y - player.Y) * (oduk.Y - player.Y)) <= 841)
                {
                    MessageBox.Show("당신은 오덕왕에게 잡혔습니다. 오덕왕이 당신을 먹어버렸습니다 ㅠㅠ");
                    this.Close();
                }
            }
            #endregion

            #region Make New Odukking and Move Oduks
            if (frame % 30 == 0)
            {
                if (odukCount > 95)
                {
                }
                else
                {
                    Random r = new Random();
                    int selector = frame % 4;
                    switch (selector)
                    {
                        case 0:
                            new_X = r.Next(5, 980);
                            if (new_X == player.X) new_X--;
                            new_Y = 5;
                            if (new_Y == player.Y) new_Y--;
                            new_X_Speed = 2 * ((player.X - new_X) / Math.Abs(player.X - new_X));
                            new_Y_Speed = 2 * ((player.Y - new_Y) / Math.Abs(player.Y - new_Y));
                            break;
                        case 1:
                            new_X = r.Next(5, 980);
                            if (new_X == player.X) new_X--;
                            new_Y = 720;
                            if (new_Y == player.Y) new_Y--;
                            new_X_Speed = 2 * ((player.X - new_X) / Math.Abs(player.X - new_X));
                            new_Y_Speed = 2 * ((player.Y - new_Y) / Math.Abs(player.Y - new_Y));
                            break;
                        case 2:
                            new_X = 5;
                            if (new_X == player.X) new_X--;
                            new_Y = r.Next(5, 720);
                            if (new_Y == player.Y) new_Y--;
                            new_X_Speed = 2 * ((player.X - new_X) / Math.Abs(player.X - new_X));
                            new_Y_Speed = 2 * ((player.Y - new_Y) / Math.Abs(player.Y - new_Y));
                            break;
                        default:
                            new_X = 980;
                            if (new_X == player.X) new_X--;
                            new_Y = r.Next(5, 720);
                            if (new_Y == player.Y) new_Y--;
                            new_X_Speed = 2 * ((player.X - new_X) / Math.Abs(player.X - new_X));
                            new_Y_Speed = 2 * ((player.Y - new_Y) / Math.Abs(player.Y - new_Y));
                            break;
                    }
                    odukKings[odukCount] = new OdukKing(new_X, new_Y, new_X_Speed, new_Y_Speed);
                    odukCount++;
                }
            }
            
            foreach (OdukKing oduk in odukKings)
            {
                if (oduk == null) continue;
                if (oduk.X < 4 | oduk.X > 995)
                {
                    oduk.Y_reflect();
                }
                if (oduk.Y < 4 | oduk.Y > 724)
                {
                    oduk.X_reflect();
                }
                oduk.move();
            }
            #endregion

            #region Player Moving
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
            g.Clear(Color.Pink);
            
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

        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case 'x':
                    if (skillCount >= 3) break;
                    player.skill(odukKings);
                    odukCount = 0;
                    skillCount++;
                    break;
            }
        }
    }
}