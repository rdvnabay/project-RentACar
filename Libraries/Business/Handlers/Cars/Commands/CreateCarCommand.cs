using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.Brands.Commands
{
    public class CreateCarCommand : IRequest<IResult>
    {
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public string Name { get; set; }
        public int ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }

        public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, IResult>
        {
            private readonly ICarRepository _carDal;
            private readonly IMediator _mediator;
            public CreateCarCommandHandler(ICarRepository carDal, IMediator mediator)
            {
                _carDal = carDal;
                _mediator = mediator;
            }
            public async Task<IResult> Handle(CreateCarCommand request, CancellationToken cancellationToken)
            {
                var isThereBrandRecord = _carDal.GetAll().Any(x => x.Name == request.Name);
                if (isThereBrandRecord)
                {
                    return new ErrorResult(Messages.NameAlreadyExist);
                }
                var addedCar = new Car
                {
                    Name = request.Name,
                    BrandId = request.BrandId,
                    ColorId = request.ColorId,
                    DailyPrice=request.DailyPrice,
                    Description=request.Description,
                    ModelYear=request.ModelYear  
                };
                _carDal.Add(addedCar);
                //await _brandDal.SaveChangesAsync();
                return new SuccessResult(Messages.Added);
            }
        }
    }
}

