using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kol2.Exceptions
{
    public class ArtistDoesNotExistsException : Exception
    {
        public ArtistDoesNotExistsException(string message) : base(message)
        {
        }

        public ArtistDoesNotExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public ArtistDoesNotExistsException()
        {
        }
    }
}
