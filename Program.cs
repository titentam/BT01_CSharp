using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace _102210021
{
    internal class Program
    {
        static void Main(string[] args)
        {
            QuanLy ql = new QuanLy();
            NhanVien nhanVien1 = new NhanVien
            {
                ID = "11111111",    
                Name = "Phan Thanh Tam",
                DateStartWork = new Date
                {
                    Day = 12,
                    Month =1,
                    Year =2019
                },
                Sex = false,
                Salary = 10
            };
            NhanVien nhanVien2 = new NhanVien
            {
                ID = "12111111",
                Name = "Phan Tam",
                DateStartWork = new Date
                {
                    Day = 12,
                    Month = 10,
                    Year = 2012
                },
                Sex = false,
                Salary = 10
            };
            NhanVien nhanVien3 = new NhanVien
            {
                ID = "13111111",
                Name = "Phan Thanh Tu",
                DateStartWork = new Date
                {
                    Day = 14,
                    Month = 1,
                    Year = 2019
                },
                Sex = true,
                Salary = 10
            };
            NhanVien nhanVien4 = new NhanVien
            {
                ID = "14111111",
                Name = "Phan Thanh Tung",
                DateStartWork = new Date
                {
                    Day = 12,
                    Month = 3,
                    Year = 2019
                },
                Sex = false,
                Salary = 100
            };
            NhanVien nhanVien5 = new NhanVien
            {
                ID = "15111111",
                Name = "Phan Thanh",
                DateStartWork = new Date
                {
                    Day = 4,
                    Month = 1,
                    Year = 2019
                },
                Sex = false,
                Salary = 103
            };
            NhanVien nhanVien6 = new NhanVien
            {
                ID = "16111111",
                Name = "Phan Thanh Tam",
                DateStartWork = new Date
                {
                    Day = 12,
                    Month = 6,
                    Year = 2019
                },
                Sex = true,
                Salary = 10
            };
            NhanVien nhanVien7 = new NhanVien
            {
                ID = "17111111",
                Name = "Thanh Tam",
                DateStartWork = new Date
                {
                    Day = 7,
                    Month = 10,
                    Year = 2019
                },
                Sex = true,
                Salary = 104
            };
            NhanVien nhanVien8 = new NhanVien
            {
                ID = "18111111",
                Name = "Phan Thanh",
                DateStartWork = new Date
                {
                    Day = 24,
                    Month = 1,
                    Year = 2019
                },
                Sex = false,
                Salary = 10
            };
            NhanVien nhanVien9 = new NhanVien
            {
                ID = "19111111",
                Name = "Phan Thanh Tan",
                DateStartWork = new Date
                {
                    Day = 20,
                    Month = 10,
                    Year = 2019
                },
                Sex = false,
                Salary = 10
            };
            ql.ThemNv(nhanVien1);
            ql.ThemNv(nhanVien2);
            ql.ThemNv(nhanVien3);
            ql.ThemNv(nhanVien4);
            ql.ThemNv(nhanVien5);
            ql.ThemNv(nhanVien6);
            ql.ThemNv(nhanVien7);
            ql.ThemNv(nhanVien8);
            ql.ThemNv(nhanVien9);

            ql.ChuongTrinh();
            
            Console.ReadKey();

        }

    }
}
