using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wims.Application.Common.Errors
{
    public class IncorrectPasswordError : IError
    {
        public List<IError> Reasons => throw new NotImplementedException();

        public string Message => "Incorrect Password";

        public Dictionary<string, object> Metadata => throw new NotImplementedException();
    }
}
