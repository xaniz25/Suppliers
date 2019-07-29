using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suppliers
{
    public static class TravelExpertsDB
    {
        public static SqlConnection GetConnection()
        {
            string con = @"Data Source=localhost\SAIT;Initial Catalog=TravelExperts;Integrated Security=True";
            return new SqlConnection(con);
        }
    }
}
