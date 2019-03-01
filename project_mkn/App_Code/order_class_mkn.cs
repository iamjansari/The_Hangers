using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for order_class_mkn
/// </summary>
public class order_class_mkn
{
	public order_class_mkn()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int order_id { get; set; }
    public string email_id { get; set; }
    public int fk_product_id { get; set; }
    public double product_amount { get; set; }
    public int product_quantity { get; set; }
    public int product_status { get; set; }
    public string date { get; set; }
    public string size { get; set; }
}