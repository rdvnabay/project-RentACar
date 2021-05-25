using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using Core.Entities.Dtos;
using DataAccess.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfLanguageDal : EfEntityRepositoryBase<Language, RentACarDbContext>, ILanguageDal
    {
        public async Task<List<SelectionItem>> GetLanguagesLookUp()
        {
            using (var context = new RentACarDbContext())
            {
                var lookUp = await (from lang in context.Languages
                                    select new SelectionItem()
                                    {
                                        Id = lang.Id,
                                        Label = lang.Name
                                    }).ToListAsync();
                return lookUp;
            }
        }

        public async Task<List<SelectionItem>> GetLanguagesLookUpWithCode()
        {
            using (var context=new RentACarDbContext())
            {
                var lookUp = await (from lang in context.Languages
                                    select new SelectionItem()
                                    {
                                        Id=lang.Code.ToString(),
                                        Label=lang.Name

                                    }).ToListAsync();
                return lookUp;
            }
        }
    }
}
