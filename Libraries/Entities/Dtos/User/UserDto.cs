using Core.Entities;

namespace Entities.Dtos.User
{
    public class UserDto:IDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
        //public List<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
