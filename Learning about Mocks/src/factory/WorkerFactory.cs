using System;
using System.Collections.Generic;
using System.Text;

using LearningAboutMocks.src.Workers;
using LearningAboutMocks.src.PaymentCalculator;

namespace LearningAboutMocks.src.factory
{
    public class WorkerFactory : IWorkerFactory
    {
        public WorkerFactory() { }

        public IWorkers GetWorker(string workerType)
        {
            IWorkers worker;
            switch (workerType)
            {
                case "Babysitter":
                    worker = CreateBabysitter();
                    break;
                case "LawnCare":
                    worker = CreateLawnCare();
                    break;
                default:
                    worker = null;
                    break;
            }

            return worker;
        }

        private IWorkers CreateBabysitter()
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

            var boundaries = new List<PaymentBoundary>
            {
                { paymentBoundary },
                { paymentBoundary2 },
                { paymentBoundary3 }
            };

            var calculator = new PaymentCalculator.PaymentCalculator(boundaries);
            return new Babysitter(calculator);
        }

        private IWorkers CreateLawnCare()
        {
            DateTime testStart = new DateTime(2018, 7, 6, 12, 0, 0);
            DateTime testEnd = new DateTime(2018, 7, 6, 16, 0, 0);
            int testCostPerHour = 1;

            var paymentBoundary = new PaymentBoundary(testStart, testEnd, testCostPerHour);

            DateTime testStart2 = new DateTime(2018, 7, 6, 16, 0, 0);
            DateTime testEnd2 = new DateTime(2018, 7, 6, 20, 0, 0);
            int testCostPerHour2 = 2;

            var paymentBoundary2 = new PaymentBoundary(testStart2, testEnd2, testCostPerHour2);

            DateTime testStart3 = new DateTime(2018, 7, 6, 20, 0, 0);
            DateTime testEnd3 = new DateTime(2018, 7, 7, 0, 0, 0);
            int testCostPerHour3 = 3;

            var paymentBoundary3 = new PaymentBoundary(testStart3, testEnd3, testCostPerHour3);

            DateTime testStart4 = new DateTime(2018, 7, 6, 0, 0, 0);
            DateTime testEnd4 = new DateTime(2018, 7, 7, 4, 0, 0);
            int testCostPerHour4 = 4;

            var paymentBoundary4 = new PaymentBoundary(testStart4, testEnd4, testCostPerHour4);

            var boundaries = new List<PaymentBoundary>
            {
                { paymentBoundary },
                { paymentBoundary2 },
                { paymentBoundary3 },
                { paymentBoundary4 }
            };

            var calculator = new PaymentCalculator.PaymentCalculator(boundaries);
            return new LawnCare(calculator);
        }
    }
}
