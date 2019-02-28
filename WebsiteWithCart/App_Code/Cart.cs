using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Cart
/// </summary>
 
public class Cart
{
    public decimal Total
    {
        get
        {
            decimal tot = 0.0M;
            foreach(KeyValuePair<Product,int> kvp in Items)
            {
                decimal subTot = 0.0M;//for this one product
                Product p = kvp.Key;
                decimal price = p.Price;
                int qty = kvp.Value;
                subTot = price * qty;
                tot = tot + subTot;
            }
            return tot;
        }
    }

    public Dictionary<Product,int> Items;
    public Cart(Dictionary<Product,int> prods)
    {
        Items = prods;
          
    }

    public Cart() //created a blank constructor to be able to use it on product on !ispostback
    {
        Items = new Dictionary<Product, int>();// we need this to be able to click add or it will crash.
    }

    public void Add(Product p , int qty)
    {
        if(Items.ContainsKey(p))//if already had in dictionary, update new value in cart
        {
            Items[p] += qty;
        }
        else //if not in dictionary add it now
        {
            Items.Add(p,qty);
        }
    }

    public void EmptyCart()
    {  //remove all items from the cart
        Items.Clear();
    }

    public void ChangeQuantity(Product p, int newQty)
    {
        if (newQty > 0)
        {
            Items[p] = newQty; //assosiative array  
        }
        
    }
    public void ChangeQuantityIn(Product p ,int subQty)
    {
        if (subQty >= 0) //subtract value in cart
        {
            Product pFromCart = null;
            foreach (KeyValuePair<Product, int> kvp in Items)
            {
                pFromCart = kvp.Key;
                if (pFromCart.ID == p.ID)
                {   //Items[p] -= subQty;// compares objects in RAM
                   
                    break;
                }
            }
            if (subQty > 0)
            {
                Items[pFromCart] = subQty;// compares "UPC" labels of 2 objects in RAM
            }
            else
            {
                Items.Remove(pFromCart);// new Qty = 0, so just remove him totally     
            }
        }
        
    }
  
}