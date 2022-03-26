using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.Languages.Queries
{
    public class GetLanguagesQuery:IRequest<IDataResult<IEnumerable<Language>>>
    {
        public class GetLanguagesQueryHandler : IRequestHandler<GetLanguagesQuery, IDataResult<IEnumerable<Language>>>
        {
            private readonly ILanguageRepository _languageDal;
            private readonly IMediator _mediator;

            public GetLanguagesQueryHandler(ILanguageRepository languageDal, IMediator mediator)
            {
                _languageDal = languageDal;
                _mediator = mediator;
            }
            public async Task<IDataResult<IEnumerable<Language>>> Handle(GetLanguagesQuery request, CancellationToken cancellationToken)
            {
                var languages = _languageDal.GetAll();
                return new SuccessDataResult<IEnumerable<Language>>(languages);
            }
        }
    }
}
