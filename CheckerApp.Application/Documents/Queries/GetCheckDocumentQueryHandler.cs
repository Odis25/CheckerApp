using AutoMapper;
using AutoMapper.QueryableExtensions;
using CheckerApp.Application.Common.Interfaces;
using CheckerApp.Application.Hardwares.Queries;
using CheckerApp.Domain.Entities.HardwareEntities;
using CheckerApp.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CheckerApp.Application.Documents.Queries
{
    public class GetCheckDocumentQueryHandler : IRequestHandler<GetCheckDocumentQuery, ContractCheckStatusVm>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetCheckDocumentQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ContractCheckStatusVm> Handle(GetCheckDocumentQuery request, CancellationToken cancellationToken)
        {
            var contract = await _context.Contracts.FindAsync(request.ContractId);

            var vm = new ContractCheckStatusVm
            {
                ContractNumber = contract.ContractNumber,
                DomesticNumber = contract.DomesticNumber,
                Name = contract.Name,
                HardwareChecks = new List<HardwareCheckStatusDto>()
            };

            foreach (var item in contract.HardwareList)
            {
                switch (item.HardwareType)
                {
                    case HardwareType.Cabinet:

                        var hardwareDto = _mapper.Map<CabinetCheckStatusDto>(item);

                        vm.HardwareChecks.Add(hardwareDto);                       
                        break;
                    case Domain.Enums.HardwareType.FlowComputer:
                        break;
                    case Domain.Enums.HardwareType.Flowmeter:
                        break;
                    case Domain.Enums.HardwareType.Network:
                        break;
                    case Domain.Enums.HardwareType.PLC:
                        break;
                    case Domain.Enums.HardwareType.Pressure:
                        break;
                    case Domain.Enums.HardwareType.Temperature:
                        break;
                    case Domain.Enums.HardwareType.Valve:
                        break;
                }
            }

            return vm;
        }
    }
}
