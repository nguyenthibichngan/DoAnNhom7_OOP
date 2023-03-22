using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace DoAnCuoiKy
{

    public class ListProduct : Product
    {
        public void Write2LPro(string namefile, ListProduct a)
        {
            List<Product> tempwrite = a.listProduct;
            File.WriteAllText(namefile, string.Empty);
            StreamWriter sw = File.AppendText(namefile);
            for (int i = 0; i < tempwrite.Count; i++)
            {
                sw.WriteLine("{0}-{1}-{2}-{3}", tempwrite[i].ProductID, tempwrite[i].ProductName, tempwrite[i].ProductPrice, tempwrite[i].WarrantyPeriod);
            }
            sw.Close();
        }

        public ListProduct Read2LPro(string NameLis)
        {
            List<Product> temp = new List<Product>();
            List<string> list = new List<string>();
            Program.ReadFile(NameLis, list);
            if (new FileInfo(NameLis).Length != 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    var result = list[i].Split('-');
                    temp.Add(new Product(result[0], result[1], (Convert.ToDouble(result[2])), result[3]));
                }
            }
            return new ListProduct(temp);
        }


        public List<Product> listProduct;
        public List<Product> Listproduct
        {
            get { return listProduct; }
            set { listProduct = value; }
        }
        public ListProduct()
        {
            this.listProduct = new List<Product>();
        }
        public ListProduct(List<Product> listProduct)
        {
            this.listProduct = listProduct;
        }
        public override string ToString()
        {
            List<Product> tempt = this.listProduct;
            string temp = "";
            /* temp = string.Format("{0}{1,15}{2,15}{3,15}}", "ID", "Name", "Price", "WarrantyPeriod");*/
            for (int i = 0; i < tempt.Count; i++)
            {
                temp += $"({tempt[i].ProductID}, {tempt[i].ProductName}, {tempt[i].ProductPrice},{tempt[i].WarrantyPeriod})\n";
            }
            return temp;
        }
        //thêm sản phẩm
        public ListProduct AddProduct(ListProduct a, Product key, string namefile_txt)
        {//ok
            List<Product> temp = a.listProduct;
            int dem = 0;
            for (int i = 0; i < temp.Count; i++)
            {
                if (temp[i].ProductID == key.ProductID)
                {
                    dem++;
                }
            }
            if (dem != 0)
            {
                Console.WriteLine("lỗi!! ID sản phẩm đã tồn tại.");
            }
            else
            {
                temp.Add(key);
                Console.WriteLine("Thêm sản phẩm thành công!");
                Write2LPro(namefile_txt, new ListProduct(temp));
            }
            return new ListProduct(temp);
        }
        //sắp xếp theo mã
        public ListProduct SortID(ListProduct a)
        {//ok
            List<Product> temp = a.listProduct;
            for (int i = 0; i < temp.Count; i++)
                for (int j = 0; j < temp.Count - 1; j++)
                {
                    if (string.Compare(temp[j].ProductID, temp[j + 1].ProductID, true) > 0)
                    {
                        Product tam = temp[j];
                        temp[j] = temp[j + 1];
                        temp[j + 1] = tam;
                    }
                }
            return new ListProduct(temp);
        }
        //sắp xếp theo tên
        public ListProduct SortName(ListProduct a)
        {
            List<Product> temp = a.listProduct;
            for (int i = 0; i < temp.Count; i++)
                for (int j = 0; j < temp.Count - 1; j++)
                {
                    if (string.Compare(temp[j].ProductName, temp[j + 1].ProductName, false) > 0)
                    {
                        Product tam = temp[j];
                        temp[j] = temp[j + 1];
                        temp[j + 1] = tam;
                    }
                }
            return new ListProduct(temp);
        }
        //sắp xếp giá tăng dần
        public ListProduct SortPriceAsc(ListProduct a)
        {
            a = ++a;
            return a;
        }
        //sắp xếp giá giảm dần
        public ListProduct SortPriceDec(ListProduct a)
        {
            a = --a;
            return a;
        }
        //operator
        public static ListProduct operator ++(ListProduct a)
        {//ok
            List<Product> temp = a.listProduct;
            for (int i = 0; i < temp.Count; i++)
                for (int j = 0; j < temp.Count - 1; j++)
                {
                    if (temp[j].ProductPrice > temp[j + 1].ProductPrice)
                    {
                        Product tam = temp[j];
                        temp[j] = temp[j + 1];
                        temp[j + 1] = tam;
                    }
                }
            return new ListProduct(temp);
        }
        public static ListProduct operator --(ListProduct a)
        {//ok
            List<Product> temp = a.listProduct;
            for (int i = 0; i < temp.Count; i++)
                for (int j = 0; j < temp.Count - 1; j++)
                {
                    if (temp[j].ProductPrice <= temp[j + 1].ProductPrice)
                    {
                        Product tam = temp[j];
                        temp[j] = temp[j + 1];
                        temp[j + 1] = tam;
                    }
                }
            return new ListProduct(temp);
        }
        //tìm theo mã
        public string FindID(ListProduct a, string key)
        {
            List<Product> temp = new List<Product>();
            List<Product> temp1 = a.listProduct;
            int dem = 0;
            for (int j = 0; j < temp1.Count; j++)
            {
                if (temp1[j].ProductID.ToLower().Contains(key.ToLower()))
                {
                    temp.Add(temp1[j]);
                    dem++;
                }
            }
            if (dem == 0)
                return "Không có  Mã sản phẩm nào phù hợp!!";
            else
                return (new ListProduct(temp)).ToString();
        }
        //tìm theo tên
        public string FindName(ListProduct a, string key)
        {
            List<Product> temp = new List<Product>();
            List<Product> temp1 = a.listProduct;
            int dem = 0;
            for (int j = 0; j < temp1.Count; j++)
            {
                if (temp1[j].ProductName.ToLower().Contains(key.ToLower()))
                {
                    temp.Add(temp1[j]);
                    dem++;
                }
            }
            if (dem == 0)
                return "Không có Tên sản phẩm nào phù hợp!!";
            else
                return (new ListProduct(temp)).ToString();
        }
        //xóa theo mã
        public ListProduct DeleteProductbyID(ListProduct a, string key, string namefile_txt)
        {//ok
            /*List<Product> temp = new List<Product>();*/
            List<Product> temp = a.listProduct;
            int dem = 0;
            for (int j = 0; j < temp.Count; j++)
            {
                if (temp[j].ProductID.ToLower() == key.ToLower())
                {
                    temp.Remove(temp[j]);
                    dem++;
                }
            }
            if (dem == 0)
                Console.WriteLine("Không tìm thấy Mã sản phẩm phù hợp.");
            else
            {
                Console.WriteLine("Xóa thông tin sản phẩm thành công!");
                Write2LPro(namefile_txt, new ListProduct(temp));
            }
            return new ListProduct(temp);
        }
        //xóa theo tên
        public ListProduct DeleteProductbyName(ListProduct a, string key, string namefile_txt)
        {
            List<Product> temp = a.listProduct;
            int dem = 0;
            for (int j = 0; j < temp.Count; j++)
            {
                if (temp[j].ProductName.ToLower() == key.ToLower())
                {
                    temp.Remove(temp[j]);
                    dem++;
                }
            }
            if (dem == 0)
                Console.WriteLine("Không tìm thấy Tên sản phẩm phù hợp.");
            else
            {
                Console.WriteLine("Xóa thông tin sản phẩm thành công!");
                Write2LPro(namefile_txt, new ListProduct(temp));
            }
            return new ListProduct(temp);
        }
        //cập nhật giá
        public ListProduct UpdateProductPrice(ListProduct a, string IDkey, int price, string namefile_txt)
        {
            List<Product> temp = a.listProduct;
            int dem = 0;
            for (int j = 0; j < temp.Count; j++)
            {
                if (temp[j].ProductID.ToLower() == IDkey.ToLower())
                {
                    temp[j].ProductPrice = price;
                    dem++;
                }
            }
            if (dem == 0)
                Console.WriteLine("Không tìm thấy Mã sản phẩm phù hợp.");
            else
            {
                Console.WriteLine("Cập nhật thông tin sản phẩm thành công!");
                Write2LPro(namefile_txt, new ListProduct(temp));
            }
            return new ListProduct(temp);
        }
        //cập nhật thời gian bảo hành
        public ListProduct UpdateProductWarrantyPerio(ListProduct a, string IDkey, string warrantyPerio, string namefile_txt)
        {
            List<Product> temp = a.listProduct;
            int dem = 0;
            for (int j = 0; j < temp.Count; j++)
            {
                if (temp[j].ProductID.ToLower() == IDkey.ToLower())
                {
                    temp[j].ProductName = warrantyPerio;
                    dem++;
                }
            }
            if (dem == 0)
                Console.WriteLine("Không tìm thấy Mã sản phẩm phù hợp.");
            else
            {
                Console.WriteLine("Cập nhật thông tin sản phẩm thành công!");
                Write2LPro(namefile_txt, new ListProduct(temp));
            }
            return new ListProduct(temp);
        }
    }
}


