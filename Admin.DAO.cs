using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Model_template;

namespace Admin.DAL
{

    public class AdminDAO
    {
        SqlConnection con = new SqlConnection(@"...........");
        SqlCommand cmd = null;
        SqlDataAdapter da = null;
        DataSet ds = null;
        DataTable dt = null;
        string Query = null;


        public bool AddProduct(Product_model product)
        {
            try
            {
                Query = "INSERT INTO product values(@Product_ID ,@Product_name,@Manufacturer,@Product_category,@Product_price,@Product_Seller,@Product_stock)";
                cmd = new SqlCommand(Query, con);

                cmd.Parameters.AddWithValue("@Product_ID", product.Product_ID);
                cmd.Parameters.AddWithValue("@Product_name", product.Product_name);
                cmd.Parameters.AddWithValue("@Manufacturer", product.Manufacturer);
                cmd.Parameters.AddWithValue("@Product_category", product.Product_category);
                cmd.Parameters.AddWithValue("@Product_price", product.Product_price);
                cmd.Parameters.AddWithValue("@Product_Seller", product.Product_Seller);
                cmd.Parameters.AddWithValue("@Product_stock", product.Product_stock);
                

                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        public DataRow ViewCustomers(Order_model order)
        {
            Query = "Select CustomerId,CustomerName,CustomerEmail,CustomerPhoneNumber from CustomerDetails";
            da = new SqlDataAdapter(Query, con);
            dt = new DataTable("Orders");
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0];
            }
            else
            {
                return null;
            }

        }

        public bool Update_Orders(Order_model order)
        {
            try
            {
                Query = "Update OrderDetails set Order_Status= @Oderstatus,ExpectedDateOfDelivery=@ExpectedDateOfDeliver where Order_ID=@OderId";
                cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Oderstatus", order.Order_Status);
                cmd.Parameters.AddWithValue("@ExpectedDateOfDeliver", order.ExpectedDateOfDelivery);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                throw e;
                

            }
            finally
            {
                con.Close();
            }

        }

        public bool Update_Shipping(Shipping_details sd)
        {
            try
            {
                Query = "Update OrderDetails set Shipping_status= @ShippingStatus where Order_id=@OrderID";
                cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@ShippingStatus", sd.Shipping_status);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                throw e;


            }
            finally
            {
                con.Close();
            }
        }
    }
}
