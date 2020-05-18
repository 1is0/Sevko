using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_8
{
    enum Course
    {
        First = 1,
        Second,
        Third,
        Fourth,
        Fifth
    }
    abstract class Student : Man
    {
        public string University { get; set; }
        public Course Cours { get; set; }
        public Student() : base()
        {
            University = "BSUIR";
            Cours = Course.First;
        }
        public Student(string name, int age, string country, string university, Course cor) : base(name, age, country)
        {
            University = university;
            Cours = cor;
        }
    }
}
