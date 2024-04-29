using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.WebSockets;

namespace ADONETDEMOS
{
    public partial class DataSetDemo : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Response.Write("First Time Load");
                string CS = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
                try
                {
                    using (con = new SqlConnection(CS))
                    {
                        SqlCommand cmd = new SqlCommand("Select top 10 * from Emails", con);
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            DataTable dt = new DataTable("Emails");
                            //DataColumn col = new DataColumn("ID");
                            dt.Columns.Add("ID");
                            dt.Columns.Add("First_Name");
                            dt.Columns.Add("Last_Name");
                            dt.Columns.Add("Email");
                            dt.Columns.Add("Gender");

                            while (reader.Read())
                            {
                                DataRow row = dt.NewRow();

                                int ID = Convert.ToInt32(reader["ID"]);

                                row["ID"] = ID;
                                row["First_Name"] = reader["First_Name"];
                                row["Last_Name"] = reader["Last_Name"];
                                row["Email"] = reader["Email"];
                                row["Gender"] = reader["Gender"];

                                dt.Rows.Add(row);
                            }
                            throw new Exception("Tesst Con");
                            ds.Tables.Add(dt);
                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                        }
                        Response.Write(con.State);
                    }
                    Response.Write(con.State);
                }
                catch (Exception ex)
                {
                    Response.Write(con.State);
                    //Response.Write(ex);
                }
                finally {
                    //con.Close();
                }

            }
            else {
                Response.Write("Page Refreshed");
            }
        }
    }
}