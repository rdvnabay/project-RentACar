using Core.Entities;

namespace Entities.Dtos
{
    public class RentalListDto:IDto
    {
        public string BrandName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
