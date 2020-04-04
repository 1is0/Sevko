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
            Man man = new Man(4);
            man[0] = new Man("Anastasia", 20, "Belarus");
            man[1] = new Man("Svetlana", 23, "Germany");
            man[2] = new Man();
            man[3] = new Man();
            Console.WriteLine("Enter the name: ");
            man[3].Name = Console.ReadLine();
            CheckStr(man[3].Name);
            Console.WriteLine("Enter the age: ");
            try
            {
                man[3].Age = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Invalid input. Try more");
                Environment.Exit(0);
            }
            Console.WriteLine("Enter the country: ");
            man[3].Country = Console.ReadLine();
            CheckStr(man[3].Country);
            Output(man);
        }
        // Вывод на консоль
        static void Output(Man man)
        {
            for (int i = 0; i < Man.Counter; i++)
            {
                man[i].Print(i);
            }
        }
        // Проверки на ввод
        static void CheckStr(string str)
        {
            for(int i = 0; i < str.Length; i++)
            {
                if (!char.IsLetter(str[i]))
                {
                    Console.WriteLine("Invalid input. Try more");
                    Environment.Exit(0);
                }
            }
        }
    }
}
