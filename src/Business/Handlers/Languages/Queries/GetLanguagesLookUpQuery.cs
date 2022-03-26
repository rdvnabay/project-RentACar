using Core.Entities.Dtos;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.Languages.Queries
{
    public class GetLanguagesLookUpQuery : IRequest<IDataResult<IEnumerable<SelectionItem>>>
    {
        public class GetLanguagesLookUpQueryHandler : IRequestHandler<GetLanguagesLookUpQuery, IDataResult<IEnumerable<SelectionItem>>>
        {
            private readonly ILanguageRepository _languageDal;
            private readonly IMediator _mediator;

            public GetLanguagesLookUpQueryHandler(ILanguageRepository languageDal, IMediator mediator)
            {
                _languageDal = languageDal;
                _mediator = mediator;
            }

            public async Task<IDataResult<IEnumerable<SelectionItem>>> Handle(GetLanguagesLookUpQuery request, CancellationToken cancellationToken)
            {
                return new SuccessDataResult<IEnumerable<SelectionItem>>(await _languageDal.GetLanguagesLookUp());
            }
        }
    }
}
