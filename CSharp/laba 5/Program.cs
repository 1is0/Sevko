using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("STUDENTS OF DIFFERENT SPECIALTIES");
            Specialty spec = new Specialty(2);
            spec[0] = new Specialty();
            spec[1] = new Specialty("Roman", 19, "Belarus", "BSMU", Course.Second, "Pediatric", 80, 60);
            for (int i = 0; i < 2; i++)
            {
                spec[i].Print(i + 1);
            }
        }
    }
}
