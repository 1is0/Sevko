using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_6
{
    public struct DataStud
    {
        public int lazinessCoefficient;
        public int chanceOfDeduction;
    }
    class Specialty : Student, IAverageMark, IComparable<Specialty>, ICloneable
    {
        DataStud dataStud;
        public string Spec { get; set; }
        public int Math { get; set; }
        public int Philosophy { get; set; }
        public int HistOfBel { get; set; }
        public Specialty() : base()
        {
            Spec = "IaTP";
            dataStud.lazinessCoefficient = 40;
            dataStud.chanceOfDeduction = 1;
            Math = 10;
            Philosophy = 9;
            HistOfBel = 10;
        }
        public Specialty(string name, int age, string country, string university, Course cor, string specialty, int coeff, int chance, int math, int phil, int hist) : base(name, age, country, university, cor)
        {
            Spec = specialty;
            dataStud.lazinessCoefficient = coeff;
            dataStud.chanceOfDeduction = chance;
            Math = math;
            Philosophy = phil;
            HistOfBel = hist;
        }
        public int CompareTo(Specialty obj)
        {
            if (this.Age > obj.Age)
            {
                return 1;
            }
            if (this.Age < obj.Age)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
        public object Clone()
        {
            return (Specialty)this.MemberwiseClone();
        }
        public override void Print(int i)
        {
            double aver = averMark();
            Console.WriteLine($"{i}. Name: {Name}\n" +
                $"Age: {Age}\n" +
                $"Country: {Country}\n" +
                $"University: {University}\n" +
                $"Specialty: {Spec}\n" +
                $"Course: {(int)Cours}\n" +
                $"Laziness coefficient: {dataStud.lazinessCoefficient}%\n" +
                $"Chance of deduction: {dataStud.chanceOfDeduction}%\n" +
                $"Average mark: {aver.ToString("0.00")}\n" +
                $"Retake exam: {checkRetake()}\n");
        }
        public double averMark() {
            double averMark = 0;
            averMark = (Math + Philosophy + HistOfBel) / 3.0;
            return averMark;
        }
        public string checkRetake()
        {
            if (Math < 4 || Philosophy < 4 || HistOfBel < 4)
            {
                return "yes";
            }
            else
            {
                return "no";
            }
        }
    }
}
