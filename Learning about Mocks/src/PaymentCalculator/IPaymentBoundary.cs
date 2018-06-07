using System;

namespace LearningAboutMocks.src.PaymentCalculator
{
    public interface IPaymentBoundary
    {
        DateTime GetStartBoundary();
        void SetStartBoundary(DateTime time);

        DateTime GetEndBoundary();
        void SetEndBoundary(DateTime time);

        double GetCostPerHour();
        void SetCostPerHour(int cost);

        double GetTotalBoundaryHours();
    }
}
