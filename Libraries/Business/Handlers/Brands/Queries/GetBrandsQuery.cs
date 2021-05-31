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
    public class GetBrandsQuery:IRequest<IDataResult<IEnumerable<Brand>>>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class GetBrandsQueryHandler : IRequestHandler<GetBrandsQuery, IDataResult<IEnumerable<Brand>>>
        {
            private readonly IMediator _mediator;
            private readonly IBrandDal _brandDal;

            public GetBrandsQueryHandler(IMediator mediator, IBrandDal brandDal)
            {
                _mediator = mediator;
                _brandDal = brandDal;
            }
            public async Task<IDataResult<IEnumerable<Brand>>> Handle(GetBrandsQuery request, CancellationToken cancellationToken)
            {
                var brands = await _brandDal.GetAllAsync();
                return new SuccessDataResult<IEnumerable<Brand>>(brands);
            }
        }
    }
}
