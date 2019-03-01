using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class view_user : System.Web.UI.Page
{
    String email_id="";
          static int id = 0;
    protected void Page_Load(object sender, EventArgs e)
    {

    
    
        WebService ws = new WebService();
        Repeater1.DataSource = ws.view_user();
        Repeater1.DataBind();
    

    }
    

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        
        email_id = (e.CommandArgument.ToString());
        if (e.CommandName == "delete")
        {
            WebService ws = new WebService();
            int ans = ws.delete_user(email_id);
            if (ans == 0)
            {
                Response.Redirect("~/view_user.aspx");
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something wrong')", true);
            }
        }
        
    }
   

    }
