using System.Data;
using TravelBookingWebApp.Models;

namespace TravelBookingWebApp.Common
{
    public class DataTableCommon
    {
        public DataTable TrainDataTable;

        public DataTableCommon()
        {
            TrainDataTable = new DataTable();
        }

        public DataTable ConvertToDataTable(List<TrainBookingModel> trainList)
        {
            DataTable dataTable = new DataTable();

            
            dataTable.Columns.Add("TrainNo", typeof(Int32));
            dataTable.Columns.Add("TrainName", typeof(string));
            dataTable.Columns.Add("SEQ",typeof(int));
            dataTable.Columns.Add("StationCode", typeof(string));
            dataTable.Columns.Add("StationName", typeof(string));
            dataTable.Columns.Add("Distance", typeof(int));
            dataTable.Columns.Add("SourceStation", typeof(string));
            dataTable.Columns.Add("DestinationStation", typeof(string));
            dataTable.Columns.Add("ArrivalTime", typeof(string));
            dataTable.Columns.Add("DepartureTime", typeof(string));



            // Add rows to the DataTable
            foreach (var train in trainList)
            {
                DataRow row = dataTable.NewRow();
                row["TrainNo"] = train.TNo; 
                row["TrainName"] = train.TName;
                row["SEQ"] = train.SEQ;
                row["StationCode"] = train.SCode;
                row["StationName"] = train.SName;
                row["Distance"] = train.Distance;
                row["SourceStation"] = train.SSName;
                row["DestinationStation"] = train.DestStName;
                row["ArrivalTime"] = train.Atime;
                row["DepartureTime"] = train.DTime;

                dataTable.Rows.Add(row);
            }

            return dataTable;
        }
    }
}