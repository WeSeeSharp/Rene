using LearningAboutMocks.src.PaymentCalculator;
using System;

namespace LearningAboutMocks.src.Workers
{
    class LawnCare : IWorkers
    {
        IPaymentCalculator Calculator;
        DateTime startTime;
        DateTime endTime;

        public LawnCare(IPaymentCalculator calculator)
        {
            this.Calculator = calculator;
        }

        public void CreateNewEvent(DateTime start, DateTime end)
        {
            this.startTime = start;
            this.endTime = end;
        }

        public double CalculatePayment()
        {
            return this.Calculator.GetPayment(this.startTime, this.endTime);
        }

        public double GetTotalWorkedHours()
        {
            return this.endTime.Subtract(this.startTime).TotalHours;
        }
    }
}
