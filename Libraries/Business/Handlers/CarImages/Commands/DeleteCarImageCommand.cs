using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.Brands.Commands
{
    public class DeleteCarImageCommand : IRequest<IResult>
    {
        public int Id { get; set; }

        public class DeleteCarImageCommandHandler : IRequestHandler<DeleteCarImageCommand, IResult>
        {
            private readonly IMediator _mediator;
            private readonly ICarImageDal _carImageDal;
            public DeleteCarImageCommandHandler(IMediator mediator, ICarImageDal carImageDal)
            {
                _mediator = mediator;
                _carImageDal = carImageDal;
            }
            public async Task<IResult> Handle(DeleteCarImageCommand request, CancellationToken cancellationToken)
            {
                var carImageToDelete = _carImageDal.Get(x => x.Id == request.Id);
                _carImageDal.Delete(carImageToDelete);
                return new SuccessResult(Messages.Deleted);
            }
        }
    }
}
