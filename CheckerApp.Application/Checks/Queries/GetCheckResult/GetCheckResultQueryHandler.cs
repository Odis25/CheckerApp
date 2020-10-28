using AutoMapper;
using CheckerApp.Application.Common.Interfaces;
using CheckerApp.Application.Hardwares.Helpers;
using CheckerApp.Application.Hardwares.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace CheckerApp.Application.Checks.Queries.GetCheckResult
{
    public class GetCheckResultQueryHandler : IRequestHandler<GetCheckResultQuery, CheckListDto>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetCheckResultQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CheckListDto> Handle(GetCheckResultQuery request, CancellationToken cancellationToken)
        {
            var contract = await _context.Contracts.FirstOrDefaultAsync(c => c.Id == request.ContractId);

            var check = await _context.CheckResults.FirstOrDefaultAsync(c => c.ContractId == request.ContractId);

            CheckListDto vm = new CheckListDto 
            { 
                Id = check?.Id,
                Contract = _mapper.Map<ContractDto>(contract) 
            };
            
            foreach (var hardware in contract.HardwareList)
            {
                HardwareCheckDto hardwareCheckDto;

                if (hardware.CheckResult == null)
                {
                    hardwareCheckDto = HardwareCheckHelper.GetHardwareCheckDto(hardware.HardwareType);
                    hardwareCheckDto.Hardware = _mapper.Map<HardwareDto>(hardware);
                }
                else
                {
                    hardwareCheckDto = _mapper.Map<HardwareCheckDto>(hardware.CheckResult);
                }

                vm.HardwareChecks.Add(hardwareCheckDto);
            }
           
            return vm;
        }
    }
}
