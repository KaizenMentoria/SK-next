using System;

namespace App.Helpers;

public static class DateTimeHelper
{
    public static string ToFormattedDate(this DateTime dateTime)
    {
        return dateTime.ToString("dd-MM-yyyy");
    }
}