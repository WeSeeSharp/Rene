using System;
using LearningAboutMocks.src.PaymentCalculator;
using NUnit.Framework;

namespace LearningAboutMockTests
{
    public class TestPaymentBoundary
    {
        DateTime testStartTime = new DateTime(2018, 7, 6, 15, 0, 0);
        DateTime testEndTime = new DateTime(2018, 7, 6, 20, 0, 0);
        int testCost = 8;

        [Test]
        public void BoundaryCreation()
        {
            PaymentBoundary sut = new PaymentBoundary(testStartTime, testEndTime, testCost);

            Assert.AreEqual(sut.GetCostPerHour(), testCost);
            Assert.AreEqual(sut.GetEndBoundary(), testEndTime);
            Assert.AreEqual(sut.GetStartBoundary(), testStartTime);
        }

        [Test]
        public void ModifyBoundary()
        {
            var newStartTime = new DateTime(2018, 7, 6, 14, 0, 0);
            var newEndTime = new DateTime(2018, 7, 7, 14, 30, 0);
            var newCost = 10;

            PaymentBoundary sut = new PaymentBoundary(testStartTime, testEndTime, testCost);

            sut.SetCostPerHour(newCost);
            sut.SetEndBoundary(newEndTime);
            sut.SetStartBoundary(newStartTime);

            Assert.AreEqual(sut.GetCostPerHour(), newCost);
            Assert.AreEqual(sut.GetEndBoundary(), newEndTime);
            Assert.AreEqual(sut.GetStartBoundary(), newStartTime);
        }
    }
}
