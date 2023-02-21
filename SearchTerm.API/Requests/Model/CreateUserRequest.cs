using System.ComponentModel.DataAnnotations;

namespace SearchTerm.API.Requests.Model
{
    public class CreateUserRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
    }
}
