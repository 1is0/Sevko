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
            Man man = new Man(2);
            man[0] = new Man();
            man[1] = new Man("Alina", 19, "Belarus");
            Console.WriteLine("MANS");
            Output(man); 
            Student stud = new Student(2);
            stud[0] = new Student();
            stud[1] = new Student("Alina", 19, "Belarus", "BSMU", "Pediatric");
            Console.WriteLine("STUDENTS");
            Output(stud);
            IaTP spec1 = new IaTP();
            Console.WriteLine("STUDENTS OF DIFFERENT SPECIALTIES");
            spec1.Print(0);
            Pediatric spec2 = new Pediatric("Alina", 19, "Belarus", "BSMU", "Pediatric", 80, 50);
            spec2.Print(1);
            ECF spec3 = new ECF("Roman", 19, "Belarus", "BSUIR", "ECF", 100, 100);
            spec3.Print(2);
        }
        static void Output(Student stud)
        {
            for (int i = 0; i < Student.Counter; i++)
            {
                stud[i].Print(i);
            }
        }
        static void Output(Man man)
        {
            for (int i = 0; i < Man.Counter; i++)
            {
                man[i].Print(i);
            }
        }
    }
}
