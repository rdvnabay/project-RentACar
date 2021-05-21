using Core.Entities;
using System;

namespace Entities.Dtos
{
    public class CarImageAddDto:IDto
    {
        public CarImageAddDto()
        {
            Date = DateTime.Now;
        }
        public int CarId { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }
    }
}
