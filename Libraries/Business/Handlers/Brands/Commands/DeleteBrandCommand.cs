using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.Brands.Commands
{
    public class DeleteBrandCommand:IRequest<IResult>
    {
        public int Id { get; set; }

        public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand, IResult>
        {
            private readonly IMediator _mediator;
            private readonly IBrandDal _brandDal;
            public DeleteBrandCommandHandler(IMediator mediator, IBrandDal brandDal)
            {
                _mediator = mediator;
                _brandDal = brandDal;
            }
            public async Task<IResult> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
            {
                var brandToDelete = _brandDal.Get(x => x.Id == request.Id);
                _brandDal.Delete(brandToDelete);
                return new SuccessResult(Messages.Deleted);
            }
        }
    }
}
