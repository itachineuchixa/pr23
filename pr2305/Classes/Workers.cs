using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr2305.Classes
{
    class Workers
    {
        const int l_name  = 30;
        int birth_year;
        double pay;
        public string name { get; set; }
        public int Birth_year { get { return birth_year; } set { if (value > 0) value = birth_year; else  throw new FormatException(); } }
        public double Pay { get { return pay; } set { if (value > 0) value = pay; else throw new FormatException(); } }
        public Workers() { name = "Anon"; birth_year = 1999; pay = 5000;
        }
        public Workers(string s)
        {
            name = s.Substring(0, l_name);
            birth_year = Convert.ToInt32(s.Substring(l_name, 4));
            pay = Convert.ToDouble(s.Substring(l_name, +4));
            if (birth_year < 0) throw new FormatException();
            if (pay < 0) throw new FormatException();
        }
        public override string ToString()
        {
            return string.Format("Name: {0,30} birth: {1} pay: {2:F2}", name, birth_year, pay);
        }
        public static double operator +(Workers worker, double a)
        {
            worker.pay += a;
            return worker.pay;
        }
        public static double operator +(double a, Workers worker)
        {
            worker.pay += a;
            return worker.pay;
        }
        public static double operator -(double a, Workers worker)
        {
            worker.pay -= a;
            return worker.pay;
        }
        public static double operator -(Workers worker, double a)
        {
            worker.pay -= a;
            return worker.pay;
        }
    }
}
