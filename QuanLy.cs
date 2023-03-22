using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DoAnCuoiKy
{
    class QuanLy
    {
        string fileSaleStaff = "salestaff.txt";
        string fileAccountant = "accountant.txt";
        string fileManager = "manager.txt";
        string fileinvoice = "invoice.txt";
        string fileCustomer = "customer.txt";
        string fileProduct = "product.txt";
        string filesalary = "salary.txt";
        public static void ShowGreen(string s)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(s);
            Console.ResetColor();
        }
        public static void ShowRed(string s)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(s);
            Console.ResetColor();
        }
        public static void ShowYel(string s)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(s);
            Console.ResetColor();
        }
        public static void ShowEnd(string s)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(s);
            Console.ResetColor();
        }

        public void MenuChinh()
        {
            ListProduct listProduct = new ListProduct();
            ListProduct a = new ListProduct();
            ListCustomer l = new ListCustomer();
            l.AddCustomer(l, new Customer("KH01", "Nguyễn Thị Bích", "TP.Hồ Chí Minh", "0907997949", "26/04/1997"), fileCustomer);
            l.AddCustomer(l, new Customer("KH02", "Lê Gia Bảo", "Bình Dương", "0903998755", "03/07/1995"), fileCustomer);
            l.AddCustomer(l, new Customer("KH03", "Nguyễn Văn Lợi", "Tiền Giang", "0913909009", "18/07/1996"), fileCustomer);
            l.AddCustomer(l, new Customer("KH04", "Trần Văn Long", "Bình Thuận", "0903774381", "27/03/1992"), fileCustomer);
            l.AddCustomer(l, new Customer("KH05", "Nguyễn Thiên Kim", "Cà Mau", "0908589596", "16/09/1994"), fileCustomer);

            a = a.Read2LPro(fileProduct);

        MENU:
            Console.Clear();

            string DoAn = "ĐỒ ÁN: LẬP TRÌNH HƯỚNG ĐỐI TƯỢNG";
            string DeTai = "ĐỀ TÀI: QUẢN LÝ BÁN LAPTOP";
            string InfoSV = "NHÓM 7 | LỚP: 22D1INF50903701";
            string Separator = "*****************************";
            string choice;
            Action<string> action;

            Console.WriteLine();
            Console.SetCursorPosition((Console.WindowWidth - DoAn.Length) / 2, Console.CursorTop);
            action = ShowGreen;
            action?.Invoke(DoAn);
            Console.SetCursorPosition((Console.WindowWidth - DeTai.Length) / 2, Console.CursorTop);
            action?.Invoke(DeTai);
            Console.SetCursorPosition((Console.WindowWidth - InfoSV.Length) / 2, Console.CursorTop);
            action?.Invoke(InfoSV);
            Console.SetCursorPosition((Console.WindowWidth - Separator.Length) / 2, Console.CursorTop);
            action?.Invoke(Separator);
            Console.WriteLine();

        BEGIN:

            Console.WriteLine("VỊ TRÍ:");
            Console.WriteLine("[0] - Kết thúc chương trình");
            Console.WriteLine("[1] - Nhân viên bán hàng");
            Console.WriteLine("[2] - Kế toán");
            Console.WriteLine("[3] - Quản lý nhân viên");
            Console.WriteLine("[4] - Quản lý sản phẩm");
            Console.WriteLine("[5] - Quản lý khách hàng");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\n> Nhập vị trí của bạn: ");
            Console.ForegroundColor = ConsoleColor.White;

            choice = Console.ReadLine();

            switch (choice)
            {
                case "0":
                    goto THEEND;
                case "1":
                    NhanVienBanHang();
                    goto BEGIN;
                case "2":
                    KeToan();
                    goto BEGIN;
                case "3":
                    QuanLyNhanVien();
                    goto BEGIN;
                case "4":
                    QuanLySanPham(a);
                    goto BEGIN;
                case "5":
                    QuanLyKhachHang(l);
                    goto BEGIN;
                default:
                    Console.WriteLine("\n Lựa chọn không nằm trong danh mục chức năng. [Enter] để lựa chọn lại"); Console.ReadKey();
                    goto MENU;
            }
        THEEND:
            Console.Clear();
            Console.WriteLine();
            Console.SetCursorPosition((Console.WindowWidth - "KẾT THÚC CHƯƠNG TRÌNH".Length) / 2, Console.CursorTop);
            action = ShowEnd;
            action?.Invoke("KẾT THÚC CHƯƠNG TRÌNH");
            Console.SetCursorPosition(Console.WindowWidth / 2, Console.CursorTop);
            Console.ReadKey();
        }
        private void QuanLySanPham(ListProduct a)
        {
        Y:;
            Console.Clear();
            Console.SetCursorPosition((Console.WindowWidth - "QUẢN LÝ SẢN PHẨM".Length) / 2, Console.CursorTop);
            Console.WriteLine("QUẢN LÝ SẢN PHẨM");

            Console.WriteLine("[0]  TRỞ LẠI MENU CHÍNH\n");
            Console.WriteLine("[1]  DANH MỤC SẢN PHẨM");
            Console.WriteLine("[2]  THÊM SẢN PHẨM");
            Console.WriteLine("[3]  CẬP NHẬT THÔNG TIN SẢN PHẨM");
            Console.WriteLine("[4]  XOÁ SẢN PHẨM");
            Console.WriteLine("[5]  TRA CỨU SẢN PHẨM");
            Console.WriteLine("[6]  SẮP XẾP SẢN PHẨM");
            Console.Write("Nhập lựa chọn của bạn: ");

            string oppiton = Console.ReadLine();
            switch (oppiton)
            {
                case "0":
                    Console.Clear();
                    return;
                case "1":
                    {
                        Console.WriteLine("List Sản Phẩm:");
                        Console.WriteLine(a.ToString());
                        Console.Write("Nhấm [ENTER] để nhập lại lựa chọn.");
                        Console.ReadKey();
                    }
                    goto Y;
                case "2":
                    {
                        Console.WriteLine("");
                        Console.Write("Nhập thông tin sản phẩm muốn thêm:\n\tMã sản phẩm: ");
                        string id = Console.ReadLine();
                        Console.Write("\tTên sản phẩm: ");
                        string name = Console.ReadLine();
                        Console.Write("\tGiá: ");
                        int price = int.Parse(Console.ReadLine());
                        Console.Write("\tThời gian bảo hành: ");
                        string warrantyPerio = Console.ReadLine();
                        a.AddProduct(a, new Product(id, name, price, warrantyPerio), fileProduct);
                        Console.Write("Nhấm [ENTER] để nhập lại lựa chọn.");
                        Console.ReadKey();
                    }
                    goto Y;
                case "3":
                    {
                        Console.Write("Nhập Lựa chọn đối tượng cần cập nhật thông tin \n\t[1] Giá sản phẩm\t\t[2] Thời gian bảo hành\n ");
                        string temp = Console.ReadLine();
                        switch (temp)
                        {
                            case "1":
                                {
                                    Console.Write("Nhập Mã (Của sản phẩm cần sửa Price) và Giá cần sửa.\n\tID: ");
                                    string id = Console.ReadLine();
                                    Console.Write("\tGiá Sản phẩm: ");
                                    int price = int.Parse(Console.ReadLine());
                                    a.UpdateProductPrice(a, id, price, fileProduct);
                                }; break;
                            case "2":
                                {
                                    Console.Write("Nhập Mã (Của sản phẩm cần sửa Price) và Thời gian bảo hành cần sửa\n\tID: ");
                                    string id = Console.ReadLine();
                                    Console.Write("\tThời gian bảo hành: ");
                                    string WarrantyPerio = Console.ReadLine();
                                    a.UpdateProductWarrantyPerio(a, id, WarrantyPerio, fileProduct);
                                }; break;
                            default: Console.WriteLine("Lựa chọn không hợp lệ!!"); break;
                        }
                        Console.Write("Nhấm [ENTER] để nhập lại lựa chọn.");
                        Console.ReadKey();
                    }
                    goto Y;
                case "4":
                    {
                        Console.Write("\n\t[1] Xóa theo Mã sản phẩm\t\t[2] Xóa theo Tên sản phẩm\n ");
                        Console.Write("Nhập lựa chọn: ");
                        string temp = Console.ReadLine();
                        switch (temp)
                        {
                            case "1":
                                {
                                    Console.Write("Nhập Mã sản phẩm cần xóa\n\tID: ");
                                    string id = Console.ReadLine();
                                    a.DeleteProductbyID(a, id, fileProduct);
                                }; break;
                            case "2":
                                {
                                    Console.Write("Nhập Tên sản phẩm cần xóa\n\tName: ");
                                    string name = Console.ReadLine();
                                    a.DeleteProductbyName(a, name, fileProduct);
                                }; break;
                            default: Console.WriteLine("Lựa chọn không hợp lệ!!"); break;
                        }
                        Console.Write("Nhấm [ENTER] để nhập lại lựa chọn.");
                        Console.ReadKey();
                    }
                    goto Y;
                case "5":
                    {
                        Console.Write("\n\t[1] Tra cứu theo Mã sản phẩm\t\t[2] Tra cứu theo Tên sản phẩm\n");
                        Console.Write("Nhập Lựa chọn: ");
                        string temp = Console.ReadLine();
                        switch (temp)
                        {
                            case "1":
                                {
                                    Console.Write("Nhập Mã sản phẩm cần tra cứu\n\tID: ");
                                    string id = Console.ReadLine();
                                    Console.WriteLine(a.FindID(a, id));
                                }; break;
                            case "2":
                                {
                                    Console.Write("Nhập tên sản phẩm cần tra cứu\n\tName: ");
                                    string name = Console.ReadLine();
                                    Console.WriteLine(a.FindName(a, name));
                                }; break;
                            default: Console.WriteLine("Lựa chọn không hợp lệ!!"); break;
                        }
                        Console.Write("Nhấm [ENTER] để nhập lại lựa chọn.");
                        Console.ReadKey();
                    }
                    goto Y;
                case "6":
                    {
                        Console.Write("\n\t[1] Sắp Xếp Theo Mã Sản Phẩm\t[2] Sắp xếp Theo Giá\t[3] Sắp xếp theo Tên Sản Phẩm\n");
                        Console.Write("Nhập Lựa chọn: ");
                        string temp = Console.ReadLine();
                        switch (temp)
                        {
                            case "1":
                                {
                                    a.SortID(a);
                                }; break;
                            case "2":
                                {
                                    Console.WriteLine("\t\t[1] Tăng Dần\t [2] Giảm Dần ");
                                    Console.Write("Nhập Lựa chọn: ");
                                    string luachon = Console.ReadLine();
                                    if (luachon == "1")
                                        a.SortPriceAsc(a);
                                    else
                                        if (luachon == "2")
                                        a.SortPriceDec(a);
                                    else
                                        Console.WriteLine("Lựa chọn không hợp lệ!!");
                                }; break;
                            case "3":
                                {
                                    a.SortName(a);
                                }; break;
                            default: Console.WriteLine("Lựa chọn không hợp lệ!!"); break;
                        }
                        Console.WriteLine("Danh sách sản phẩm sau sắp xếp là:\n" + a.ToString());
                        Console.Write("Nhấm [ENTER] để nhập lại lựa chọn.");
                        Console.ReadKey();
                    }
                    goto Y;
                default:
                    Console.WriteLine("\n Lựa chọn không nằm trong danh mục chức năng. [Enter] để lựa chọn lại"); Console.ReadKey(); break;
            }
            goto Y;
        }

        private void QuanLyKhachHang(ListCustomer l)
        {

        MENUQLKH:
            Console.Clear();
            Console.SetCursorPosition((Console.WindowWidth - "QUẢN LÝ KHÁCH HÀNG".Length) / 2, Console.CursorTop);
            Console.WriteLine("QUẢN LÝ KHÁCH HÀNG");

            Console.WriteLine("[0]  TRỞ LẠI MENU CHÍNH");
            Console.WriteLine("[1]  DANH MỤC KHÁCH HÀNG");
            Console.WriteLine("[2]  THÊM KHÁCH HÀNG");
            Console.WriteLine("[3]  CẬP NHẬT THÔNG TIN KHÁCH HÀNG");
            Console.WriteLine("[4]  TRA CỨU THÔNG TIN KHÁCH HÀNG THEO TÊN");
            Console.WriteLine();

            Console.Write("Nhập lựa chọn: ");
            string s = Console.ReadLine();
            switch (s)
            {
                case "0":
                    Console.Clear();
                    return;
                case "1":
                    {
                        Console.WriteLine("Danh mục khách hàng:");
                        Console.WriteLine(l.ToString());
                        Console.ReadLine();
                        goto MENUQLKH;

                    }
                case "2":
                    {
                        l.Input(l, fileCustomer);
                        Console.WriteLine("Thêm khách hàng thành công!");
                        Console.ReadKey();
                        goto MENUQLKH;
                    }
                case "3":
                    {
                        l.UpdateCustomer(l, fileCustomer);
                        Console.WriteLine("Cập nhật thông tin thành công!");
                        Console.ReadKey();
                        goto MENUQLKH;
                    }
                case "4":
                    {
                        Console.WriteLine(l.FindName(l));
                        Console.ReadLine();
                        goto MENUQLKH;
                    }
            }
        }

        public void GetStaffInfor(List<string> list, List<SaleStaff> saleStaffsList)
        {
            Program.ReadFile(fileSaleStaff, list);
            for (int i = 0; i < list.Count; i++)
            {
                var s = list[i].Split('-');
                saleStaffsList.Add(new SaleStaff(s[0], s[1], s[2], Convert.ToInt32(s[3]), Convert.ToDouble(s[4]), s[5], s[6], Convert.ToInt32(s[7])));

            }
        }
        public void GetStaffInfor(List<string> list, List<Accountant> accountantsList)
        {
            Program.ReadFile(fileAccountant, list);
            for (int i = 0; i < list.Count; i++)
            {
                var s = list[i].Split('-');
                accountantsList.Add(new Accountant(s[0], s[1], s[2], Convert.ToInt32(s[3]), Convert.ToDouble(s[4]), s[5], s[6], Convert.ToInt32(s[7])));

            }
        }
        public void GetStaffInfor(List<string> list, List<Management> managementsList)
        {

            Program.ReadFile(fileManager, list);
            for (int i = 0; i < list.Count; i++)
            {
                var s = list[i].Split('-');
                managementsList.Add(new Management(s[0], s[1], s[2], Convert.ToInt32(s[3]), Convert.ToDouble(s[4]), s[5], s[6], Convert.ToInt32(s[7])));

            }


        }
        public void GetCustomInfor(ListCustomer CList, List<string> list)
        {
            Program.ReadFile(fileCustomer, list);
            {
                for (int i = 0; i < list.Count; i++)
                {
                    var s = list[i].Split('-');
                    List<Customer> temp = CList.list;
                    temp.Add(new Customer(s[0], s[1], s[2], s[3], s[4]));
                }
            }
        }
        public void GetInvoiceInfor(List<string> list, List<Invoice> invoicesList)
        {

            Program.ReadFile(fileinvoice, list);
            for (int i = 0; i < list.Count; i++)
            {
                var s = list[i].Split('-');
                invoicesList.Add(new Invoice(s[0], s[1], s[2], s[3], Convert.ToDouble(s[4]), Convert.ToInt32(s[5])));
            }


        }
        public int Sign(string a)
        {
            if (a.Length <= 2)
                return 0;
            else
            {
                switch (a.Substring(0, 2))
                {
                    case "BH":
                        return 1;
                    case "KT":
                        return 2;
                    case "QL":
                        return 3;
                    default:
                        return 0;
                }
            }

        }
        public void GetProInfo(ListProduct proList, List<string> list, List<Product> productList)
        {
            Program.ReadFile(fileProduct, list);

            for (int i = 0; i < list.Count; i++)
            {
                var result = list[i].Split('-');
                productList.Add(new Product(result[0], result[1], (Convert.ToDouble(result[2])), result[3]));
            }
        }

        public void NhanVienBanHang()
        {
            Console.Clear();
            string choice;
            Action<string> action;

            List<string> Slist = new List<string>();
            List<SaleStaff> saleStaffsList = new List<SaleStaff>();
            GetStaffInfor(Slist, saleStaffsList);

            List<Invoice> invoicesList = new List<Invoice>();
            List<string> IList = new List<string>();
            GetInvoiceInfor(IList, invoicesList);

            List<string> pList = new List<string>();
            List<Product> productList = new List<Product>();
            ListProduct product = new ListProduct();
            GetProInfo(product, pList, productList);

            Console.SetCursorPosition((Console.WindowWidth - "NHÂN VIÊN BÁN HÀNG".Length) / 2, Console.CursorTop);
            action = ShowGreen;
            action?.Invoke("NHÂN VIÊN BÁN HÀNG");
            for (int i = 3; i >= 0; i--)
            {
                if (i == 0)
                {
                    action = ShowEnd;
                    action?.Invoke("Đăng nhập thất bại!\n");
                    Console.Clear();

                }
                else
                {
                    Console.Write("> Tên đăng nhập: ");
                    string tendangnhap = Console.ReadLine();
                    Console.Write("> Mật khẩu: ");
                    string mk = Console.ReadLine();
                    int count = 0;
                    foreach (SaleStaff s in saleStaffsList)
                    {
                        if (s.Login(tendangnhap, mk) == true)
                        {
                            count++;
                            break;
                        }
                    }
                    if (count == 0)
                    {
                        Console.WriteLine("Sai tên đăng nhập hoặc mật khẩu!");
                        Console.WriteLine("Đăng nhập lại.\n");
                        Console.WriteLine("Còn {0} lần đăng nhập.", i - 1);
                    }
                    else
                    {
                        Console.WriteLine("Đăng nhập thành công!");

                    loops1:
                        Console.Clear();
                        Console.WriteLine("\nDanh mục chức năng: \n");
                        Console.WriteLine("[0] - Trở lại MENU chính");
                        Console.WriteLine("[1] - Xem thông tin sản phẩm cụ thể");
                        Console.WriteLine("[2] - Xem danh sách sản phẩm");
                        Console.WriteLine("[3] - Tạo hóa đơn\n");

                        action = ShowYel;
                        action?.Invoke("Lựa chọn của bạn: ");
                        choice = Console.ReadLine();
                        switch (choice)
                        {
                            case "0":
                                Console.Clear();
                                return;
                            case "1":
                                Console.Write("> Nhập mã sản phẩm cần tìm: ");
                                string key = Console.ReadLine();
                                count = 0;
                                foreach (Product p in productList)
                                {
                                    if (p.ProductID.Equals(key))
                                    {
                                        Console.WriteLine(p.ToString());
                                        count++;
                                        break;
                                    }
                                }
                                if (count == 0)
                                {
                                    action = ShowRed;
                                    action?.Invoke("Không tìm thấy kết quả!");
                                }                                 
                                Console.WriteLine("\nNhấn [ENTER] để tiếp tục.");
                                Console.ReadLine();
                                goto loops1;
                            case "2":
                                Console.Clear();
                                Console.WriteLine("Danh sách sản phẩm");
                                foreach (Product p in productList)
                                {
                                    Console.WriteLine(p.ToString());
                                }
                                Console.WriteLine("\nNhấn [ENTER] để tiếp tục.");
                                Console.ReadKey();
                                goto loops1;
                            case "3":
                                SaleStaff.CreateInvoice(invoicesList, "invoice.txt");
                                Console.ReadKey();
                                goto loops1;
                            default:
                                Console.WriteLine("Lựa chọn không hợp lệ!");
                                goto loops1;
                        }
                    }
                }
            }
        }
        public void KeToan()
        {
            Console.Clear();
            Accountant.CalSalary(fileSaleStaff, fileAccountant, filesalary);
            string choice;
            Action<string> action;

            List<string> Alist = new List<string>();
            List<Accountant> accountantsList = new List<Accountant>();
            GetStaffInfor(Alist, accountantsList);

            List<string> IList = new List<string>();
            List<Invoice> invoicesList = new List<Invoice>();
            GetInvoiceInfor(IList, invoicesList);

            Console.SetCursorPosition((Console.WindowWidth - "KẾ TOÁN".Length) / 2, Console.CursorTop);
            action = ShowGreen;
            action?.Invoke("KẾ TOÁN");
            for (int i = 3; i >= 0; i--)
            {
                if (i == 0)
                {
                    Console.WriteLine("Đăng nhập thất bại!\n");
                    Console.Clear();
                }
                else
                {
                    Console.Write("> Tên đăng nhập: ");
                    string tendangnhap = Console.ReadLine();
                    Console.Write("> Mật khẩu: ");
                    string mk = Console.ReadLine();
                    int count = 0;
                    foreach (Accountant s in accountantsList)
                    {
                        if (s.Login(tendangnhap, mk) == true)
                        {
                            count++;
                            break;
                        }
                    }
                    if (count == 0)
                    {
                        Console.WriteLine("Sai tên đăng nhập hoặc mật khẩu!");
                        Console.WriteLine("Đăng nhập lại.\n");
                        Console.WriteLine("Còn {0} lần đăng nhập.", i - 1);
                    }
                    else
                    {
                        Console.WriteLine("Đăng nhập thành công!");
                    loopa1:
                        Console.Clear();
                        Console.WriteLine("Danh mục chức năng: \n");
                        Console.WriteLine("[0] Trở lại MENU chính");
                        Console.WriteLine("[1] Hiển thị lương");
                        Console.WriteLine("[2] Tính doanh thu");
                        Console.WriteLine("[3] In hóa đơn");
                        Console.Write("> Nhập lựa chọn của bạn: ");
                        choice = Console.ReadLine();
                        switch (choice)
                        {
                            case "0":
                                Console.Clear();
                                return;
                            case "1":
                                Accountant.ShowSalary("salary.txt");
                                Console.ReadKey();
                                goto loopa1;
                            case "2":
                                Console.Write("Doanh thu đạt được: ");
                                Console.WriteLine(Accountant.CalRevenue(invoicesList));
                                Console.WriteLine("Nhấn [ENTER] để tiếp tục.");
                                Console.ReadKey();
                                goto loopa1;

                            case "3":
                                Accountant.PrintInvoice(fileinvoice);
                                Console.ReadKey();
                                goto loopa1;

                            default:
                                Console.WriteLine("Lựa chọn không hợp lệ");
                                goto loopa1;
                        }
                    }
                }
            }
        }
        private void QuanLyNhanVien()//management.
        {
            Console.Clear();
            string choice;
            Action<string> action;

            List<Management> managementsList = new List<Management>();
            List<string> MList = new List<string>();
            GetStaffInfor(MList, managementsList);

            List<string> Slist = new List<string>();
            List<SaleStaff> saleStaffsList = new List<SaleStaff>();
            GetStaffInfor(Slist, saleStaffsList);

            List<string> Alist = new List<string>();
            List<Accountant> accountantsList = new List<Accountant>();
            GetStaffInfor(Alist, accountantsList);

            List<string> pList = new List<string>();
            List<Product> productList = new List<Product>();
            ListProduct product = new ListProduct();
            GetProInfo(product, pList, productList);

            Console.SetCursorPosition((Console.WindowWidth - "QUẢN LÝ NHÂN VIÊN".Length) / 2, Console.CursorTop);
            action = ShowGreen;
            action?.Invoke("QUẢN LÝ NHÂN VIÊN");
            for (int i = 3; i >= 0; i--)
            {
                if (i == 0)
                {
                    Console.WriteLine("Đăng nhập thất bại!\n");
                    Console.Clear();
                }
                else
                {
                    Console.Write("> Tên đăng nhập: ");
                    string tendangnhap = Console.ReadLine();
                    Console.Write("> Mật khẩu: ");
                    string mk = Console.ReadLine();
                    int count = 0;
                    foreach (Management s in managementsList)
                    {
                        if (s.Login(tendangnhap, mk) == true)
                        {
                            count++;
                            break;
                        }
                    }
                    if (count == 0)
                    {
                        action = ShowEnd;
                        action?.Invoke("Sai tên đăng nhập hoặc mật khẩu!");
                        action?.Invoke("Đăng nhập lại.\n");
                        Console.WriteLine("Còn {0} lần đăng nhập.", i - 1);
                    }
                    else
                    {
                        Console.WriteLine("Đăng nhập thành công!");
                    loopm1:
                        Console.Clear();
                        Console.WriteLine("[0]  QUAY LẠI MENU CHÍNH\n");
                        Console.WriteLine("[1]  DANH SÁCH NHÂN VIÊN");
                        Console.WriteLine("[2]  SA THẢI NHÂN VIÊN");
                        Console.WriteLine("[3]  TUYỂN NHÂN VIÊN");
                        Console.WriteLine("[4]  TÌM KIẾM NHÂN VIÊN");
                        Console.WriteLine("[5]  THAY ĐỔI THÔNG TIN NHÂN VIÊN");
                        Console.Write("> Nhập lựa chọn của bạn: ");
                        choice = Console.ReadLine();
                        switch (choice)
                        {
                            case "0":
                                Console.Clear();
                                return;

                            case "1":
                                Console.WriteLine("\nDANH SÁCH NHÂN VIÊN\n");
                                Console.WriteLine("[1] - Nhân viên bán hàng");
                                Console.WriteLine("[2] - Kế toán");
                                Console.Write("> Nhập lựa chọn của bạn: ");
                                choice = Console.ReadLine();
                                saleStaffsList.Sort(Staff.CompareById);
                                accountantsList.Sort(Staff.CompareById);
                                managementsList.Sort(Staff.CompareById);
                                switch (choice)
                                {
                                    case "1":
                                        Console.WriteLine("\nDANH SÁCH NHÂN VIÊN BÁN HÀNG\n");
                                        saleStaffsList.Sort(Staff.CompareById);
                                        Console.WriteLine("{0}{1,25}{2,25}{3,20}{4,25}{5,35}", "ID", "Vị trí", "Tên", "Tuổi", "Hệ số lương", "Số ngày làm việc");
                                        foreach (SaleStaff s in saleStaffsList)
                                        {
                                            Console.WriteLine(s.ToString());
                                        }
                                        break;
                                    case "2":
                                        Console.WriteLine("\nDANH SÁCH KẾ TOÁN\n");
                                        accountantsList.Sort(Staff.CompareById);
                                        Console.WriteLine("{0}{1,25}{2,25}{3,20}{4,25}{5,35}", "ID", "Vị trí", "Tên", "Tuổi", "Hệ số lương", "Số ngày làm việc");
                                        foreach (Accountant s in accountantsList)
                                        {
                                            Console.WriteLine(s.ToString());
                                        }
                                        break;
                                }
                                Console.WriteLine("\nNhấn [Enter] để trở lại danh mục chức năng");
                                Console.ReadKey();
                                goto loopm1;

                            case "2":
                            loopcase2:
                                Console.Clear();
                                Console.WriteLine("\nDANH SÁCH NHÂN VIÊN BÁN HÀNG\n");

                                saleStaffsList.Sort(Staff.CompareById);
                                Console.WriteLine("{0}{1,25}{2,25}{3,20}{4,25}{5,35}", "ID", "Vị trí", "Tên", "Tuổi", "Hệ số lương", "Số ngày làm việc");
                                foreach (SaleStaff s in saleStaffsList)
                                {
                                    Console.WriteLine(s.ToString());
                                }

                                Console.WriteLine("\nDANH SÁCH KẾ TOÁN\n");
                                accountantsList.Sort(Staff.CompareById);
                                Console.WriteLine("{0}{1,25}{2,25}{3,20}{4,25}{5,35}", "ID", "Vị trí", "Tên", "Tuổi", "Hệ số lương", "Số ngày làm việc");
                                foreach (Accountant s in accountantsList)
                                {
                                    Console.WriteLine(s.ToString());
                                }
                            loopid:
                                Console.Write("> Nhập id: ");
                                string id = Console.ReadLine();
                                if (id != "")
                                {
                                    switch (Sign(id))
                                    {
                                        case 1:
                                            Management.RemoveStaff(saleStaffsList, Management.FindStaff(saleStaffsList, id), fileSaleStaff);
                                            Console.WriteLine("Đã sa thải thải và cập nhật danh sách thành công!");
                                            Console.WriteLine("Nhấn [ENTER] để tiếp tục.");
                                            break;
                                        case 2:
                                            Management.RemoveStaff(accountantsList, Management.FindStaff(accountantsList, id), fileAccountant);
                                            Console.WriteLine("Đã sa thải thải và cập nhật danh sách thành công!");
                                            Console.WriteLine("Nhấn [ENTER] để tiếp tục.");
                                            break;
                                        default:
                                            Console.WriteLine("Không tìm thấy kết quả!");
                                            Console.WriteLine("Nhấn [ENTER] để tiếp tục.");
                                            Console.ReadKey();
                                            goto loopcase2;
                                    }
                                    Console.ReadKey();
                                    goto loopm1;
                                }
                                else
                                {
                                    Console.Clear();
                                    goto loopid;
                                }
                            case "3":
                            loopcase3:
                                Console.Clear();
                                Console.WriteLine("-TUYỂN NHÂN VIÊN-");
                                Console.Write("Nhập id: ");
                                string id3 = Console.ReadLine();
                                count = 0;
                                if (id3 == "")
                                    goto loopcase3;
                                if (Sign(id3) == 1)
                                {
                                    foreach (SaleStaff s in saleStaffsList)
                                    {
                                        if (s.Id == id3)
                                        {
                                            count++;
                                        }
                                    }
                                    if (count != 0)
                                    {
                                        action = ShowEnd;
                                        action?.Invoke("Mã nhân viên đã trùng! Vui lòng nhập lại");
                                        goto loopcase3;
                                    }
                                    else
                                    {
                                        Console.Write("> Vị trí: ");
                                        string position = Console.ReadLine();
                                        Console.Write("> Tên: ");
                                        string name = Console.ReadLine();
                                        Console.Write("> Tuổi: ");
                                        int age = int.Parse(Console.ReadLine());
                                        Console.Write("> Hệ số lương: ");
                                        double hsl = double.Parse(Console.ReadLine());
                                        Console.Write("> Tên đăng nhập: ");
                                        string pw = Console.ReadLine();
                                        Console.Write("> Mật khẩu: ");
                                        mk = Console.ReadLine();
                                        Console.Write("> Số ngày làm việc: ");
                                        int wd = int.Parse(Console.ReadLine());

                                        SaleStaff s2 = new SaleStaff(id3, position, name, age, hsl, pw, mk, wd);
                                        saleStaffsList.Add(s2);
                                        Management.AddStaff(saleStaffsList, Management.FindStaff(saleStaffsList, id3), fileSaleStaff);
                                        Console.WriteLine("Đã thêm nhân viên bán hàng thành công vào danh sách!");
                                        Console.WriteLine("\nNhấn [Enter] để trở lại danh mục chức năng");
                                    }
                                }
                                if (Sign(id3) == 2)
                                {
                                    foreach (SaleStaff s in saleStaffsList)
                                    {
                                        if (s.Id == id3)
                                        {
                                            count++;
                                        }
                                    }
                                    if (count != 0)
                                    {
                                        action = ShowEnd;
                                        action?.Invoke("Mã nhân viên đã trùng! Vui lòng nhập lại.");
                                        goto loopcase3;
                                    }
                                    else
                                    {
                                        Console.Write("> Vị trí: ");
                                        string position = Console.ReadLine();
                                        Console.Write("> Tên: ");
                                        string name = Console.ReadLine();
                                        Console.Write("> Tuổi: ");
                                        int age = int.Parse(Console.ReadLine());
                                        Console.Write("> Hệ số lương: ");
                                        double hsl = double.Parse(Console.ReadLine());
                                        Console.Write("> Tên đăng nhập: ");
                                        string pw = Console.ReadLine();
                                        Console.Write("> Mật khẩu: ");
                                        mk = Console.ReadLine();
                                        Console.Write("> Số ngày làm việc: ");
                                        int wd = int.Parse(Console.ReadLine());
                                        Accountant s2 = new Accountant(id3, position, name, age, hsl, pw, mk, wd);
                                        accountantsList.Add(s2);
                                        Management.AddStaff(accountantsList, Management.FindStaff(accountantsList, id3), fileSaleStaff);
                                        Console.WriteLine("Đã thêm nhân viên bán hàng thành công vào danh sách!");
                                        Console.WriteLine("\nNhấn [Enter] để trở lại danh mục chức năng.");
                                    }

                                }
                                Console.ReadKey();
                                goto loopm1;
                            case "4":
                            loopcase4:
                                Console.Clear();
                                Console.WriteLine("TÌM KIẾM NHÂN VIÊN");
                                Console.Write("> Nhập id nhân viên: ");
                                string id4 = Console.ReadLine();
                                if (id4 == "")
                                    goto loopcase4;
                                if (Sign(id4) == 1)
                                {
                                    if (Management.FindStaff(saleStaffsList, id4) != null)
                                    {
                                        Console.WriteLine("{0}{1,25}{2,25}{3,20}{4,25}{5,35}", "ID", "Vị trí", "Tên", "Tuổi", "Hệ số lương", "Số ngày làm việc");
                                        Console.WriteLine((Management.FindStaff(saleStaffsList, id4)).ToString());
                                    }
                                    else
                                    {
                                        Console.WriteLine("Không tìm thấy kết quả!");
                                        Console.WriteLine("\nNhấn [Enter] để trở lại danh mục chức năng.");
                                    }
                                    Console.ReadKey();
                                }
                                if (Sign(id4) == 2)
                                {
                                    if (Management.FindStaff(accountantsList, id4) != null)
                                    {
                                        Console.WriteLine("{0}{1,25}{2,25}{3,20}{4,25}{5,35}", "ID", "Vị trí", "Tên", "Tuổi", "Hệ số lương", "Số ngày làm việc");
                                        Console.WriteLine((Management.FindStaff(accountantsList, id4)).ToString());
                                    }
                                    else
                                    {
                                        Console.WriteLine("Không tìm thấy kết quả!");
                                        Console.WriteLine("\nNhấn [Enter] để trở lại danh mục chức năng.");
                                    }
                                }
                                if (Sign(id4) != 2 && Sign(id4) != 1)
                                {
                                    Console.WriteLine("Không tìm thấy kết quả");
                                    Console.ReadKey();
                                }
                                Console.ReadKey();

                                goto loopm1;
                            case "5":
                            loopcase5:
                                Console.Clear();
                                Console.WriteLine("CHỈNH SỬA THÔNG TIN NHÂN VIÊN");
                                Console.Write("> Nhập id nhân viên cần chỉnh sửa thông tin: ");
                                id = Console.ReadLine();
                                if (id == "")
                                    goto loopcase5;

                                if (Sign(id) == 1)
                                {
                                    if (Management.FindStaff(saleStaffsList, id) != null)
                                    {
                                        Console.Write("> Tên: ");
                                        string name = Console.ReadLine();
                                        Console.Write("> Tuổi: ");
                                        int age = int.Parse(Console.ReadLine());
                                        Console.Write("> Hệ số lương: ");
                                        double hsl = double.Parse(Console.ReadLine());
                                        Console.Write("> Tên đăng nhập: ");
                                        string pw = Console.ReadLine();
                                        Console.Write("> Mật khẩu: ");
                                        mk = Console.ReadLine();
                                        Console.Write("> Số ngày làm việc: ");
                                        int wd = int.Parse(Console.ReadLine());
                                        SaleStaff sal1 = new SaleStaff(id, (Management.FindStaff(saleStaffsList, id)).Position, name, age, hsl, pw, mk, wd);

                                        Management.RemoveStaff(saleStaffsList, Management.FindStaff(saleStaffsList, id), fileSaleStaff);
                                        Management.AddStaff(saleStaffsList, sal1, fileSaleStaff);

                                        Console.WriteLine("Cập nhật thông tin thành công!");
                                        Console.WriteLine("Nhấn [ENTER] để tiếp tục.");
                                        Console.ReadKey();
                                    }
                                    else
                                        Console.WriteLine("Không tìm thấy kết quả!");
                                        Console.WriteLine("Nhấn [ENTER] để tiếp tục.");
                                    goto loopm1;
                                }
                                if (Sign(id) == 2)
                                {
                                    if (Management.FindStaff(accountantsList, id) != null)
                                    {
                                        Console.Write("> Tên: ");
                                        string name = Console.ReadLine();
                                        Console.Write("> Tuổi: ");
                                        int age = int.Parse(Console.ReadLine());
                                        Console.Write("> Hệ số lương: ");
                                        double hsl = double.Parse(Console.ReadLine());
                                        Console.Write("> Tên đăng nhập: ");
                                        string pw = Console.ReadLine();
                                        Console.Write("> Mật khẩu: ");
                                        mk = Console.ReadLine();
                                        Console.Write("> Số ngày làm việc: ");
                                        int wd = int.Parse(Console.ReadLine());
                                        Accountant sal2 = new Accountant(id, (Management.FindStaff(accountantsList, id)).Position, name, age, hsl, pw, mk, wd);

                                        Management.RemoveStaff(accountantsList, Management.FindStaff(accountantsList, id), fileAccountant);
                                        Management.AddStaff(accountantsList, sal2, fileAccountant);

                                        Console.WriteLine("Cập nhật thông tin thành công!");
                                        Console.WriteLine("Nhấn [ENTER] để tiếp tục.");
                                    }
                                    else
                                        Console.WriteLine("Không tìm thấy kết quả!");
                                        Console.WriteLine("Nhấn [ENTER] để tiếp tục.");
                                    goto loopm1;
                                }
                                if (Sign(id) != 2 && Sign(id) != 1)
                                {
                                    Console.WriteLine("Không tìm thấy kết quả");
                                    Console.WriteLine("Nhấn [ENTER] để tiếp tục.");
                                    Console.ReadKey();
                                    goto loopcase2;
                                }
                                goto loopm1;
                            default:
                                goto loopm1;
                        }
                    }
                }
            }
        }
    }
}

