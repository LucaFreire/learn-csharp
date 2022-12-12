using System;

double[] array = new double[]
{
    8.4, 8.6, 8.4, 7.0, 7.2, 10.0, 7.2, 9.4, 9.8
};

Console.WriteLine(mediaEspecial(array));

double mediaEspecial(double[] array)
{   
    array = array.OrderBy(i => i).ToArray();

    if (array.Count() >= 4)
    {
        int len = array.Count();

        var x1 = array[0];
        var x2 = array[1];
        var x3 = array[len-1];
        var x4 = array[len-2];

        var x = (x1 + x2 + x3 + x4) / 4;
        return x;
    }
    else
        return array.Average();
}
