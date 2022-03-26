using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.Brands.Queries
{
    public class GetColorQuery : IRequest<IDataResult<Color>>
    {
        public int ColorId { get; set; }

        public class GetColorQueryHandler : IRequestHandler<GetColorQuery, IDataResult<Color>>
        {
            private readonly IMediator _mediator;
            private readonly IColorRepository _colorDal;
            public GetColorQueryHandler(IMediator mediator, IColorRepository colorDal)
            {
                _mediator = mediator;
                _colorDal = colorDal;
            }
            public async Task<IDataResult<Color>> Handle(GetColorQuery request, CancellationToken cancellationToken)
            {
                var color = await _colorDal.GetAsync(x => x.Id == request.ColorId);
                return new SuccessDataResult<Color>(color);
            }
        }
    }
}
