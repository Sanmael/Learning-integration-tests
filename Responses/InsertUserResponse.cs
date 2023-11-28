using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProjectNunit.Requests;

namespace TestProjectNunit.Responses
{
    public record class InsertUserResponse
  ( 
    string message,
    UserDTO UserDTO
  );
}
