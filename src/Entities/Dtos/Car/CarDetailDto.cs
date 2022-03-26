using Core.Entities;
using System.Collections.Generic;

namespace Entities.Dtos.Car
{
    public class CarDetailDto:IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public string Description { get; set; }
        public int ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
    }
}
