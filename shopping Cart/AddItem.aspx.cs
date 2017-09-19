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
    public partial class AddItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var pid = TextBoxPid.Text;
            var pname = TextBoxPname.Text;
            var quantity = Convert.ToInt32(TextBoxQuantity.Text);
            var price = TextBoxPrice.Text;
            try
            {
                using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["SampleShoppingCartConnectionString"].ConnectionString))
                {


                    SqlCommand cmd = new SqlCommand($"INSERT INTO Products VALUES('{pname}','{pid}','{quantity}','{price}')");

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
                Response.Write("<script>alert('Exception  arised while adding new item" + ex.Message + "')</script>");

            }
        }


    }
}