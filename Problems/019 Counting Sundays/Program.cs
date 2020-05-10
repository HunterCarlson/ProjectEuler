using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _019_Counting_Sundays
{
    class Program
    {
        static void Main(string[] args)
        {
            //You are given the following information, but you may prefer to do some research for yourself.

            //    1 Jan 1900 was a Monday.
            //    Thirty days has September,
            //    April, June and November.
            //    All the rest have thirty-one,
            //    Saving February alone,
            //    Which has twenty-eight, rain or shine.
            //    And on leap years, twenty-nine.
            //    A leap year occurs on any year evenly divisible by 4, but not on a century unless it is divisible by 400.

            //How many Sundays fell on the __first of the month__ during the twentieth century (1 Jan 1901 to 31 Dec 2000)?


            //first calculate number of days from 1-1-1901 to 12-31-2000
            const int startYear = 1901;
            const int endYear = 2000;

            int numSundays = 0;

            int day = 1;    //0 = sunday, data given starts monday

            int numDays = 0;
            for (int year = startYear; year <= endYear; year++)
            {
                numDays += 365;
                if (isLeapYear(year))
                {
                    numDays ++;
                }
            }

            Console.WriteLine(numDays);
            //36525 days


            //find what day it was 1 Jan 1901
            int dayOffset = 365 % 7;
            day += dayOffset;
            Console.WriteLine(day);
            //returns 2, so it was Tuesday


            for (int year = startYear; year <= endYear; year++)     //for each year
            {
                for (int month = 1; month <= 12; month++)   //for each month (Jan = 1)
			    {
			        //check if first day of month is sunday
                    if (day % 7 == 0)
                    {
                        numSundays ++;
                    }
                    //increment days to the next month
                    day += DaysInMonth(month, year);
			    }
            }

            Console.WriteLine("{0} Sundays", numSundays);

            Console.Read();
        }

        public static bool isLeapYear(int year)
        {
            //    A leap year occurs on any year evenly divisible by 4, but not on a century unless it is divisible by 400.

            if (year % 4 == 0)  //divisible by 4
            {
                if (year % 100 == 0)    //century
                {
                    if (year % 400 == 0)     //divisuble by 400
                    {
                        return true;
                    }
                    return false;
                }
                return true;
            }
            return false;
        }

        public static int DaysInMonth(int month, int year)
        {
            if (month == 2)
            {
                if (isLeapYear(year))
                {
                    return 29;
                }
                return 28;
            }
            if (month == 9
                || month == 4
                || month == 6
                || month == 11)
            {
                return 30;
            }
            return 31;
        }
    }
}
