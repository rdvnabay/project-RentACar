using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.Languages.Commands
{
    public class CreateLanguageCommand:IRequest<IResult>
    {
        public string Name { get; set; }
        public string Code { get; set; }

        public class CreateLanguageCommandHandler : IRequestHandler<CreateLanguageCommand, IResult>
        {
            private readonly ILanguageRepository _languageDal;
            private readonly IMediator _mediator;
            public CreateLanguageCommandHandler(ILanguageRepository languageDal,IMediator mediator)
            {
                _languageDal = languageDal;
                _mediator = mediator;
            }


            public async Task<IResult> Handle(CreateLanguageCommand request, CancellationToken cancellationToken)
            {
                var isThereLanguageRecord = _languageDal.GetAll().Any(x => x.Name == request.Name);
                if (isThereLanguageRecord)
                {
                    return new ErrorResult(Messages.NameAlreadyExist);
                }
                var addedLanguage = new Language
                {
                    Name = request.Name,
                    Code = request.Code
                };

                 _languageDal.Add(addedLanguage);
                
                return new SuccessResult(Messages.Added);
            }
        }
    }
}
