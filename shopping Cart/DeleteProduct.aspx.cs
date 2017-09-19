using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace shopping_Cart
{
    public partial class DeleteProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dataTable = new DataTable();
                using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["SampleShoppingCartConnectionString"].ConnectionString))
                {
                    string pId = Request.QueryString["productId"];
                    SqlCommand cmd = new SqlCommand("Select Pname from Products where Pid='" + pId+"'");
                    cmd.Connection = connection;
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    dataAdapter.Fill(dataTable);
                }
                string pname = dataTable.Rows[0][0].ToString();
                dataTable = new DataTable();
                using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["SampleShoppingCartConnectionString"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("Select * from OrderDetails where Pname='" + pname+"'");
                    cmd.Connection = connection;
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    dataAdapter.Fill(dataTable);
                }
                int rowCount = dataTable.Rows.Count;
                if (rowCount == 0)
                {
                    using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["SampleShoppingCartConnectionString"].ConnectionString))
                    {
                        string pId = Request.QueryString["productId"];
                        SqlCommand cmd = new SqlCommand("DELETE FROM Products where pid='"+pId+"'");
                        cmd.Connection = connection;
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                        dataAdapter.Fill(dataTable);
                    }

                }
                else
                {
                    Response.Write("<script>alert('you  have already bought ')</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Exception  arised while delete " + ex.Message + "')</script>");

            }
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProductManipulation.aspx");
        }
    }
}