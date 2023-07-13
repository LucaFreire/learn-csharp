using Timer = System.Windows.Forms.Timer;

namespace MoveComponents;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        var form = new Form();
        Point? p = null;

        var pn = new Panel();
        pn.Width = 50;
        pn.Height = 50;
        pn.Location = new Point(20, 20);
        pn.BackColor = Color.Blue;

        var pn2 = new Panel();
        pn2.Width = 30;
        pn2.Height = 30;
        pn2.Location = new Point(200, 200);
        pn2.BackColor = Color.Red;

        form.Controls.Add(pn);
        form.Controls.Add(pn2);

        var tm = new Timer();
        tm.Interval = 10;
        form.Load += delegate
        {
            tm.Start();
        };

        form.KeyDown += (s, e) =>
        {
            if (e.KeyCode == Keys.Escape)
                Application.Exit();
        };

        pn2.MouseMove += (s, e) =>
        {
            if (p is null)
                return;

            var dx = e.Location.X - p.Value.X;
            var dy = e.Location.Y - p.Value.Y;
            pn2.Location = new Point(
                pn2.Location.X + dx,
                pn2.Location.Y + dy
            );

            if(Math.Abs(pn.Location.X - pn2.Location.X) < pn.Width &&
            Math.Abs(pn.Location.Y - pn2.Location.Y) < pn.Height )
            {
                pn.Controls.Add(pn2);
                pn.Show();
                MessageBox.Show("YEP");
            }
        };

        pn2.MouseDown += (s, e) =>
        {
            p = e.Location;
        };

        pn2.MouseUp += (s, e) =>
        {
            p = null;
        };

        Application.Run(form);
    }
}