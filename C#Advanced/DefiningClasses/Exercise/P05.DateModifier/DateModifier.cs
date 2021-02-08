using System;
using System.Linq;

namespace P05.DateModifier
{
    public class DateModifier
    {
        public int GetDifferenceOfTwoDates(string dateOne, string dateTwo)
        {
            int[] dateOneInfo = dateOne
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

            int year1 = dateOneInfo[0];
            int month1 = dateOneInfo[1];
            int day1 = dateOneInfo[2];

            DateTime dateTime1 = new DateTime(year1, month1, day1);

            int[] dateTwoInfo = dateTwo
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

            int year2 = dateTwoInfo[0];
            int month2 = dateTwoInfo[1];
            int day2 = dateTwoInfo[2];

            DateTime dateTime2 = new DateTime(year2, month2, day2);

            return Math.Abs((dateTime1 - dateTime2).Days);
        }
    }
}
