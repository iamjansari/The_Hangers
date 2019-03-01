using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class feedback_view : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        WebService ws = new WebService();
        Repeater2.DataSource = ws.view_feedback();
        Repeater2.DataBind();
    
    }
}