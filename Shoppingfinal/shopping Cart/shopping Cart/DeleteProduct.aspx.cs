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
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["SampleShoppingCartConnectionString"].ConnectionString))
            {
                string pId = Request.QueryString["productId"];
                SqlCommand cmd = new SqlCommand("Select * from OrderDetail where ProductId=" + pId);
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
                    SqlCommand cmd = new SqlCommand("Select * from OrderDetail where ProductId=" + pId);
                    cmd.Connection = connection;
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    dataAdapter.Fill(dataTable);

                   
                }

            }
            else
            {
                Console.WriteLine("The item is already in Cart so u cannot proceed more");
            }
        }
    }
}