using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_5
{
    class IaTP : Student
    {
        DataStud dataStud;
        public IaTP() : base()
        {
            dataStud.lazinessCoefficient = 40;
            dataStud.chanceOfDeduction = 1;
        }
        public override void Print(int i)
        {
            Console.WriteLine($"{i + 1}. Name: {Name}, Age: {Age}, Country: {Country}\n" +
                $"University: {University}, Specialty: {Specialty}, Course: {(int)Cours}\n" +
                $"Laziness coefficient: {dataStud.lazinessCoefficient}%, Chance of deduction: {dataStud.chanceOfDeduction}%\n");
        }
    }
}
