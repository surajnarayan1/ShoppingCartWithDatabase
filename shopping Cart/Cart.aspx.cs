
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Collections.Generic.Dictionary<string, float>;
namespace shopping_Cart
{
    public partial class Cart : System.Web.UI.Page
    {
        static string connectionString;
        Dictionary<string, float> cartItems;
        Label[] productName;
        Label[] price;
        Label amount, totalPrice;
        float total = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            connectionString = @"Data Source=TAVDESKRENT009;Initial Catalog=SampleShoppingCart;User Id=sa;Password=test123!@#";
            cartItems = (Dictionary<string, float>)(HttpContext.Current.Session["cartItem"]);
            KeyCollection coll = cartItems.Keys;
            List<string> items = coll.ToList();
            productName = new Label[cartItems.Count];
            price = new Label[cartItems.Count];
            for (int i = 0; i < cartItems.Count; i++)
            {
                productName[i] = new Label();
                price[i] = new Label();
                productName[i].Text = items[i];
                total += cartItems[items[i]];
                price[i].Text = cartItems[items[i]].ToString();
                this.Controls.Add(productName[i]);
                this.Controls.Add(new LiteralControl("<br >"));
                this.Controls.Add(price[i]);
                this.Controls.Add(new LiteralControl("<br >"));
                this.Controls.Add(new LiteralControl("<br >"));
            }
            amount = new Label();
            totalPrice = new Label();
            amount.Text = total.ToString();
            totalPrice.Text = "Total Price: ";
            this.Controls.Add(totalPrice);
            this.Controls.Add(amount);
        }

        protected void CheckOut_click(object sender, EventArgs e)
        {
            var orderId = SaveOrder();
            var cart = (Dictionary<string, float>)(HttpContext.Current.Session["cartItem"]);

            foreach (var key in cart.Keys)
            {
                SaveOrderItem(orderId, key, cart[key]);
            }
            Session["cart"] = new Dictionary<string, int>();
            Response.Redirect("InventoryItem.aspx");
        }
        private void SaveOrderItem(Guid orderId, string productName, float price)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string command = $"insert into OrderDetails values('{productName}','{orderId}','{null}','{price}')";
                SqlCommand cmd = new SqlCommand(command, conn);
                cmd.ExecuteNonQuery();
            }
        }
        private Guid SaveOrder()
        {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                var orderId = Guid.NewGuid();
                conn.Open();
                string command = $"insert into Orders values('{orderId}',CURRENT_TIMESTAMP,'{total}')";
                SqlCommand cmd = new SqlCommand(command, conn);
                cmd.ExecuteNonQuery();
                return orderId;
            }
        }
    }
}