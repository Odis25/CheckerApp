using CheckerApp.Mobile.Interfaces;
using CheckerApp.Mobile.Models;
using CheckerApp.Mobile.Models.Hardware;
using CheckerApp.Mobile.Models.Software;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CheckerApp.Mobile.Services
{
    public class MockContractService : IContractService
    {
        private IList<HardwareDto> _hardwares = new List<HardwareDto>
        {
            new CabinetDto { Id=1, Position="ШКУ", SerialNumber="666", LastModified= DateTime.Now, Constructed = DateTime.Now.AddDays(-6), CreatedBy = "Подозрительный типок", Created = DateTime.Now },
            new PressureDto { Id=2, Position="PIT201", SerialNumber="777", LastModified= DateTime.Now,DeviceType = "Metran", DeviceModel="PT-100", MinValue=0, MaxValue=10, SignalType = Common.Enums.SignalType.Current, EU = "МПа", CreatedBy = "Подозрительный типок", Created = DateTime.Now },
            new TemperatureDto { Id=2, Position="TIT101", SerialNumber="888", LastModified= DateTime.Now,DeviceType = "Metran", DeviceModel="T-1000", MinValue=0, MaxValue=10, SignalType = Common.Enums.SignalType.Current, EU = "МПа", CreatedBy = "Подозрительный типок", Created = DateTime.Now },
        };

        private IList<SoftwareDto> _softwares = new List<SoftwareDto>
        {
            new SoftwareDto{Id=1, Name = "ReportReporter", Version="1.1"},
            new ScadaDto{Id=2, Name = "ScadaReporter", Version = "2.3"}
        };

        public Task<ContractDto> GetContractAsync(int id)
        {
            return Task.FromResult(new ContractDto
            {
                Id = 1,
                ContractNumber = "123-123-123",
                DomesticNumber = "321-321-321",
                HasProtocol = false,
                ProjectNumber = "222-222-222",
                Name = "Договор на поставку какой-то ерунды на месторождение \"ХРЕНБРЕДГАЗНЕФТЬСАЛО-Мытищи\" находящееся в какой-то глуши куда хрен доедешь на оленьих упряжках с пьяным ямщиком непонятного происхождения",
                LastModified = DateTime.Now,
                HardwareList = _hardwares,
                SoftwareList = _softwares
            });

        }

        public Task<ContractsListDto> GetContractsAsync()
        {
            var contracts = new ContractsListDto();

            contracts.Contracts.Add(new ContractDto
            {
                Id = 1,
                ContractNumber = "СПГ.123456",
                DomesticNumber = "12-2021",
                HasProtocol = true,
                ProjectNumber = "12-2021-111",
                Name = "Договор с очень-очень длинным названием которое не помещается на экран №1",
                LastModified = DateTime.Now
            });

            contracts.Contracts.Add(new ContractDto
            {
                Id = 2,
                ContractNumber = "СПГ.4353454",
                DomesticNumber = "22-2021",
                HasProtocol = false,
                ProjectNumber = "22-2021-112",
                Name = "Договор с очень-очень длинным названием которое не помещается на экран №2",
                LastModified = DateTime.Now
            });

            contracts.Contracts.Add(new ContractDto
            {
                Id = 1,
                ContractNumber = "СПГ.3463677",
                DomesticNumber = "32-2021",
                HasProtocol = true,
                ProjectNumber = "72-2021-5576",
                Name = "Договор на поставку какой-то ерунды на месторождение \"ХРЕНБРЕДГАЗНЕФТЬСАЛО-Мытищи\" находящееся в какой-то глуши куда хрен доедешь на оленьих упряжках с пьяным ямщиком непонятного происхождения",
                LastModified = DateTime.Now
            });

            return Task.FromResult(contracts);
        }
    }
}
