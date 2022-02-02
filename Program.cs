using System;

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

                // we want full weeks sunday - saturday, endDate is a DateTime object that ends on the previous sunday
                DateTime endDate = today.AddDays(-(int)today.DayOfWeek);

                // subtract # of weeks from endDate to get the startDate, we multiplay the number of weeks by 7 days to get the total days to subtract 
                DateTime startDate = endDate.AddDays(-(weeks * 7));

                Console.WriteLine(startDate);

            }
            else if (resp == "2")
            {
                // TODO: parse data file
            }
        }
    }
}
