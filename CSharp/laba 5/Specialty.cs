using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_5
{
    public struct DataStud
    {
        public int lazinessCoefficient;
        public int chanceOfDeduction;
    }
    class Specialty : Student
    {
        DataStud dataStud;
        public string Spec { get; set; }
        public Specialty(int number)
        {
            data = new Student[number];
        }
        public Specialty() : base()
        {
            Spec = "IaTP";
            dataStud.lazinessCoefficient = 40;
            dataStud.chanceOfDeduction = 1;
        }
        public Specialty(string name, int age, string country, string university, Course cor, string specialty, int coeff, int chance) : base(name, age, country, university, cor)
        {
            Spec = specialty;
            dataStud.lazinessCoefficient = coeff;
            dataStud.chanceOfDeduction = chance;
        }
        public override void Print(int i)
        {
            Console.WriteLine($"{i}. Name: {Name}\n" +
                $"Age: {Age}\n" +
                $"Country: {Country}\n" +
                $"University: {University}\n" +
                $"Specialty: {Spec}\n" +
                $"Course: {(int)Cours}\n" +
                $"Laziness coefficient: {dataStud.lazinessCoefficient}%\n" +
                $"Chance of deduction: {dataStud.chanceOfDeduction}%\n");
        }
    }
}

