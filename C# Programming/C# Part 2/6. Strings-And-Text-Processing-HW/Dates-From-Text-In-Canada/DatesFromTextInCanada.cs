﻿/*  Problem 19. Dates from text in Canada
    Write a program that extracts from a given text all dates that match the format DD.MM.YYYY.
    Display them in the standard date format for Canada.
 */
/*  Note: Added input for faster testing
        Input:
        I was born at 14.06.1980. My sister was born at 3.7.1984. In 5/1999 I graduated my high school. The law says (see section 7.3.12) that we are allowed to do this (section 7.4.2.9).
        Output:
        14.06.1980
        3.7.1984    
 */

using System;
using System.Globalization;   // needed for Regex
using System.Text.RegularExpressions;   // needed for CultureInfo and DateTimeStyles

class DatesFromTextInCanada
{
    static void Main()
    {
        //// the real input
        //string text = Console.ReadLine();
        // for faster testing
        string text = "I was born at 14.06.1980. My sister was born at 3.7.1984. In 5/1999 I graduated my high school. The law says (see section 7.3.12) that we are allowed to do this (section 7.4.2.9).";

        Console.WriteLine("Extracted dates from the sample text: ");

        foreach (Match item in Regex.Matches(text, @"\b[0-9]{1,2}.[0-9]{1,2}.[0-9]{2,4}"))
        {
            DateTime date;

            if (DateTime.TryParseExact(item.Value, "d.M.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            {
                Console.WriteLine(date.ToString(CultureInfo.GetCultureInfo("en-CA").DateTimeFormat.ShortDatePattern));
            }
        }

        Console.WriteLine();
    }
}