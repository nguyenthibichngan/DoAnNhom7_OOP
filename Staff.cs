using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DoAnCuoiKy
{
    public abstract class Staff
    {
        private string id;
        private string position;
        private string name;
        private int age;
        private double coffSalary;
        private int workDate;
        private string loginName;
        private string password;

        public string Id { get { return id; } set { id = value; } }
        public string Position { get { return position; } set { position = value; } }
        public string Name { get { return name; } set { name = value; } }
        public int Age { get { return age; } set { age = value; } }
        public double CoffSalary { get { return coffSalary; } set { coffSalary = value; } }
        public int WorkDate { get { return workDate; } set { workDate = value; } }
        public string LoginName { get { return loginName; } set { loginName = value; } }
        public string Password
        {
            get { return password; }
            set { password = value; }

        }
        public Staff(string _id, string _position, string _name, int _age, double _coffsalary, string _loginName, string _password, int _workDate)
        {
            this.Id = _id;
            this.Position = _position;
            this.Name = _name;
            this.Age = _age;
            this.CoffSalary = _coffsalary;
            this.WorkDate = _workDate;
            this.LoginName = _loginName;
            this.Password = _password;

        }
        public Staff()
        {
            this.Id = "";
            this.Position = "";
            this.CoffSalary = 0;
            this.WorkDate = 0;
            this.Name = "";
            this.Age = 0;
            this.Password = "";
            this.LoginName = "";

        }
        public override string ToString()
        {
            return string.Format("{0}{1,25}{2,25}{3,15}{4,25}{5,35}", this.Id, this.Position, this.Name, this.Age, this.CoffSalary, this.WorkDate);
        }
        public bool Login(string loginName, string password)
        {
            if (this.LoginName == loginName && this.password == password)
                return true;
            else
                return false;
        }
        public bool UpdatePassword(string password)
        {
            if (this.Password == password)
                return false;
            else
            {
                this.Password = password;
                return true;
                //return "Successful password update."
            }
        }
        public static int CompareByName(Staff x, Staff y)
        {
            return String.Compare(x.name, y.name);
        }
        public static int CompareById(Staff x, Staff y)
        {
            return String.Compare(x.id, y.id);
        }
        public static int CompareBySalary(Staff x, Staff y)
        {
            return x.coffSalary.CompareTo(y.coffSalary);
        }
        public void CalcSalary(string filepath)
        {
            double salary = this.CoffSalary * this.workDate * 415000;
            StreamWriter sw = File.AppendText(filepath);
            sw.WriteLine($"{this.Position}-{this.Id}-{this.Name}-{salary}");
            sw.Close();
        }

    }
    public class SaleStaff : Staff
    {
        public SaleStaff(string _id, string _position, string _name, int _age, double _coffSalary, string _loginName, string _passWord, int _workDate) : base(_id, _position, _name, _age, _coffSalary, _loginName, _passWord, _workDate) { }
        public static string GetInfo(ListProduct proList, string key)
        {
            return proList.FindID(proList, key);
        }
        public static void SaveInfo(List<SaleStaff> stafflist, string filepath)
        {
            File.WriteAllText(filepath, string.Empty);
            StreamWriter sw = File.AppendText(filepath);
            foreach (SaleStaff staff in stafflist)
            {
                sw.WriteLine($"{staff.Id}-{staff.Position}-{staff.Name}-{staff.Age}-{staff.CoffSalary}-{staff.LoginName}-{staff.Password}-{staff.WorkDate}");
            }
            sw.Close();
        }

        // doi tra san pham

        public static void CreateInvoice(List<Invoice> invoiceList, string filepath)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.Write("> Nhập id: ");
            string id = Console.ReadLine();
            Console.Write("> Nhập tên khách hàng: ");
            string custName = Console.ReadLine();
            Console.Write("> Nhập số điện thoại khách hàng: ");
            string pNum = Console.ReadLine();
            Console.Write("> Nhập đơn giá: ");
            float uPrice = float.Parse(Console.ReadLine());
            Console.Write("> Nhập tên sản phẩm: ");
            string prdName = Console.ReadLine();
            Console.Write("> Nhập số lượng: ");
            int tQuantity = int.Parse(Console.ReadLine());

            invoiceList.Add(new Invoice(id, custName, pNum, prdName, uPrice, tQuantity));
            StreamWriter sw = File.AppendText(filepath);
            sw.WriteLine("");
            sw.WriteLine("{0}-{1}-{2}-{3}-{4}-{5}", id, custName, pNum, prdName, uPrice, tQuantity);
            sw.Close();
            Console.Clear();
            Console.SetCursorPosition((Console.WindowWidth - "HÓA ĐƠN\t".Length) / 2, Console.CursorTop);
            Console.WriteLine("HÓA ĐƠN");
            Console.WriteLine("Mã hóa đơn: " + id);
            Console.WriteLine("Tên khách hàng: " + custName);
            Console.WriteLine("Số điện thoại: " + pNum);
            Console.WriteLine("Sản phẩm: " + prdName);
            Console.WriteLine("Đơn giá: " + uPrice);
            Console.WriteLine("Số lượng: " + tQuantity);
            Console.WriteLine("Thành tiền: " + (uPrice) * tQuantity);
            Console.SetCursorPosition((Console.WindowWidth - "-----------------------------------------".Length) / 2, Console.CursorTop);
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("\nNhấn [ENTER] để tiếp tục.");
        }
    }
    public class Management : Staff
    {
        public Management(string _id, string _position, string _name, int _age, double _coffSalary, string _loginName, string _passWord, int _workDate) : base(_id, _position, _name, _age, _coffSalary, _loginName, _passWord, _workDate) { }

        public void ShowStaff(List<SaleStaff> staffList, List<Accountant> accList)
        {
            Console.WriteLine("Nhân viên cần tìm kiếm:");
            Console.WriteLine("[1] - Nhân viên bán hàng.");
            Console.WriteLine("[2] - Kế toán.");
            Console.Write(">Lựa chọn của bạn: ");
            string s = Console.ReadLine();
            loop:
            Console.WriteLine("> Nhập id:");
            string id = Console.ReadLine();
            if(id != "")
            {
                Console.Clear();
                goto loop;
            }    
            switch (s)
            {
                case "1":
                    for (int i = 0; i < staffList.Count; i++)
                    {
                        if (staffList[i].Id.Contains(s))
                            Console.Write(staffList[i].ToString());
                    }
                    break;
                case "2":
                    for (int i = 0; i < accList.Count; i++)
                    {
                        if (accList[i].Id.Contains(s))
                            Console.WriteLine(accList[i].ToString());
                    }
                    break;
            }
        }
        public static List<Accountant> RemoveStaff(List<Accountant> staffslist, Accountant staff, string filepath)
        {
            staffslist.Remove(staff);
            Accountant.SaveInfo(staffslist, filepath);
            return staffslist;
        }
        public static List<SaleStaff> RemoveStaff(List<SaleStaff> staffslist, SaleStaff staff, string filepath)
        {
            staffslist.Remove(staff);
            SaleStaff.SaveInfo(staffslist, filepath);
            return staffslist;
        }
        public static void SaveInfo(List<Management> stafflist, string filepath)
        {
            File.WriteAllText(filepath, string.Empty);
            StreamWriter sw = File.AppendText(filepath);
            foreach (Management staff in stafflist)
            {
                sw.WriteLine($"{staff.Id}-{staff.Position}-{staff.Name}-{staff.Age}-{staff.CoffSalary}-{staff.LoginName}-{staff.Password}-{staff.WorkDate}");
            }
            sw.Close();
        }
        public static List<Management> AddStaff(List<Management> staffslist, Management staff, string filepath)
        {
            //staffslist.Add(staff);
            StreamWriter sw = File.AppendText(filepath);
            sw.WriteLine($"{staff.Id}-{staff.Position}-{staff.Name}-{staff.Age}-{staff.CoffSalary}-{staff.LoginName}-{staff.Password}-{staff.WorkDate}");
            sw.Close();
            return staffslist;
        }
        public static List<Accountant> AddStaff(List<Accountant> staffslist, Accountant staff, string filepath)
        {
           // staffslist.Add(staff);
            StreamWriter sw = File.AppendText(filepath);
            sw.WriteLine($"{staff.Id}-{staff.Position}-{staff.Name}-{staff.Age}-{staff.CoffSalary}-{staff.LoginName}-{staff.Password}-{staff.WorkDate}");
            sw.Close();
            return staffslist;
        }
        public static List<SaleStaff> AddStaff(List<SaleStaff> staffslist, SaleStaff staff, string filepath)
        {
            //staffslist.Add(staff);
            StreamWriter sw = File.AppendText(filepath);
            sw.WriteLine($"{staff.Id}-{staff.Position}-{staff.Name}-{staff.Age}-{staff.CoffSalary}-{staff.LoginName}-{staff.Password}-{staff.WorkDate}");
            sw.Close();
            return staffslist;
        }
        public static Management FindStaff(List<Management> managementsList, string s)
        {
            int count = 0;
            foreach (Management staff in managementsList)
            {
                if (staff.Id.ToLower().Contains(s.ToLower()))
                {
                    count++;
                    return staff;
                }
            }
            if (count == 0)
                return null;
            return Management.FindStaff(managementsList, s);
        }
        public static SaleStaff FindStaff(List<SaleStaff> saleStaffsList, string s)
        {
            int count = 0;
            foreach (SaleStaff staff in saleStaffsList)
            {
                if (staff.Id.ToLower().Contains(s.ToLower()))
                {
                    count++;
                    return staff;
                }
            }
            if (count == 0)
                return null;
            return Management.FindStaff(saleStaffsList, s);
        }
        public static Accountant FindStaff(List<Accountant> accountants, string s)
        {
            int count = 0;
            foreach (Accountant staff in accountants)
            {
                if (staff.Id.ToLower().Contains(s.ToLower()))
                {
                    count++;
                    return staff;
                }
            }
            if (count == 0)
                return null;
            return Management.FindStaff(accountants, s);
        }
    }
    public class Accountant : Staff
    {
        public Accountant(string _id, string _position, string _name, int _age, double _coffSalary, string _loginName, string _passWord, int _workDate) : base(_id, _position, _name, _age, _coffSalary, _loginName, _passWord, _workDate) { }
        public static void SaveInfo(List<Accountant> stafflist, string filepath)
        {
            File.WriteAllText(filepath, string.Empty);
            StreamWriter sw = File.AppendText(filepath);
            foreach (Accountant staff in stafflist)
            {
                sw.WriteLine($"{staff.Id}-{staff.Position}-{staff.Name}-{staff.Age}-{staff.CoffSalary}-{staff.LoginName}-{staff.Password}-{staff.WorkDate}");
            }
            sw.Close();
        }
        public static void CalSalary(string fileS,string fileA,string filesalary)
        {
            List<string> slist = new List<string>();
            List<string> alist = new List<string>();
            Program.ReadFile(fileS, slist);
            Program.ReadFile(fileA, alist);
            File.WriteAllText(filesalary, string.Empty);
            StreamWriter sw = File.AppendText(filesalary);
            
            for(int i = 0; i < slist.Count; i++)
            {
                var temt = slist[i].Split('-');
                sw.WriteLine("{0}-{1}-{2}-{3}", temt[1], temt[0], temt[2], Convert.ToInt32(temt[7]) * Convert.ToDouble(temt[4]) * 4150);
            }
            for (int i = 0; i < alist.Count; i++)
            {
                var temt = alist[i].Split('-');
                sw.WriteLine("{0}-{1}-{2}-{3}", temt[1], temt[0], temt[2], Convert.ToInt32(temt[7]) * Convert.ToDouble(temt[4]) * 4150);
            }
            sw.Close();
        }
        public static void ShowSalary(string filepath)
        {
            string choice;
            List<string> list = new List<string>();
            Program.ReadFile(filepath, list);
            Console.WriteLine("[1] - In lương theo mã nhân viên cụ thể");
            Console.WriteLine("[2] - In lương của toàn bộ nhân viên");
            Console.Write("> Lựa chọn của bạn: ");
            choice = Console.ReadLine();
            int count = 0;
            switch (choice)
            {
                case "1":
                    Console.Write("> Nhập id cần tìm: ");
                    string id = Console.ReadLine();

                    for (int i = 0; i < list.Count; i++)
                    {
                        var result = list[i].Split('-');
                        if (result[1].Equals(id))
                        {
                            Console.WriteLine($"Tên nhân viên: {result[2]}, tiền lương: {result[3]}");
                            Console.WriteLine("Nhấn [ENTER] để tiếp tục.");
                            count++;
                        }
                        break;
                    }
                    if(count == 0)
                    {
                        Console.WriteLine("Không tìm thấy mã nhân viên!");
                        Console.WriteLine("Nhấn [ENTER] để tiếp tục.");
                    }
                    Console.ReadKey();
                    break;
                case "2":
                    for (int i = 0; i < list.Count; i++)
                    {
                        var result = list[i].Split('-');
                        Console.WriteLine(" Vị trí: {0}  ID: {1}  Tên:  {2}   Lương:   {3}", result[0], result[1], result[2], result[3]);
                    }
                    break;
            }
        }

        public static double CalRevenue(List<Invoice> invoicesList)
        {
            double ttRevenue = 0.0f;
            foreach (Invoice invoice in invoicesList)
            {
                ttRevenue += (invoice.UnitPrice * invoice.TotalQuantity);
            }
            return ttRevenue;
        }
        public static void PrintInvoice(string filepath)
        {
            List<string> result = new List<string>();
            Program.ReadFile(filepath, result);
            int count = 0;
            Console.SetCursorPosition((Console.WindowWidth - "IN HÓA ĐƠN".Length) / 2, Console.CursorTop);
            Console.WriteLine("IN HÓA ĐƠN");
            Console.WriteLine("[1] - In hóa đơn theo nhu cầu");
            Console.WriteLine("[2] - In toàn bộ hóa đơn.");
            Console.Write("> Lựa chọn của bạn: ");
            string c = Console.ReadLine();
            switch (c)
            {
                case "1":
                    Console.Write("> Nhập mã hóa đơn cần tìm: ");
                    string id = Console.ReadLine();
                    for (int i = 0; i < result.Count; i++)
                    {
                        var t = result[i].Split('-');
                        if (t[0] == id)
                        {
                            Console.Clear();
                            Console.SetCursorPosition((Console.WindowWidth - "HÓA ĐƠN\t".Length) / 2, Console.CursorTop);
                            Console.WriteLine("HÓA ĐƠN");
                            Console.WriteLine("Mã hóa đơn: " + t[0]);
                            Console.WriteLine("Tên khách hàng: " + t[1]);
                            Console.WriteLine("Số điện thoại: " + t[2]);
                            Console.WriteLine("Sản phẩm: " + t[3]);
                            Console.WriteLine("Đơn giá: " + t[4]);
                            Console.WriteLine("Số lượng: " + t[5]);
                            Console.WriteLine("Thành tiền: " + (Convert.ToDouble(t[4]) * Convert.ToInt32(t[5])));
                            Console.SetCursorPosition((Console.WindowWidth - "-----------------------------------------".Length) / 2, Console.CursorTop);
                            Console.WriteLine("-----------------------------------------");
                            count++;
                        }
                    }
                    if (count == 0)
                        Console.WriteLine("Không tìm thấy hóa đơn");

                    break;
                case "2":
                    Console.Clear();
                    for (int i = 0; i < result.Count; i++)
                    {
                        var s = result[i].Split('-');
                        Console.SetCursorPosition((Console.WindowWidth - "HÓA ĐƠN\t".Length) / 2, Console.CursorTop);
                        Console.WriteLine("HÓA ĐƠN");
                        Console.WriteLine("Mã hóa đơn: " + s[0]);
                        Console.WriteLine("Tên khách hàng: " + s[1]);
                        Console.WriteLine("Số điện thoại: " + s[2]);
                        Console.WriteLine("Sản phẩm: " + s[3]);
                        Console.WriteLine("Đơn giá: " + s[4]);
                        Console.WriteLine("Số lượng: " + s[5]);
                            Console.WriteLine("Thành tiền: " + (Convert.ToDouble(s[4]) * Convert.ToInt32(s[5])));

                        Console.SetCursorPosition((Console.WindowWidth - "-----------------------------------------".Length) / 2, Console.CursorTop);
                        Console.WriteLine("------------------------------------");

                    }
                    break;
            }

        }

    }

}

