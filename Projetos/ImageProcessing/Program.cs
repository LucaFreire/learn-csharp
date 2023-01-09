using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Collections.Generic;
using System.Runtime.InteropServices;


(Bitmap bmp, float[] img) sobel((Bitmap bmp, float[] img) t)
{
    float[] kernel = new float[]{1,0,-1};
    float[] result = new float[t.img.Length];
    
    var Img = t.bmp;
    var _img = t.img;
    
    float fora = -0f;
    float soma = 0f;

    for (int i = 1; i < Img.Width - 1; i++) // Y
    {
        for (int j = 1; j < Img.Height - 1; j++)
        {
            int index = i + j * Img.Width;
            soma = _img[index - 1] + _img[index] + _img[index + 1];
            result[index] = soma + _img[i];
        }
    }

    float a = 0;
    float b = 0;
    soma = 0;

    //  1 4 5 6 7 2
    for (int j = 1; j < Img.Height - 1; j++)
    {    
        for (int k = 0; k < kernel.Length-1; k++)
        {
            soma += _img[k] + _img[k + 1];
        }
        a = soma;
        b = soma - _img[0] + _img[kernel.Length-1];

        for (int i = 1; i < Img.Width - 1; i++) // X
        {
                a = b;
                b += _img[i+kernel.Length-1] - _img[i];
            result[i] = a - b; 
        }
    }
    
    return (t.bmp , result);
}

(Bitmap bmp, float[] img) conv(
    (Bitmap bmp, float[] img) t, float[] kernel)
{
    var N = (int)Math.Sqrt(kernel.Length);
    var wid = t.bmp.Width;
    var hei = t.bmp.Height;
    var _img = t.img;
    float[] result = new float[_img.Length];

    for (int j = N / 2; j < hei - N / 2; j++)
    {
        for (int i = N / 2; i < wid - N / 2; i++)
        {
            float sum = 0;

            for (int k = 0; k < N; k++)
            {
                for (int l = 0; l < N; l++)
                {
                    sum += _img[i + k - (N / 2) + (j + l - (N / 2)) * wid] * 
                        kernel[k + l * N];
                }
            }

            if (sum > 1f)
                sum = 1f;
            else if (sum < 0f)
                sum = 0f;

            result[i + j * wid] = sum;
        }
    }

    var Imgbytes = discretGray(result);
    img(t.bmp, Imgbytes);

    return (t.bmp, result);
}

(Bitmap bmp, float[] img) morfology((Bitmap bmp, float[] img) t, float[] kernel, bool erosion)
{
    bool match = false;
    int wid = t.bmp.Width;
    int hei = t.bmp.Height;

    float[] imgor = t.img;
    float[] newImg = new float[imgor.Length];
    var tamKernel = (int)Math.Sqrt(kernel.Length);

    for (int i = 0; i < imgor.Length; i++)
    {
        match = erosion;
        int x = i % wid,
            y = i / wid;

        for (int j = 0; j < kernel.Length; j++)
        {
            if (kernel[j] == 0f)
                continue;
            
            int kx = j % tamKernel,
                ky = j / tamKernel;

            int tx = x + kx - tamKernel / 2;
            int ty = y + ky - tamKernel / 2;

            if (tx < 0 || ty < 0 || tx >= wid || ty >= hei)
                continue;

            int index = tx + ty * wid;

            if (imgor[index] == 1f)
            {
                if (!erosion)
                {
                    match = true;
                    break;
                }
            }
            else
            {
                if (erosion)
                {
                    match = false;
                    break;
                }
            }
        }

        if (match)
            newImg[i] = 1f;
    }

    var Imgbytes = discretGray(newImg);
    img(t.bmp, Imgbytes);

    return (t.bmp, newImg);
}

List<Rectangle> segmentation((Bitmap bmp, float[] img) t)
{
    var rects = segmentationT(t, 0);
    var areas = rects.Select(r => r.Width * r.Height);
    var average = areas.Average();
    
    return rects
        .Where(r => r.Width * r.Height > average)
        .ToList();
}

List<Rectangle> segmentationT((Bitmap bmp, float[] img) t, int threshold)
{
    List<Rectangle> list = new List<Rectangle>();
    Stack<int> stack = new Stack<int>();

    float[] img = t.img;
    int wid = t.bmp.Width;
    float crr = 0.01f;

    int minx, maxx, miny, maxy;
    int count = 0;

    for (int i = 0; i < img.Length; i++)
    {
        if (img[i] > 0f)
            continue;
        
        minx = int.MaxValue;
        miny = int.MaxValue;
        maxx = int.MinValue;
        maxy = int.MinValue;
        count = 0;
        stack.Push(i);

        while (stack.Count > 0)
        {
            int j = stack.Pop();

            if (j < 0 || j >= img.Length)
                continue;
            
            if (img[j] > 0f)
                continue;

            int x = j % wid,
                y = j / wid;
            
            if (x < minx)
                minx = x;
            if (x > maxx)
                maxx = x;
            
            if (y < miny)
                miny = y;
            if (y > maxy)
                maxy = y;
            
            img[j] = crr;
            count++;

            stack.Push(j - 1);
            stack.Push(j + 1);
            stack.Push(j + wid);
            stack.Push(j - wid);
        }

        crr += 0.01f;
        if (count < threshold)
            continue;

        Rectangle rect = new Rectangle(
            minx, miny, maxx - minx, maxy - miny
        );
        list.Add(rect);
    }

    return list;
}

void otsu((Bitmap bmp, float[] img) t, float db = 0.05f)
{
    var histogram = hist(t.img, db);
    int threshold = 0;

    float Ex0 = 0;
    float Ex1 = t.img.Average();
    float Dx0 = 0;
    float Dx1 = t.img.Sum(x => x * x);
    int N0 = 0;
    int N1 = t.img.Length;

    float minstddev = float.PositiveInfinity;

    for (int i = 0; i < histogram.Length; i++)
    {
        float value = db * (2 * i + 1) / 2;
        float s = histogram[i] * value;

        if (N0 == 0 && histogram[i] == 0)
            continue;

        Ex0 = (Ex0 * N0 + s) / (N0 + histogram[i]);
        Ex1 = (Ex1 * N1 - s) / (N1 - histogram[i]);

        N0 += histogram[i];
        N1 -= histogram[i];

        Dx0 += value * value * histogram[i];
        Dx1 -= value * value * histogram[i];

        float stddev =
            Dx0 - N0 * Ex0 * Ex0 + 
            Dx1 - N1 * Ex1 * Ex1;
        
        if (float.IsInfinity(stddev) ||
            float.IsNaN(stddev))
            continue;
        
        if (stddev < minstddev)
        {
            minstddev = stddev;
            threshold = i;
        }
    }
    float bestTreshold = db * (2 * threshold + 1) / 2;

    tresh(t, bestTreshold);
}

void tresh((Bitmap bmp, float[] img) t, 
    float threshold = 0.5f)
{
    for (int i = 0; i < t.img.Length; i++)
        t.img[i] = t.img[i] > threshold ? 1f : 0f;
}

float[] equalization(
    (Bitmap bmp, float[] img) t,
    float threshold = 0f,
    float db = 0.05f)
{
    int[] histogram = hist(t.img, db);

    int dropCount = (int)(t.img.Length * threshold);
    
    float min = 0;
    int droped = 0;
    for (int i = 0; i < histogram.Length; i++)
    {
        droped += histogram[i];
        if (droped > dropCount)
        {
            min = i * db;
            break;
        }
    }

    float max = 0;
    droped = 0;
    for (int i = histogram.Length - 1; i > -1; i--)
    {
        droped += histogram[i];
        if (droped > dropCount)
        {
            max = i * db;
            break;
        }
    }

    var r = 1 / (max - min);
    
    for (int i = 0; i < t.img.Length; i++)
    {
        float newValue = (t.img[i] - min) * r;
        if (newValue > 1f)
            newValue = 1f;
        else if (newValue < 0f)
            newValue = 0f;
        t.img[i] = newValue;
    }
    
    return t.img;
}

void showHist((Bitmap bmp, float[] img) t, float db = 0.05f)
{
    var histogram = hist(t.img, db);
    var histImg = drawHist(histogram);
    showBmp(histImg);
}

(Bitmap bmp, float[] img) open(string path)
{
    var bmp = Bitmap.FromFile(path) as Bitmap;
    var byteArray = bytes(bmp);
    var dataCont = continuous(byteArray);
    var gray = grayScale(dataCont);
    return (bmp, gray);
}

void inverse((Bitmap bmp, float[] img) t)
{
    for (int i = 0; i < t.img.Length; i++)
        t.img[i] = 1f - t.img[i];
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

void show((Bitmap bmp, float[] gray) t)
{
    var bytes = discretGray(t.gray);
    var image = img(t.bmp, bytes);
    showBmp(image);
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
        ImageLockMode.ReadWrite,
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

void showBmp(Image img)
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

void showRects((Bitmap bmp, float[] img) t, List<Rectangle> list)
{
    var g = Graphics.FromImage(t.bmp);

    foreach (var rect in list)
        g.DrawRectangle(Pens.Red, rect);
    
    showBmp(t.bmp);
}

var image = open("image.png");

var sobell = sobel(image);

show(sobell);

