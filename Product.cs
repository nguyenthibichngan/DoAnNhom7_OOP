using System;
using System.Collections.Generic;

namespace DoAnCuoiKy
{
public class Product
{
    private string productID;
    private string productName;
    private double productPrice;
    private string warrantyPeriod;
    public string ProductID
    {
        get { return productID; }
        set { productID = value; }
    }
    public string ProductName
    {
        get { return productName; }
        set { productName = value; }
    }
    public double ProductPrice
    {
        get { return productPrice; }
        set { productPrice = value; }
    }
    public string WarrantyPeriod
    {
        get { return warrantyPeriod; }
        set { warrantyPeriod = value; }
    }

    public Product(string productID, string productName, double productPrice, string warrantyPeriod)
    {
        this.ProductID = productID;
        this.ProductName = productName;
        this.ProductPrice = productPrice;
        this.WarrantyPeriod = warrantyPeriod;
    }
    public Product()
    {
        this.ProductID = "";
        this.ProductName = "";
        this.ProductPrice = 0;
        this.warrantyPeriod = "";
    }


    public override string ToString()
    {
        return $"({productID}, {productName}, {productPrice},{warrantyPeriod})";
    }

    public string GetInfo()
    {
        return "ID: " + productID + ", Name: " + productName + ", Price: " + productPrice + ", WarrantyPeriod: " + warrantyPeriod + ".";
    }

    public void UpdateProduct()
    {

    }
}
}