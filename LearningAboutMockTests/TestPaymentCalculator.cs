using System;
using NUnit.Framework;

using LearningAboutMocks.src.PaymentCalculator;
using System.Collections.Generic;

namespace LearningAboutMockTests
{
    class TestPaymentCalculator
    {
        List<PaymentBoundary> boundaries;
        PaymentCalculator sut;

        [SetUp]
        public void SetUp()
        {
            DateTime testStart = new DateTime(2018, 7, 6, 14, 0, 0);
            DateTime testEnd = new DateTime(2018, 7, 6, 20, 0, 0);
            int testCostPerHour = 10;

            var paymentBoundary = new PaymentBoundary(testStart, testEnd, testCostPerHour);

            DateTime testStart2 = new DateTime(2018, 7, 6, 20, 0, 0);
            DateTime testEnd2 = new DateTime(2018, 7, 6, 22, 0, 0);
            int testCostPerHour2 = 20;

            var paymentBoundary2 = new PaymentBoundary(testStart2, testEnd2, testCostPerHour2);

            DateTime testStart3 = new DateTime(2018, 7, 6, 22, 0, 0);
            DateTime testEnd3 = new DateTime(2018, 7, 7, 4, 0, 0);
            int testCostPerHour3 = 30;

            var paymentBoundary3 = new PaymentBoundary(testStart3, testEnd3, testCostPerHour3);

            boundaries = new List<PaymentBoundary>
            {
                { paymentBoundary },
                { paymentBoundary2 },
                { paymentBoundary3 }
            };

            sut = new PaymentCalculator(boundaries);
        }

        [Test]
        public void CanReturnPaymentBoundaries()
        {
            Assert.AreEqual(sut.GetTimeBoundaries(), boundaries);
        }

        [Test]
        public void CanGetTotalPaymentOfWorkedHoursWhenHoursAreNotInAPayBoundary()
        {
            var startTime = new DateTime(2018, 1, 1, 15, 0, 0);
            var endTime = new DateTime(2018, 1, 1, 22, 0, 0);

            var expectedPayment = 0;

            var payment = sut.GetPayment(startTime, endTime);

            Assert.AreEqual(expectedPayment, payment);
        }

        [Test]
        public void CanGetTheTotalPaymentOfWorkedHoursInOneBoundaryOnly()
        {
            var startTime = new DateTime(2018, 7, 6, 15, 0, 0);
            var endTime = new DateTime(2018, 7, 6, 16, 0, 0);

            var expectedPayment = 10;

            var payment = sut.GetPayment(startTime, endTime);

            Assert.AreEqual(expectedPayment, payment);
        }

        [Test]
        public void CanGetTheTotalPaymentOfWorkedHoursInTwoBoundaries()
        {
            var startTime = new DateTime(2018, 7, 6, 15, 0, 0);
            var endTime = new DateTime(2018, 7, 6, 21, 0, 0);

            var expectedPayment = 70;

            var payment = sut.GetPayment(startTime, endTime);

            Assert.AreEqual(expectedPayment, payment);
        }

        [Test]
        public void CanGetTheTotalPaymentOfWorkedHoursInThreeBoundaries()
        {
            var startTime = new DateTime(2018, 7, 6, 15, 0, 0);
            var endTime = new DateTime(2018, 7, 7, 1, 0, 0);

            var expectedPayment = 180;

            var payment = sut.GetPayment(startTime, endTime);

            Assert.AreEqual(expectedPayment, payment);
        }

        [Test]
        public void CanGetTheTotalPaymentOfWorkedHoursInFourBoundaries()
        {
            DateTime testStart = new DateTime(2018, 7, 6, 15, 0, 0);
            DateTime testEnd = new DateTime(2018, 7, 6, 20, 0, 0);
            int testCostPerHour = 10;

            var paymentBoundary = new PaymentBoundary(testStart, testEnd, testCostPerHour);

            DateTime testStart2 = new DateTime(2018, 7, 6, 20, 0, 0);
            DateTime testEnd2 = new DateTime(2018, 7, 7, 0, 0, 0);
            int testCostPerHour2 = 10;

            var paymentBoundary2 = new PaymentBoundary(testStart2, testEnd2, testCostPerHour2);

            DateTime testStart3 = new DateTime(2018, 7, 7, 0, 0, 0);
            DateTime testEnd3 = new DateTime(2018, 7, 7, 2, 0, 0);
            int testCostPerHour3 = 10;

            var paymentBoundary3 = new PaymentBoundary(testStart3, testEnd3, testCostPerHour3);

            DateTime testStart4 = new DateTime(2018, 7, 7, 2, 0, 0);
            DateTime testEnd4 = new DateTime(2018, 7, 7, 4, 0, 0);
            int testCostPerHour4 = 10;

            var paymentBoundary4 = new PaymentBoundary(testStart4, testEnd4, testCostPerHour4);

            boundaries = new List<PaymentBoundary>
            {
                { paymentBoundary },
                { paymentBoundary2 },
                { paymentBoundary3 },
                { paymentBoundary4 }
            };

            sut = new PaymentCalculator(boundaries);

            var startTime = new DateTime(2018, 7, 6, 15, 0, 0);
            var endTime = new DateTime(2018, 7, 7, 4, 0, 0);

            var expectedPayment = 130;

            var payment = sut.GetPayment(startTime, endTime);

            Assert.AreEqual(expectedPayment, payment);
        }
    }
}
