using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntitiesObjects.Responses
{
    public record PersonResponse
    (
        long Id , 
        long UserId ,
        string FirstName ,
        string LastName ,
        int Age ,
        DateTime Birthday ,
        decimal Salary ,
        int JobPosition 
    );
}
