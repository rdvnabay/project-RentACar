using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.Translates.Queries
{
    public class GetTranslateQuery : IRequest<IDataResult<Translate>>
    {
        public int Id { get; set; }

        public class GetTranslateQueryHandler : IRequestHandler<GetTranslateQuery, IDataResult<Translate>>
        {
            private readonly ITranslateRepository _translateDal;
            private readonly IMediator _mediator;

            public GetTranslateQueryHandler(ITranslateRepository translateDal, IMediator mediator)
            {
                _translateDal = translateDal;
                _mediator = mediator;
            }
            
            public async Task<IDataResult<Translate>> Handle(GetTranslateQuery request, CancellationToken cancellationToken)
            {
                var translate =  _translateDal.Get(p => p.Id == request.Id);
                return new SuccessDataResult<Translate>(translate);
            }
        }
    }
}
