using Entities.Concrete;
using System.Collections.Generic;

namespace WebUIAspNetMvcCore.Areas.AdminPanel.Models
{
    public class ColorListModel
    {
        public int ColorId { get; set; }
        public List<Color> Colors { get; set; }
    }
}
