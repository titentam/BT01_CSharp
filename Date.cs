using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _102210021
{
    internal class Date
    {
        public int Day { get ; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public static bool Check(int ngay, int thang, int nam)
        {
            switch (thang)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    if (ngay <= 0 || ngay > 31) return false;
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    if (ngay <= 0 || ngay > 30) return false;
                    break;
                case 2:
                    if (nam % 400 == 0 || (nam % 4 == 0 && nam % 100 != 0))
                    {
                        if (ngay <= 0 || ngay > 29) return false;
                    }
                    else if (ngay <= 0 || ngay > 29) return false;
                    break;
                default:
                    return false;
            }
            return true;
        }

        public override string ToString()
        {
            return Convert.ToString(Day) + "/" + Convert.ToString(Month) + "/"+ Convert.ToString(Year);
        }
        public void Nhap()
        {
            nhaplai:
            Console.Write("Nhap ngay: ");
            Day = Convert.ToInt32(Console.ReadLine());
            Console.Write("Nhap thang: ");
            Month = Convert.ToInt32(Console.ReadLine());
            Console.Write("Nhap nam: ");
            Year = Convert.ToInt32(Console.ReadLine());
            if (!Check(Day, Month, Year)) goto nhaplai;
        }
    }
}
