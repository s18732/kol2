using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kol2.Exceptions
{
    public class PerformanceDateIsNotWithinEventTime : Exception
    {
        public PerformanceDateIsNotWithinEventTime(string message) : base(message)
        {
        }

        public PerformanceDateIsNotWithinEventTime(string message, Exception innerException) : base(message, innerException)
        {
        }

        public PerformanceDateIsNotWithinEventTime()
        {
        }
    }
}
