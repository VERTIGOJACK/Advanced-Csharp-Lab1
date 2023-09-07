using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Csharp_Lab1.Exceptions
{
    internal class OrganizationException : Exception
    {
        public OrganizationException() { }

        public OrganizationException(string message) : base(message)
        {

        }
    }
}
