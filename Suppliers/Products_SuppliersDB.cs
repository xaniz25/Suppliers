using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Suppliers
{
    public static class Products_SuppliersDB
    {
        public static DataTable GetProductsBySupplier(int SupplierId)
        {
            DataTable dt;

            using (SqlConnection con = TravelExpertsDB.GetConnection())
            {
                string query = "select p.ProductId, ProdName from Suppliers s " +
                               "join Products_Suppliers ps on s.SupplierId = ps.SupplierId " +
                               "join Products p on p.ProductId = ps.ProductId " +
                               "where @SupplierId=s.SupplierId";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@SupplierId", SupplierId);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    con.Close();
                }
            }

            return dt;
        }
    }
}
