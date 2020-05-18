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
            Man man = new Man(3);
            man[0] = new Man("Anastasia", 20, "Belarus");
            man[1] = new Man();
            man[2] = Input();
            for (int i = 0; i < 3; i++)
            {
                man[i].Print(i + 1);
            }
        }
        static Man Input()
        {
            string name;
            string country;
            string age;
            Console.WriteLine("Enter your name:");
            name = Console.ReadLine();
            Console.WriteLine("Enter your age:");
            age = Console.ReadLine();
            Console.WriteLine("Enter your country:");
            country = Console.ReadLine();
            if(!Int32.TryParse(age, out int intAge) || name.Any(x => !char.IsLetter(x)) || country.Any(x => !char.IsLetter(x)))
            {
                Console.WriteLine("Wrong input.");
                Environment.Exit(0);
            }
            return new Man(name, intAge, country);
        }
    }
}
