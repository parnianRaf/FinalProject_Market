using System.Globalization;
using AppCore;

namespace ExtensionMethods;
public static class Extensions
{
    public static string FullNameToString(this User user )
    {
        return $"{user.FirstName} {user.LastName}";
    }

    public static string? IranianDate(this DateTime? date)
    {
        if(date!=null)
        {
            PersianCalendar calendar = new();
            string persianDateString = string.Format("{0}/{1}/{2}", calendar.GetYear((DateTime)date), calendar.GetMonth((DateTime)date), calendar.GetDayOfMonth((DateTime)date));
            return persianDateString;
        }
        return null;
      
    }
    public static string IranianDate2(this DateTime date)
    {
       
        PersianCalendar calendar = new();
        string persianDateString = string.Format("{0}/{1}/{2}", calendar.GetYear(date), calendar.GetMonth(date), calendar.GetDayOfMonth(date));
        return persianDateString;
 

    }

}

