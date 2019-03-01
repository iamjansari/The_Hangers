using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default4 : System.Web.UI.Page
{
            static int id=0;
  
    protected void Page_Load(object sender, EventArgs e)
    {


                if (!IsPostBack)
        {
            id = Convert.ToInt32(Request.QueryString["product_id"].ToString());
            
            WebService ws = new WebService();
            List<product_class_mkn> lst = new List<product_class_mkn>();
            lst = ws.get_all_by_productid(id);
            
            pnm.Text = lst[0].product_name;
            Image1.ImageUrl = lst[0].product_image;
            pp.Text = lst[0].product_price + "";
            DropDownList2.SelectedValue = lst[0].product_size;
            pd.Text = lst[0].product_description;
            uitid.Text = lst[0].item_id+"";

        }
    }
    protected void proupdate_Click(object sender, EventArgs e)
{
    string path = "", ext = "";
    if(pnm.Text=="" && pp.Text=="" && path=="" && pd.Text=="")
    {
        
    if (FileUpload1.HasFile == true)
    {
        ext = System.IO.Path.GetExtension(FileUpload1.FileName);
        if (ext == ".jpeg" || ext == ".jpg" || ext == ".png" || ext == ".JPG")
        {
            path = "~/image/" + FileUpload1.FileName;
            FileUpload1.SaveAs(Server.MapPath(path));
        }
    }
    else
    {
        path = Image1.ImageUrl;
    }
    }
    WebService ws = new WebService();
    int ans = ws.update_product(id,pnm.Text,Convert.ToDouble(pp.Text),path,pd.Text,DropDownList2.SelectedItem.Text,Convert.ToInt32(uitid.Text.Trim()));
    if (ans == 0)
    {
        Response.Redirect("~/product_a_u_d.aspx");
    }   
 }


}
