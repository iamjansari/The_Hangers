using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class signup : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void click1(object sender, EventArgs e)
    {
        WebService ws = new WebService();
        int res = ws.check_emailid(s_email_id.Text.Trim());
    
        if (res == 0)
        {
            int ans = ws.user_signup(s_email_id.Text.Trim(), s_pass.Text.Trim(), s_name.Text.Trim(), Convert.ToInt64(s_phoneno.Text.Trim()), s_add.Text.Trim(), Convert.ToInt64(s_pincode.Text.Trim()));
            if (ans == 0)
            {
                s_email_id.Text = "";

                s_pass.Text = "";
                
               s_name.Text = "";
                s_add.Text = "";
                s_phoneno.Text = "";
                s_pincode.Text = "";

                Response.Redirect("~/login.aspx", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong.')", true);
            }

        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Email ID already exists.')", true);
        }
    }

}
