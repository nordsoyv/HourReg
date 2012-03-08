using System;
using System.Web.Mvc;
using System.Collections.Generic;

namespace TimeForing.Common
{
    public static class Util
    {
        //                                       fil,jan,feb,mar,apr, may, jun, jul, aug, sep, okt, nov, des
        private static readonly int[] NormYear = { 0,  0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 334 };
        private static readonly int[] LeapYear = { 0,  0, 31, 61, 91, 121, 152, 182, 213, 244, 274, 305, 335 };


        public static List<DateTime> GenerateDates(int weekNum, int year)
        {
            DateTime startDate = Util.StartDateInWeek(weekNum, year);
            DateTime endDate = startDate.AddDays(6);

            List<DateTime > dates = new List<DateTime>();

            for (DateTime d = startDate; d <= endDate; d = d.AddDays(1))
            {
                dates.Add(d);
            }

            return dates;
        }


        public static SelectList GenerateWeekDropdown(DateTime d)
        {
            
            int weekNum = Util.WeekInYear(d);
            List<SelectListItem> w = new List<SelectListItem>();
            for (int i = 0; i < 3; i++)
            {
                string currWeek = (weekNum - i).ToString();
                DateTime startDate = Util.StartDateInWeek(weekNum - i, DateTime.Today.Year);
                DateTime endDate = startDate.AddDays(7);
                w.Add(new SelectListItem { Value = currWeek, Text = "Uke nr " + currWeek + " (" + startDate.ToString("dd/MM") + " - " + endDate.ToString( "dd/MM") +")"});
            }
            return new SelectList(w, "Value", "Text");
        }
        

        public static DateTime StartDateInWeek(int weekNum, int year)
        {
            DateTime jan4 = new DateTime(year, 1, 4);
            DateTime jan1 = new DateTime(year, 1, 1);
            int dayInWeek = 1; //monday
            int jan4DayNum = WeekDay(jan4);
            int correction = dayInWeek + jan4DayNum +3; 
            int dayInYear = (weekNum*7) + dayInWeek  ;
            dayInYear -= correction  ;

            return jan1.AddDays(dayInYear);

        }

        public static int WeekInYear(DateTime d)
        {   
            int dayOfMonth = d.Day;
            int month = d.Month;
            int dayOfWeek = WeekDay(d);
            if(DateTime .IsLeapYear( d.Year ))
            {
                int tmp = LeapYear[month] + dayOfMonth;
                tmp = tmp - dayOfWeek + 10;
                return tmp/7;
            }else
            {
                int tmp = NormYear[month] + dayOfMonth;
                tmp = tmp - dayOfWeek + 10;
                return tmp / 7;
            }
        }

        private static int WeekDay(DateTime d)
        {
            int dayOfweek;
            switch (d.DayOfWeek )
            {
                case DayOfWeek.Monday:
                    dayOfweek = 1;
                    break;
                case DayOfWeek.Tuesday:
                    dayOfweek = 2;
                    break;
                case DayOfWeek.Wednesday:
                    dayOfweek = 3;
                    break;
                case DayOfWeek.Thursday:
                    dayOfweek = 4;
                    break;
                case DayOfWeek.Friday:
                    dayOfweek = 5;
                    break;
                case DayOfWeek.Saturday:
                    dayOfweek = 6;
                    break;
                case DayOfWeek.Sunday:
                    dayOfweek = 7;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return dayOfweek;
        }


    }
}