using Core.Entities;

namespace Entities.Dtos.Car
{
    public class CarAddDto:IDto
    {
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public string ImagePath { get; set; }
        public double DailyPrice { get; set; }
        public string Description { get; set; }
        public int ModelYear { get; set; }
        public string Name { get; set; }
    }
}
