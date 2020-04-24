using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_8
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 3;
            Specialty[] spec = new Specialty[n];
            spec[0] = new Specialty("Inna", 22, "Belarus", "MSLU", Course.Fourth, "MFL", 30, 0, 2, 10, -5);
            spec[1] = new Specialty("Misha", 19, "Belarus", "BSUIR", Course.First, "IaTP", 75, 60, 10, 2, 5);
            spec[2] = new Specialty();
            Array.Sort(spec);
            for (int i = 0; i < n; i++)
            {
                try
                {
                    if (((IAverageMark)spec[i]).Math < 0 || ((IAverageMark)spec[i]).Philosophy < 0 || ((IAverageMark)spec[i]).HistOfBel < 0)
                    {
                        throw new Exception();
                    }
                }
                catch
                {
                    spec[i].NotifyMark += mes => Console.ForegroundColor = ConsoleColor.Red;
                }
                try
                {
                    if (spec[i].checkRetake() == "Yes" || spec[i].checkRetake() == "Unknown")
                    {
                        throw new Exception();
                    }
                }
                catch
                {
                    spec[i].NotifyRetake += mes => Console.ForegroundColor = ConsoleColor.Red;
                }

                spec[i].NotifyMark += delegate (string mes)
                {
                    Console.WriteLine(mes);
                };
                spec[i].NotifyRetake += delegate (string mes)
                {
                    Console.WriteLine(mes);
                };
                spec[i].Print(i + 1);
            }
        }
    }
}
