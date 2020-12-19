using AutoMapper;
using CheckerApp.Application.Common.Interfaces;
using CheckerApp.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace CheckerApp.Application.Hardwares.Queries
{
    public class GetHardwateDetailQueryHandler : IRequestHandler<GetHardwareDetailQuery, HardwareDto>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public GetHardwateDetailQueryHandler(IAppDbContext context, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<HardwareDto> Handle(GetHardwareDetailQuery request, CancellationToken cancellationToken)
        {
            var result =  await _context.Hardwares
                .FirstOrDefaultAsync(h => h.Id == request.Id);

            result.CreatedBy = (await _userManager.FindByIdAsync(result.CreatedBy)).FullName;
            result.LastModifiedBy = (await _userManager.FindByIdAsync(result.LastModifiedBy))?.FullName;

            return _mapper.Map<HardwareDto>(result);
        }
    }
}
