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
            Specialty spec = new Specialty(3);
            spec[0] = new Specialty();
            spec[1] = new Specialty("Misha", 19, "Belarus", "BSUIR", Course.First, "IaTP", 75, 60, 4, 5, 5);
            spec[2] = new Specialty("Inna", 22, "Belarus", "MSLU", Course.Fourth, "MFL", 30, 0, 2, 10, 7);
            spec[0].Print(1);
            spec[1].Print(2);
            spec[2].Print(3);
        }
    }
}
