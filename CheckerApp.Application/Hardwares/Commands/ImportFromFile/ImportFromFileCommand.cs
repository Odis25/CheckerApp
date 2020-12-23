using MediatR;

namespace CheckerApp.Application.Hardwares.Commands.ImportFromFile
{
    public class ImportFromFileCommand: IRequest
    {
        public int ContractId { get; set; }
        public byte[] FileContent { get; set; }
    }
}
