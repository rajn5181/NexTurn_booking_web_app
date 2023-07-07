namespace TravelBookingWebApp.Common
{
    public class DataTablePagerCommon
    {
        public int Draw { get; set; }
        public string SortColumn { get; set; }
        public string SortColumnDir { get; set; }
        public string SearchText { get; set; }
        public int PageSize { get; set; }
        public int Skip { get; set; }
        public int RecordsTotal { get; set; }
        public dynamic data { get; set; }
    }
}
