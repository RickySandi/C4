using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C4_Model.RESTLayer.Exceptions
{
    public class BadRequestException: Exception
    {
        public BadRequestException(string ex) : base(ex)
        {
        }
    }
}
