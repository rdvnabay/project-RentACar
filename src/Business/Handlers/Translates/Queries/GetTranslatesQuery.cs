using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.Translates.Queries
{
    public class GetTranslatesQuery : IRequest<IDataResult<IEnumerable<Translate>>>
    {
        public class GetTranslatesQueryHandler : IRequestHandler<GetTranslatesQuery, IDataResult<IEnumerable<Translate>>>
        {
            private readonly ITranslateRepository _translateDal;
            private readonly IMediator _mediator;

            public GetTranslatesQueryHandler(ITranslateRepository translateDal, IMediator mediator)
            {
                _translateDal = translateDal;
                _mediator = mediator;
            }
 
            public async Task<IDataResult<IEnumerable<Translate>>> Handle(GetTranslatesQuery request, CancellationToken cancellationToken)
            {
                return new SuccessDataResult<IEnumerable<Translate>>( _translateDal.GetAll());
            }
        }
    }
}
