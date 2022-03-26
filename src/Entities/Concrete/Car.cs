using Core.Entities;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class Car:IEntity
    {
        public Car()
        {
            CarImages = new List<CarImage>();
        }
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public string Name { get; set; }
        public int ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }

        public Brand Brand { get; set; }
        public Color Color { get; set; }
        public List<CarImage> CarImages { get; set; }
    }
}
