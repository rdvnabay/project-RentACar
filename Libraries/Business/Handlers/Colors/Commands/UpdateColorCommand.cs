using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.Brands.Commands
{
    public class UpdateColorCommand : IRequest<IResult>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateColorCommandHandler : IRequestHandler<UpdateColorCommand, IResult>
        {
            private readonly IColorDal _colorDal;
            private readonly IMediator _mediator;

            public UpdateColorCommandHandler(IColorDal colorDal, IMediator mediator)
            {
                _colorDal = colorDal;
                _mediator = mediator;
            }
            public async Task<IResult> Handle(UpdateColorCommand request, CancellationToken cancellationToken)
            {
                var isThereColorRecord = _colorDal.Get(x => x.Id == request.Id);
                isThereColorRecord.Id = request.Id;
                isThereColorRecord.Name = request.Name;

                _colorDal.Update(isThereColorRecord);
                return new SuccessResult(Messages.Updated);
            }
        }
    }
}
