using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Script.Services;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService
{

    SqlConnection cnn;
    SqlDataAdapter da;
    SqlCommand cmd;
    DataTable dt;
    DataSet ds;

    private string getcnnstr()
    {
        return ConfigurationManager.ConnectionStrings["DatabaseConnectionString1"].ConnectionString;
    }


    public WebService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public int user_login(string email_id, string pass)
    {
        cnn = new SqlConnection(getcnnstr());
        cmd = new SqlCommand("select * from user_tbl_mkn where email_id='" + email_id + "' and password='" + pass + "'", cnn);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        dt = new DataTable();
        dt = ds.Tables[0];
        return dt.Rows.Count;


    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public int user_signup(string email, string pass, string name, double mobileno, string address, double pincode)
    {
        int flag = 0;
        try
        {


            cnn = new SqlConnection(getcnnstr());
            cmd = new SqlCommand("insert into user_tbl_mkn (email_id,name,mobile_no,address,password,pincode) values (@email_id,@name,@mobile_no,@address,@password,@pincode)", cnn);
            cmd.Parameters.AddWithValue("@email_id", email);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@mobile_no", mobileno);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.Parameters.AddWithValue("@password", pass);

            cmd.Parameters.AddWithValue("@pincode", pincode);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        catch (Exception ex)
        {
            flag = 1;
            cnn.Close();
        }
        return flag;
    }




    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public int user_signup_app(string email, string pass, string name, double mobileno, string address, double pincode,string question,string answer)
    {
        int flag = 0;
        try
        {


            cnn = new SqlConnection(getcnnstr());
            cmd = new SqlCommand("insert into user_tbl_mkn (email_id,name,mobile_no,address,password,pincode,question,answer) values (@email_id,@name,@mobile_no,@address,@password,@pincode,@question,@answer)", cnn);
            cmd.Parameters.AddWithValue("@email_id", email);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@mobile_no", mobileno);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.Parameters.AddWithValue("@password", pass);

            cmd.Parameters.AddWithValue("@pincode", pincode);
            cmd.Parameters.AddWithValue("@question", question);
            cmd.Parameters.AddWithValue("@answer", answer);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        catch (Exception ex)
        {
            flag = 1;
            cnn.Close();
        }
        return flag;
    }





    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public int inser_feedback(string fk_email_id,string feedback)
    {
        int flag = 0;
        try
        {


            cnn = new SqlConnection(getcnnstr());
            cmd = new SqlCommand("insert into feedback_tbl_mkn (feedback,fk_email_id) values (@feedback,@fk_email_id)", cnn);
            cmd.Parameters.AddWithValue("@fk_email_id", fk_email_id);
           
            cmd.Parameters.AddWithValue("@feedback", feedback);
            
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        catch (Exception ex)
        {
            flag = 1;
            cnn.Close();
        }
        return flag;
    }



    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public int insert_product(string productname, double price, string img, string description, string size, int item_id)
    {
        int flag = 0;
        try
        {
            cnn = new SqlConnection(getcnnstr());
            cmd = new SqlCommand("insert into product_tbl_mkn (product_name,product_price,product_image,product_description,product_size,item_id) values (@product_name,@product_price,@product_image,@product_description,@product_size,@item_id)", cnn);

            cmd.Parameters.AddWithValue("@product_name", productname);
            cmd.Parameters.AddWithValue("@product_price", price);
            cmd.Parameters.AddWithValue("@product_image", img);
            cmd.Parameters.AddWithValue("@product_description", description);

            cmd.Parameters.AddWithValue("@product_size", size);
            cmd.Parameters.AddWithValue("@item_id", item_id);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        catch (Exception ex)
        {
            flag = 1;
            cnn.Close();
        }
        return flag;
    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public int check_emailid(string email)
    {
        cnn = new SqlConnection(getcnnstr());
        cmd = new SqlCommand("select * from user_tbl_mkn where email_id='" + email + "'", cnn);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        dt = new DataTable();
        dt = ds.Tables[0];
        return dt.Rows.Count;
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
    public List<order_class_mkn> get_all_columnof_ordertbl()
    {
        cnn = new SqlConnection(getcnnstr());
        cmd = new SqlCommand("SELECT * from order_tbl_mkn", cnn);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        dt = new DataTable();
        dt = ds.Tables[0];
        List<order_class_mkn> lst1 = new List<order_class_mkn>();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            lst1.Add(new order_class_mkn()
            {
                order_id = Convert.ToInt32(dt.Rows[i]["order_id"].ToString()),
                email_id = (dt.Rows[i]["email_id"].ToString()),
                fk_product_id = Convert.ToInt32(dt.Rows[i]["fk_product_id"].ToString()),
                product_amount = Convert.ToDouble(dt.Rows[i]["product_amount"].ToString()),
                product_quantity = Convert.ToInt32(dt.Rows[i]["product_quantity"].ToString()),
                product_status = Convert.ToInt32(dt.Rows[i]["product_status"].ToString()),
                date = (dt.Rows[i]["date"].ToString()),
                size = (dt.Rows[i]["size"].ToString())


            });
        }
        return lst1;


    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
    public int update(int order_id, string email_id, int fk_product_id, double product_amount, int product_quantity, int product_status, string date, string size)
    {
        int flag = 0;
        try
        {

            cnn = new SqlConnection(getcnnstr());
            cmd = new SqlCommand("UPDATE order_tbl_mkn set  email_id=@email_id,fk_product_id=@fk_product_id,product_amount=@product_amount,product_quantity=@product_quantity,product_status=@product_status,date=@date,size=@size where order_id='" + order_id + "'", cnn);


            cmd.Parameters.AddWithValue("@email_id", email_id);


            cmd.Parameters.AddWithValue("@fk_product_id", fk_product_id);
            cmd.Parameters.AddWithValue("@product_amount", product_amount);

            cmd.Parameters.AddWithValue("@product_quantity", product_quantity);
            cmd.Parameters.AddWithValue("@product_status", product_status);
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@size", size);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();

        }
        catch (Exception ex)
        {
            flag = 1;
        }
        return flag;
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
    public int delete_order(int order_id)
    {
        int flag = 0;
        try
        {
            cnn = new SqlConnection(getcnnstr());
            cmd = new SqlCommand("DELETE from order_tbl_mkn WHERE order_id='" + order_id + "'", cnn);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();

        }
        catch (Exception ex)
        {

            flag = 1;
        }
        return flag;
    }




    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
    public int delete_feedback(string email_id)
    {
        int flag = 0;
        try
        {
            cnn = new SqlConnection(getcnnstr());
            cmd = new SqlCommand("DELETE from feedback_tbl_mkn WHERE fk_email_id='" + email_id + "'", cnn);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();

        }
        catch (Exception ex)
        {

            flag = 1;
        }
        return flag;
    }




    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
    public int delete_user(string order_id)
    {
        int flag = 0;
        try
        {
            cnn = new SqlConnection(getcnnstr());
            cmd = new SqlCommand("DELETE from user_tbl_mkn WHERE email_id='" + order_id + "'", cnn);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();

        }
        catch (Exception ex)
        {

            flag = 1;
        }
        return flag;
    }




    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
    public int delete_product(int order_id)
    {
        int flag = 0;
        try
        {
            cnn = new SqlConnection(getcnnstr());
            cmd = new SqlCommand("DELETE from product_tbl_mkn WHERE product_id='" + order_id + "'", cnn);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();

        }
        catch (Exception ex)
        {

            flag = 1;
        }
        return flag;
    }



    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<order_class_mkn> get_all_by_orderid(int ord)
    {
        cnn = new SqlConnection(getcnnstr());
        cmd = new SqlCommand("select * from order_tbl_mkn where order_id='" + ord + "'", cnn);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        dt = new DataTable();
        dt = ds.Tables[0];
        List<order_class_mkn> lst1 = new List<order_class_mkn>();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            lst1.Add(new order_class_mkn()
            {


                order_id = Convert.ToInt32(dt.Rows[i]["order_id"].ToString()),
                //email_id = (dt.Rows[i]["email_id"].ToString()),
                email_id = (dt.Rows[i]["email_id"].ToString()),
                fk_product_id = Convert.ToInt32(dt.Rows[i]["fk_product_id"].ToString()),
                product_amount = Convert.ToDouble(dt.Rows[i]["product_amount"].ToString()),
                product_quantity = Convert.ToInt32(dt.Rows[i]["product_quantity"].ToString()),
                product_status = Convert.ToInt32(dt.Rows[i]["product_status"].ToString()),
                date = (dt.Rows[i]["date"].ToString()),
                size = (dt.Rows[i]["size"].ToString())


            });
        }
        return lst1;


    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<product_class_mkn> get_all_by_productid(int ord)
    {
        cnn = new SqlConnection(getcnnstr());
        cmd = new SqlCommand("select * from product_tbl_mkn where product_id='" + ord + "'", cnn);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        dt = new DataTable();
        dt = ds.Tables[0];
        List<product_class_mkn> lst1 = new List<product_class_mkn>();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            lst1.Add(new product_class_mkn()
            {


                product_id = Convert.ToInt32(dt.Rows[i]["product_id"].ToString()),
                product_name = (dt.Rows[i]["product_name"].ToString()),
                product_price = Convert.ToDouble(dt.Rows[i]["product_price"].ToString()),
                product_image = (dt.Rows[i]["product_image"].ToString()),
                product_description = (dt.Rows[i]["product_description"].ToString()),
                product_size = (dt.Rows[i]["product_size"].ToString()),

            });
        }
        return lst1;


    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<product_class_mkn> get_all_product()
    {
        cnn = new SqlConnection(getcnnstr());
        cmd = new SqlCommand("select * from product_tbl_mkn", cnn);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        dt = new DataTable();
        dt = ds.Tables[0];
        List<product_class_mkn> lst1 = new List<product_class_mkn>();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            lst1.Add(new product_class_mkn()
            {
                product_id = Convert.ToInt32(dt.Rows[i]["product_id"].ToString()),
                product_name = (dt.Rows[i]["product_name"].ToString()),
                product_price = Convert.ToDouble(dt.Rows[i]["product_price"].ToString()),
                product_image = (dt.Rows[i]["product_image"].ToString()),
                product_description = (dt.Rows[i]["product_description"].ToString()),
                product_size = (dt.Rows[i]["product_size"].ToString()),
                item_id = Convert.ToInt32(dt.Rows[i]["item_id"].ToString())
            });
        }
        return lst1;


    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
    public int update_product(int product_id, string product_name, double product_price, string product_image, string product_description, string product_size, int item_id)
    {
        int flag = 0;
        try
        {

            cnn = new SqlConnection(getcnnstr());
            cmd = new SqlCommand("UPDATE product_tbl_mkn set product_name=@product_name,product_price=@product_price,product_image=@product_image,product_description=@product_description, product_size=@product_size,item_id=@item_id where product_id='" + product_id + "'", cnn);





            cmd.Parameters.AddWithValue("@product_name", product_name);
            cmd.Parameters.AddWithValue("@product_price", product_price);

            cmd.Parameters.AddWithValue("@product_description", product_description);
            cmd.Parameters.AddWithValue("@product_size", product_size);
            cmd.Parameters.AddWithValue("@product_image", product_image);
            cmd.Parameters.AddWithValue("@item_id", item_id);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();

        }
        catch (Exception ex)
        {
            flag = 1;
        }
        return flag;
    }



    /*[WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
    public int update_order(int order_id, string email_id,int fk_product_id, double product_amount,int product_quantity,int product_status, String date,String size)
    {
        int flag = 0;
        try
        {

            cnn = new SqlConnection(getcnnstr());
            cmd = new SqlCommand("UPDATE product_tbl_mkn set product_name=@product_name,product_price=@product_price,product_image=@product_image,product_description=@product_description, product_size=@product_size,item_id=@item_id where product_id='" + product_id + "'", cnn);





            cmd.Parameters.AddWithValue("@product_name", product_name);
            cmd.Parameters.AddWithValue("@product_price", product_price);

            cmd.Parameters.AddWithValue("@product_description", product_description);
            cmd.Parameters.AddWithValue("@product_size", product_size);
            cmd.Parameters.AddWithValue("@product_image", product_image);
            cmd.Parameters.AddWithValue("@item_id", item_id);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();

        }
        catch (Exception ex)
        {
            flag = 1;
        }
        return flag;
    }


    */


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public int insert_order(int order_id, string email_id, int fk_product_id, double product_amount, int product_quantity, int product_status, string date, string size)
    {
        int flag = 0;
        try
        {
            cnn = new SqlConnection(getcnnstr());
            cmd = new SqlCommand("insert into order_tbl_mkn () values ()", cnn);

            cmd.Parameters.AddWithValue("@email_id", email_id);


            cmd.Parameters.AddWithValue("@fk_product_id", fk_product_id);
            cmd.Parameters.AddWithValue("@product_amount", product_amount);

            cmd.Parameters.AddWithValue("@product_quantity", product_quantity);
            cmd.Parameters.AddWithValue("@product_status", product_status);
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@size", size);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        catch (Exception ex)
        {
            flag = 1;
            cnn.Close();
        }
        return flag;
    }



    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<menu_class_mkn> get_all_item()
    {
        cnn = new SqlConnection(getcnnstr());
        cmd = new SqlCommand("select * from menu_tbl_mkn", cnn);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        dt = new DataTable();
        dt = ds.Tables[0];
        List<menu_class_mkn> lst1 = new List<menu_class_mkn>();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            lst1.Add(new menu_class_mkn()
            {
                item_id = Convert.ToInt32(dt.Rows[i]["item_id"].ToString()),
                item_name = (dt.Rows[i]["item_name"].ToString()),
                item_image = (dt.Rows[i]["item_image"].ToString()),

            });
        }
        return lst1;


    }
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<product_class_mkn> search_by_product_name(string name)
    {
        cnn = new SqlConnection(getcnnstr());
        cmd = new SqlCommand("select * from product_tbl_mkn where product_name like '" + name + "%'", cnn);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        dt = new DataTable();
        dt = ds.Tables[0];
        List<product_class_mkn> lst1 = new List<product_class_mkn>();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            lst1.Add(new product_class_mkn()
            {
                product_id = Convert.ToInt32(dt.Rows[i]["product_id"].ToString()),
                product_name = (dt.Rows[i]["product_name"].ToString()),
                product_price = Convert.ToDouble(dt.Rows[i]["product_price"].ToString()),
                product_image = (dt.Rows[i]["product_image"].ToString()),
                product_description = (dt.Rows[i]["product_description"].ToString()),
                product_size = (dt.Rows[i]["product_size"].ToString()),
                item_id = Convert.ToInt32(dt.Rows[i]["item_id"].ToString())
            });
        }
        return lst1;


    }



    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<product_class_mkn> search_by_product_price_less_1001()
    {
        cnn = new SqlConnection(getcnnstr());
        cmd = new SqlCommand("select * from product_tbl_mkn where product_price <1001", cnn);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        dt = new DataTable();
        dt = ds.Tables[0];
        List<product_class_mkn> lst1 = new List<product_class_mkn>();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            lst1.Add(new product_class_mkn()
            {
                product_id = Convert.ToInt32(dt.Rows[i]["product_id"].ToString()),
                product_name = (dt.Rows[i]["product_name"].ToString()),
                product_price = Convert.ToDouble(dt.Rows[i]["product_price"].ToString()),
                product_image = (dt.Rows[i]["product_image"].ToString()),
                product_description = (dt.Rows[i]["product_description"].ToString()),
                product_size = (dt.Rows[i]["product_size"].ToString()),
                item_id = Convert.ToInt32(dt.Rows[i]["item_id"].ToString())
            });
        }
        return lst1;

    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<product_class_mkn> search_by_product_price_1000_1500()
    {
        cnn = new SqlConnection(getcnnstr());
        cmd = new SqlCommand("select * from product_tbl_mkn where product_price BETWEEN 1000 and 1501", cnn);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        dt = new DataTable();
        dt = ds.Tables[0];
        List<product_class_mkn> lst1 = new List<product_class_mkn>();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            lst1.Add(new product_class_mkn()
            {
                product_id = Convert.ToInt32(dt.Rows[i]["product_id"].ToString()),
                product_name = (dt.Rows[i]["product_name"].ToString()),
                product_price = Convert.ToDouble(dt.Rows[i]["product_price"].ToString()),
                product_image = (dt.Rows[i]["product_image"].ToString()),
                product_description = (dt.Rows[i]["product_description"].ToString()),
                product_size = (dt.Rows[i]["product_size"].ToString()),
                item_id = Convert.ToInt32(dt.Rows[i]["item_id"].ToString())
            });
        }
        return lst1;



    }




    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<product_class_mkn> search_by_product_price_1500_2001()
    {
        cnn = new SqlConnection(getcnnstr());
        cmd = new SqlCommand("select * from product_tbl_mkn where product_price BETWEEN 1500 and 2001", cnn);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        dt = new DataTable();
        dt = ds.Tables[0];
        List<product_class_mkn> lst1 = new List<product_class_mkn>();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            lst1.Add(new product_class_mkn()
            {
                product_id = Convert.ToInt32(dt.Rows[i]["product_id"].ToString()),
                product_name = (dt.Rows[i]["product_name"].ToString()),
                product_price = Convert.ToDouble(dt.Rows[i]["product_price"].ToString()),
                product_image = (dt.Rows[i]["product_image"].ToString()),
                product_description = (dt.Rows[i]["product_description"].ToString()),
                product_size = (dt.Rows[i]["product_size"].ToString()),
                item_id = Convert.ToInt32(dt.Rows[i]["item_id"].ToString())
            });
        }
        return lst1;



    }



    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<product_class_mkn> search_by_product_price_gret_2000()
    {
        cnn = new SqlConnection(getcnnstr());
        cmd = new SqlCommand("select * from product_tbl_mkn where product_price > 2000", cnn);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        dt = new DataTable();
        dt = ds.Tables[0];
        List<product_class_mkn> lst1 = new List<product_class_mkn>();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            lst1.Add(new product_class_mkn()
            {
                product_id = Convert.ToInt32(dt.Rows[i]["product_id"].ToString()),
                product_name = (dt.Rows[i]["product_name"].ToString()),
                product_price = Convert.ToDouble(dt.Rows[i]["product_price"].ToString()),
                product_image = (dt.Rows[i]["product_image"].ToString()),
                product_description = (dt.Rows[i]["product_description"].ToString()),
                product_size = (dt.Rows[i]["product_size"].ToString()),
                item_id = Convert.ToInt32(dt.Rows[i]["item_id"].ToString())
            });
        }
        return lst1;

    }




    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<product_class_mkn> search_by_product_price_asending()
    {
        cnn = new SqlConnection(getcnnstr());
        cmd = new SqlCommand("select * from product_tbl_mkn ORDER BY product_price asc", cnn);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        dt = new DataTable();
        dt = ds.Tables[0];
        List<product_class_mkn> lst1 = new List<product_class_mkn>();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            lst1.Add(new product_class_mkn()
            {
                product_id = Convert.ToInt32(dt.Rows[i]["product_id"].ToString()),
                product_name = (dt.Rows[i]["product_name"].ToString()),
                product_price = Convert.ToDouble(dt.Rows[i]["product_price"].ToString()),
                product_image = (dt.Rows[i]["product_image"].ToString()),
                product_description = (dt.Rows[i]["product_description"].ToString()),
                product_size = (dt.Rows[i]["product_size"].ToString()),
                item_id = Convert.ToInt32(dt.Rows[i]["item_id"].ToString())
            });
        }
        return lst1;

    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<product_class_mkn> search_by_product_price_desc()
    {
        cnn = new SqlConnection(getcnnstr());
        cmd = new SqlCommand("select * from product_tbl_mkn ORDER BY product_price desc", cnn);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        dt = new DataTable();
        dt = ds.Tables[0];
        List<product_class_mkn> lst1 = new List<product_class_mkn>();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            lst1.Add(new product_class_mkn()
            {
                product_id = Convert.ToInt32(dt.Rows[i]["product_id"].ToString()),
                product_name = (dt.Rows[i]["product_name"].ToString()),
                product_price = Convert.ToDouble(dt.Rows[i]["product_price"].ToString()),
                product_image = (dt.Rows[i]["product_image"].ToString()),
                product_description = (dt.Rows[i]["product_description"].ToString()),
                product_size = (dt.Rows[i]["product_size"].ToString()),
                item_id = Convert.ToInt32(dt.Rows[i]["item_id"].ToString())
            });
        }
        return lst1;

    }



    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public int fav_add(String email_id, int fk_product_id)
    {
        int flag = 0;
        try
        {


            cnn = new SqlConnection(getcnnstr());
            cmd = new SqlCommand("insert into favourite_tbl_mkn (email_id,fk_product_id) values (@email_id,@fk_product_id)", cnn);

            cmd.Parameters.AddWithValue("@email_id", email_id);
            cmd.Parameters.AddWithValue("@fk_product_id", fk_product_id);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        catch (Exception ex)
        {
            flag = 1;
            cnn.Close();
        }
        return flag;
    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<fav_and_product> view_fav()
    {
        cnn = new SqlConnection(getcnnstr());
        cmd = new SqlCommand("select * from favourite_tbl_mkn as f , product_tbl_mkn as p where f.fk_product_id = p.product_id", cnn);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        dt = new DataTable();
        dt = ds.Tables[0];
        List<fav_and_product> lst1 = new List<fav_and_product>();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            lst1.Add(new fav_and_product()
            {
                product_id = Convert.ToInt32(dt.Rows[i]["product_id"].ToString()),
                product_name = (dt.Rows[i]["product_name"].ToString()),
                product_price = Convert.ToDouble(dt.Rows[i]["product_price"].ToString()),
                product_image = (dt.Rows[i]["product_image"].ToString()),
                product_description = (dt.Rows[i]["product_description"].ToString()),
                product_size = (dt.Rows[i]["product_size"].ToString()),
                item_id = Convert.ToInt32(dt.Rows[i]["item_id"].ToString()),

                fk_product_id = Convert.ToInt32(dt.Rows[i]["fk_product_id"].ToString()),
                email_id = (dt.Rows[i]["email_id"].ToString()),
                favourite_id = Convert.ToInt32(dt.Rows[i]["favourite_id"].ToString())
            });
        }
        return lst1;

    }



 /*   [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<feedback_user_class_mkn> view_feedback()
    {
        cnn = new SqlConnection(getcnnstr());
        cmd = new SqlCommand("select * from feedback_tbl_mkn as f , user_tbl_mkn as u where f.fk_email_id = u.email_id", cnn);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        dt = new DataTable();
        dt = ds.Tables[0];
        List<feedback_user_class_mkn> lst1 = new List<feedback_user_class_mkn>();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            lst1.Add(new feedback_user_class_mkn()
            {


                fk_email_id = (dt.Rows[i]["fk_email_id"].ToString()),
                feedback_id = Convert.ToInt32(dt.Rows[i]["feedback_id"].ToString()),
                feedback = (dt.Rows[i]["feedback"].ToString()),

                mobile_no = Convert.ToDouble(dt.Rows[i]["mobile_no"].ToString()),
                address = (dt.Rows[i]["address"].ToString()),
                password = (dt.Rows[i]["password"].ToString()),
                pincode = Convert.ToInt32(dt.Rows[i]["pincode"].ToString()),
                name = (dt.Rows[i]["name"].ToString()),
                email_id = (dt.Rows[i]["email_id"].ToString())


            });
        }
        return lst1;

    }


    */



    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<feedback_class_mkn> view_feedback()
    {
        cnn = new SqlConnection(getcnnstr());
        cmd = new SqlCommand("select * from feedback_tbl_mkn", cnn);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        dt = new DataTable();
        dt = ds.Tables[0];
        List<feedback_class_mkn> lst1 = new List<feedback_class_mkn>();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            lst1.Add(new feedback_class_mkn()
            {


                fk_email_id = (dt.Rows[i]["fk_email_id"].ToString()),
                feedback_id = Convert.ToInt32(dt.Rows[i]["feedback_id"].ToString()),
                feedback = (dt.Rows[i]["feedback"].ToString()),



            });
        }
        return lst1;

    }




    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<order_class_mkn> view_order_admin()
    {
        cnn = new SqlConnection(getcnnstr());
        cmd = new SqlCommand("select * from order_tbl_mkn", cnn);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        dt = new DataTable();
        dt = ds.Tables[0];
        List<order_class_mkn> lst1 = new List<order_class_mkn>();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            lst1.Add(new order_class_mkn()
            {
                order_id = Convert.ToInt32(dt.Rows[i]["order_id"].ToString()),
                size = (dt.Rows[i]["size"].ToString()),
                product_amount = Convert.ToDouble(dt.Rows[i]["product_amount"].ToString()),
                product_quantity = Convert.ToInt32(dt.Rows[i]["product_quantity"].ToString()),
                product_status = Convert.ToInt32(dt.Rows[i]["product_status"].ToString()),
                fk_product_id = Convert.ToInt32(dt.Rows[i]["fk_product_id"].ToString()),
                date = (dt.Rows[i]["date"].ToString()),
                email_id = (dt.Rows[i]["email_id"].ToString()),
                
            });
        }
        return lst1;

    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<order_class_mkn> view_order(String email_id)
    {
        cnn = new SqlConnection(getcnnstr());
        cmd = new SqlCommand("select * from order_tbl_mkn where email_id = '" + email_id + "'", cnn);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        dt = new DataTable();
        dt = ds.Tables[0];
        List<order_class_mkn> lst1 = new List<order_class_mkn>();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            lst1.Add(new order_class_mkn()
            {
                order_id = Convert.ToInt32(dt.Rows[i]["order_id"].ToString()),
                size = (dt.Rows[i]["size"].ToString()),
                product_amount = Convert.ToDouble(dt.Rows[i]["product_amount"].ToString()),
                product_quantity = Convert.ToInt32(dt.Rows[i]["product_quantity"].ToString()),
                product_status = Convert.ToInt32(dt.Rows[i]["product_status"].ToString()),
                fk_product_id = Convert.ToInt32(dt.Rows[i]["fk_product_id"].ToString()),
                date = (dt.Rows[i]["date"].ToString()),
                email_id = (dt.Rows[i]["email_id"].ToString()),

            });
        }
        return lst1;

    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<user_class_mkn> view_user()
    {
        cnn = new SqlConnection(getcnnstr());
        cmd = new SqlCommand("select * from user_tbl_mkn", cnn);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        dt = new DataTable();
        dt = ds.Tables[0];
        List<user_class_mkn> lst1 = new List<user_class_mkn>();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            lst1.Add(new user_class_mkn()
            {
                mobile_no = Convert.ToDouble(dt.Rows[i]["mobile_no"].ToString()),
                address = (dt.Rows[i]["address"].ToString()),
                password = (dt.Rows[i]["password"].ToString()),
                pincode = Convert.ToInt32(dt.Rows[i]["pincode"].ToString()),
                name = (dt.Rows[i]["name"].ToString()),
                email_id = (dt.Rows[i]["email_id"].ToString()),

            });
        }
        return lst1;

    }





    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public int forgot_pass(string email_id,string answer)
   
    {
        int flag = 0;
        try
        {
            cnn = new SqlConnection(getcnnstr());
            cmd = new SqlCommand("select * from user_tbl_mkn where email_id='" + email_id + "' and answer='" + answer + "'", cnn);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            dt = new DataTable();
            dt = ds.Tables[0];
        }

        catch (Exception ex)
        {
            flag = 1;
            cnn.Close();
        }
        return flag;
    }



    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
    public int update_forgot_passwprd(string email_id,string password)
    {
        int flag = 0;
        try
        {

            cnn = new SqlConnection(getcnnstr());
            cmd = new SqlCommand("UPDATE user_tbl_mkn set password=@password where email_id='" + email_id + "'", cnn);


           // cmd.Parameters.AddWithValue("@email_id", email_id);


            cmd.Parameters.AddWithValue("@password", password);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();

        }
        catch (Exception ex)
        {
            flag = 1;
        }
        return flag;
    }




}
