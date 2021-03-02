using AutoMapper;
using AutoMapper.QueryableExtensions;
using CheckerApp.Application.Common.Interfaces;
using CheckerApp.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
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
            try
            {
                var contract = await _context.Contracts.FirstOrDefaultAsync(c => c.Id == request.Id);

                var result = _mapper.Map<ContractDetailDto>(contract);

                result.HardwareList = result.HardwareList.OrderBy(h => h.HardwareType);
                result.CreatedBy = (await _userManager.FindByIdAsync(result.CreatedBy)).FullName;
                result.LastModifiedBy = (await _userManager.FindByIdAsync(result.LastModifiedBy))?.FullName;

                return result;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }

}
