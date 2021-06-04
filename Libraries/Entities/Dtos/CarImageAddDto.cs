using Core.Entities;

namespace Entities.Dtos
{
    public class CarImageAddDto:IDto
    {
        public int CarId { get; set; }
        public string ImagePath { get; set; }
    }
}
