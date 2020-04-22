using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_5
{
    class Pediatric : Student
    {
        DataStud dataStud;
        public Pediatric(string name, int age, string country, string university, string specialty, int coeff, int chance) : base(name, age, country, university, specialty)
        {
            dataStud.lazinessCoefficient = coeff;
            dataStud.chanceOfDeduction = chance;
        }
        public override void Print(int i)
        {
            Console.WriteLine($"{i + 1}. Name: {Name}, Age: {Age}, Country: {Country}\n" +
                $"University: {University}, Specialty: {Specialty}, Course: {(int)Cours}\n" +
                $"Laziness coefficient: {dataStud.lazinessCoefficient}%, Chance of deduction: {dataStud.chanceOfDeduction}%\n");
        }
    }
}
