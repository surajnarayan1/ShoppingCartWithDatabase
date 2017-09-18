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
            var price = Convert.ToInt32(TextBox3.Text);
            try
            {

                using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["SampleShoppingCartConnectionString"].ConnectionString))
                {
                    string pId = Request.QueryString["productId"];
                    SqlCommand cmd = new SqlCommand($"UPDATE Products SET Pname = '{pname}', Quantity= {quantity}, Price= {price} where Pid = '" + pId + "'");
                    cmd.Connection = connection;
                    //SqlDataAdapter da = new SqlDataAdapter(cmd);
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataSet dataset = new DataSet();
                    dataAdapter.Fill(dataset);


                    Response.Redirect("ProductManipulation.aspx");

                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Exception  arised while updating  new item" + ex.Message + "')</script>");

            }


        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddItem.aspx");
        }
    }
}