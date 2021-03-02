using AutoMapper;
using CheckerApp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace CheckerApp.Application.Softwares.Queries.GetSoftware
{
    public class GetSoftwareQueryHandler : IRequestHandler<GetSoftwareQuery, SoftwareDto>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetSoftwareQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<SoftwareDto> Handle(GetSoftwareQuery request, CancellationToken cancellationToken)
        {
            var software = await _context.Softwares.FirstOrDefaultAsync(s=> s.Id == request.Id);

            var result = _mapper.Map<SoftwareDto>(software);

            return result;
        }
    }
}
