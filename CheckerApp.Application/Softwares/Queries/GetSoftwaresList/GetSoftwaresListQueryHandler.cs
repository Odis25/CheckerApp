using AutoMapper;
using CheckerApp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CheckerApp.Application.Softwares.Queries.GetSoftwaresList
{
    public class GetSoftwaresListQueryHandler : IRequestHandler<GetSoftwaresListQuery, SoftwaresListDto>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetSoftwaresListQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SoftwaresListDto> Handle(GetSoftwaresListQuery request, CancellationToken cancellationToken)
        {
            var softwaresListDto = await _context.Softwares.ToListAsync();

            var vm = new SoftwaresListDto
            {
                Softwares = _mapper.Map<IList<SoftwareDto>>(softwaresListDto)
            };

            return vm;
        }
    }
}
