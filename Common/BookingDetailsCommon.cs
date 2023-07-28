using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TravelBookingWebApp.Models;

namespace TravelBookingWebApp.Common
{
    public class BookingDetailsCommon
    {
        private List<SqlParameter> Parameters;

        public BookingDetailsCommon()
        {
            Parameters = new List<SqlParameter>();
        }

        public TrainBookingModel Get(int id)
        {
            Parameters.Add(new SqlParameter("@ID", id));

            try
            {
                using (DataTable dtResult = new SQL().returnSqlDataTable("GetTrainListById", Parameters))
                {
                    if (dtResult.Rows.Count > 0)
                    {
                        DataRow row = dtResult.Rows[0];

                        TrainBookingModel objBT = new TrainBookingModel();
                        objBT.TNo = Convert.IsDBNull(row["TNo"]) ? default(int) : Convert.ToInt32(row["TNo"]);
                        objBT.SEQ = Convert.IsDBNull(row["SEQ"]) ? default(int) : Convert.ToInt32(row["SEQ"]);
                        objBT.TName = Convert.IsDBNull(row["TName"]) ? default(string) : Convert.ToString(row["TName"]);
                        objBT.Atime = Convert.IsDBNull(row["Atime"]) ? default(string) : Convert.ToString(row["Atime"]);
                        objBT.DTime = Convert.IsDBNull(row["DTime"]) ? default(string) : Convert.ToString(row["DTime"]);
                        objBT.SCode = Convert.IsDBNull(row["SCode"]) ? default(string) : Convert.ToString(row["SCode"]);
                        objBT.SName = Convert.IsDBNull(row["SName"]) ? default(string) : Convert.ToString(row["SName"]);
                        objBT.Distance = Convert.IsDBNull(row["Distance"]) ? default(int) : Convert.ToInt32(row["Distance"]);
                        objBT.DestStName = Convert.IsDBNull(row["DestStName"]) ? default(string) : Convert.ToString(row["DestStName"]);
                        objBT.SSName = Convert.IsDBNull(row["SSName"]) ? default(string) : Convert.ToString(row["SSName"]);

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
