using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.Brands.Commands
{
    public class DeleteColorCommand : IRequest<IResult>
    {
        public int Id { get; set; }

        public class DeleteColorCommandHandler : IRequestHandler<DeleteColorCommand, IResult>
        {
            private readonly IMediator _mediator;
            private readonly IColorRepository _colorDal;
            public DeleteColorCommandHandler(IMediator mediator, IColorRepository colorDal)
            {
                _mediator = mediator;
                _colorDal = colorDal;
            }
            public async Task<IResult> Handle(DeleteColorCommand request, CancellationToken cancellationToken)
            {
                var colorToDelete = _colorDal.Get(x => x.Id == request.Id);
                _colorDal.Delete(colorToDelete);
                return new SuccessResult(Messages.Deleted);
            }
        }
    }
}
