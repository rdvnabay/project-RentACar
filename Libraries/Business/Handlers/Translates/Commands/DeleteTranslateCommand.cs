using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.Translates.Commands
{
    public class DeleteTranslateCommand : IRequest<IResult>
    {
        public int Id { get; set; }

        public class DeleteTranslateCommandHandler : IRequestHandler<DeleteTranslateCommand, IResult>
        {
            private readonly ITranslateRepository _translateDal;
            private readonly IMediator _mediator;

            public DeleteTranslateCommandHandler(ITranslateRepository translateDal, IMediator mediator)
            {
                _translateDal = translateDal;
                _mediator = mediator;
            }

            public async Task<IResult> Handle(DeleteTranslateCommand request, CancellationToken cancellationToken)
            {
                var translateToDelete = _translateDal.Get(p => p.Id == request.Id);
                _translateDal.Delete(translateToDelete);
                return new SuccessResult(Messages.Deleted);
            }
        }
    }
}
