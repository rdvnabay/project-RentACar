using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.Brands.Commands
{
    public class DeleteCarCommand : IRequest<IResult>
    {
        public int Id { get; set; }

        public class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand, IResult>
        {
            private readonly IMediator _mediator;
            private readonly ICarDal _carDal;
            public DeleteCarCommandHandler(IMediator mediator, ICarDal carDal)
            {
                _mediator = mediator;
                _carDal = carDal;
            }
            public async Task<IResult> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
            {
                var carToDelete = _carDal.Get(x => x.Id == request.Id);
                _carDal.Delete(carToDelete);
                return new SuccessResult(Messages.Deleted);
            }
        }
    }
}
