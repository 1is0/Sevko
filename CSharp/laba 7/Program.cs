using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_7
{
    class Program
    {
        static void Main(string[] args)
        {
            Number a = new Number(6, 5);
            Number b = new Number(4, 3);
            Number c = new Number();
            string x = "1 6/18";
            Console.WriteLine("a:");
            a.Print();
            Console.WriteLine("b:");
            b.Print();
            Console.WriteLine($"x = {x}\n");
            Console.WriteLine($"c = a + b = {(c = a + b).ValueOutput()}");
            Console.WriteLine($"c = a - b = {(c = a - b).ValueOutput()}");
            Console.WriteLine($"c = - a - b = {(c = - a - b).ValueOutput()}");
            Console.WriteLine($"c = a * b = {(c = a * b).ValueOutput()}");
            Console.WriteLine($"c = a / b = {(c = a / b).ValueOutput()}");
            Console.WriteLine($"a > b {(a > b)}");
            Console.WriteLine($"c < a {(c < a)}");
            Console.WriteLine($"b == x {(b == Number.FromStrToNumber(x))}\n");
            
            string[] str = new string[4];
            str[0] = "1.111";
            str[1] = "32/45";
            str[2] = "36 9/34";
            str[3] = "678";
            Number[] arrNum = new Number[4];
            for(int i = 0; i < 4; i++)
            {
                arrNum[i] = Number.FromStrToNumber(str[i]);
            }
            Array.Sort(arrNum);
            double[] arrDouble = new double[4];
            for (int i = 0; i < 4; i++)
            {
                arrDouble[i] = arrNum[i];
            }
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"{arrNum[i].ValueOutput()} = {arrDouble[i]}");
            }
        }
    }
}
