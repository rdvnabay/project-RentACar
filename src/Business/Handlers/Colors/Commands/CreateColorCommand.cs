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
    public class CreateColorCommand : IRequest<IResult>
    {
        public string Name { get; set; }

        public class CreateColorCommandHandler : IRequestHandler<CreateColorCommand, IResult>
        {
            private readonly IColorRepository _colorDal;
            private readonly IMediator _mediator;
            public CreateColorCommandHandler(IColorRepository colorDal, IMediator mediator)
            {
                _colorDal = colorDal;
                _mediator = mediator;
            }
            public async Task<IResult> Handle(CreateColorCommand request, CancellationToken cancellationToken)
            {
                var isThereColorRecord = _colorDal.GetAll().Any(x => x.Name == request.Name);
                if (isThereColorRecord)
                {
                    return new ErrorResult(Messages.NameAlreadyExist);
                }
                var addedColor = new Color
                {
                    Name = request.Name
                };
                _colorDal.Add(addedColor);
                //await _brandDal.SaveChangesAsync();
                return new SuccessResult(Messages.Added);
            }
        }
    }
}

