using CheckerApp.Application.Checks.Queries.GetCheckResultFile;
using System.Threading.Tasks;

namespace CheckerApp.Application.Common.Interfaces
{
    public interface IFileService
    {
        Task<byte[]> BuildExcelFileAsync(CheckResultDto checkResult);
    }
}
