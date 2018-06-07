using System;

namespace LearningAboutMocks.src.PaymentCalculator
{
    public class PaymentBoundary : IPaymentBoundary
    {
        DateTime BoundaryStartTime;
        DateTime BoundaryEndTime;
        double Cost;

        public PaymentBoundary()
        {
            BoundaryEndTime = DateTime.MinValue;
            BoundaryStartTime = DateTime.MinValue;
            Cost = 0;
        }

        public PaymentBoundary(DateTime boundaryStartTime, DateTime boundaryEndTime, int cost)
        {
            this.BoundaryStartTime = boundaryStartTime;
            this.BoundaryEndTime = boundaryEndTime;
            this.Cost = cost;
        }

        public double GetCostPerHour()
        {
            return this.Cost;
        }

        public DateTime GetEndBoundary()
        {
            return this.BoundaryEndTime;
        }

        public DateTime GetStartBoundary()
        {
            return this.BoundaryStartTime;
        }

        public void SetCostPerHour(int cost)
        {
            this.Cost = cost;
        }

        public void SetEndBoundary(DateTime time)
        {
            this.BoundaryEndTime = time;
        }

        public void SetStartBoundary(DateTime time)
        {
            this.BoundaryStartTime = time;
        }

        public double GetTotalBoundaryHours()
        {
            return BoundaryEndTime.Subtract(BoundaryStartTime).TotalHours;
        }
    }
}
