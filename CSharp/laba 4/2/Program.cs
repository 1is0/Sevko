using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace ConsoleApp1
{
    class Program
    {
        [DllImport(@"C:\Users\polin\source\repos\2 sem\C#\laba 4\2\MYDLL\Debug\MYDLL.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern double Area(int radius);

        [DllImport(@"C:\Users\polin\source\repos\2 sem\C#\laba 4\2\MYDLL\Debug\MYDLL.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern double Circumference(int radius);

        [DllImport(@"C:\Users\polin\source\repos\2 sem\C#\laba 4\2\MYDLL\Debug\MYDLL.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern double SectorArea(int radius, int angle);
        static void Main(string[] args)
        {
            Calculation();
            Console.ReadKey();
        }
        public static void Calculation()
        {
            int radius = 10;
            int angle = 60;
            Console.WriteLine($"Area of a circle is {Area(radius)}\n");
            Console.WriteLine($"Circumference is {Circumference(radius)}\n");
            Console.WriteLine($"Circle sector area is {SectorArea(radius, angle)}\n");
        }
    }
}

