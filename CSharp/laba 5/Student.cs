using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_5
{
    enum Course
    {
        First = 1,
        Second,
        Third,
        Fourth,
        Fifth
    }
    class Student : Man
    {
        public struct DataStud
        {
            public int lazinessCoefficient;
            public int chanceOfDeduction;
        }
        public string University { get; set; }
        public string Specialty { get; set; }
        public Course Cours { get; set; }
        public Student() : base()
        {
            University = "BSUIR";
            Specialty = "IaTP";
            Cours = Course.First;
        }
        public Student(int number)
        {
            data = new Student[number];
            Counter = number;
        }
        public Student(string name, int age, string country, string university, string specialty) : base(name, age, country)
        {
            University = university;
            Specialty = specialty;
            Cours = Course.Second;
        }
        public override void Print(int i)
        {
            Console.WriteLine($"{i + 1}. Name: {Name}, Age: {Age}, Country: {Country}\n" +
                $"University: {University}, Specialty: {Specialty}, Course: {(int)Cours}\n");
        }
    }
}
