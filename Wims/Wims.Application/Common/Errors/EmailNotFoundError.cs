using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wims.Application.Common.Errors
{
    public class EmailNotFoundError : IError
    {
        public List<IError> Reasons => throw new NotImplementedException();

        public string Message => "Email does not exist.";

        public Dictionary<string, object> Metadata => throw new NotImplementedException();
    }
}
