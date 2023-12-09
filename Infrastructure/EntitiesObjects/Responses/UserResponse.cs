using Infrastructure.EntitiesObjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntitiesObjects.Responses
{
    public record UserResponse
    (
     string message,
     User UserDTO
    );
}
