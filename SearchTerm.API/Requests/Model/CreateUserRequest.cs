using System.ComponentModel.DataAnnotations;

namespace SearchTerm.API.Requests.Model
{
    public class CreateUserRequest
    {
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
    }
}
