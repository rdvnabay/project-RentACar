using Core.Entities;

namespace Entities.Dtos.CarImage
{
    public class CarImageUpdateDto:IDto
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string ImagePath { get; set; }
    }
}
