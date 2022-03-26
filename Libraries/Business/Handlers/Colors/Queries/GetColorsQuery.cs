using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.Colors.Queries
{
    public  class GetColorsQuery:IRequest<IDataResult<IEnumerable<Color>>>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class GetColorsQueryHandler : IRequestHandler<GetColorsQuery, IDataResult<IEnumerable<Color>>>
        {
            private readonly IMediator _mediator;
            private readonly IColorRepository _colorDal;
            public GetColorsQueryHandler(IMediator mediator, IColorRepository colorDal)
            {
                _mediator = mediator;
                _colorDal = colorDal;
            }
            public async Task<IDataResult<IEnumerable<Color>>> Handle(GetColorsQuery request, CancellationToken cancellationToken)
            {
                var colors = await _colorDal.GetAllAsync();
                return new SuccessDataResult<IEnumerable<Color>>(colors);
            }
        }
    }
}
