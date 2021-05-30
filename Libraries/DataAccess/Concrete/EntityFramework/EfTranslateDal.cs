using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using Core.Entities.Dtos;
using DataAccess.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfTranslateDal : EfEntityRepositoryBase<Translate, RentACarDbContext>, ITranslateDal
    {
        public EfTranslateDal(RentACarDbContext context) : base(context) { }
        public async Task<List<TranslateDto>> GetTranslateDto()
        {
            using (var context=new RentACarDbContext())
            {
                var list = await (from lang in context.Languages
                                  join trs in context.Translates
                                  on lang.Id equals trs.LanguageId
                                  select new TranslateDto()
                                  {
                                      Id=trs.Id,
                                      Language=lang.Name,
                                      Code=trs.Code,
                                      Value=trs.Value
                                  }).ToListAsync();
                return list;
            }
        }

        public async Task<string> GetTranslatesByLang(string langCode)
        {
            using (var context = new RentACarDbContext())
            {
                var data = await (from lang in context.Languages
                                  join trs in context.Translates
                                  on lang.Id equals trs.LanguageId
                                  where lang.Code == langCode
                                  select trs).ToDictionaryAsync(x => (string)x.Code, x => (string)x.Value);
                var str = JsonConvert.SerializeObject(data);
                return str;
            }
        }

        public async Task<Dictionary<string, string>> GetTranslateWordList(string lang)
        {
            using (var context = new RentACarDbContext())
            {
                var list = await context.Translates.Where(x => x.Code == lang).ToListAsync();
                return list.ToDictionary(x => x.Code, x => x.Value);
            }
        }
    }
}
