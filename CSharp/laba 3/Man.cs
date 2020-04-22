using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_3
{
    class Man
    {
        public int Counter { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public Man[] data;
        // Конструкторы
        public Man()
        {
            Name = "Polina";
            Age = 18;
            Country = "Belarus";
        }
        public Man(int number)
        {
            data = new Man[number];
            Counter = number;
        }
        public Man(string name, int age, string country)
        {
            Age = age;
            Name = name;
            Country = country;
        }
        // Индексатор
        public Man this[int index]
        {
            get
            {
                return data[index];
            }
            set
            {
                data[index] = value;
            }
        }
        // Методы
        public void Print(int i)
        {
            Console.WriteLine($"{i}. Name: {Name}, Age: {Age}, Country: {Country}\n");
        }
    }
}