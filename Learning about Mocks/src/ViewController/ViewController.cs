using System;
using LearningAboutMocks.src.View;
using LearningAboutMocks.exceptions;
using LearningAboutMocks.src.factory;
using LearningAboutMocks.src.Workers;

namespace LearningAboutMocks.src.ViewController
{
    public class ViewController : IViewController
    {
        public IView view;
        public IWorkerFactory factory;
        public IWorkers Worker;

        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public string WorkerType { get; private set; }
        
        public ViewController(IView view, IWorkerFactory factory)
        {
            this.view = view;
            this.factory = factory;
            this.view.ClearView();
        }

        public void Update()
        {
            if ((StartTime == DateTime.MinValue) || (EndTime == DateTime.MinValue))
            {
                throw new ANewException("Bad News Bears");
            } 
        }

        public void SetStartTime(DateTime time)
        {
            this.StartTime = time;
        }

        public void SetEndTime(DateTime time)
        {
            this.EndTime = time;
        }

        public string GetWorkerTypeFromView()
        {
            WorkerType = view.EnterWorkerType();
            return WorkerType;
        }

        public DateTime GetStartTimeFromView()
        {
            var startTime = view.EnterStartTime();
            SetStartTime(startTime);
            return startTime;
        }

        public DateTime GetEndTimeFromView()
        {
            var endTime = view.EnterEndTime();
            SetEndTime(endTime);
            return endTime;
        }

        public void UpdateView()
        {
            Setup(WorkerType, StartTime, EndTime);
        }

        public void Setup(string workerType, DateTime startTime, DateTime endTime)
        {
            Worker = factory.GetWorker(workerType);
            Worker.CreateNewEvent(startTime, endTime);
            var cost = Worker.CalculatePayment();

            this.view.UpdateView(startTime, endTime, workerType, cost);
        }

    }
}
