using System.Collections.Generic;

App.Run();

public class BluerControl
{   
    public void ApplyBlur(byte[] data)
    {
        byte[] copy = new byte[data.Length];

        for (int i = 20; i < copy.Length - 21; i++)
        {
            int sum = 0;
            for (int j = -20; j < 21; j++)
                sum += data[i + j];
            
            copy[i] = (byte)(sum / 41);
        }

        for (int i = 0; i < data.Length; i++)
            data[i] = copy[i];
    }
}