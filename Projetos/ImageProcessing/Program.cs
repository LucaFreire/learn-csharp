using System;
using System.Linq;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Collections.Generic;
using System.Runtime.InteropServices;

(Bitmap bmp, float[] img) PreencheMeio((Bitmap bmp, float[] img) org) 
{
    float[] Imagem = org.img;
    float[] ArrayReturn = new float[Imagem.Length];
    int ImageWid = org.bmp.Width; 
    int ImageHeight = org.bmp.Height; 

    for (int j = 5; j < ImageHeight - 5; j++)
    {
        for (int i = 5; i < ImageWid - 5; i++)
        {

            int index = i + j * ImageWid;

            if (Imagem[index] == 0f) 
            {
                int newIndexCorner1 = (i - 1) + ((j - 1) * ImageWid);
                int newIndexCorner2 = (i + 1) + ((j - 1) * ImageWid);
                int newIndexCorner3 = (i + 1) + ((j + 1) * ImageWid);
                int newIndexCorner4 = (i + 1) + ((j + 1) * ImageWid);

                for (int k = 1; true; k++)
                {

                    if (k % 2 == 0)
                    {

                        if ((newIndexCorner1 -= k) >= 0)
                            newIndexCorner1 -= k;

                        if ((newIndexCorner2 += k) <= Imagem.Length)
                            newIndexCorner2 += k;

                        if ((newIndexCorner3 -= k) >= 0)
                            newIndexCorner3 -= k;

                        if ((newIndexCorner4 += k) <= Imagem.Length)
                            newIndexCorner4 +=  k;

                        if ((Imagem[newIndexCorner1] >= 1 &&
                        Imagem[newIndexCorner2] >= 1 &&  
                        Imagem[newIndexCorner3] >= 1 &&
                        Imagem[newIndexCorner4] >= 1) || (
                        ( (newIndexCorner1 -= k) >= 0) ||
                        ( (newIndexCorner2 += k) <= Imagem.Length) || 
                        ( (newIndexCorner3 -= k) >= 0) ||
                        ( (newIndexCorner4 += k) <= Imagem.Length )))
                        {
                            float sum = Imagem[newIndexCorner1] + Imagem[newIndexCorner2] +
                            Imagem[newIndexCorner3] + Imagem[newIndexCorner4];
                            ArrayReturn[index] = k / sum;
                            break;
                        }

                        continue;
                    }

                    if ((newIndexCorner1 -= k * ImageWid) >= 0)
                        newIndexCorner1 -= k * ImageWid;

                    if ((newIndexCorner2 -= k * ImageWid) >= 0)
                        newIndexCorner2 -= k * ImageWid;

                    if ((newIndexCorner3 += k * ImageWid) <= Imagem.Length)
                        newIndexCorner3 += k * ImageWid;

                    if ((newIndexCorner4 += k * ImageWid) <= Imagem.Length)
                        newIndexCorner4 += k * ImageWid;

                    if ((Imagem[newIndexCorner1] >= 1 &&
                    Imagem[newIndexCorner2] >= 1 &&  
                    Imagem[newIndexCorner3] >= 1 &&
                    Imagem[newIndexCorner4] >= 1) || (
                    ( (newIndexCorner1 -= k * ImageWid) >= 0) ||
                    ( (newIndexCorner2 -= k * ImageWid) >= 0) || 
                    ( (newIndexCorner3 += k * ImageWid) <= Imagem.Length) ||
                    ( (newIndexCorner4 += k * ImageWid) <= Imagem.Length )))
                    {
                        float sum = Imagem[newIndexCorner1] + Imagem[newIndexCorner2] +
                        Imagem[newIndexCorner3] + Imagem[newIndexCorner4];
                        ArrayReturn[index] = k / sum;
                        break;
                    }

                }
            }

            else
            {
                // var IndexCorner1 = i - 1 + (j - 1) * ImageWid;
                // var IndexCorner2 = i + 1 + (j - 1) * ImageWid;

                // float Media1 = (Imagem[IndexCorner1] + Imagem[IndexCorner2]) / 2; // Média de algo

                // var IndexCorner3 = i - 1 + (j + 1) * ImageWid;
                // var IndexCorner4 = i + 1 + (j + 1) * ImageWid;

                // float Media2 = (Imagem[IndexCorner3] + Imagem[IndexCorner4]) / 2; // Média de algo 2

                ArrayReturn[index] = Imagem[index];  // A lista recebe a soma das médias e divide por 2
                
            }
            
        }
    }


    var ImgGray = discretGray(ArrayReturn);

    var Imagemz = img(org.bmp, ImgGray) as Bitmap;

    return (org.bmp, ArrayReturn);

}



(Bitmap bmp, float[] img) RedimensionaImg((Bitmap bmp, float[] img) org, float v1, float v2) 
{
    // Recebe uma imagem e um valor para redimensionar uma imagem (resize)

    int ImgWid = org.bmp.Width;
    int ImgHei = org.bmp.Height;
    Bitmap Img2 = new Bitmap((int)(v1 * ImgWid),(int)(v2 * ImgHei));
    int Img2Wid = Img2.Width;
    int Img2Hei = Img2.Height;

    float[] ArrayImg = org.img;
    float[] Img2Size = new float[Img2Wid * Img2Hei];


    for (int i = 0; i < ImgWid; i++)
    {
        for (int j = 0; j < ImgHei; j++)
        {
            Img2Size[i + j * Img2Wid] = ArrayImg[i + j * ImgWid];
        }
    }

    var GrayImg = discretGray(Img2Size);
    var Imagem = img(Img2, GrayImg) as Bitmap;

    var ImagemReturn = (Imagem, Img2Size);

    ImagemReturn = affine(ImagemReturn, scale(v1, v2)); // Redimensiona a nova imagem
    
    return ImagemReturn;
}


(Bitmap bmp, float[] img) Mineaffine((Bitmap bmp, float[] img) t, params float[] p)
{

    float[] retorno = new float[t.img.Length];
    int index = 0;


    for (int j = 0; j < t.bmp.Height; j++) // Y
    {
        for (int i = 0; i < t.bmp.Width; i++) // X
        {
            
            index = i + j * t.bmp.Width;

            float x1 = (int)(p[0] * i + p[1] * j + p[2]);

            float y1 = (int)(p[3] * i + p[4] * j + p[5]);

            if (x1 >= t.bmp.Width || x1 < 0 || y1 >= t.bmp.Height  || y1 < 0)
                continue;

            retorno[(int)(x1 + y1 * t.bmp.Width)] = t.img[index];

        }
    }
    return (t.bmp, retorno);
}

Matrix4x4 mat(params float[] arr)
{
    return new Matrix4x4(
        arr[0], arr[1], arr[2], 0,
        arr[3], arr[4], arr[5], 0,
        arr[6], arr[7], arr[8], 0,
             0,      0,      0, 1
    );
}

Matrix4x4 rotation(float degree)
{
    float radian = degree / 180 * MathF.PI;
    float cos = MathF.Cos(radian);
    float sin = MathF.Sin(radian);
    return mat(
        cos, -sin, 0,
        sin,  cos, 0,
          0,    0, 1
    );
}

Matrix4x4 translate(float dx, float dy)
{
    return mat(
        1, 0, dx,
        0, 1, dy,
        0, 0, 1
    );
}

Matrix4x4 translateFromSize(float dx, float dy,
    (Bitmap bmp, float[] img) t)
{
    return mat(
        1, 0, dx * t.bmp.Width,
        0, 1, dy * t.bmp.Height,
        0, 0, 1
    );
}

Matrix4x4 scale(float dx, float dy)
{
    return mat(
        dx, 0, 0,
        0, dy, 0,
        0, 0, 1
    );
}

Matrix4x4 shear(float cx, float cy)
{
    return mat(
        1, cx, 0,
        cy, 1, 0,
        0, 0, 1
    );
}

(Bitmap bmp, float[] img) affine((Bitmap bmp, float[] img) t,
    Matrix4x4 mat)
{
    float[] p = new float[]
    {
        mat.M11, mat.M12, mat.M13,
        mat.M21, mat.M22, mat.M23,
        mat.M31, mat.M32, mat.M33,
    };
    var _img = t.img;
    float[] nova = new float[_img.Length];
    int wid = t.bmp.Width;
    int hei = t.bmp.Height;
    int x = 0;
    int y = 0;
    int index = 0;

    for (int i = 0; i < wid; i++)
    {
        for (int j = 0; j < hei; j++)
        {
            x = (int)(p[0] * i + p[1] * j + p[2]);
            y = (int)(p[3] * i + p[4] * j + p[5]);

            if(x < 0 || x >= wid || y < 0 || y >= wid)
                continue;
            else
            {
                index = (int)(x + y * wid);
                nova[index] = _img[i+j * wid];
            }
        }
    }

    var Imgbytes = discretGray(nova);
    img(t.bmp, Imgbytes);

    return (t.bmp, nova);
}

(Bitmap bmp, float[] img) sobel((Bitmap bmp, float[] img) t,
    bool dir = true)
{
    var im = t.img;
    float[] tempo = new float[im.Length];
    float[] final = new float[im.Length];
    int wid = t.bmp.Width;
    int hei = t.bmp.Height;

    for (int i = 1; i < wid - 1; i++)
    {
        float sum = 
            im[i + 0 * wid] + 
            im[i + 1 * wid] + 
            im[i + 2 * wid];
        for (int j = 1; j < hei - 1; j++)
        {
            int index = i + j * wid;
            tempo[index] = im[index] + sum;

            sum -= im[index - 1];
            sum += im[index + 1];
        }
    }
    
    for (int j = 1; j < hei - 1; j++)
    {
        float seq = 
            im[0 + j * wid] + 
            im[1 + j * wid];
        for (int i = 1; i < wid - 1; i++)
        {
            float nextSeq = 
                im[i + j * wid] +
                im[i + 1 + j * wid];

            int index = i + j * wid;
            float value = dir ? seq - nextSeq : nextSeq - seq;
            if (value > 1f)
                value = 1f;
            else if (value < 0f)
                value = 0f;
            final[index] = value;

            seq = nextSeq;
        }
    }

    var Imgbytes = discretGray(final);
    img(t.bmp, Imgbytes);

    return (t.bmp, final);
}

(Bitmap bmp, float[] img) conv(
    (Bitmap bmp, float[] img) t, params float[] kernel)
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


var image = open("shuregui.png");

image = RedimensionaImg(image, 1.1f, 1.1f);

image = PreencheMeio(image);

show(image);