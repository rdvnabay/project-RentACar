﻿using Core.Entities;

namespace Entities.Dtos.Color
{
    public class ColorUpdateDto:IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
