using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

/// <summary>
/// Summary description for EmployeeAuthenticate
/// </summary>
public class EmployeeAuthenticate
{
	public EmployeeAuthenticate()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static string EmpAuthenticate(string Eid, string Epwd)
    {
        var jsonResponse="0";
        string username = "api_pstcl";
        string password = "amritsarpatiala";
        string empid = Eid;
        string pswd = Epwd;
        //string apiCredential = username + ":" + password + ":" + empid + ":" + pswd;
        //return apiCredential;
        string apiCredential = "Basic " + username + ":" + password + ":" + empid + ":" + pswd;
        const string WEBSERVICE_URL = "https://hrapipstcl.pspcl.in/api/EmployeeAuthenticate/";
        try
        {
            var webRequest = System.Net.WebRequest.Create(WEBSERVICE_URL);
            
            if (webRequest != null)
            {
                webRequest.Method = "GET";
                //webRequest.Timeout = 20000;
                webRequest.ContentType = "application/json";
                webRequest.Headers.Add("Authorization", apiCredential);
                //webRequest.Headers.Add("Authorization", "Basic dcmGV25hZFzc3VudDM6cGzdCdvQ=");
                using (System.IO.Stream s = webRequest.GetResponse().GetResponseStream())
                {
                    using (System.IO.StreamReader sr = new System.IO.StreamReader(s))
                    {
                        jsonResponse = sr.ReadToEnd();
                        Console.WriteLine(String.Format("Response: {0}", jsonResponse));
                    }
                }
            }
            
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", ex.Message, true);
        }
        return jsonResponse;
    }
}
