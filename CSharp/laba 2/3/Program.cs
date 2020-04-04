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
            string str = Console.ReadLine();
            str = str.ToUpper();
            int i = 0;
            bool check, exist = false;
            int dec;
            CheckSymb(str);
            while (i < str.Length)
            {
                check = true;
                if (!char.IsWhiteSpace(str[i]))
                {
                    int counter = i;
                    check = CheckHox(str, ref i);
                    if (check)
                    {
                        exist = true;
                        while (counter <= i && counter < str.Length)
                        {
                            Console.Write(str[counter]);
                            counter++;
                        }
                        if (counter == str.Length)
                        {
                            Console.Write(" ");
                        }
                        dec = DecNum(str, i - 1);
                        Console.WriteLine("= " + dec);
                    }
                    i++;
                }
                else
                {
                    i++;
                }
            }
            if (!exist)
            {
                Console.WriteLine("There are no hexadecimal numbers.");
            }
        }
        static bool CheckHox(string str, ref int i)
        {
            bool check = true;
            char[] hex = new char[] { 'A', 'B', 'C', 'D', 'E', 'F' };
            if(str[i] == '0' && str[i + 1] == 'X')
            {
                i += 2;
            }
            while (i < str.Length && !char.IsWhiteSpace(str[i]))
            {
                if (!(char.IsDigit(str[i]) || hex.Contains(str[i])))
                {
                    check = false;
                }
                i++;
            }
            return check;
        }
        static int DecNum(string str, int i)
        {
            double expon = 0;
            int tempDec = 0;
            int dec = 0;
            for(; i >= 0 && !char.IsWhiteSpace(str[i]); i--, expon++)
            {
                tempDec = ConvToDec(str[i]);
                dec += tempDec * (int)Math.Pow(16, expon);
            }
            return dec;
        }
        static void CheckSymb(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (!(char.IsWhiteSpace(str[i]) || char.IsLetterOrDigit(str[i])))
                {
                    Console.WriteLine("The string should consists of English letters, numbers and spaces.");
                    Environment.Exit(0);
                }
            }
        }
        static int ConvToDec(char ch)
        {
            int tempDec = 0;
            if (char.IsDigit(ch))
            {
                tempDec = (int)char.GetNumericValue(ch);
            }
            else
            {
                tempDec = Convert.ToInt32(ch) - 55;
            }
            return tempDec;
        }
    }
}
