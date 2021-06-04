using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.Brands.Commands
{
    public class UpdateCarImageCommand : IRequest<IResult>
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }

        public class UpdateCarImageCommandHandler : IRequestHandler<UpdateCarImageCommand, IResult>
        {
            private readonly ICarImageDal _carImageDal;
            private readonly IMediator _mediator;

            public UpdateCarImageCommandHandler(ICarImageDal carImageDal, IMediator mediator)
            {
                _carImageDal = carImageDal;
                _mediator = mediator;
            }
            public async Task<IResult> Handle(UpdateCarImageCommand request, CancellationToken cancellationToken)
            {
                var isThereCarImageRecord = _carImageDal.Get(x => x.Id == request.Id);
                isThereCarImageRecord.Id = request.Id;
                isThereCarImageRecord.CarId = request.CarId;
                isThereCarImageRecord.ImagePath = request.ImagePath;
                isThereCarImageRecord.CreatedDate = request.Date;

                _carImageDal.Update(isThereCarImageRecord);
                return new SuccessResult(Messages.Updated);
            }
        }
    }
}
