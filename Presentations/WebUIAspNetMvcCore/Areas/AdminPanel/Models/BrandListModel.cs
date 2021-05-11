using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUIAspNetMvcCore.Areas.AdminPanel.Models
{
    public class BrandListModel
    {
        public int BrandId { get; set; }
        public List<Brand> Brands { get; set; }
    }
}
