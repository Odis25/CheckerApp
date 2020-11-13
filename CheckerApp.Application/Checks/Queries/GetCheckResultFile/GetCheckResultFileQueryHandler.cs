using AutoMapper;
using CheckerApp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CheckerApp.Application.Checks.Queries.GetCheckResultFile
{
    public class GetCheckResultFileQueryHandler : IRequestHandler<GetCheckResultFileQuery, CheckResultFileDto>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;

        public GetCheckResultFileQueryHandler(IAppDbContext context, IMapper mapper, IFileService fileService)
        {
            _context = context;
            _mapper = mapper;
            _fileService = fileService;
        }
        public async Task<CheckResultFileDto> Handle(GetCheckResultFileQuery request, CancellationToken cancellationToken)
        {
            var contract = await _context.Contracts.FirstOrDefaultAsync(c => c.Id == request.ContractId);
            var hardwarechecks = contract.HardwareList.Select(e => _mapper.Map<HardwareCheckDto>(e.CheckResult));
            var softwarechecks = contract.SoftwareList.Select(e => _mapper.Map<SoftwareCheckDto>(e.CheckResult));

            var vm = new CheckResultDto
            {
                Contract = _mapper.Map<ContractDto>(contract),
                HardwareChecks = hardwarechecks,
                SoftwareChecks = softwarechecks
            };

            var content = await _fileService.BuildExcelFileAsync(vm);

            return new CheckResultFileDto
            {
                Content = content,
                ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                FileName = $"Протокол проверки оборудования по договору {contract.DomesticNumber}.xlsx"
            };
        }
    }
}
