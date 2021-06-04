using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfOperationClaimDal : EfEntityRepositoryBase<OperationClaim, RentACarDbContext>, IOperationClaimDal
    {
       public EfOperationClaimDal(RentACarDbContext context) : base(context) { }
    }
}
