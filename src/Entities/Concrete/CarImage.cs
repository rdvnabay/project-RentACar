using Core.Entities;
using System;

namespace Entities.Concrete
{
    public class CarImage:IEntity
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string ImagePath { get; set; }
        public DateTime CreatedDate { get; set; }

        public Car Car { get; set; }
    }
}
