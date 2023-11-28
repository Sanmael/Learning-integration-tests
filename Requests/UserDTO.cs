using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectNunit.Requests
{
    public record class UserDTO
    (string password,
    string email,
    string phone,
    string nickName
    );
}
