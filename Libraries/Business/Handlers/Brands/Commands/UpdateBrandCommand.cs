using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.Brands.Commands
{
    public class UpdateBrandCommand:IRequest<IResult>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, IResult>
        {
            private readonly IBrandDal _brandDal;
            private readonly IMediator _mediator;

            public UpdateBrandCommandHandler(IBrandDal brandDal, IMediator mediator)
            {
                _brandDal = brandDal;
                _mediator = mediator;
            }
            public async Task<IResult> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
            {
                var isThereBrandRecord = _brandDal.Get(x => x.Id == request.Id);
                isThereBrandRecord.Id = request.Id;
                isThereBrandRecord.Name = request.Name;

                _brandDal.Update(isThereBrandRecord);
                return new SuccessResult(Messages.Updated);
            }
        }
    }
}
