using System;
using System.Globalization;

namespace LearningAboutMocks.src.View
{
    public class View : IView
    {
        public void ClearView()
        {
            Console.Clear();
        }

        public DateTime EnterEndTime()
        {
            Console.Write("Enter End Time in MM/dd/yyyy HH:mm : ");
            var input = Console.ReadLine();
            var dt = DateTime.ParseExact(input, "MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture);
            return dt;
        }

        public DateTime EnterStartTime()
        {
            Console.Write("Enter Start Time in MM/dd/yyyy HH:mm : ");
            var input = Console.ReadLine();
            var dt = DateTime.ParseExact(input, "MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture);
            return dt;
        }

        public string EnterWorkerType()
        {
            Console.Write("Enter End Time (Babysitter) : ");
            return Console.ReadLine();
        }

        public void UpdateView(DateTime startTime, DateTime endTime, string workerType, double cost)
        {
            Console.WriteLine();
            Console.WriteLine("*** *** *** ***");
            Console.WriteLine("Worker Type: " + workerType);
            Console.WriteLine("StartTime : " + startTime.ToShortTimeString() + " " + "EndTime : " + endTime.ToShortTimeString());
            Console.WriteLine("Payment Required : " + cost.ToString());
            Console.WriteLine("*** *** *** ***");
            Console.WriteLine();
        }
    }
}
