using System.IO;
using System;
using System.Linq;
using static System.Console;
using System.Collections.Generic;

var days = getDays();
var bikes = getSharings();


// Exercício 1 ------------------------------------------------------
var Exer1 = bikes.Average(x => x.Registred + x.Casual);

Console.WriteLine($"Mean: {Exer1}");


// Exercício 2 ------------------------------------------------------
var Exer2 = bikes.GroupBy(x => x.Day / 30)
                .Select(z => new{
                    Mes = z.Key,
                    Soma = z.Average(g => g.Casual + g.Registred)
                });

foreach (var item in Exer2)
    Console.WriteLine($"Mes: {item.Mes} -- Mean: {item.Soma}");


// Exercício 3 ------------------------------------------------------
var Exer3Season = bikes.Join(days,
                bike => bike.Day,
                dia => dia.Day,
                (bike,dia) => new{
                    Season = dia.Season,
                    Soma = (bike.Casual + bike.Registred) / bike.Casual
                })
                .GroupBy(xx => xx.Season)
                .Select( x => new {
                    Season = x.Key,
                    media = x.Select( gg => gg.Soma)
                }
                );

Console.WriteLine($"By Season\n");
foreach (var item in Exer3Season)
    Console.WriteLine($"Season: {item.Season} -- Mean: {item.media}");

var Exer3Temp = bikes.Join(days,
                bike => bike.Day,
                dia => dia.Day,
                (bike,dia) => new{
                    Temporada = dia.Temp,
                    Cas = bike.Casual,
                    Reg = bike.Registred
                }).GroupBy(xx => xx.Temporada )
                .Select( x => new {
                    Temp = x.Key,
                    media = x.Average( gg => gg.Cas + gg.Reg)
                });

Console.WriteLine($"By Temp\n");
foreach (var item in Exer3Temp)
    Console.WriteLine($"Temp: {item.Temp} -- Mean: {item.media}");


// Exercício 4 ------------------------------------------------------
var Exer4 = bikes.Join(days,
                bike => bike.Day,
                dia => dia.Day,
                (bike,dia) => new{
                    Trampo = dia.IsWorkingDay,
                    Reg = bike.Registred,
                    Cas = bike.Casual
                })
                .GroupBy(tt => tt.Trampo)
                .Select(vv => new{
                    Trampo = vv.Select(x => x.Trampo),
                    mean = vv.Average(x => x.Cas + x.Reg)
                });

foreach (var item in Exer4)
    Console.WriteLine($"{item.Trampo} -- {item.mean}");


// Exercício 5 ------------------------------------------------------



var maximum = bikes.Max(x => x.Registred + x.Casual);
var minimum = bikes.Min(x => x.Registred + x.Casual);

var GetDiaMax = bikes.First(xx => xx.Casual + xx.Registred == maximum);
var GetDiaMin = bikes.First(xx => xx.Casual + xx.Registred == minimum);

var getMax = days.Where(zz => zz.Day == GetDiaMax.Day);
var getMin = days.Where(zz => zz.Day == GetDiaMin.Day);

var infoMax = getMax.Select(xx => new{
    Dia = xx.Day,
    Trampo = xx.IsWorkingDay,
    Season = xx.Season,
    Temp = xx.Temp,
    Weather = xx.Weather
});

var infoMin = getMin.Select(xx => new{
    Dia = xx.Day,
    Trampo = xx.IsWorkingDay,
    Season = xx.Season,
    Temp = xx.Temp,
    Weather = xx.Weather
});

Console.WriteLine($"Valor Max: {maximum} -- Dia: {infoMax.Select(x => x.Dia)}...."); // PQQQQQQQQQ????????


// var infoMax = days.Where(zz => zz.Day == GetDiaMax.Day)
//                 .Select(info => new{
//                     Trampo = info.IsWorkingDay,
//                     Clima = info.Weather,
//                     Season = info.Season,
//                     Temp = info.Temp,
//                     Dia = info.Day
//                 });
//                                                          VER O PORQUE DE N FUNCIONAR
// var infoMin = days.Where(zz => zz.Day == GetDiaMin.Day)
//                 .Select(info => new{
//                     Trampo = info.IsWorkingDay,
//                     Clima = info.Weather,
//                     Season = info.Season,
//                     Temp = info.Temp,
//                     Dia = info.Day
//                 });


IEnumerable<DayInfo> getDays()
{
    StreamReader reader = new StreamReader("dayInfo.csv");
    reader.ReadLine();

    while (!reader.EndOfStream)
    {
        var data = reader.ReadLine().Split(',');
        DayInfo day = new DayInfo();

        day.Day = int.Parse(data[0]);
        day.Season = int.Parse(data[1]);
        day.IsWorkingDay = int.Parse(data[2]) == 1;
        day.Weather = int.Parse(data[3]);
        day.Temp = float.Parse(data[4].Replace('.', ','));

        yield return day;
    }
    reader.Close();
}

IEnumerable<BikeSharing> getSharings()
{
    StreamReader reader = new StreamReader("bikeSharing.csv");
    reader.ReadLine();

    while(!reader.EndOfStream)
    {
        var data = reader.ReadLine().Split(',');
        BikeSharing bike = new BikeSharing();

        bike.Day = int.Parse(data[0]);
        bike.Casual = int.Parse(data[1]);
        bike.Registred = int.Parse(data[2]);
        
        yield return bike;
    }
    reader.Close();
}

public class DayInfo
{
    public int Day { get; set; }
    public int Season { get; set; }
    public bool IsWorkingDay { get; set; }
    public int Weather { get; set; }
    public float Temp { get; set; }
}

public class BikeSharing
{
    public int Day { get; set; }
    public int Casual { get; set; }
    public int Registred { get; set; }
}
