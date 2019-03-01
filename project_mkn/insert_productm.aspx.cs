using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class insert_productm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string pat = "";

        if (proimg.HasFile == true)
        {
            string ext = System.IO.Path.GetExtension(proimg.FileName);
            if (ext == ".png" || ext == ".jpeg" || ext == ".jpg" || ext == ".JPG" || ext == ".PNG")
            {
                pat = "~/image/" + proimg.FileName;
                proimg.SaveAs(Server.MapPath(pat));
            }
        }


        WebService cls = new WebService();

        int ans = cls.insert_product(proname.Text.Trim(), Convert.ToInt64(propri.Text.Trim()), pat, prodis.Text.Trim(), DropDownList1.SelectedItem.Text, Convert.ToInt32(itid.Text.Trim()));

        Response.Redirect("~/product_a_u_d.aspx");
    }
 
}