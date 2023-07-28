using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TravelBookingWebApp.Models;

namespace TravelBookingWebApp.Common
{
    public class LoginCommon
    {
        private List<SqlParameter> Parameters;

        public LoginCommon()
        {
            Parameters = new List<SqlParameter>();
        }

        public LoginModel Get(string id, string password)
        {
            Parameters.Add(new SqlParameter("@userid", id));
            Parameters.Add(new SqlParameter("@password", password));


            try
            {
                using (DataTable dtResult = new SQL().returnSqlDataTable("userLogin", Parameters))
                {
                    if (dtResult.Rows.Count > 0)
                    {
                        DataRow row = dtResult.Rows[0];

                        LoginModel objBT = new LoginModel();
                        objBT.userid = Convert.IsDBNull(row["userid"]) ? default(string) : Convert.ToString(row["userid"]);
                        objBT.password = Convert.IsDBNull(row["pwd"]) ? default(string) : Convert.ToString(row["pwd"]);
                        return objBT;
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception
                throw ex;
            }
            finally
            {
                Parameters.Clear();
            }

            return null; // Return null if no data is found
        }
    }
}
