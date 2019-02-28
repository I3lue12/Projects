using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
/// <summary>
/// Summary description for Product
/// </summary>
public class Product
{
    public int ID;
    public string Mfg, Model, Part, Description;
    public string Img;
    public decimal Price;

    public Product(int id, string mfg,string model, string part, decimal price, string description, string img)
    {
        ID = id;
        Mfg = mfg;
        Model = model;
        Part = part;
        Description = description;
        Img = img;
        Price = price;
    }
}