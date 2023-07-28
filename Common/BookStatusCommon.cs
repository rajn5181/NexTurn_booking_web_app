using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TravelBookingWebApp.Models;

namespace TravelBookingWebApp.Common
{
    public class BookStatusCommon
    {
        private List<SqlParameter> Parameters;

        public BookStatusCommon()
        {
            Parameters = new List<SqlParameter>();
        }

        public void Save(UserBookingModel objBookModel)
        {
            Parameters.Add(new SqlParameter("@p_trainNo", objBookModel.trainNo));
            Parameters.Add(new SqlParameter("@p_trainName", objBookModel.trainName));
            Parameters.Add(new SqlParameter("@p_distance", objBookModel.distance));
            Parameters.Add(new SqlParameter("@p_source", objBookModel.source));
            Parameters.Add(new SqlParameter("@p_destination", objBookModel.destination));
            Parameters.Add(new SqlParameter("@p_name", objBookModel.name));
            Parameters.Add(new SqlParameter("@p_email", objBookModel.email));
            Parameters.Add(new SqlParameter("@p_phone", objBookModel.phone));
            Parameters.Add(new SqlParameter("@p_age", objBookModel.age));
            Parameters.Add(new SqlParameter("@p_passengers", objBookModel.passengers));

            SQL sql=new SQL();
            sql.ExecuteStoredToSave("SaveUserData", Parameters);

        }
    }
}
