using CheckerApp.WebUI.ViewModels.Contract;
using System.Threading.Tasks;

namespace CheckerApp.WebUI.Interfaces
{
    public interface IContractService
    {
        Task<ContractsListVm> GetContracts();
        Task<ContractDetailVm> GetContract(int id);
        Task<int> CreateContract(CreateContractVm command);
    }
}
