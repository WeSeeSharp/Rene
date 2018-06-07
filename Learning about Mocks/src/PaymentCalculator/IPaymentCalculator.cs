using System;
using System.Collections.Generic;
using System.Text;

namespace LearningAboutMocks.src.PaymentCalculator
{
    public interface IPaymentCalculator
    {
        List<PaymentBoundary> GetTimeBoundaries();
        void SetBoundaries(List<PaymentBoundary> newBoundaries);
        double GetPayment(DateTime start, DateTime end);
    }
}
