using Core.Entities;

namespace Entities.Dtos.Customer
{
    public class CustomerAddDto:IDto
    {
        public int UserId { get; set; }
        public string CompantName { get; set; }
    }
}
