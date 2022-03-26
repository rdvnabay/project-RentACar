using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Context;

namespace DataAccess.Concrete.EntityFramework
{
    public class OperationClaimRepository : EfEntityRepositoryBase<OperationClaim, RentACarDbContext>, IOperationClaimRepository
    {
       public OperationClaimRepository(RentACarDbContext context) : base(context) { }
    }
}
