using AutoMapper;
using CheckerApp.Application.Common.Interfaces;
using CheckerApp.Application.Hardwares.Helpers;
using CheckerApp.Application.Hardwares.Queries;
using CheckerApp.Application.Softwares.Queries.GetSoftwaresList;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CheckerApp.Application.Checks.Queries.GetCheckList
{
    public class GetCheckListQueryHandler : IRequestHandler<GetCheckListQuery, CheckListDto>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetCheckListQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CheckListDto> Handle(GetCheckListQuery request, CancellationToken cancellationToken)
        {
            //todo: почистить код
            var contract = await _context.Contracts.FirstOrDefaultAsync(c => c.Id == request.ContractId);

            var vm = new CheckListDto
            {
                Contract = _mapper.Map<ContractDto>(contract)
            };

            foreach (var hardware in contract.HardwareList)
            {
                HardwareCheckDto hardwareCheckDto;

                if (hardware.CheckResult == null)
                {
                    hardwareCheckDto = CheckHelper.GetHardwareCheckDto(hardware.HardwareType);
                    hardwareCheckDto.Hardware = _mapper.Map<HardwareDto>(hardware);
                }
                else
                {
                    hardwareCheckDto = _mapper.Map<HardwareCheckDto>(hardware.CheckResult);
                }

                vm.HardwareChecks.Add(hardwareCheckDto);
            }

            foreach (var software in contract.SoftwareList)
            {
                SoftwareCheckDto softwareCheckDto;

                if (software.CheckResult == null)
                {
                    softwareCheckDto = CheckHelper.GetSoftwareCheckDto(software.SoftwareType);
                    softwareCheckDto.Software = _mapper.Map<SoftwareDto>(software);
                }
                else
                {
                    softwareCheckDto = _mapper.Map<SoftwareCheckDto>(software.CheckResult);
                }

                vm.SoftwareChecks.Add(softwareCheckDto);
            }

            vm.HardwareChecks = vm.HardwareChecks.OrderBy(h => h.Hardware.HardwareType).ToList();

            return vm;
        }
    }
}
