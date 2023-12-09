using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntitiesObjects.Entities
{
    public record User
    (
       long Id,
       string Password,
       string Email,
       string Phone,
       string NickName
    );
}
