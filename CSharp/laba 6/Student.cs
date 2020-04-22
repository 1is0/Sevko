using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_6
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
        public string University { get; set; }
        public Course Cours { get; set; }
        public Student() : base()
        {
            University = "BSUIR";
            Cours = Course.First;
        }
        public Student(int number)
        {
            data = new Student[number];
        }
        public Student(string name, int age, string country, string university, Course cor) : base(name, age, country)
        {
            University = university;
            Cours = cor;
        }
        public override void Print(int i)
        {
            Console.WriteLine($"{i}. Name: {Name}, Age: {Age}, Country: {Country}\n" +
           $"University: {University}, Course: {(int)Cours}\n");
        }
    }
}
