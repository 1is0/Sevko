using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_8
{
    class Man
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        // Конструкторы
        public Man()
        {
            Name = "Polina";
            Age = 18;
            Country = "Belarus";
        }
        public Man(string name, int age, string country)
        {
            Age = age;
            Name = name;
            Country = country;
        }
        // Методы
        public virtual void Print(int i)
        {
            Console.WriteLine($"{i}. Name: {Name}, Age: {Age}, Country: {Country}\n");
        }
    }
}