using Core.Entities;

namespace Entities.Dtos
{
    public class CustomerAddDto:IDto
    {
        public int UserId { get; set; }
        public string CompantName { get; set; }
    }
}
