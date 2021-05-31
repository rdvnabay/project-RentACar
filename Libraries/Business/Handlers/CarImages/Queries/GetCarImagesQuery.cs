using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.CarImages.Queries
{
    public class GetCarImagesQuery:IRequest<IDataResult<IEnumerable<CarImage>>>
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }

        public class GetCarImagesQueryHandler : IRequestHandler<GetCarImagesQuery, IDataResult<IEnumerable<CarImage>>>
        {
            private readonly IMediator _mediator;
            private readonly ICarImageDal _carImageDal;
            public GetCarImagesQueryHandler(IMediator mediator, ICarImageDal carImageDal)
            {
                _mediator = mediator;
                _carImageDal = carImageDal;
            }
            public async Task<IDataResult<IEnumerable<CarImage>>> Handle(GetCarImagesQuery request, CancellationToken cancellationToken)
            {
                var carImages = await _carImageDal.GetAllAsync();
                return new SuccessDataResult<IEnumerable<CarImage>>(carImages);
            }
        }
    }
}
