using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for feedback_user_class_mkn
/// </summary>
public class feedback_user_class_mkn
{
	public feedback_user_class_mkn()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public string email_id { get; set; }
    public string name { get; set; }
    public double mobile_no { get; set; }
    public string address { get; set; }
    public string password { get; set; }
    public double pincode { get; set; }
    public string question { get; set; }
    public string answer { get; set; }
    

    public int feedback_id { get; set; }
    public string feedback { get; set; }
    public string fk_email_id { get; set; }





}