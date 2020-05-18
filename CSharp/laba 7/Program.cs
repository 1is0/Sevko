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
            Console.WriteLine("Enter the numerator and denominator of the FIRST number with a space.");
            Number a = InputNumber();
            Console.WriteLine("Enter the numerator and denominator of the SECOND number with a space.");
            Number b = InputNumber();

            Number c = new Number();
            string x = "1 6/18";
            Console.WriteLine("\na:");
            a.Print();
            Console.WriteLine("b:");
            b.Print();
            Console.WriteLine($"x = {x}\n");
            Console.WriteLine($"c = a + b = {(c = a + b).ValueOutput()}");
            Console.WriteLine($"c = a - b = {(c = a - b).ValueOutput()}");
            Console.WriteLine($"c = - a - b = {(c = -a - b).ValueOutput()}");
            Console.WriteLine($"c = a * b = {(c = a * b).ValueOutput()}");
            Console.WriteLine($"c = a / b = {(c = a / b).ValueOutput()}");
            Console.WriteLine($"a > b {(a > b)}");
            Console.WriteLine($"c < a {(c < a)}");
            Console.WriteLine($"b == x {(b == Number.FromStrToNumber(x))}\n");

            string[] str = new string[4];
            str[0] = "1.11331";
            str[1] = "32/45";
            str[2] = "36 9/34";
            str[3] = "678";

            Number[] arrNum = new Number[4];
            for (int i = 0; i < 4; i++)
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
        static Number InputNumber()
        {
            string enterStr;
            String[] number;
            bool success;
            int integ = 0;
            int nat = 0;

            enterStr = Console.ReadLine();
            number = enterStr.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (number.Length != 2)
            {
                Console.WriteLine("Wrong input.");
                Environment.Exit(0);
            }
            success = Int32.TryParse(number[0], out integ) && Int32.TryParse(number[1], out nat);
            if (!success)
            {
                Console.WriteLine("Wrong input.");
                Environment.Exit(0);
            }
            if (nat == 0)
            {
                Console.WriteLine("Denominator cannot be zero.");
                Environment.Exit(0);
            }
            return new Number(integ, nat);
        }
    }
}
