using System;
using System.Collections.Generic;
using System.Text;

namespace LearningAboutMocks.exceptions
{
    public class ANewException : Exception
    {
        public ANewException()
        {
        }

        public ANewException(string message)
            : base(message)
        {
        }

        public ANewException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
