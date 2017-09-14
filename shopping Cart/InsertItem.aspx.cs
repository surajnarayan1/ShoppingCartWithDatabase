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
    public partial class InsertItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var pid = TextBox4.Text;
            var pname = TextBox1.Text;
            var Quantity = TextBox2.Text;
            var price = TextBox3.Text;
            using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["SampleShoppingCartConnectionString"].ConnectionString))
            {

                //string pId = Request.QueryString["productId"];
                SqlCommand cmd = new SqlCommand($"INSERT INTO Products VALUES ('{pname}', { pid },{int.Parse(Quantity) },{int.Parse(price)})",connection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataSet dataset = new DataSet();
                dataAdapter.Fill(dataset);

            }
        }
    }
}