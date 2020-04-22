using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("MANS");
            Man man = new Man(2);
            man[0] = new Man();
            man[1] = new Man("Roman", 19, "Belarus");
            man[0].Print(1);
            man[1].Print(2);
            Console.WriteLine("STUDENTS");
            Student stud = new Student(2);
            stud[0] = new Student();
            stud[1] = new Student("Roman", 19, "Belarus", "BSMU", Course.Second);
            stud[0].Print(1);
            stud[1].Print(2);
            Console.WriteLine("STUDENTS OF DIFFERENT SPECIALTIES");
            Specialty spec = new Specialty(2);
            spec[0] = new Specialty();
            spec[1] = new Specialty("Roman", 19, "Belarus", "BSMU", Course.Second, "Pediatric", 80, 60);
            spec[0].Print(1);
            spec[1].Print(2);
        }
    }
}
