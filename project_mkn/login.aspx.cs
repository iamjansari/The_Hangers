using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
   static int t = 0;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
       protected void click1(object sender, EventArgs e)
        {


            WebService cls = new WebService();
            int ans = cls.user_login(email_id.Text.Trim(), password.Text.Trim());
            if (ans == 0)
            {
                t = 1;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Email ID password not matched.')", true);

            }
            else
            {
                Response.Redirect("~/product_a_u_d.aspx");
            }
            if (t == 1)
            {
                email_id.Text = "";



            }

        }
   
     


         protected void nuser_Click(object sender, EventArgs e)
         {
             Response.Redirect("~/signup.aspx", true);
         }
  
}