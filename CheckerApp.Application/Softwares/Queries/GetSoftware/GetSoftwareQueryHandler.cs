using AutoMapper;
using AutoMapper.QueryableExtensions;
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
            var software = await _context.Softwares
                .ProjectTo<SoftwareDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(s=> s.Id == request.Id);

            return software;
        }
    }
}
