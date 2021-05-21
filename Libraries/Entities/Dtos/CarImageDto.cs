using Core.Entities;
using System;

namespace Entities.Dtos
{
    public class CarImageDto:IDto
    {
        public CarImageDto()
        {
            Date = DateTime.Now;
        }
        public int Id { get; set; }
        public int CarId { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }
    }
}
