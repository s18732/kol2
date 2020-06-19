using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kol2.Exceptions
{
    public class EventDoesNotExistsException : Exception
    {
        public EventDoesNotExistsException(string message) : base(message)
        {
        }

        public EventDoesNotExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public EventDoesNotExistsException()
        {
        }
    }
}
