using AutoMapper;
using AutoMapper.QueryableExtensions;
using CheckerApp.Application.Common.Interfaces;
using CheckerApp.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace CheckerApp.Application.Contracts.Queries.GetContractDetail
{
    public class GetContractQueryHandler : IRequestHandler<GetContractDetailQuery, ContractDetailDto>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public GetContractQueryHandler(IAppDbContext context, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task<ContractDetailDto> Handle(GetContractDetailQuery request, CancellationToken cancellationToken)
        {
            var res = await _context.Contracts
                .ProjectTo<ContractDetailDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(c => c.Id == request.Id);

            res.CreatedBy = (await _userManager.FindByIdAsync(res.CreatedBy)).FullName;
            res.LastModifiedBy = (await _userManager.FindByIdAsync(res.LastModifiedBy))?.FullName;

            return res;
        }
    }

}
