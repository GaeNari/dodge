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
        public MainForm()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
        }
        int frame;
        bool movingLeft = false;
        bool movingRight = false;
        bool movingUp = false;
        bool movingDown = false;

        Player player = new Player();

        public void UpdateWorld(float elapsed)
        {
            frame++;
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
        }
        public void MainForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.Black);

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
