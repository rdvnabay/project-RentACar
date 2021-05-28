using Core.Entities.Dtos;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.Translates.Queries
{
    public class GetTranslateListDtoQuery : IRequest<IDataResult<IEnumerable<TranslateDto>>>
    {
        public class GetTranslateListDtoQueryHandler : IRequestHandler<GetTranslateListDtoQuery, IDataResult<IEnumerable<TranslateDto>>>
        {
            private readonly ITranslateDal _translateDal;
            private readonly IMediator _mediator;

            public GetTranslateListDtoQueryHandler(ITranslateDal translateDal, IMediator mediator)
            {
                _translateDal = translateDal;
                _mediator = mediator;
            }

            public async Task<IDataResult<IEnumerable<TranslateDto>>> Handle(GetTranslateListDtoQuery request, CancellationToken cancellationToken)
            {
                return new SuccessDataResult<IEnumerable<TranslateDto>>(await _translateDal.GetTranslateDto());
            }
        }
    }
}
