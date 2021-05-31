using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.Brands.Commands
{
    public class UpdateCarCommand : IRequest<IResult>
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public string Name { get; set; }
        public int ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }

        public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand, IResult>
        {
            private readonly ICarDal _carDal;
            private readonly IMediator _mediator;

            public UpdateCarCommandHandler(ICarDal carDal, IMediator mediator)
            {
                _carDal = carDal;
                _mediator = mediator;
            }
            public async Task<IResult> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
            {
                var isThereCarRecord = _carDal.Get(x => x.Id == request.Id);
                isThereCarRecord.Id = request.Id;
                isThereCarRecord.ColorId = request.ColorId;
                isThereCarRecord.BrandId = request.BrandId;
                isThereCarRecord.Name = request.Name;
                isThereCarRecord.DailyPrice = request.DailyPrice;
                isThereCarRecord.Description = request.Description;
                isThereCarRecord.ModelYear = request.ModelYear;

                _carDal.Update(isThereCarRecord);
                return new SuccessResult(Messages.Updated);
            }
        }
    }
}
