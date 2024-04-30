using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADONETDEMOS
{
    public partial class GridViewDemo : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        string CS = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();   
            }
            
        }
        public void BindData() {
            try
            {
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("Select top 100 * from Emails", con);
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
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.SelectedIndex = -1;
        }

        protected void GridView1_PageIndexChanged(object sender, EventArgs e)
        {
            BindData();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.SelectedIndex = -1;
            GridView1.EditIndex = e.NewEditIndex;
            BindData();

        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindData();

        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Int32.Parse(GridView1.DataKeys[e.RowIndex].Value.ToString());

            TextBox FirstName = GridView1.Rows[e.RowIndex].FindControl("FirstNameTB") as TextBox;
            string firstname = FirstName.Text.Trim();

            TextBox LastName = GridView1.Rows[e.RowIndex].Cells[2].Controls[0] as TextBox;
            string lastname = LastName.Text.Trim();

            TextBox Email = GridView1.Rows[e.RowIndex].FindControl("EmailTB") as TextBox;
            string email = Email.Text.Trim();

            DropDownList Gender = GridView1.Rows[e.RowIndex].FindControl("EmailDD") as DropDownList;
            string gender = Gender.SelectedItem.Text;

            SqlConnection con = new SqlConnection(CS);
            SqlCommand cmd = new SqlCommand("update Emails set First_name='" + firstname + "', Last_name='" + lastname + "', " +
                "Email='" + email + "', Gender='" + gender + "' where id='"+id+"'", con);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            GridView1.EditIndex = -1;
            BindData();

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Int32.Parse(GridView1.DataKeys[e.RowIndex].Value.ToString());
            SqlConnection con = new SqlConnection(CS);
            SqlCommand cmd = new SqlCommand("delete from Emails where id='" + id + "'", con);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            GridView1.EditIndex = -1;
            BindData();
        }
    }
}