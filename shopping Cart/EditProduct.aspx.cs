using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;

namespace shopping_Cart
{
    public partial class EditProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var pname = TextBox1.Text;
            var quantity = TextBox2.Text;
            var price = TextBox3.Text;

            using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["SampleShoppingCartConnectionString"].ConnectionString))
            {
                string pId = Request.QueryString["productId"];
                SqlCommand cmd = new SqlCommand($"UPDATE Products SET Pname = {pname}, Quantity= {quantity},price= {price} where Pid = " + pId);
                cmd.Connection = connection;
                //SqlDataAdapter da = new SqlDataAdapter(cmd);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataSet dataset = new DataSet();
              dataAdapter.Fill(dataset);

            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("InsertItem.aspx");
        }

       

      
    }
}