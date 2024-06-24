using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace TesttaskEPTL_Api.Data_Context
{
    public class Connection
    {

         SqlConnection  sqlcon;
        SqlCommand sqlcmd;
        SqlDataAdapter da;
        private string my_conn = "Data Source=DHANU099;Initial catalog=DBStudent;TrustServerCertificate=True;User ID=sa;password=Game@123;";
        public SqlConnection Connect()
        {
            try
            {
                sqlcon = new SqlConnection(my_conn);
                sqlcmd = new SqlCommand();
                if (sqlcon.State == System.Data.ConnectionState.Open)
                {
                    sqlcon.Close();
                }
                sqlcon.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return sqlcon;
        }
        public DataTable FetchQuery(string query)
        {
            sqlcon = Connect();
            sqlcmd = new SqlCommand(query, sqlcon);
            da = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }



    }
}
