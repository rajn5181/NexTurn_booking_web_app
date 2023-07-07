using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TravelBookingWebApp.Models;

namespace TravelBookingWebApp.Common
{
    public class TrainBookingCommon
    {
        private List<SqlParameter> Parameters;

        public TrainBookingCommon()
        {
            Parameters = new List<SqlParameter>();
        }

        public List<TrainBookingModel> Get(TrainBookingModel objBookModel)
        {
            Parameters.Add(new SqlParameter("@From", objBookModel.Source));
            Parameters.Add(new SqlParameter("@To", objBookModel.Destination));

            List<TrainBookingModel> TLM = new List<TrainBookingModel>();

            try
            {
                using (DataTable dtResult = new SQL().returnSqlDataTable("Gettrainlist", Parameters))
                {
                    if (dtResult.Rows.Count > 0)
                    {
                        foreach (DataRow item in dtResult.Rows)
                        {
                            TrainBookingModel objBT = new TrainBookingModel();
                            objBT.TNo = Convert.IsDBNull(item["TNo"]) ? default(int) : Convert.ToInt32(item["TNo"]);
                            objBT.SEQ = Convert.IsDBNull(item["SEQ"]) ? default(int) : Convert.ToInt32(item["SEQ"]);
                            objBT.TName = Convert.IsDBNull(item["TName"]) ? default(string) : Convert.ToString(item["TName"]);
                            objBT.SCode = Convert.IsDBNull(item["SCode"]) ? default(string) : Convert.ToString(item["SCode"]);
                            objBT.SName = Convert.IsDBNull(item["SName"]) ? default(string) : Convert.ToString(item["SName"]);
                            objBT.Distance = Convert.IsDBNull(item["Distance"]) ? default(int) : Convert.ToInt32(item["Distance"]);
                            objBT.DestStName = Convert.IsDBNull(item["DestStName"]) ? default(string) : Convert.ToString(item["DestStName"]);
                            TLM.Add(objBT);
                        }
                    }
                    return TLM;
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
        }
    }
}
