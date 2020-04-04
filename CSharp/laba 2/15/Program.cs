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
            char[] vow = new char[] { 'a', 'e', 'y', 'u', 'i', 'o' };
            StringBuilder str = new StringBuilder(Console.ReadLine());
            bool exist = false;
            Check(str);
            for(int i = str.Length - 1; i > 0; i--)
            {
                if (vow.Contains(str[i - 1]))
                {
                    exist = true;
                    if (str[i] == 122)
                    {
                        str[i] = (char)97;
                    }
                    else
                    {
                        str[i] = (char)(str[i] + 1);
                    }
                }
            }
            if (!exist)
            {
                Console.WriteLine("There are no vowel letters.");
            }
            else
            {
                Console.WriteLine(str);
            }
        }
        static void Check(StringBuilder str)
        {
            for(int i = 0; i < str.Length; i++)
            {
                if (!(Char.IsLower(str[i]) || Char.IsWhiteSpace(str[i])))
                {
                    Console.WriteLine("String should consists of English lowercase letters amd white spaces.");
                    Environment.Exit(0);
                }
            }
        }
    }
}
