using CheckerApp.Mobile.Models;
using System.Threading.Tasks;

namespace CheckerApp.Mobile.Interfaces
{
    public interface IContractService
    {
        Task<ContractsListDto> GetContractsAsync();
        Task<ContractDto> GetContractAsync(int id);
    }
}
