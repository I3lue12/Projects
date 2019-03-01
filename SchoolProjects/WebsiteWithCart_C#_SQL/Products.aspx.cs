using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO; //added for file manipulation (path.combine())
using System.Drawing; //img thumbnail creation.
using System.Web.UI.HtmlControls;

public partial class Products : System.Web.UI.Page
{
    //protected string publicConstring = @"Data Source=den1.mssql3.gear.host; Database=prg412database; User ID=prg412database; Password=Sp0i_r-kt6c3;";

    protected Keymaker kenny//rare case where property is protected
    {
        get
        {
            if (Session["kenny"] == null)
            {   
                Session["kenny"] = new Keymaker();
            }
            return (Keymaker)Session["kenny"];
        }
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {   //phase a
       if(Session["user"] == null)
        {
            Response.Redirect("Login.aspx");
        }

       if(Session["cart"] == null)
        {  //only on first page load we want a cart:)        
            Cart c = new Cart();
            Session["cart"] = c;//adds the product and quantity to the cart session 
        }

        List<Product> allProds = kenny.GetAllProducts();
        foreach (Product p in allProds)
        {
            string imgFilenameDB = p.Img;
            string absImgFileNamePath = Path.Combine(Server.MapPath(""), "Images", "Products", imgFilenameDB);

            System.Drawing.Image full = System.Drawing.Image.FromFile(absImgFileNamePath);
            System.Drawing.Image thumb = full.GetThumbnailImage(100, 100, null, IntPtr.Zero);

            string absThumbPath = Path.Combine(Server.MapPath(""), "Images", "Products", "Thumbs", imgFilenameDB);
            if (!File.Exists(absThumbPath))
            {
                thumb.Save(absThumbPath);
            }
            string relThumbPath = Path.Combine("Images", "Products", "Thumbs", imgFilenameDB);
            ///\\\///\\\///\\\///\\\///\\\///
            ImageButton imgProd = new ImageButton();// programmatic instantiation
            imgProd.ImageUrl = relThumbPath;//assign it to a thumbnail
            imgProd.ID = "img" + p.ID;//give it a name containing the unique Product ID
            imgProd.Click += ImgProd_Click;
            phMain.Controls.Add(imgProd);

            HtmlGenericControl br = new HtmlGenericControl("br");
            phMain.Controls.Add(br);

            Label lblMfr = new Label();
            lblMfr.Text = p.Model;
            lblMfr.ForeColor = Color.Red;
            lblMfr.Font.Bold = true;
            phMain.Controls.Add(lblMfr);
            HtmlGenericControl br2 = new HtmlGenericControl("br");
            phMain.Controls.Add(br2);

            Label lblModel = new Label();
            lblModel.Text = p.Model;
            phMain.Controls.Add(lblModel);
            HtmlGenericControl br3 = new HtmlGenericControl("br");
            phMain.Controls.Add(br3);

            Label lblPart = new Label();
            lblPart.Text = p.Part;
            br = new HtmlGenericControl("br");
            phMain.Controls.Add(br);

            Label lblQty = new Label();
            lblQty.Text = "Qty:";
            phMain.Controls.Add(lblQty);

            TextBox tbQty = new TextBox();
            tbQty.ID = "tb" + p.ID;//unique foreach p csharp knows to convert p to sting
            tbQty.Text = "1";
            tbQty.Width = 10;
            tbQty.BackColor = Color.Aqua;
            tbQty.BorderStyle = BorderStyle.Groove;
            phMain.Controls.Add(tbQty);

            Button btnAddToCart = new Button();
            btnAddToCart.ID = "btn" + p.ID;
            btnAddToCart.Text = "Add To Cart";
            btnAddToCart.BackColor = Color.Teal;
            btnAddToCart.BorderStyle = BorderStyle.Inset;
            btnAddToCart.BorderWidth = 10;
            btnAddToCart.Click += BtnAddToCart_Click;
            phMain.Controls.Add(btnAddToCart);

            br = new HtmlGenericControl("br");
            phMain.Controls.Add(br);

        }

        Button btnViewCart = new Button();
        btnViewCart.ID = "btnViewCart";
        btnViewCart.Text = "View Your Cart";
        btnViewCart.BackColor = Color.Black;
        btnViewCart.ForeColor = Color.White;
        btnViewCart.BorderWidth = 10;
        btnViewCart.Click += BtnViewCart;
        phMain.Controls.Add(btnViewCart);
        
    }
                                                                                                                                             
    protected void Page_PreRender(object sender, EventArgs e)
    {  //phase c        
        UserInfo ui = (UserInfo)Session["user"];
        lblTitle.Text = "hello, " + ui.First + " " + ui.Last + "</r/n>";
    }

    private void BtnAddToCart_Click(object sender, EventArgs e)
    {

        Button b = (Button)sender;
        string proIDName = b.ID.Substring(3);
        int id = Convert.ToInt32(proIDName);
        //TextBox q = (TextBox)sender;//why wont this work -?-
        //string qty = q.ID.Substring(3);//
        //int quantID = Convert.ToInt32(qty);
        if (Session["cart"] != null)
        {
            Cart c = (Cart)Session["cart"];
            Product p = kenny.GetProduct(id); 
            foreach(Control LC in phMain.Controls)
            { //Search controls looking for correct text box qty        
                if(LC is TextBox)
                { // are you a textbox
                    TextBox tb = (TextBox)LC;
                    string idAsString = tb.ID.Substring(2);
                    int qtyID = Convert.ToInt32(idAsString);
                    if(qtyID == id)
                    {
                        string qtyAsString = tb.Text;
                        int qtyToAdd = Convert.ToInt32(qtyAsString);
                        int qtyAlreadyInCart = 0;
                        bool found = false;//assume we cant find product in cart
                        foreach(KeyValuePair<Product, int> kvp in c.Items)
                        {
                            if(kvp.Key.ID == p.ID)
                            {
                                found = true;//found the item already in cart. 
                                qtyAlreadyInCart = kvp.Value;//store the qty of that item in cart
                            }
                        }
                        if(found)
                        {
                            c.ChangeQuantityIn(p, qtyAlreadyInCart + qtyToAdd);
                        }
                        else
                        {
                            c.Add(p, qtyToAdd);
                        }
                        
                        Session["cart"] = c;
                    }
                }
            }
            //temp
            //Response.Redirect("CartPage.aspx");
        }  
    }

    private void ImgProd_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton ib = (ImageButton)sender;
        string idAsString = ib.ID.Substring(3);
        int id = Convert.ToInt32(idAsString);
        Session["product"] = id;//place id into session
        Response.Redirect("Detail.aspx");//send to detail page
    }

    private void BtnViewCart(object sender, EventArgs e)
    {
        Response.Redirect("CartPage.aspx");
    }
}