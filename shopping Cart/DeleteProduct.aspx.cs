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
            string productName=string.Empty;
            using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["SampleShoppingCartConnectionString"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Select Pname from Products where Pid='" + Request.QueryString["productId"]+"'",connection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable sqlOutput = new DataTable();
                da.Fill(sqlOutput);
                productName = sqlOutput.Rows[0][0].ToString();
            }
             using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["SampleShoppingCartConnectionString"].ConnectionString))
            {
                string pId = Request.QueryString["productId"];
                SqlCommand cmd = new SqlCommand("Select * from OrderDetails where Pname='"+ productName+"'");
                cmd.Connection = connection;
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataSet dataset = new DataSet();
                dataAdapter.Fill(dataset);
                dataTable = dataset.Tables[0];
            }
            if (dataTable.Rows.Count == 0)
            {
                using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["SampleShoppingCartConnectionString"].ConnectionString))
                {
                    string pId = Request.QueryString["productId"];
                    SqlCommand cmd = new SqlCommand("DELETE FROM products WHERE Pid=" + pId);
                    cmd.Connection = connection;
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataSet dataset = new DataSet();
                    dataAdapter.Fill(dataset);
                }
                Response.Write("<script>" +
                                "if(confirm('The product has been deleted'))" +
                                "{window.location='ProductManipulation.aspx';}" +
                                "</script>");
            }
            else
            {
                Response.Write("<script>if(confirm('The item is already sold, so u cannot proceed more')){window.location='ProductManipulation.aspx';}</script>");
            }
        }
    }
}