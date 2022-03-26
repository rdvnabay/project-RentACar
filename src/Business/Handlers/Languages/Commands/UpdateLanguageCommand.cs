using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.Languages.Commands
{
    public class UpdateLanguageCommand:IRequest<IResult>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }


        public class UpdateLanguageCommandHandler : IRequestHandler<UpdateLanguageCommand, IResult>
        {
            private readonly ILanguageRepository _languageDal;
            private readonly IMediator _mediator;

            public UpdateLanguageCommandHandler(ILanguageRepository languageDal, IMediator mediator)
            {
                _languageDal = languageDal;
                _mediator = mediator;
            }
            public async Task<IResult> Handle(UpdateLanguageCommand request, CancellationToken cancellationToken)
            {
                var isThereLanguageRecord = _languageDal.Get(x => x.Id == request.Id);
                isThereLanguageRecord.Id = request.Id;
                isThereLanguageRecord.Name = request.Name;
                isThereLanguageRecord.Code = request.Code;

                _languageDal.Update(isThereLanguageRecord);
                return new SuccessResult(Messages.Updated);
            }
        }
    }
}
