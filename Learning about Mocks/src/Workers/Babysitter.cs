using System;

using LearningAboutMocks.src.PaymentCalculator;

namespace LearningAboutMocks.src.Workers
{
    class Babysitter : IWorkers
    {
        IPaymentCalculator Calculator;
        DateTime startTime;
        DateTime endTime;

        public Babysitter(IPaymentCalculator calculator)
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
