using Infrastructure.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntitiesObjects.Requests
{
    public class UserRequest : BaseRequest
    {        
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string NickName { get; set; }

        public UserRequest()
        {
        }
    }
}
