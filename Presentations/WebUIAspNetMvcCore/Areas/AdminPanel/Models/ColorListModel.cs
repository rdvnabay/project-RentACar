using Entities.Concrete;
using Entities.Dtos.Color;
using System.Collections.Generic;

namespace WebUIAspNetMvcCore.Areas.AdminPanel.Models
{
    public class ColorListModel
    {
        public int ColorId { get; set; }
        public List<ColorDto> Colors { get; set; }
    }
}
