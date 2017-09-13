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
    public partial class ProductManipulation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["SampleShoppingCartConnectionString"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Select * from Products");
                cmd.Connection = connection;
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(dataTable);
            }
            foreach(DataRow row in dataTable.Rows)
            {
                TableCell productId = new TableCell();
                TableCell productName = new TableCell();
                TableCell productQuantity = new TableCell();
                TableCell productPrice = new TableCell();
                TableCell editAction = new TableCell();
                TableCell deleteAction = new TableCell();
                productId.Text = row[1].ToString();
                productName.Text = row[0].ToString();
                productQuantity.Text = row[2].ToString();
                productPrice.Text = row[3].ToString();
                LinkButton editButton = new LinkButton();
                editButton.Text = "Edit";
                editButton.PostBackUrl = "EditProduct.aspx?productId=" + row[1].ToString();
                editAction.Controls.Add(editButton);
                LinkButton deleteButton = new LinkButton();
                deleteButton.Text = "Delete";
                deleteButton.PostBackUrl = "DeleteProduct.aspx?productId=" + row[1].ToString();
                deleteAction.Controls.Add(deleteButton);
                TableRow actualTableRow = new TableRow();
                actualTableRow.Cells.Add(productId);
                actualTableRow.Cells.Add(productName);
                actualTableRow.Cells.Add(productQuantity);
                actualTableRow.Cells.Add(productPrice);
                actualTableRow.Cells.Add(editAction); 
                actualTableRow.Cells.Add(deleteAction);
                ProductTable.Rows.Add(actualTableRow);
            }
        }
    }
}