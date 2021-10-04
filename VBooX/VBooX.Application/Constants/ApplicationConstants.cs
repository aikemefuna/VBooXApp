using System;
using System.Security.Cryptography;

namespace VBooX.Application.Constants
{
    public static class ApplicationConstants
    {
        public static string GenerateRNGB(int lenght)
        {
            RNGCryptoServiceProvider cryptoServiceProvider = new RNGCryptoServiceProvider();
            byte[] numArray = new byte[lenght];
            byte[] data = numArray;
            cryptoServiceProvider.GetBytes(data);
            return BitConverter.ToUInt32(numArray, 0).ToString();
        }

        public static string TimeAgo(this DateTime dateTime)
        {
            string empty = string.Empty;
            TimeSpan timeSpan = DateTime.Now - dateTime;
            return !(timeSpan <= TimeSpan.FromSeconds(60.0)) ? (!(timeSpan <= TimeSpan.FromMinutes(60.0)) ? (!(timeSpan <= TimeSpan.FromHours(24.0)) ? (!(timeSpan <= TimeSpan.FromDays(30.0)) ? (!(timeSpan <= TimeSpan.FromDays(365.0)) ? (timeSpan.Days > 365 ? string.Format("about {0} years ago", (object)(timeSpan.Days / 365)) : "about a year ago") : (timeSpan.Days > 30 ? string.Format("about {0} months ago", (object)(timeSpan.Days / 30)) : "about a month ago")) : (timeSpan.Days > 1 ? string.Format("about {0} days ago", (object)timeSpan.Days) : "yesterday")) : (timeSpan.Hours > 1 ? string.Format("about {0} hours ago", (object)timeSpan.Hours) : "about an hour ago")) : (timeSpan.Minutes > 1 ? string.Format("about {0} minutes ago", (object)timeSpan.Minutes) : "about a minute ago")) : string.Format("{0} seconds ago", (object)timeSpan.Seconds);
        }

        public static string TimeDifference(this DateTime dateTime)
        {
            string str = string.Empty;
            TimeSpan timeSpan = dateTime - DateTime.Now;
            if (DateTime.Now > dateTime)
                str = dateTime.TimeAgo();
            else if (timeSpan <= TimeSpan.FromHours(24.0))
                str = timeSpan.Hours > 1 ? string.Format("Visit in {0} hours time", (object)timeSpan.Hours) : "Visit in less than an hour";
            else if (timeSpan <= TimeSpan.FromDays(30.0))
            {
                if (timeSpan.Days > 1 && timeSpan.Days < 2)
                    str = "Visit scheduled for tomorrow";
                else if (timeSpan.Days > 2 && timeSpan.Days > 3)
                    str = "Visit scheduled for next-tomorrow";
                else if (timeSpan.Days > 3)
                    str = string.Format("Visit in {0} days time", timeSpan.Days);
            }
            else
                str = !(timeSpan > TimeSpan.FromDays(30.0)) || !(timeSpan <= TimeSpan.FromDays(60.0)) ? (!(timeSpan > TimeSpan.FromDays(60.0)) || !(timeSpan <= TimeSpan.FromDays(365.0)) ? string.Format("Visit scheduled in {0} years time", (timeSpan.Days / 365)) : "Visit scheduled for next year") : string.Format("Visit scheduled for next month", (timeSpan.Days / 30));
            return str;
        }
    }
}
