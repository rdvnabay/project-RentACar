using Entities.Concrete;
using Entities.Dtos.Brand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUIAspNetMvcCore.Areas.AdminPanel.Models
{
    public class BrandListModel
    {
        public int BrandId { get; set; }
        public List<BrandDto> Brands { get; set; }
    }
}
