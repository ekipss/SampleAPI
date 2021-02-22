using System;
using System.Collections.Generic;
using System.Text;

namespace SampleAPI.Domain.Exceptions
{
    public class SampleAPIDomainException : Exception
    {
        public SampleAPIDomainException()
        { }

        public SampleAPIDomainException(string message)
            : base(message)
        { }

        public SampleAPIDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
