using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.Brands.Queries
{
    public class GetBrandQuery:IRequest<IDataResult<Brand>>
    {
        public int BrandId { get; set; }

        public class GetBrandQueryHandler : IRequestHandler<GetBrandQuery, IDataResult<Brand>>
        {
            private readonly IMediator _mediator;
            private readonly IBrandDal _brandDal;
            public GetBrandQueryHandler(IMediator mediator, IBrandDal brandDal)
            {
                _mediator = mediator;
                _brandDal = brandDal;
            }
            public async Task<IDataResult<Brand>> Handle(GetBrandQuery request, CancellationToken cancellationToken)
            {
                var brand = await _brandDal.GetAsync(x => x.Id == request.BrandId);
                return new SuccessDataResult<Brand>(brand);
            }
        }
    }
}
