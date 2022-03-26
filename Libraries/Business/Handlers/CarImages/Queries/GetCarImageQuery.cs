using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.CarImages.Queries
{
    public class GetCarImageQuery:IRequest<IDataResult<CarImage>>
    {
        public int Id { get; set; }

        public class GetCarImageQueryHandler : IRequestHandler<GetCarImageQuery, IDataResult<CarImage>>
        {
            private readonly IMediator _mediator;
            private readonly ICarImageRepository _carImageDal;
            public GetCarImageQueryHandler(IMediator mediator, ICarImageRepository carImageDal)
            {
                _mediator = mediator;
                _carImageDal = carImageDal;
            }
            public async Task<IDataResult<CarImage>> Handle(GetCarImageQuery request, CancellationToken cancellationToken)
            {
                var carImage = await _carImageDal.GetAsync(x => x.Id == request.Id);
                return new SuccessDataResult<CarImage>(carImage);
            }
        }
    }
}
