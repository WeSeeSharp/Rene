using System;
using System.Collections.Generic;
using System.Text;

using LearningAboutMocks.src.Workers;

namespace LearningAboutMocks.src.factory
{
    public interface IWorkerFactory
    {
        IWorkers GetWorker(string workerType);
    }
}
