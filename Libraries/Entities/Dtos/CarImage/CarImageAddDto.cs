using Core.Entities;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Entities.Dtos.CarImage
{
    public class CarImageAddDto:IDto
    {
        public int CarId { get; set; }
        public string ImagePath { get; set; }
    }
}
