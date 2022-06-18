using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    public class Clouds
    {
        public int all { get; set; }
    }

    public class Coord
    {
        public double lon { get; set; }
        public double lat { get; set; }
    }

    public class Main
    {
        public double temp { get; set; }
        public double feels_like { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
        public int pressure { get; set; }
        public int humidity { get; set; }
    }

    public class Root
    {
        public Coord coord { get; set; }
        public List<Weather> weather { get; set; }
        public string @base { get; set; }
        public Main main { get; set; }
        public int visibility { get; set; }
        public Wind wind { get; set; }
        public Clouds clouds { get; set; }
        public int dt { get; set; }
        public Sys sys { get; set; }
        public int timezone { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int cod { get; set; }
        public DateTime FromMS(long microSec)
        {
            DateTime day = new DateTime(1970, 1, 1,0,0,0,0,System.DateTimeKind.Utc).ToLocalTime();
            day = day.AddSeconds(microSec).ToLocalTime();
            return day;
        }
        public int KelvinCensius(double d, bool kelvin = false)
        {
            return (int)(kelvin ? (d - 273.15) : (d + 273.15));
        }

        public int windspeed(double[] data)
        {
            double temp = data[0];
            int pos = 0;
            for (int i = 0; i < 2; i++)
            {
                if (temp < data[i + 1])
                {
                    temp = data[i + 1];
                    pos = i + 1;
                }
            }
                return pos;
        }
        public void ShowMenu1()
        {
            Console.Clear();
            Console.WriteLine(" ------------------------");
            Console.WriteLine("|        Welcome          |");
            Console.WriteLine("  Please Enter to optain: |");
            Console.WriteLine("| 1- Weather              |");
            Console.WriteLine("| 2- Sun rise and set Time|");
            Console.WriteLine("| 3- Temperature (°C)     |");
            Console.WriteLine("| 4- the more windy       |");
            Console.WriteLine("| 5- humidity and pressure|");
            Console.WriteLine("---------------------------");
        }
    }

    public class Sys
    {
        public int type { get; set; }
        public int id { get; set; }
        public string country { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
    }

    public class Weather
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

    public class Wind
    {
        public double speed { get; set; }
        public int deg { get; set; }
        public double gust { get; set; }
    }

    
}
