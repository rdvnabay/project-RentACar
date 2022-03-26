using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using Core.Entities.Dtos;
using DataAccess.Abstract;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class LanguageRepository : EfEntityRepositoryBase<Language, RentACarDbContext>, ILanguageRepository
    {
        public LanguageRepository(RentACarDbContext context) : base(context) { }
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
