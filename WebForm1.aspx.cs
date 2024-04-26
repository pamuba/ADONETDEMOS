using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADONETDEMOS
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //1.
            string CS = "Data Source=MLBSRL1-106854;Initial Catalog=SSIS;Integrated Security=True;Connect Timeout=30;";
            //2.
            SqlConnection con =new SqlConnection(CS);
            try
            {
                //3.
                SqlCommand cmd = new SqlCommand("SELECT  * FROM EMAILS;SELECT  * FROM TestData", con);
                //4.
                con.Open();
                //5.
                //

                //dt = SqlDataAdapter

                using (SqlDataReader reader = cmd.ExecuteReader()) {
                    
                    GridView1.DataSource = reader;
                    GridView1.DataBind();
                    while (reader.NextResult()) {
                        GridView2.DataSource = reader;
                        GridView2.DataBind();
                    }

                }
                SqlDataReader reader1 = cmd.ExecuteReader();
                bool first = reader1.HasRows;
                reader1.Read();
                
                Label1.Text = reader1.GetValue(3).ToString();

                if (reader1.HasRows) {
                    while (reader1.Read())
                    {
                        reader1.Close();
                    }
                }
                
                bool r = reader1.Read();
                //todo
                bool second = reader1.HasRows;
                ////
                //SqlDataReader reader = cmd.ExecuteReader();
                ////Label1.Text = reader.FieldCount.ToString();
                ////Label1.Text = reader.GetValue(3).ToString();

                //// reader is fast, live connection, read-only, forward only

                DataTable dt = new DataTable();
                //dt.Columns.Add("Data");

                ////while (reader.Read()) {
                //reader.Read();
                //dt.Rows.Add(reader[1]+" " + reader[2]);
                //reader.Read();
                //dt.Rows.Add(reader[1] + " " + reader[2]);
                ////reader.NextResult();
                //reader.Read();
                //dt.Rows.Add(reader[1] + " " + reader[2]);
                ////}
                //GridView1.DataSource = dt;
                //GridView1.DataBind();

                //NextResult() is used when we run  two select stamts on the same command 

            }
            catch(Exception ex) {
                Console.WriteLine(ex.Message);
            }
            finally { con.Close();  }
            
        }
    }
}