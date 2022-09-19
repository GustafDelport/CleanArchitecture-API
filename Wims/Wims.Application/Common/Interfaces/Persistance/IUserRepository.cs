using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wims.Domain.Entities;

namespace Wims.Application.Common.Interfaces.Persistance
{
    public interface IUserRepository
    {
        User? GetUserByEmail(string email);

        void Add(User user);
    }
}
