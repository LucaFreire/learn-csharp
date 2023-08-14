using System.Collections;
using Timer = System.Windows.Forms.Timer;

namespace Sprites;

static class Program
{
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Form form = new Form();

        form.WindowState = FormWindowState.Maximized;

        Graphics? g = null;
        Bitmap? bmp = new Bitmap(@"Mega.png");
        var tm = new Timer();
        var pb = new PictureBox();
        form.Controls.Add(pb);

        pb.Dock = DockStyle.Fill;

        Queue<DateTime> queue = new Queue<DateTime>();
        queue.Enqueue(DateTime.Now);

        int totalLines = 2;
        int totalColumns = 5;
        Rectangle[] Frames = new Rectangle[totalLines * totalColumns];

        int totalWid = bmp.Width;
        int totalHei = bmp.Height;

        int widthMega = totalWid / totalColumns;
        int heightMega = totalHei / totalLines;

        int indexControl = 0;
        for (int i = 0; i < totalLines; i++)
        {
            for (int j = 0; j < totalColumns; j++, indexControl++)
                Frames[indexControl] = new Rectangle((widthMega * j), (heightMega * i), widthMega, heightMega);
        }

        int positionX = 0;
        int positionY = 0;
        int indexFrame = 0;

        tm.Interval = 20;
        tm.Tick += delegate
        {
            g.Clear(Color.White);
            var now = DateTime.Now;
            queue.Enqueue(now);
            if (queue.Count > 19)
            {
                DateTime old = queue.Dequeue();
                var time = now - old;
                var fps = (int)(19 / time.TotalSeconds);
            }

            g.DrawImage(bmp, new Rectangle(positionX, positionY, 400, 400), Frames[indexFrame], GraphicsUnit.Pixel);
            pb.Refresh();
        };

        form.Load += delegate
        {
            Bitmap? bmp2 = new Bitmap(pb.Width, pb.Height);

            g = Graphics.FromImage(bmp2);
            g.Clear(Color.Blue);
            pb.Image = bmp2;
            tm.Start();
        };

        form.KeyDown += (s, e) =>
        {
            if (e.KeyCode == Keys.Escape)
                Application.Exit();

            if (e.KeyCode == Keys.D)
            {
                if (indexFrame >= Frames.Length - 1)
                    indexFrame = 0;
                else
                    indexFrame++;
                positionX += 50;
            }

            if (e.KeyCode == Keys.A)
            {
                if (indexFrame <= 0)
                    indexFrame = Frames.Length - 1;
                else
                    indexFrame--;
                positionX -= 50;
            }

            if (e.KeyCode == Keys.W)
            {
                if (indexFrame >= Frames.Length - 1)
                    indexFrame = 0;
                else
                    indexFrame++;
                positionY -= 50;
            }

            if (e.KeyCode == Keys.S)
            {
                if (indexFrame >= Frames.Length - 1)
                    indexFrame = 0;
                else
                    indexFrame++;
                positionY += 50;
            }
        };
        Application.Run(form);
    }
}