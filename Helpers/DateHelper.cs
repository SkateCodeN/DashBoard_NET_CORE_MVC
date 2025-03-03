using System;

namespace MyDashboardApp.Helpers
{
    public static class DateHelper
    {
        public static string FormatDate(DateTime date)
        {
            return date.ToString("MM-dd-yyyy");
        }
    }
}