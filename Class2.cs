using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Class2
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            Program p = new Program();
            double[] tab = new double[3];
            string[] land = {"Morocco", "Oslo", "Jakarta","New York","Tokyo","Paris","Kiev","Moscow","Berlin"};
            try
            {
                var s = p.getRes(land[0]);
                Root t = await s;
                Console.WriteLine("What’s the weather like in Morocco ?");
                Console.WriteLine("the weather in " + t.name + " is " + t.weather[0].main);
                Console.WriteLine("");
                
                s = p.getRes(land[1]);
                t = await s;
                Console.WriteLine("When will the sun rise and set today in Oslo (in readable, UTC time)?");
                Console.WriteLine("the sunset is at : " + t.FromMS(t.sys.sunset).ToShortTimeString());
                Console.WriteLine("the sunrise is at : " + t.FromMS(t.sys.sunrise).ToShortTimeString());
                Console.WriteLine("");

                s = p.getRes(land[2]);
                t = await s;
                Console.WriteLine("What’s the temperature in Jakarta (in Celsius)");
                Console.WriteLine("the temperature in " + t.name + " is " + t.KelvinCensius(t.main.temp, true) +"°C");
                Console.WriteLine("");


                Console.WriteLine(" Where is it more windy, New-York, Tokyo or Paris?");
                for (int i = 0; i < 3; i++)
                {
                    s = p.getRes(land[i+3]);
                    t = await s;
                    tab[i] = t.wind.speed;
                }
                int pos = t.windspeed(tab);
                s = p.getRes(land[pos+3]);
                t = await s;
                Console.WriteLine(" the place with the more windy is : " + t.name);
                Console.WriteLine("");




                Console.WriteLine("What is the humidity and pressure like in Kiev, Moscow and Berlin?");
                for (int i = 6; i < 9; i++)
                {
                    s = p.getRes(land[i]);
                    t = await s;
                    Console.WriteLine("the humidity in " + t.name + " is " + t.main.humidity +"%"+ " and the pressure is : " + t.main.pressure + " hPa");
                    Console.WriteLine("");
                }

            }
            catch(Exception e)
            {
                Console.WriteLine("Data invalid");
            }

        }

    }
}
