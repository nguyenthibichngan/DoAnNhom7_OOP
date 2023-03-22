using System;
using System.Collections.Generic;
using System.Text;

namespace DoAnCuoiKy
{
    public class Invoice
{
    private string invoiceId;
    private string customerName;
    private string phone;
    private string productName;

    private double unitPrice;
    private int totalQuantity;

    public string InvoiceId
    {
        get { return invoiceId; }
        set { invoiceId = value; }
    }
    public string NameCustormer
    {
        get { return customerName; }
        set { customerName = value; }
    }
    public string Phone
    {
        get { return phone; }
        set { phone = value; }
    }
    public double UnitPrice
    { get { return unitPrice; } set { unitPrice = value; } }
    public int TotalQuantity
    { get { return totalQuantity; } set { totalQuantity = value; } }

    public string ProductName { get { return productName; } set { productName = value; } }

    public Invoice(string _id, string _name, string _phone, string _productName, double _unitPrice, int _ttquantity)
    {
        this.InvoiceId = _id;
        this.NameCustormer = _name;
        this.Phone = _phone;
        this.ProductName = _productName;
        this.UnitPrice = _unitPrice;
        this.TotalQuantity = _ttquantity;
    }
    public override string ToString()
    {
        return string.Format(this.GetType() + $"> Id: {this.InvoiceId}, customer name: {this.NameCustormer}, phone number: {this.Phone}, product name:{this.ProductName}, unit price: {this.UnitPrice},total quantity: {this.TotalQuantity}");
    }
}
}
