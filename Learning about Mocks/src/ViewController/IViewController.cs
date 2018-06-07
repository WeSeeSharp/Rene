using System;
using System.Collections.Generic;
using System.Text;

namespace LearningAboutMocks.src.ViewController
{
    public interface IViewController
    {
        void Update();
        void SetStartTime(DateTime time);
        void SetEndTime(DateTime time);
    }
}
