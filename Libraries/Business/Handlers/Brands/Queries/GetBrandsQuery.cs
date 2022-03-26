using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.Brands.Queries
{
    public class GetBrandsQuery:IRequest<IDataResult<List<Brand>>>
    {
        public class GetBrandsQueryHandler : IRequestHandler<GetBrandsQuery, IDataResult<List<Brand>>>
        {
            private readonly IMediator _mediator;
            private readonly IBrandRepository _brandDal;

            public GetBrandsQueryHandler(IMediator mediator, IBrandRepository brandDal)
            {
                _mediator = mediator;
                _brandDal = brandDal;
            }
            public async Task<IDataResult<List<Brand>>> Handle(GetBrandsQuery request, CancellationToken cancellationToken)
            {
                var brands = await _brandDal.GetAllAsync();
                return new SuccessDataResult<List<Brand>>(brands);
            }
        }
    }
}
