using System;
using System.Text.RegularExpressions;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace laba_7
{
    class Number : IComparable
    {
        public int Integer { get; set; }
        public int NatNum { get; set; }
        
        public Number() : this(1, 1) { }

        public Number(int i, int n)
        {
            Integer = i;
            NatNum = n;
        }

        public static Number operator +(Number a) => a;
        public static Number operator -(Number a) => new Number(-a.Integer, a.NatNum);
        public static Number operator +(Number a, Number b)
            => new Number(a.Integer * b.NatNum + b.Integer * a.NatNum, a.NatNum * b.NatNum);
        public static Number operator -(Number a, Number b)
            => a + (-b);
        public static Number operator *(Number a, Number b)
            => new Number(a.Integer * b.Integer, a.NatNum * b.NatNum);
        public static Number operator /(Number a, Number b)
        {
            if (b.Integer != 0)
            {
                return new Number(a.Integer * b.NatNum, a.NatNum * b.Integer);
            }
            else
            {
                throw new Exception("Denominator cannot be zero.");
            }
        }
        public static bool operator >(Number a, Number b)
            => (double)(a.Integer / a.NatNum) > (double)(b.Integer / b.NatNum);
        public static bool operator <(Number a, Number b)
            => (double)(a.Integer / a.NatNum) < (double)(b.Integer / b.NatNum);
        public static bool operator >=(Number a, Number b)
            => (double)(a.Integer / a.NatNum) >= (double)(b.Integer / b.NatNum);
        public static bool operator <=(Number a, Number b)
            => (double)(a.Integer / a.NatNum) <= (double)(b.Integer / b.NatNum);
        public static bool operator ==(Number a, Number b)
            => a.Equals(b);
        public static bool operator !=(Number a, Number b)
            => !a.Equals(b);

        public override bool Equals(Object obj)
        {
            if ((obj == null))
            {
                return false;
            }
            Number p = obj as Number;
            return (double)(p.Integer / p.NatNum) == (double)(this.Integer / this.NatNum);
        }
        public override int GetHashCode()
            => Tuple.Create(Integer, NatNum).GetHashCode();

        public void Print()
        {
            Console.WriteLine(((double)Integer / NatNum).ToString("0.00"));
            if (Integer > NatNum && Integer % NatNum != 0)
            {
                int intPart = Integer / NatNum;
                int numOfRealPart = Integer % NatNum;
                Console.WriteLine(intPart + " " + numOfRealPart + "/" + NatNum);
            }
            if(NatNum == 1)
            {
                Console.WriteLine(Integer);
            }
            Console.WriteLine(ValueOutput() + "\n");
        }

        public string ValueOutput()
        {
            return Integer + "/" + NatNum;
        }

        public static Number FromStrToNumber(string str)
        {
            Number num = new Number();
            Regex regex1 = new Regex(@"\d\s{1}\d\/\d");
            Regex regex2 = new Regex(@"\d\/\d");
            if (Int32.TryParse(str, out int res1))
            {
                num.Integer = res1;
            }
            else if (Double.TryParse(str, NumberStyles.Any, CultureInfo.InvariantCulture, out double res2))
            {
                string[] numStr = new string[2];
                numStr = str.Split('.');
                num.NatNum = (int)Math.Pow(10, numStr[1].Length);
                num.Integer = Int32.Parse(numStr[0]) * num.NatNum + Int32.Parse(numStr[1]);
            }
            else if (regex1.Matches(str).Count == 1)
            {
                string[] numStr = new string[3];
                numStr = str.Split(new Char[] { ' ', '/' });
                num.NatNum = Int32.Parse(numStr[2]);
                num.Integer = Int32.Parse(numStr[0]) * num.NatNum + Int32.Parse(numStr[1]);
            }
            else if (regex2.Matches(str).Count == 1)
            {
                string[] numStr = new string[2];
                numStr = str.Split('/');
                num.Integer = Int32.Parse(numStr[0]);
                num.NatNum = Int32.Parse(numStr[1]);
            }
            else
            {
                throw new Exception("Cannot be converted to a number.");
            }
            return num;

        }

        int IComparable.CompareTo(object obj)
        {
            Number p = obj as Number;
            if (p != null)
            {
                if ((double)this.Integer / this.NatNum > (double)p.Integer / p.NatNum)
                {
                    return 1;
                }
                if ((double)this.Integer / this.NatNum < (double)p.Integer / p.NatNum)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                throw new Exception("Impossible to compare two objects.");
            }
        }

        public static implicit operator int(Number num)
            => (int)Math.Round((double)num.Integer / num.NatNum);
        public static implicit operator double(Number num)
            => ((double)num.Integer / num.NatNum);
    }
}
