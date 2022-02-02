using System;
using System.IO;

namespace SleepData
{
    class Program
    {
        static void Main(string[] args)
        {

            var file = "data.txt";

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
                StreamWriter sw = new StreamWriter(file);

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

                // parse data file if it exists 
                if (File.Exists(file))
                {

                    // read data from file 
                    StreamReader sr = new StreamReader(file);

                    // run this until the stream position is at the end 
                    while (!sr.EndOfStream)
                    {
                        // reads a single line of characters and returns it as a string, 1 line of text represents 1 week of data
                        string line = sr.ReadLine();

                        // convert the string into an array
                        string[] week = line.Split(',');

                        // the 1st element in teh array is the date, converts the string into a DateTime object 
                        DateTime date = DateTime.Parse(week[0]);

                        // the 2nd element is the hours of sleep with a "|" delimiter 
                        int[] hours = Array.ConvertAll(week[1].Split("|"), int.Parse);

                        // display date for the current week 
                        Console.WriteLine($"Week of {date:MMM}, {date:dd}, {date:yyy}");

                        // display column headers 
                        Console.WriteLine($"{"Su",3}{"Mo",3}{"Tu",3}{"We",3}{"Th",3}{"Fr",3}{"Sa",3}");
                        Console.WriteLine($"{"--",3}{"--",3}{"--",3}{"--",3}{"--",3}{"--",3}{"--",3}");

                        // display hours of sleep for each day 
                        Console.WriteLine($"{hours[0],3}{hours[1],3}{hours[2],3}{hours[3],3}{hours[4],3}{hours[5],3}{hours[6],3}");
                        Console.WriteLine();
                    }

                }
                else
                {
                    Console.WriteLine("File does not exist");
                }

            }
        }
    }
}
