using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace _102210021
{
    internal class NhanVien
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public Date DateStartWork { get; set; }
        public bool Sex { get; set; }
        public double Salary { get; set; }

        public override string ToString()
        {
            return "ID: " + ID + " |Name: " + Name + " |DSW: " + DateStartWork.ToString()
                + " |Sex: " + (Sex ? "Nu" : "Nam") + " |Salary: " + Convert.ToString(Salary);
        }
        public void Nhap()
        {
            nhaplai:
            Console.Write("Nhap ma(8 ki tu): ");
            ID = Console.ReadLine();
            if (ID.Length != 8) goto nhaplai;
            Console.Write("Nhap ten: ");
            Name = Console.ReadLine();
            Console.WriteLine("Nhap ngay vao lam: ");
            Date tmp = new Date();
            tmp.Nhap();
            DateStartWork = tmp;
            //DateStartWork.Nhap();
            Console.Write("Nhap gioi tinh(0 Nam, 1 Nu): ");
            int choice;
            Int32.TryParse(Console.ReadLine(), out choice);
            Sex = choice == 0 ? false : true;
            Console.Write("Nhap luong: ");
            Salary = Convert.ToDouble(Console.ReadLine());
        }

    }
}
