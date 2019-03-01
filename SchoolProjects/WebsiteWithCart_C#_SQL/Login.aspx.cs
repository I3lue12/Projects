using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Login : System.Web.UI.Page
{
    protected Keymaker kenny//rare case where property is protected
    {
        get
        {
            if(Session["kenny"]==null)
            {   //if keymaker does not exist instantiate now and place into Session
                Session["kenny"] = new Keymaker();
            }
            return (Keymaker)Session["kenny"];
        }
        
    }

    protected void Page_Load(object sender, EventArgs e)
    { //Phace A
      // query = "Insert into UserInfo values ('unkindled','superstrongpass','brendon','blau','brendon@yahoo.com',29,1,'Owner');";


                                                                 // DELETE THIS LATER...
        UserInfo ui = new UserInfo("unkindled", "superstrongpass", "brendon", "blau", "asdf@asdf.com", 28, true, AdminRights.Admin);
        Session["user"] = ui;// log me in NOW
        Response.Redirect("Products.aspx");


        
        #region getting database image
        imgProd.Visible = false;
        //Keymaker kenny = new Keymaker();
        //List<Product> allProds = kenny.GetAllProducts();
        //foreach(Product p in allProds)
        //{
        //    Response.Write(p.ID + ", " + p.Mfg + ", " + p.Model + ", " + p.Part + ", " + p.Description);
        //    imgProd.ImageUrl = p.Img;
        //}
        #endregion
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    { //Phace B
       if(kenny.CheckUserExists(tbUser.Text))
        {
            if(kenny.CheckPMatches(tbUser.Text,tbPass.Text))
            {   
                UserInfo ui = kenny.GetUser(tbUser.Text);
                Session["user"] = ui; //log them in by
                Response.Redirect("Products.aspx");
            }
            else
            {
                Response.Write("Bad Password");
            }
        }
       else
        {
            Response.Write("Bad Username");
        }
    }
    protected void Page_PreRender(object sender, EventArgs e)
    {    //Phace C

    }


    protected void btnRegister_Click(object sender, EventArgs e)
    {
        //phace b
        Response.Redirect("Registration.aspx");
        
    }
}