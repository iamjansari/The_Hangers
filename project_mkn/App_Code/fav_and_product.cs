using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for fav_and_product
/// </summary>
public class fav_and_product
{
	public fav_and_product()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int product_id { get; set; }
    public string product_name { get; set; }
    public double product_price { get; set; }
    public string product_image { get; set; }
    public string product_description { get; set; }
    public string product_size { get; set; }
    public int item_id { get; set; }

    public int favourite_id { get; set; }
    public string email_id { get; set; }
    public int fk_product_id { get; set; }
    
}