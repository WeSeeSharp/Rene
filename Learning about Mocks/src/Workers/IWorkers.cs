using System;
using System.Collections.Generic;
using System.Text;

namespace LearningAboutMocks.src.Workers
{
    public interface IWorkers
    {
        double CalculatePayment();
        double GetTotalWorkedHours();
        void CreateNewEvent(DateTime x, DateTime y);
    }
}
