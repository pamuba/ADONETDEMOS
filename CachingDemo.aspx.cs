using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ADONETDEMOS
{
    public partial class CachingDemo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLoad_Click(object sender, EventArgs e)
        {

            if (Cache["Data"] == null)
            {
                string CS = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
                using (SqlConnection cn = new SqlConnection(CS))
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT TOP (10) [FirstName] ,[MiddleName] ,[LastName],[Suffix] ,[CompanyName],[SalesPerson],[EmailAddress],[Phone] FROM [SSIS].[dbo].[Customer]", cn);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    Cache["Data"] = ds;

                    Gridview1.DataSource = ds;
                    Gridview1.DataBind();
                }
                Label1.Text = "Data loaded from the database.";
            }
            else {
                Gridview1.DataSource = (DataSet)Cache["Data"];
                Gridview1.DataBind();

                Label1.Text = "Data loaded from the Cache.";
            }
        }

        protected void ClrCache_Click(object sender, EventArgs e)
        {
            if (Cache["Data"] != null)
            {
                Cache.Remove("Data");
                Label1.Text = "Data removed from the Cache.";
                Gridview1.DataSource = null;
                Gridview1.DataBind();
            }
            else {
                Label1.Text = "Nothing in the Cache.";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label2.Text = "";
            string CS = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
            SqlConnection cn = new SqlConnection(CS);
            string sqlQuery = "select * from address where AddressID=" + TextBox1.Text;    
            SqlDataAdapter da = new SqlDataAdapter(sqlQuery, cn);
            DataSet ds = new DataSet();
            da.Fill(ds, "Address");

            ViewState["QUERY"] = sqlQuery;
            ViewState["DATA"] = ds;

            if (ds.Tables["Address"].Rows.Count > 0)
            {
                DataRow row = ds.Tables["Address"].Rows[0];
                TextBox2.Text = row["AddressLine1"].ToString();
                TextBox4.Text = row["AddressLine2"].ToString();
                TextBox3.Text = row["City"].ToString();
                TextBox5.Text = row["StateProvince"].ToString();
                TextBox6.Text = row["CountryRegion"].ToString();
                TextBox7.Text = row["PostalCode"].ToString();
            }
            else {

                TextBox2.Text = "";
                TextBox3.Text = "";
                TextBox4.Text = "";
                TextBox5.Text = "";
                TextBox6.Text = "";
                TextBox7.Text = "";

                Label2.ForeColor = System.Drawing.Color.Red;
                Label2.Text = "No record found with ID = " + TextBox1.Text;
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
            SqlConnection cn = new SqlConnection(CS);

            SqlDataAdapter da = new SqlDataAdapter((string)ViewState["QUERY"], cn);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);

            DataSet ds = (DataSet)ViewState["DATA"];

            if (ds.Tables["Address"].Rows.Count > 0)
            {
                DataRow row = ds.Tables["Address"].Rows[0];
                row["AddressLine1"] = TextBox2.Text;
                row["AddressLine2"] = TextBox4.Text;
                row["City"] = TextBox3.Text;
                row["StateProvince"] = TextBox5.Text;
                row["CountryRegion"] = TextBox6.Text;
                row["PostalCode"] = TextBox7.Text;
            }

            int u = da.Update(ds, "Address");
            if (u > 0)
            {
                Label2.ForeColor = System.Drawing.Color.Green;
                Label2.Text = "Record Updated with ID = " + TextBox1.Text;
            }
        }
    }
}
