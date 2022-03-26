using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.Translates.Commands
{
    public class UpdateTranslateCommand : IRequest<IResult>
    {
        public int Id { get; set; }
        public int LanguageId { get; set; }
        public string Value { get; set; }
        public string Code { get; set; }

        public class UpdateTranslateCommandHandler : IRequestHandler<UpdateTranslateCommand, IResult>
        {
            private readonly ITranslateRepository _translateDal;
            private readonly IMediator _mediator;

            public UpdateTranslateCommandHandler(ITranslateRepository translateDal, IMediator mediator)
            {
                _translateDal = translateDal;
                _mediator = mediator;
            }

            public async Task<IResult> Handle(UpdateTranslateCommand request, CancellationToken cancellationToken)
            {
                var isThereTranslateRecord =  _translateDal.Get(u => u.Id == request.Id);

                isThereTranslateRecord.Id = request.Id;
                isThereTranslateRecord.LanguageId = request.LanguageId;
                isThereTranslateRecord.Value = request.Value;
                isThereTranslateRecord.Code = request.Code;

                _translateDal.Update(isThereTranslateRecord);
                return new SuccessResult(Messages.Updated);
            }
        }
    }
}
