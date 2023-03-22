using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DoAnCuoiKy
{
    public class ListCustomer
    {
        public List<Customer> list = new List<Customer>();
        public List<Customer> List
        {
            get { return list; }
            set { list = value; }
        }
        public ListCustomer()
        {
            this.list = new List<Customer>();
        }
        public ListCustomer(List<Customer> customer)
        {
            this.list = customer;
        }


        public ListCustomer Read2LPro(string NameLis)
        {
            List<Customer> temp = new List<Customer>();
            List<string> list = new List<string>();
            Program.ReadFile(NameLis, list);
            if (new FileInfo(NameLis).Length != 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    var result = list[i].Split('-');
                    temp.Add(new Customer(result[0], result[1], result[2], result[3], result[4]));
                }
            }
            return new ListCustomer(temp);
        }
        //thêm khách hàng
        public Customer AddCustomer(ListCustomer a, Customer customer, string namefile_txt)
        {
            List<Customer> temp = a.list;
            int dem = 0;
            for (int i = 0; i < temp.Count; i++)
            {
                if (temp[i].CustomerID == customer.CustomerID)
                {
                    dem++;
                }
            }
            if (dem != 0)
            {
                Console.WriteLine("lỗi!! ID khách hàng đã tồn tại.");
            }
            else
            {
                temp.Add(customer);
                Write2LCustomer(namefile_txt, new ListCustomer(temp));
            }
            return customer;
        }

        public Customer Input(ListCustomer a, string namefile_txt)
        {
            Console.Write("> Nhập Mã khách hàng: ");
            string id = Console.ReadLine();
            Customer customer = new Customer();
            int dem = 0;
            for (int i = 0; i < a.list.Count; i++)
            {
                if (id.ToLower() == a.list[i].CustomerID.ToLower())
                    dem++;
            }
            if (dem != 0)
            {
                Console.WriteLine("Mã khách hàng đã tồn tại");
                Console.ReadKey();
            }
            else
            {
                Console.Write("> Nhập Tên khách hàng: ");
                string name = Console.ReadLine();
                Console.Write("> Nhập Địa chỉ: ");
                string address = Console.ReadLine();
                Console.Write("> Nhập Số di động: ");
                string phone = Console.ReadLine();
                Console.Write("> Nhập Ngày sinh: ");
                string date = Console.ReadLine();
                customer = new Customer(id, name, address, phone, date);
                a.AddCustomer(a, customer, namefile_txt);
            }
            return customer;
        }
        //tìm kiếm theo mã 
        public Customer FindId()
        {
            Console.Write("Nhập vào Mã khách hàng cần tìm: ");
            string input = Console.ReadLine();
            int dem = 0;
            foreach (Customer customer in list)
            {
                if (input.Equals(customer.CustomerID))
                {
                    dem++;
                    Console.Write("Thông tin khách hàng cần tìm: ");
                    Console.WriteLine(customer.ToString());
                    return customer;
                }
            }
            if (dem != 0)
                Console.WriteLine("Không có thông tin khách hàng phù hợp");
            return new Customer();
        }
        public string FindName(ListCustomer l)
        {
            List<Customer> tempt = l.list;
            List<Customer> temp = new List<Customer>();
            Console.Write("Nhập vào tên khách hàng cần tìm: ");
            string input = Console.ReadLine();
            Console.WriteLine("Thông tin (liên quan) khách hàng cần tìm: ");
            for (int j = 0; j < tempt.Count; j++)
            {
                if (tempt[j].Name.ToLower().Contains(input.ToLower()))
                {
                    temp.Add(tempt[j]);
                }
            }
            return (new ListCustomer(temp)).ToString();
        }
        public void UpdateCustomer(ListCustomer l, string namefile_txt)
        {
            Customer c = FindId();
            if (c == null)
            {
                Console.WriteLine("Không có dữ liệu");
            }
            else
            {
                l.Delete(l, c, namefile_txt);
                Console.WriteLine("\nChỉnh sửa thông tin khách hàng");
                c = Input(l, namefile_txt);
            }
        }
        public void Delete(ListCustomer l, Customer c, string namefile_txt)
        {
            List<Customer> temp = l.list;
            for (int j = 0; j < temp.Count; j++)
            {
                if (temp.Contains(c))
                {
                    temp.Remove(c);
                }
            }
        }
        public void Write2LCustomer(string path, ListCustomer a)
        {
            List<Customer> temp = a.list;
            File.WriteAllText(path, string.Empty);
            StreamWriter sw = File.AppendText(path);
            for (int i = 0; i < temp.Count; i++)
            {
                sw.WriteLine("{0}-{1}-{2}-{3}-{4}", temp[i].CustomerID, temp[i].Name, temp[i].Address, temp[i].Phone, temp[i].Date);
            }
            sw.Close();
        }
        public ListCustomer Read2LCustomer(string path)
        {
            List<Customer> temp = new List<Customer>();
            List<string> l = new List<string>();
            Program.ReadFile(path, l);
            if (new FileInfo(path).Length != 0)
            {
                for (int i = 0; i < temp.Count; i++)
                {
                    var result = l[i].Split('-');
                    temp.Add(new Customer(result[0], result[1], result[2], result[3], result[4]));
                }
            }
            return new ListCustomer(temp);
        }
        public override string ToString()
        {
            List<Customer> tempt = this.list;
            string temp = "";
            for (int i = 0; i < tempt.Count; i++)
            {
                temp += $"({tempt[i].CustomerID}, {tempt[i].Name}, {tempt[i].Address}, {tempt[i].Phone}, {tempt[i].Date})\n";
            }
            return temp;
        }

    }
}
