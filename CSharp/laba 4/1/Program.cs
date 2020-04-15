using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"About CPU:\n{System.CPUInform()}");
            Console.WriteLine($"About memory:\n{System.MemoryInform()}");
            Console.ReadKey();
        }
    }
}
