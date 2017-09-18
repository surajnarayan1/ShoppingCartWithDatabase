using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace shopping_Cart
{
    public partial class InventoryItem : System.Web.UI.Page
    {
        Dictionary<string, float> cartItem;
        // SqlConnection connect;

        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (!IsPostBack)
                {
                    using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["SampleShoppingCartConnectionString"].ConnectionString))
                    {
                        // connect = new SqlConnection(@"Data Source=TAVDESK055;Initial Catalog=SampleShoppingCart;User Id=sa;Password=test123!@#");
                        connection.Open();
                        SqlCommand command = new SqlCommand("select * from Products", connection);
                        SqlDataReader reader = command.ExecuteReader();
                        GridView1.DataSource = reader;
                        GridView1.DataBind();
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Exception arised whenever the Connection Establised during pageload" + ex.Message + "')</script>");

            }

        }

        protected void Gridview_row_command(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Add")
                {

                    int rowIndex = Int32.Parse((string)e.CommandArgument);
                    GridViewRow row = GridView1.Rows[rowIndex];
                    var pName = row.Cells[0].Text;
                    var cost = row.Cells[3].Text;
                    if (ViewState["cartItem"] == null)
                    {
                        cartItem = new Dictionary<string, float>();
                        cartItem[pName] = Convert.ToInt32(cost);
                        ViewState["cartItem"] = cartItem;
                        HttpContext.Current.Session["cartItem"] = cartItem;
                    }
                    else
                    {
                        {
                            cartItem = new Dictionary<string, float>();
                            cartItem = (Dictionary<string, float>)ViewState["cartItem"];
                            cartItem[pName] = int.Parse(cost);
                            HttpContext.Current.Session["cartItem"] = cartItem;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Exception  arised while loading the table" + ex.Message + "')</script>");

            }

        }


        protected void Button1_Click(object sender, EventArgs e)
        {
                Response.Redirect("Cart.aspx");

        }

        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProductManipulation.aspx");
        }
    }
}