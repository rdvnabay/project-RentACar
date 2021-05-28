using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.Languages.Queries
{
    public class GetLanguageQuery:IRequest<IDataResult<Language>>
    {
        public int Id { get; set; }

        public class GetLanguageQueryHandler : IRequestHandler<GetLanguageQuery, IDataResult<Language>>
        {
            private readonly ILanguageDal _languagDal;
            private readonly IMediator _mediator;

            public GetLanguageQueryHandler(ILanguageDal languagDal, IMediator mediator)
            {
                _languagDal = languagDal;
                _mediator = mediator;
            }


            public async Task<IDataResult<Language>> Handle(GetLanguageQuery request, CancellationToken cancellationToken)
            {
                var language = _languagDal.Get(x => x.Id == request.Id);
                return new SuccessDataResult<Language>(language);
            }
        }
    }
}
