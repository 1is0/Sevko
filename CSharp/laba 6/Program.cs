using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_6
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 3;
            Specialty[] spec = new Specialty[n];
            spec[0] = new Specialty("Misha", 19, "Belarus", "BSUIR", Course.First, "IaTP", 75, 60, 4, 5, 5);
            spec[1] = new Specialty("Inna", 22, "Belarus", "MSLU", Course.Fourth, "MFL", 30, 0, 2, 10, 7);
            spec[2] = new Specialty();
            Array.Sort(spec);
            for (int i = 0; i < n; i++)
            {
                spec[i].Print(i + 1);
            }
        }
    }
}
