using System;

using LearningAboutMocks.src.factory;
using LearningAboutMocks.src.View;
using LearningAboutMocks.src.ViewController;

namespace Learning_about_Mocks
{
    class Program
    {
        static void Main(string[] args)
        {
            WorkerFactory factory = new WorkerFactory();
            View view = new View();
            ViewController controller = new ViewController(view, factory);

            while (true)
            {
                var workerType = controller.GetWorkerTypeFromView();
                var startTime = controller.GetStartTimeFromView();
                var endTime = controller.GetEndTimeFromView();

                controller.UpdateView();
            }
        }
    }
}
