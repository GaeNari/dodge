using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace dodge
{
    static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            int frame = 0;

            MainForm form = new MainForm();
            form.ClientSize = new Size(1024,768);
            form.Show();

            DateTime prevUpdateTime = DateTime.Now;
            while (form.Created)
            {
                DateTime updateTime = DateTime.Now;
                float elapsed = (float)(updateTime - prevUpdateTime).TotalSeconds;
                form.UpdateWorld(elapsed, frame);
                frame++;
                form.Invalidate(true);
                prevUpdateTime = DateTime.Now;

                Application.DoEvents();
            }
        }
    }
}
