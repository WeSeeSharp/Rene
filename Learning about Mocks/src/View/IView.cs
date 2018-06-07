using System;

namespace LearningAboutMocks.src.View
{
    public interface IView
    {
        void ClearView();
        void UpdateView(DateTime startTime, DateTime endTime, string workerType, double cost);
        DateTime EnterStartTime();
        DateTime EnterEndTime();
        string EnterWorkerType();
    }
}
