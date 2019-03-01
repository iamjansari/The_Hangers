using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for product_class_mkn
/// </summary>
public class product_class_mkn
{
	public product_class_mkn()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int product_id { get; set; }
    public string product_name{get;set;}
    public double product_price{get;set;}
    public string product_image{get;set;}
    public string product_description { get; set; }
    public string product_size { get; set; }
    public int item_id { get; set; }
}