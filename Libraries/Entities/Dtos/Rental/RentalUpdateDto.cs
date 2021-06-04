using Core.Entities;
using System;

namespace Entities.Dtos.Rental
{
    public class RentalUpdateDto:IDto
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
