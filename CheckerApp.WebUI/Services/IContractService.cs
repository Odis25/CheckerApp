using CheckerApp.WebUI.ViewModels.Contract;
using System.Threading.Tasks;

namespace CheckerApp.WebUI.Services
{
    public interface IContractService
    {
        Task<ContractsListVm> GetContracts();
        Task<ContractDetailVm> GetContract(int id);
        Task<int> CreateContract(CreateContractVm command);
    }
}
