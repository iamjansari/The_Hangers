using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class view_order : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        WebService ws = new WebService();
        Repeater2.DataSource = ws.view_order_admin();
        Repeater2.DataBind();
    
    }
}