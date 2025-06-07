using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QuizManagementSystem_1
{
    internal class function
    {
        private string connectionString = @"Data Source=MANISHASHINDE37\SQLEXPRESS;Initial Catalog=Quiz1;Integrated Security=True;";

        // Method to create and return a new SQL connection
        private SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        // Method to get data with optional parameters
        public DataSet GetData(string query, Dictionary<string, object> parameters = null)

        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Add parameters if any are provided
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value);
                        }
                    }

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(ds);
                    }
                }
            }
            return ds;
        }

        // Method to execute a non-query with optional parameters
        public void setData(string query, Dictionary<string, object> parameters)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                foreach (var param in parameters)
                {
                    cmd.Parameters.AddWithValue(param.Key, param.Value);
                }
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }



        
        public SqlDataReader GetForCombo(string query)
        {
            SqlConnection con = GetConnection();
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            return sdr; // Ensure you handle closing this reader appropriately in the caller
        }
    }
}
