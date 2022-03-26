using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.Translates.Commands
{
    public class CreateTranslateCommand : IRequest<IResult>
    {
        public int LanguageId { get; set; }
        public string Value { get; set; }
        public string Code { get; set; }


        public class CreateTranslateCommandHandler : IRequestHandler<CreateTranslateCommand, IResult>
        {
            private readonly ITranslateRepository _translateDal;
            private readonly IMediator _mediator;
            public CreateTranslateCommandHandler(ITranslateRepository translateDal, IMediator mediator)
            {
                _translateDal = translateDal;
                _mediator = mediator;
            }

            public async Task<IResult> Handle(CreateTranslateCommand request, CancellationToken cancellationToken)
            {
                var isThereTranslateRecord = _translateDal.GetAll().Any(u => u.LanguageId == request.LanguageId && u.Code == request.Code);

                if (isThereTranslateRecord == true)
                {
                    return new ErrorResult(Messages.NameAlreadyExist);
                }

                var addedTranslate = new Translate
                {
                    LanguageId = request.LanguageId,
                    Value = request.Value,
                    Code = request.Code,

                };

                _translateDal.Add(addedTranslate);
                return new SuccessResult(Messages.Added);
            }
        }
    }
}
