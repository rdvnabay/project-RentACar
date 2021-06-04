using Core.Entities;

namespace Entities.Dtos.Rental
{
    public class RentalDto:IDto
    {
        public string BrandName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
