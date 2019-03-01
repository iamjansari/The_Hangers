using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class product_a_u_d : System.Web.UI.Page
{
    static int id = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
    
    
        WebService ws = new WebService();
        Repeater1.DataSource = ws.get_all_product();
        Repeater1.DataBind();
    

    }
    protected void new_item_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/insert_product.aspx",true);
    }
    

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        id = Convert.ToInt32(e.CommandArgument.ToString());
        if (e.CommandName == "update")
        {
            Response.Redirect("~/update_product.aspx?product_id=" + id);
        }
        else if (e.CommandName == "delete")
        {
            WebService ws = new WebService();
            int ans = ws.delete_product(id);
            if (ans == 0)
            {
                Response.Redirect("~/product_a_u_d.aspx");
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something wrong')", true);
            }
        }
        
    }
    
}