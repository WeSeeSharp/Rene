using System;
using System.Collections.Generic;

namespace LearningAboutMocks.src.PaymentCalculator
{
    public class PaymentCalculator : IPaymentCalculator
    {
        List<PaymentBoundary> boundaries;

        public PaymentCalculator()
        {

        }

        public PaymentCalculator(List<PaymentBoundary> paymentBoundary)
        {
            this.boundaries = paymentBoundary;
        }

        public List<PaymentBoundary> GetTimeBoundaries()
        {
            return boundaries;
        }

        public void SetBoundaries(List<PaymentBoundary> newBoundaries)
        {
            this.boundaries = newBoundaries;
        }

        public double GetPayment(DateTime startTime, DateTime endTime)
        {
            var startBoundary = FindStartingBoundary(startTime);
            var endBoundary = FindEndingBoundary(endTime);

            var indexOfStartBoundary = boundaries.IndexOf(startBoundary);
            var indexOfEndBoundary = boundaries.IndexOf(endBoundary);

            if (indexOfStartBoundary == -1 || indexOfEndBoundary == -1)
            {
                return 0;
            }
            else
            {
                var indexDiff = indexOfEndBoundary - indexOfStartBoundary;
                double payment = 0;

                switch (indexDiff)
                {
                    case 0:
                        payment = endTime.Subtract(startTime).TotalHours * startBoundary.GetCostPerHour();
                        break;
                    case 1:
                        payment = GetBookendPayment(indexOfStartBoundary, startTime, indexOfEndBoundary, endTime);
                        break;
                    default:
                        payment = GetBookendPayment(indexOfStartBoundary, startTime, indexOfEndBoundary, endTime) +
                                  GetTotalCostForBoundary(indexOfStartBoundary, indexOfEndBoundary);
                        break;
                }

                return payment;
            }
        }

        private double GetTotalCostForBoundary(int indexOfStartBoundary, int indexOfEndBoundary)
        {
            double payment = 0;

            for (var i = indexOfStartBoundary + 1; i < indexOfEndBoundary; i++)
            {
                payment += boundaries[i].GetCostPerHour() * boundaries[i].GetTotalBoundaryHours();
            }

            return payment;
        }

        private double GetBookendPayment(int startIndex, DateTime startTime, int endIndex, DateTime endTime)
        {
            var costPerHour = boundaries[startIndex].GetCostPerHour();
            var hours = boundaries[startIndex].GetEndBoundary().Subtract(startTime).TotalHours;

            var costPerHour2 = boundaries[endIndex].GetCostPerHour();
            var hours2 = endTime.Subtract(boundaries[endIndex].GetStartBoundary()).TotalHours;

            var payment = costPerHour * hours + costPerHour2 * hours2;

            return payment;
        }
            

        private PaymentBoundary FindStartingBoundary(DateTime startTime)
        {
            return FindBoundary(startTime);
        }

        private PaymentBoundary FindEndingBoundary(DateTime endTime)
        {
            return FindBoundary(endTime);
        }

        private PaymentBoundary FindBoundary(DateTime time)
        {
            foreach (var boundary in boundaries)
            {
                if (boundary.GetEndBoundary() >= time && boundary.GetStartBoundary() <= time)
                {
                    return boundary;
                }
            }
            return new PaymentBoundary();
        }
    }
}
