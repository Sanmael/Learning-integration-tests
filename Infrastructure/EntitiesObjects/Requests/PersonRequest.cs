using Infrastructure.Objects;

namespace Infrastructure.EntitiesObjects.Requests
{
    public class PersonRequest : BaseRequest
    {        
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public DateTime Birthday { get; set; }
        public decimal Salary { get; set; }
        public int JobPosition { get; set; }
        public PersonRequest()
        {

        }        
    }

}
