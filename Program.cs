﻿using System;
using System.IO;

namespace SleepData
{
    class Program
    {
        static void Main(string[] args)
        {

            // ask for input
            Console.WriteLine("Enter 1 to create data file.");
            Console.WriteLine("Enter 2 to parse data.");
            Console.WriteLine("Enter anything else to quit.");

            // input response 
            string resp = Console.ReadLine();

            if (resp == "1")
            {

                // create data file 

                // ask a question
                Console.WriteLine("How many weeks of data is needed?");

                // input the response (convert to int)
                int weeks = int.Parse(Console.ReadLine());

                // determine start and end date 
                DateTime today = DateTime.Now;

                // we want full weeks sunday - saturday, endDate is a DateTime object that ends on the previous sunday. Sunday using the DayOfWeek enum is a (int) 0
                DateTime endDate = today.AddDays(-(int)today.DayOfWeek);

                // subtract # of weeks from endDate to get the startDate, we multiplay the number of weeks by 7 days to get the total days to subtract 
                DateTime startDate = endDate.AddDays(-(weeks * 7));

                // ---- DUMMY DATA ----

                // random number generator 
                Random rnd = new Random();

                // create file 
                StreamWriter sw = new StreamWriter("data.txt");

                // fill in dummy data for each week 
                while (startDate < endDate)
                {

                    // create a new array with a length of 7; 7 days in a week 
                    int[] hours = new int[7];

                    // loop 7 times for each day of the week 
                    for (int i = 0; i < hours.Length; i++)
                    {
                        // generate random number of hours slept between 4-12 for each day 
                        hours[i] = rnd.Next(4, 13);
                    }

                    // write a formatted string with the number of hours of sleep 
                    //Console.WriteLine($"{startDate:M/d/yy},{string.Join("|", hours)}");

                    // use the StreamWriter to write a string to the stream
                    sw.WriteLine($"{startDate:M/d/yy},{string.Join("|", hours)}");

                    // add 1 week to startDate to continue with the loop
                    startDate = startDate.AddDays(7);

                }

                // ends the stream from the StreamWriter
                sw.Close();
            }
            else if (resp == "2")
            {
                // TODO: parse data file
            }
        }
    }
}
