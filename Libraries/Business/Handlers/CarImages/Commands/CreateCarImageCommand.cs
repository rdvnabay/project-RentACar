using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.Brands.Commands
{
    public class CreateCarImageCommand : IRequest<IResult>
    {
        public int CarId { get; set; }
        public string ImagePath { get; set; }

        public class CreateCarImageCommandHandler : IRequestHandler<CreateCarImageCommand, IResult>
        {
            private readonly ICarImageDal _carImageDal;
            private readonly IMediator _mediator;
            public CreateCarImageCommandHandler(ICarImageDal carImageDal, IMediator mediator)
            {
                _carImageDal = carImageDal;
                _mediator = mediator;
            }
            public async Task<IResult> Handle(CreateCarImageCommand request, CancellationToken cancellationToken)
            {
                var isThereCarImageRecord = _carImageDal.GetAll().Any(x => x.ImagePath == request.ImagePath);
                if (isThereCarImageRecord)
                {
                    return new ErrorResult(Messages.NameAlreadyExist);
                }
                var addedCarImage = new CarImage
                {
                    CarId = request.CarId,
                    ImagePath=request.ImagePath,
                };
                _carImageDal.Add(addedCarImage);
                //await _brandDal.SaveChangesAsync();
                return new SuccessResult(Messages.Added);
            }
        }
    }
}

