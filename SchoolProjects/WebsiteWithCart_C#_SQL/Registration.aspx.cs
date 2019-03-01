using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Registration : System.Web.UI.Page
{
    protected Keymaker kenny//rare case where property is protected
    {
        get
        {
            if (Session["kenny"] == null)
            {   //if keymaker does not exist instantiate now and place into Session.
                Session["kenny"] = new Keymaker();
            }
            return (Keymaker)Session["kenny"];
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    { //phace a
      //only time no bouncer check.
        UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        Session["user"] = null;//log them out if necesary
        
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    { //phace b
        int age = Convert.ToInt32(tbAge.Text);
        bool isMale = rbMale.Checked;
        
        UserInfo ui = new UserInfo(tbUsername.Text,tbPassword.Text,tbFirstName.Text,tbLastName.Text,tbEmail.Text,age ,isMale, AdminRights.User);
                                //tempted to put in session but we have kenny for this line 10
        kenny.CreatMember(ui);
        Response.Redirect("Login.aspx");

    }

    protected void btnOwner_Click(object sender, EventArgs e)
    {   //phace b
        kenny.CreateDBTables();
        Response.Write("tables created");
        btnOwner.Visible = false;
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {//phace c

    }



    
}