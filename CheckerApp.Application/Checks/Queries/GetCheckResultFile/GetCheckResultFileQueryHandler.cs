using AutoMapper;
using CheckerApp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
            var checkResult = await _context.CheckResults.FirstOrDefaultAsync(cr => cr.ContractId == request.ContractId);
            
            var contractCheckDto = _mapper.Map<CheckResultDto>(checkResult);

            var content = await _fileService.BuildExcelFileAsync(contractCheckDto);

            return new CheckResultFileDto
            {
                Content = content,
                ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                FileName = $"Протокол проверки оборудования по договору {contractCheckDto.Contract.DomesticNumber}.xlsx"
            };
        }
    }
}
