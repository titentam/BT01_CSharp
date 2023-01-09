using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Serialization;

namespace _102210021
{
    internal class QuanLy
    {
        private ListClone<NhanVien> list = new ListClone<NhanVien>();
        public delegate bool MyDelegate(string name1, string name2);
        public bool Acs(string name1, string name2)
        {
            return String.Compare(name1, name2) < 0;
        }
        public bool Desc(string name1, string name2)
        {
            return String.Compare(name1, name2) > 0;
        }
        public void QSort(int left, int right, MyDelegate myD)
        {
            int sz = list.Size();
            if (left >= sz || left < 0 || right >= sz || right < 0)
            {
                throw new ArgumentOutOfRangeException("Ngoai pham vi!");
            }
            int key = (left + right) / 2;
            int i = left, j = right;
            while (i <= j)
            {
                while (myD(list[i].ID, list[key].ID)) i++;
                while (myD(list[key].ID, list[j].ID)) j--;
                if (i <= j)
                {
                    // swap i, j
                    (list[i], list[j]) = (list[j], list[i]);
                    i++; j--;
                }
            }
            if (left < j)
                QSort(left, i, myD);
            if (i < right)
                QSort(i, right, myD);
        }
        public int compare(string a, string b)
        {
            int s1 = a.Length;
            int s2 = b.Length;
            int i = 0, j = 0;
            while (i < s1 && j < s2)
            {
                if (a[i] == b[j])
                {
                    i++; j++;
                }
                else
                {
                    break;
                }
            }
            if (i == a.Length && j == b.Length) return 0;
            return a[i] - b[j];
        }
        public int InterpolationSearch(string ID)
        {
            int sz = list.Size();
            QSort(0, sz - 1, Acs);
            int left = 0;
            int right = sz - 1;
            while (compare(list[left].ID, list[right].ID) <= 0 && compare(ID, list[left].ID) >= 0 && compare(ID, list[right].ID) <= 0)
            {
                double val1 = (double)(compare(ID, list[left].ID) / compare(list[right].ID, list[left].ID));
                int val2 = right - left;
                int Search = left + (int)val1 * val2;

                if (compare(list[Search].ID, ID) == 0)
                    return Search;

                if (compare(list[Search].ID, ID) < 0)
                    left = Search + 1;
                else
                    right = Search - 1;
            }
            return -1;
        }
        public void XoaNV()
        {
            XuatDs();
            Console.Write("\t\tNHAP MA NHAN VIEN CAN XOA: ");
            string manv;
            manv = Console.ReadLine();
            int idx = InterpolationSearch(manv);
            if (idx != -1)
            {
                try
                {
                    list.RemoveAt(idx);
                    Console.WriteLine("XOA THANH CONG!");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
            else
            {
                Console.WriteLine("KHONG TIM THAY NHAN VIEN CAN XOA");
            }
        }
        public void SapXep()
        {
            try
            {
                Console.WriteLine("\t\tSAP XEP\n");
                Console.WriteLine("\t1 Sap xep tang dan theo ma");
                Console.WriteLine("\t2 Sap xep giam dan theo ma");
                Console.Write("Nhap lua chon: ");
                int c = Convert.ToInt32(Console.ReadLine());
                if (c == 1)
                {

                    QSort(0, list.Size() - 1, Acs);
                    XuatDs();
                    Console.ReadKey();

                }
                else if (c == 2)
                {
                    QSort(0, list.Size() - 1, Desc);
                    XuatDs();
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("LUA CHON KHONG DUNG");
                    Console.ReadKey();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        public int TimKiem()
        {
            Console.WriteLine("\t\tTIM KIEM \n");
            Console.Write("\tNhap ma nhan vien: ");
            string manv = Console.ReadLine();
            int pos = InterpolationSearch(manv);
            if (pos == -1)
            {
                Console.WriteLine("\tKHONG TIM THAY");
            }
            else
            {
                Console.WriteLine("\tNhan vien co ma: {0} o vi tri {1}", manv, pos);
                Console.WriteLine(list[pos].ToString());
                Console.ReadKey();
                return pos;
            }
            Console.ReadKey();
            return -1;
        }
        public void CapNhat()
        {
            Console.WriteLine("\t\tCAP NHAT \n");
            int res = TimKiem();
            if (res != -1)
            {           
                NhanVien tmp = new NhanVien();
                tmp = list[res];
                Console.Clear();
                Console.WriteLine(list[res].ToString());
                Console.WriteLine("CHINH SUA THONG TIN NHAN VIEN");
                Console.WriteLine("1. Chinh ten");
                Console.WriteLine("2. Chinh ngay vao lam");
                Console.WriteLine("3. Chinh gioi tinh");
                Console.WriteLine("0. Tro ve");
                Console.Write("Nhap lua chon: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            Console.Write("Nhap ten moi: ");
                            string newName = Console.ReadLine();
                            tmp.Name = newName;
                            Console.WriteLine("CHINH SUA THANH CONG!");
                            Console.ReadKey();
                            list[res] = tmp;
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Nhap ngay vao lam: ");
                            Date newD = new Date();
                            newD.Nhap();
                            tmp.DateStartWork = newD;
                            Console.WriteLine("CHINH SUA THANH CONG!");
                            Console.ReadKey();
                            list[res] = tmp;
                            break;

                        }
                    case 3:
                        {
                            Console.Write("Nhap gioi tinh(0. nam, 1. nu): ");
                            int c;
                            Int32.TryParse(Console.ReadLine(), out c);
                            tmp.Sex = c == 0 ? false : true;
                            Console.WriteLine("CHINH SUA THANH CONG!");
                            Console.ReadKey();
                            list[res] = tmp;
                            break;
                        }
                    case 0:
                        break;
                    default:
                        {
                            Console.WriteLine("LUA CHON NAY KHONG CO TRONG MENU!");
                            Console.WriteLine("VUI LONG NHAP LAI!");
                            Console.ReadKey();
                            break;
                        }
                }
            }
        }
        public void XuatDs()
        {
            Console.WriteLine("\t\tDANH SACH NHAN VIEN\n");
            list.Show();
        }
        public void ThemNv()
        {
            Console.WriteLine("\t\tNHAP NHAN VIEN CAN THEM\n");
            NhanVien nv = new NhanVien();
            nv.Nhap();
            list.AddLast(nv);
            Console.WriteLine("\n\t\tTHEM THANH CONG\n");
        }
        public void ThemNv(NhanVien nv)
        {
           list.AddLast(nv);
        }
        public void ChuongTrinh()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\t\tQUAN LI DANH SACH NHAN VIEN!");
                Console.WriteLine("7.  Thoat");
                Console.WriteLine("1.  Xuat danh sach");
                Console.WriteLine("2.  Them nhan vien");
                Console.WriteLine("3.  Xoa nhan vien");
                Console.WriteLine("4.  Sap xep");
                Console.WriteLine("5.  Tim kiem nhan vien");
                Console.WriteLine("6.  Cap nhat thong tin nhan vien");
                Console.WriteLine("Nhap lua chon: ");
                int choice;
                Int32.TryParse(Console.ReadLine(), out choice);
                switch (choice)
                {
                    case 1:
                        {
                            Console.Clear();
                            XuatDs();
                            Console.ReadKey();
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            ThemNv();
                            Console.ReadKey();
                            break;
                        }
                    case 3:
                        {
                            Console.Clear();
                            XoaNV();
                            Console.ReadKey();
                            break;
                        }

                    case 4:
                        {
                            Console.Clear();
                            SapXep();
                            break;
                        }
                     case 5:
                        {
                            Console.Clear();
                            TimKiem();
                            break;
                        }

                     case 6:
                        {
                            Console.Clear();
                            CapNhat();
                            break;
                        }


                    case 7: return;
                    case 0:
                        {
                            Console.Clear();
                            Console.WriteLine("LUA CHON NAY KHONG CO TRONG MENU!");
                            Console.WriteLine("VUI LONG NHAP LAI!");
                            Console.ReadKey();
                            break;
                        }
                        
                }
            }
        }

    }
}
