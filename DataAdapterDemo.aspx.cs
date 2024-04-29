using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADONETDEMOS
{
    public partial class DataAdapterDemo : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Response.Write("First Time Load");
                string CS = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
                try
                {
                    using (SqlConnection con = new SqlConnection(CS))
                    {
                        SqlCommand cmd = new SqlCommand("Select top 10 * from Emails", con);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
                        
                        GridView1.DataSource = ds.Tables[0];
                        GridView1.DataBind();
                    }
                }
                catch (Exception ex)
                {
                  Response.Write(ex);
                }
                finally
                {
                    //con.Close();
                }

            }
            else
            {
                Response.Write("Page Refreshed");
            }
        }
    }
}