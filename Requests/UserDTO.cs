using Infrastructure.Objects;
using System.Text.Json.Serialization;

namespace TestProjectNunit.Requests
{
    public record UserDTO
    (
    string Password,
    string Email,
    string Phone,
    string NickName,    
    string Method
    ) : BaseRequest(Method);    
}
