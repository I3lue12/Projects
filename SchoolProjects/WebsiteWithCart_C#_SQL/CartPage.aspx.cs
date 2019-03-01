using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO; //added for file manipulation (path.combine())
using System.Drawing; //img thumbnail creation.
using System.Web.UI.HtmlControls;

public partial class CartPage : System.Web.UI.Page
{
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
    {
        if (Session["cart"] != null)
        {
            Cart c = (Cart)Session["cart"];
            foreach(KeyValuePair<Product,int> kvp in c.Items)
            {
                Product p = kvp.Key;
                int qty = kvp.Value;
                
            }
        } 
         PopulatePlaceHolder();//fill placeholder 
       
    }

    protected void btn_DeleteClick(object sender, EventArgs e)
    {//phace b     
        Button b = (Button)sender;
        string proIDName = b.ID.Substring(3);
        int id = Convert.ToInt32(proIDName);
        if (Session["cart"] != null)
        {
            Cart c = (Cart)Session["cart"];
            Product p = kenny.GetProduct(id);
            c.ChangeQuantityIn(p, 0);
            Session["cart"] = c;
        }
    }

    protected void btn_ChangeQty(object sender, EventArgs e)
    {//phace b
        Button b = (Button)sender;
        string proIDName = b.ID.Substring(3);
        int idButton = Convert.ToInt32(proIDName); 
        if (Session["cart"] != null)
        {
            Cart c = (Cart)Session["cart"];
            Product p = kenny.GetProduct(idButton);
            foreach (Control LC in phCartPage.Controls)
            { //Search controls looking for correct text box qty        
                if (LC is TextBox)
                { // are you a textbox
                    TextBox tb = (TextBox)LC;
                    string idAsString = tb.ID.Substring(2);
                    int qtyID = Convert.ToInt32(idAsString);
                    if (qtyID == idButton)
                    {
                        string qtyAsString = tb.Text;
                        int qty = Convert.ToInt32(qtyAsString);
                        c.ChangeQuantityIn(p, Convert.ToInt32(tb.Text));
                        Session["cart"] = c;
                    }
                }
            }
        }
    }

    protected void btn_ProductPageTransfer(object sender, EventArgs e)
    {
        Response.Redirect("Products.aspx");
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {  //phace c
        if (IsPostBack)
        {
            phCartPage.Controls.Clear();//prep, re-population of controls 
            PopulatePlaceHolder(); 
        }

        Cart c = (Cart)Session["cart"];//forgot cast

        lblCPNumTotal.Text = c.Total.ToString();
    }

    protected void PopulatePlaceHolder()
    {
        if (Session["cart"] != null)
        {
            Cart c = (Cart)Session["cart"];
            foreach (KeyValuePair<Product,int> kvp in c.Items)
            {
                Product p = kvp.Key;
                int qty = kvp.Value;

                string imgFilenameDB = p.Img;
                string relThumbPath = Path.Combine("Images", "Products", "Thumbs", imgFilenameDB);
                ///\\\///\\\///\\\///\\\///\\\///
                System.Web.UI.WebControls.Image imgProd = new System.Web.UI.WebControls.Image();// programmatic instantiation
                imgProd.ImageUrl = relThumbPath;//assign it to a thumbnail
                imgProd.ID = "img" + p.ID;//give it a name containing the unique Product ID
                phCartPage.Controls.Add(imgProd);

                HtmlGenericControl br = new HtmlGenericControl("br");
                phCartPage.Controls.Add(br);

                Label lblPrice = new Label();
                lblPrice.Text =  p.Price.ToString("C");
                lblPrice.ForeColor = Color.Red;
                lblPrice.Font.Bold = true;
                phCartPage.Controls.Add(lblPrice);
                HtmlGenericControl br2 = new HtmlGenericControl("br");
                phCartPage.Controls.Add(br2);

                Label lblQty = new Label();
                lblQty.Text = "Qty:";
                phCartPage.Controls.Add(lblQty);
                
                TextBox tbQty = new TextBox();
                tbQty.ID = "tb" + p.ID;//unique foreach p csharp knows to convert p to sting
                tbQty.Text = qty.ToString();
                tbQty.Width = 20;
                tbQty.BackColor = Color.Aqua;
                tbQty.BorderStyle = BorderStyle.Groove;
                phCartPage.Controls.Add(tbQty);

                br = new HtmlGenericControl("br");
                phCartPage.Controls.Add(br);

                Button btnChange = new Button();
                btnChange.ID = "chg" + p.ID;
                btnChange.Text = "Change";
                btnChange.BackColor = Color.Teal;
                btnChange.BorderStyle = BorderStyle.Inset;
                btnChange.BorderWidth = 10;
                btnChange.Click += btn_ChangeQty;
                phCartPage.Controls.Add(btnChange);

                br = new HtmlGenericControl("br");
                phCartPage.Controls.Add(br);

                Button btnDelete = new Button();
                btnDelete.ID = "del" + p.ID;
                btnDelete.Text = "Delete";
                btnDelete.BackColor = Color.Teal;
                btnDelete.BorderStyle = BorderStyle.Inset;
                btnDelete.BorderWidth = 10;
                btnDelete.Click += btn_DeleteClick;
                phCartPage.Controls.Add(btnDelete);

                br = new HtmlGenericControl("br");
                phCartPage.Controls.Add(br);
            }
        }

        if (Session["cart"] != null)
        {
            HtmlGenericControl br = new HtmlGenericControl("br");
            
            Cart c = (Cart)Session["cart"];
            Label lblNewLabel = new Label();
            lblNewLabel.ID = "lblTotal";
            lblNewLabel.Text = "Total: " + c.Total;
            lblNewLabel.Width = 20;
            lblNewLabel.Height = 10;
            lblNewLabel.ForeColor = Color.Red;
            phCartPage.Controls.Add(lblNewLabel);
            phCartPage.Controls.Add(br);

            Button btnGoToProductPage = new Button();
            btnGoToProductPage.ID = "someCoolId";
            btnGoToProductPage.Text = "go to product page";
            btnGoToProductPage.Click += btn_ProductPageTransfer;
            btnGoToProductPage.BorderWidth = 50;
            btnGoToProductPage.Font.Bold = true;
            phCartPage.Controls.Add(btnGoToProductPage);
            br = new HtmlGenericControl("br");
            phCartPage.Controls.Add(br);
        }
    }
}