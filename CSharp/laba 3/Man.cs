using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_3
{
    class Man
    {
        static public int Counter = 0;
        int age;
        string name;
        string country;
        public Man[] data;
        // Конструкторы
        public Man()
        {
            name = "Polina";
            age = 18;
            country = "Belarus";
        }
        public Man(int number)
        {
            data = new Man[number];
            Counter = number;
        }
        public Man(string name, int age, string country)
        {
            this.age = age;
            this.name = name;
            this.country = country;
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
        // Свойства
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }
        public int Age
        {
            get
            {
                return age;
            }

            set
            {
                age = value;
            }
        }
        public string Country
        {
            get
            {
                return country;
            }

            set
            {
                country = value;
            }
        }
        // Методы
        public void Print(int i)
        {
            Console.WriteLine((i + 1) + ". " + name + " " + age + " " + country);
        }
    }
}
