using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc.Rendering;
using TravelBookingWebApp.Models;

namespace TravelBookingWebApp.Common
{
    public class CommonFunctions
    {
        private static List<SelectListItem> selectionListItem;

        public static List<SelectListItem> GetTrainListCode(bool includeZero = true)
        {
            selectionListItem = new List<SelectListItem>();

            if (includeZero)
            {
                selectionListItem.Add(new SelectListItem()
                {
                    Text = "--Select Station--",
                    
                    //Value = string.Empty // Set the value as required
                });
            }

            try
            {
                using (DataTable dtResult = new SQL().returnSqlDataTable("GetCodelist"))
                {
                    if (dtResult.Rows.Count > 0)
                    {
                        foreach (DataRow item in dtResult.Rows)
                        {
                            selectionListItem.Add(new SelectListItem()
                            {
                                Text = item["SStation"].ToString(),
                                //Value = item["SSCode"].ToString() // Set the value as required
                            });
                        }
                    }
                }

                return selectionListItem;
            }
            catch (Exception ex)
            {
                // Handle the exception here, e.g., log or throw
                throw;
            }
        }
        public static List<SelectListItem> GetTrainToCode(bool includeZero = true)
        {
            selectionListItem = new List<SelectListItem>();

            if (includeZero)
            {
                selectionListItem.Add(new SelectListItem()
                {
                    Text = "--Select Station--",

                    //Value = string.Empty // Set the value as required
                });
            }

            try
            {
                using (DataTable dtResult = new SQL().returnSqlDataTable("GetCodelistDes"))
                {
                    if (dtResult.Rows.Count > 0)
                    {
                        foreach (DataRow item in dtResult.Rows)
                        {
                            selectionListItem.Add(new SelectListItem()
                            {
                                Text = item["DSName"].ToString(),
                                //Value = item["SSCode"].ToString() // Set the value as required
                            });
                        }
                    }
                }

                return selectionListItem;
            }
            catch (Exception ex)
            {
                // Handle the exception here, e.g., log or throw
                throw;
            }
        }
    }
}
