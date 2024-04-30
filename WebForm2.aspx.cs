using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADONETDEMOS
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(CS)) {
                SqlCommand command = new SqlCommand("AddEmpProc",cn);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Name", TextBox1.Text);
                command.Parameters.AddWithValue("@Gender", ddGender.SelectedItem.Text);
                command.Parameters.AddWithValue("@Salary", TextBox2.Text);

                SqlParameter outParameter = new SqlParameter();
                outParameter.ParameterName = "@ID";
                outParameter.SqlDbType = System.Data.SqlDbType.Int;
                outParameter.Direction = System.Data.ParameterDirection.Output;

                command.Parameters.Add(outParameter);
                cn.Open();
                command.ExecuteNonQuery();
                Label1.Text = outParameter.Value.ToString();
                cn.Close();

            }
        }
    }
}