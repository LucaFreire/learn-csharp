using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

float[] inverse(float[] img)
{
    for (int i = 0; i < img.Length; i++)
        img[i] = 1f - img[i];
    return img;
}

Image drawHist(int[] hist)
{
    var bmp = new Bitmap(512, 256);
    var g = Graphics.FromImage(bmp);
    float margin = 16;

    int max = hist.Max();
    float barlen = (bmp.Width - 2 * margin) / hist.Length;
    float r = (bmp.Height - 2 * margin) / max;

    for (int i = 0; i < hist.Length; i++)
    {
        float bar = hist[i] * r;
        g.FillRectangle(Brushes.Black, 
            margin + i * barlen,
            bmp.Height - margin - bar, 
            barlen,
            bar);
        g.DrawRectangle(Pens.DarkBlue, 
            margin + i * barlen,
            bmp.Height - margin - bar, 
            barlen,
            bar);
    }

    return bmp;
}

int[] hist(float[] img, float db = 0.05f)
{
    int histogramLen = (int)(1 / db) + 1;
    int[] histogram = new int[histogramLen];

    foreach (var pixel in img)
        histogram[(int)(pixel / db)]++;
    
    return histogram;
}

float[] grayScale(float[] img)
{
    float[] result = new float[img.Length / 3];
    
    for (int i = 0, j = 0; i < img.Length; i += 3, j++)
    {
        result[j] = 0.1f * img[i] + 
            0.59f * img[i + 1] +
            0.3f * img[i + 2];
    }

    return result;
}

float[] continuous(byte[] img)
{
    var result = new float[img.Length];
    
    for (int i = 0; i < img.Length; i++)
        result[i] = img[i] / 255f;

    return result;
}

byte[] discret(float[] img)
{
    var result = new byte[img.Length];
    
    for (int i = 0; i < img.Length; i++)
        result[i] = (byte)(255 * img[i]);

    return result;
}

byte[] discretGray(float[] img)
{
    var result = new byte[3 * img.Length];
    
    for (int i = 0; i < img.Length; i++)
    {
        var value = (byte)(255 * img[i]);
        result[3 * i] = value;
        result[3 * i + 1] = value;
        result[3 * i + 2] = value;
    }

    return result;
}

byte[] bytes(Image img)
{
    var bmp = img as Bitmap;
    var data = bmp.LockBits(
        new Rectangle(0, 0, img.Width, img.Height),
        ImageLockMode.ReadOnly,
        PixelFormat.Format24bppRgb);
    
    byte[] byteArray = new byte[3 * data.Width * data.Height];

    byte[] temp = new byte[data.Stride * data.Height];
    Marshal.Copy(data.Scan0, temp, 0, temp.Length);

    for (int j = 0; j < data.Height; j++)
    {
        for (int i = 0; i < 3 * data.Width; i++)
        {
            byteArray[i + j * 3 * data.Width] =
                temp[i + j * data.Stride];
        }
    }

    bmp.UnlockBits(data);

    return byteArray;
}

Image img(Image img, byte[] bytes)
{
    var bmp = img as Bitmap;
    var data = bmp.LockBits(
        new Rectangle(0, 0, img.Width, img.Height),
        ImageLockMode.ReadOnly,
        PixelFormat.Format24bppRgb);
    
    byte[] temp = new byte[data.Stride * data.Height];
    
    for (int j = 0; j < data.Height; j++)
    {
        for (int i = 0; i < 3 * data.Width; i++)
        {
            temp[i + j * data.Stride] =
                bytes[i + j * 3 * data.Width];
        }
    }
    
    Marshal.Copy(temp, 0, data.Scan0, temp.Length);

    bmp.UnlockBits(data);
    return img;
}

void show(Image img)
{
    ApplicationConfiguration.Initialize();

    Form form = new Form();

    PictureBox pb = new PictureBox();
    pb.Dock = DockStyle.Fill;
    pb.SizeMode = PictureBoxSizeMode.Zoom;
    form.Controls.Add(pb);

    form.WindowState = FormWindowState.Maximized;
    form.FormBorderStyle = FormBorderStyle.None;

    form.Load += delegate
    {
        pb.Image = img;
    };

    form.KeyDown += (o, e) =>
    {
        if (e.KeyCode == Keys.Escape)
        {
            Application.Exit();
        }
    };

    Application.Run(form);
}

var planta = Bitmap.FromFile("");
var bytesPlanta = bytes(planta);
var floatPlanta = continuous(bytesPlanta);
var grayPlanta = grayScale(floatPlanta);

img(planta, discretGray(grayPlanta));

var histogram = hist(grayPlanta);
var histogramImg = drawHist(histogram);
show(histogramImg);
