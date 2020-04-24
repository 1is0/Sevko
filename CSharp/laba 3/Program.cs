using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Man man = new Man(2);
            man[0] = new Man("Anastasia", 20, "Belarus");
            man[1] = new Man();
            for (int i = 0; i < 2; i++)
            {
                man[i].Print(i + 1);
            }
        }
    }
}
