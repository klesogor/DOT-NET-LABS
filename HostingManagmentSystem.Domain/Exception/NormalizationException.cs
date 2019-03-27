using System;
using System.Collections.Generic;
using System.Text;

namespace HostingManagmentSystem.Domain.Exception
{
    public class NormalizationException: SystemException
    {
        public NormalizationException(string message):base(message)
        {
        }

        public static NormalizationException Of()
        {
            return new NormalizationException("Unnormalized state access. Please, use corresponding repositories to access data");
        }
    }
}
