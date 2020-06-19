using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kol2.Exceptions
{
    public class EventHasAlreadyStartedException : Exception
    {
        public EventHasAlreadyStartedException(string message) : base(message)
        {
        }

        public EventHasAlreadyStartedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public EventHasAlreadyStartedException()
        {
        }
    }
}
