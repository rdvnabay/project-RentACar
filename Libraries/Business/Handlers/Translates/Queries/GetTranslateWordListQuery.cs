using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.Translates.Queries
{
    public class GetTranslateWordListQuery : IRequest<IDataResult<Dictionary<string, string>>>
    {
        public string Lang { get; set; }
        public class GetTranslateWordListQueryHandler : IRequestHandler<GetTranslateWordListQuery, IDataResult<Dictionary<string, string>>>
        {
            private readonly ITranslateDal _translateDal;
            private readonly IMediator _mediator;

            public GetTranslateWordListQueryHandler(ITranslateDal translateDal, IMediator mediator)
            {
                _translateDal = translateDal;
                _mediator = mediator;
            }

            public async Task<IDataResult<Dictionary<string, string>>> Handle(GetTranslateWordListQuery request, CancellationToken cancellationToken)
            {
                return new SuccessDataResult<Dictionary<string, string>>(await _translateDal.GetTranslateWordList(request.Lang));
            }
        }
    }
}
