using System;
using System.Collections.Generic;
using System.IO;
using System.Collections;
using System.Data;
using System.Linq;

namespace DoAnCuoiKy
{
    class Program
    {
        public static List<string> ReadFile(string filepath, List<string> result)
        {
            if (File.Exists(filepath))
            {
                StreamReader sr = File.OpenText(filepath);
                String s = "";
                do

                {
                    s = sr.ReadLine();
                    result.Add(s);
                } while (!sr.EndOfStream);
                sr.Close();
            }
            else
            {
                using (File.Create(filepath)) { }
            }
            return result;
        } 
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


        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.Clear();
            QuanLy q = new QuanLy();
            q.MenuChinh();
            
        }
    }
}
