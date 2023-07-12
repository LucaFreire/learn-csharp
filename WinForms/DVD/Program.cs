namespace DVD;

using System.Windows.Forms;
using System;
using System.Drawing;

static class Program
{

    static void Main()
    {

        ApplicationConfiguration.Initialize();

        Form form = new Form();
        form.WindowState = FormWindowState.Maximized;
        form.FormBorderStyle = FormBorderStyle.None;

        var timer = new Timer();
        timer.Interval = 1;

        Panel pn = new Panel();
        pn.BackColor = Color.Red;

        int sumX = 1000;
        int sumY = 1000;
        timer.Tick += delegate
        {
            var x = pn.Location.X;
            var y = pn.Location.Y;


            if (y <= 0)
                sumY = 1000;

            if (y + pn.Height >= form.Height)
                sumY = -1000;

            if (x <= 0)
                sumX = 1000;

            if (x + pn.Width >= form.Width)
                sumX = -1000;

            x += sumX;
            y += sumY;

            // if(x == 0 && y == 0 || x == 0 && y == form.Height || x == form.Width && y == form.Height || x == form.Width && y == 0 )
            //     MessageBox.Show("Né");

            pn.Location = new Point(x, y);
        };

        form.Load += delegate
        {
            timer.Start();
        };

        form.KeyDown += (s, e) =>
        {
            if (e.KeyCode == Keys.Escape)
                Application.Exit();
        };
        form.Controls.Add(pn);

        Application.Run(form);
    }
}