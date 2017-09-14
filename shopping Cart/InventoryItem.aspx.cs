using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace shopping_Cart
{
    public partial class InventoryItem : System.Web.UI.Page
    {
        Dictionary<string, float> cartItem;
         SqlConnection connect;
    
        protected void Page_Load(object sender, EventArgs e)
        {
            //try
            //{
            //    SqlConnection connection = new SqlConnection("Data Source=TAVDESKRENT009; Initial Catalog = SampleShoppingCart;User Id=sa;Password=test123!@#");
            //    SqlCommand cmd = new SqlCommand("Select * from Product ", connection);
            //    SqlDataReader reader = null;
            //    reader = cmd.ExecuteReader();
            //    GridView2.DataSource = reader;
            //    GridView2.DataBind();
            //    connection.Close();
            //}
            //catch (Exception ex)
            //{

            //}
            if (!IsPostBack)
            {
                connect = new SqlConnection(@"Data Source=TAVDESKRENT009;Initial Catalog=SampleShoppingCart;User Id=sa;Password=test123!@#");
                connect.Open();
                SqlCommand command = new SqlCommand("select * from Products", connect);
                SqlDataReader reader = command.ExecuteReader();
                GridView1.DataSource = reader;
                GridView1.DataBind();
                connect.Close();
            }
        }

        protected void Gridview_row_command(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Add")
            {
                /* int index = Convert.ToInt32(e.CommandArgument);
                  GridViewRow selectedRow = GridView1.Rows[index];
                  /*string id = GridView1.Rows[index].Cells[0].Text;
                  Session["id"] = id;
                  Response.Redirect("~/OrderDetail.aspx");*/
                // int qty = 0;
                //int.TryParse(selectedRow.Cells[2].Text, out qty);
                //selectedRow.Cells[0].Text = "" + (qty + 1);
                //selectedRow.Cells[0].Text = selectedRow.Cells[1].Text;
                //Session["1" + selectedRow.Cells[0].Text] = selectedRow.Cells[4].Text; */
                int rowIndex = Int32.Parse((string)e.CommandArgument);
                GridViewRow row = GridView1.Rows[rowIndex];
                var pName = row.Cells[0].Text;
                var cost = row.Cells[3].Text;
                if (ViewState["cartItem"] == null)
                {
                    cartItem = new Dictionary<string,float>();
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