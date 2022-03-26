using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.Translates.Queries
{
    public class GetTranslatesByLangQuery : IRequest<IDataResult<Dictionary<string, string>>>
	{
		public string Language { get; set; }
		public class GetTranslatesByLangQueryHandler : IRequestHandler<GetTranslatesByLangQuery, IDataResult<Dictionary<string, string>>>
		{
			private readonly ITranslateRepository _translateDal;
			private readonly IMediator _mediator;

			public GetTranslatesByLangQueryHandler(ITranslateRepository translateDal, IMediator mediator)
			{
				_translateDal = translateDal;
				_mediator = mediator;
			}

			public async Task<IDataResult<Dictionary<string, string>>> Handle(GetTranslatesByLangQuery request, CancellationToken cancellationToken)
			{
				return new SuccessDataResult<Dictionary<string, string>>(await _translateDal.GetTranslatesByLang(request.Language));
			}
		}
	}
}
