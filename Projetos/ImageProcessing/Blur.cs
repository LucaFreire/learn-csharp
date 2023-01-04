public static class Blur
{
    public static Bitmap ApplyBlur(Bitmap bmp, int radius=5)
    {
        Bitmap returnBmp = new Bitmap(bmp.Width, bmp.Height);
        
        var data = returnBmp.LockBits(
            new Rectangle(0, 0, returnBmp.Width, returnBmp.Height),
            System.Drawing.Imaging.ImageLockMode.ReadWrite,
            System.Drawing.Imaging.PixelFormat.Format24bppRgb
        );

        var dataOriginal = bmp.LockBits(
            new Rectangle(0, 0, bmp.Width, bmp.Height),
            System.Drawing.Imaging.ImageLockMode.ReadOnly,
            System.Drawing.Imaging.PixelFormat.Format24bppRgb
        );

        unsafe
        {
            byte* p = (byte*)data.Scan0.ToPointer();
            byte* pOriginal = (byte*)dataOriginal.Scan0.ToPointer();

            for (int j = radius; j < data.Height - radius; j++)
            {
                byte* lOriginal = p + j * dataOriginal.Stride;
                byte* l = p + j * data.Stride;
                
                for (int i = radius; i < data.Width - radius; i++, l+=3)
                {
                    float meanB = 0;
                    float meanG = 0;
                    float meanR = 0;
                    for (int k = i - radius; k < i + radius; k++)
                    {
                        l += k * 3;
                        meanB += lOriginal[0];
                        meanG += lOriginal[1];
                        meanR += lOriginal[2];
                    }
                    l[0] = (byte)meanB;
                    l[1] = (byte)meanG;
                    l[2] = (byte)meanR;
                }
            }
            
        }
        bmp.UnlockBits(dataOriginal);
        returnBmp.UnlockBits(data);

        return returnBmp;
    }
}