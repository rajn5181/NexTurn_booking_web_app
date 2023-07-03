using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace TravelBookingWebApp.Common
{
    public class SQL
    {

        SqlConnection con;
        SqlCommand cmd;
        public SQL()
        {
            con = new SqlConnection(returnConnectionString());
        }

        public string returnConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["DBCS"].ToString();
        }
        public SqlConnection returnConnection()
        {
            return con;
        }

        public DataSet returnSqlTableMultipleValue(string StoredProcedureName, List<SqlParameter> sqlParameter = null)
        {
            try
            {
                cmd = new SqlCommand(StoredProcedureName, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 6000;
                if (sqlParameter != null)
                {
                    if (sqlParameter.Count > 0)
                    {
                        foreach (SqlParameter parameter in sqlParameter)
                        {
                            cmd.Parameters.Add(parameter);
                        }
                    }
                }
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                if (con != null && con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return new DataSet();
            }
        }

        public object cmdExecuteScalar(string query)
        {
            object ReturnValue = "";
            try
            {
                con.Open();
                cmd = new SqlCommand(query, con);
                if (cmd.ExecuteScalar() != null)
                {
                    ReturnValue = cmd.ExecuteScalar();
                }
            }
            finally
            {
                con.Close();
            }
            return ReturnValue;
        }

        public DataSet returnSqlDataSet(string StoredProcedureName, List<SqlParameter> sqlParameter = null)
        {
            try
            {
                DataSet ds = new DataSet();
                cmd = new SqlCommand(StoredProcedureName, con);
                cmd.CommandType = CommandType.StoredProcedure;
                if (sqlParameter != null)
                {
                    if (sqlParameter.Count > 0)
                    {
                        foreach (SqlParameter parameter in sqlParameter)
                        {
                            cmd.Parameters.Add(parameter);
                        }
                    }
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                if (con != null && con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return new DataSet();
            }
        }
        public DataTable returnSqlDataTable(string StoredProcedureName, List<SqlParameter> sqlParameter = null)
        {
            try
            {
                DataTable dt = new DataTable();
                cmd = new SqlCommand(StoredProcedureName, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 6000;
                if (sqlParameter != null)
                {
                    if (sqlParameter.Count > 0)
                    {
                        foreach (SqlParameter parameter in sqlParameter)
                        {
                            cmd.Parameters.Add(parameter);
                        }
                    }
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                if (con != null && con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return new DataTable();
            }
        }
    }
}
