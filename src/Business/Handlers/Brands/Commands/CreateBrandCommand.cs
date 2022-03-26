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
    public class CreateBrandCommand : IRequest<IResult>
    {
        public string Name { get; set; }

        public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, IResult>
        {
            private readonly IBrandRepository _brandDal;
            private readonly IMediator _mediator;
            public CreateBrandCommandHandler(IBrandRepository brandDal, IMediator mediator)
            {
                _brandDal = brandDal;
                _mediator = mediator;
            }
            public async Task<IResult> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
            {
                var isThereBrandRecord = _brandDal.GetAll().Any(x => x.Name == request.Name);
                if (isThereBrandRecord)
                {
                    return new ErrorResult(Messages.NameAlreadyExist);
                }
                var addedBrand = new Brand
                {
                    Name = request.Name
                };
                _brandDal.Add(addedBrand);
               //await _brandDal.SaveChangesAsync();
                return new SuccessResult(Messages.Added);
            }
        }
    }
}

           