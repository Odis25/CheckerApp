using AutoMapper;
using CheckerApp.Application.Common.Interfaces;
using CheckerApp.Application.Contracts.Queries.GetContractsList;
using CheckerApp.Domain.Enums;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CheckerApp.Application.Checks.Queries
{
    public class GetCheckDocumentQueryHandler : IRequestHandler<GetCheckDocumentQuery, ContractCheckVm>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetCheckDocumentQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ContractCheckVm> Handle(GetCheckDocumentQuery request, CancellationToken cancellationToken)
        {
            var contract = await _context.Contracts.FindAsync(request.ContractId);

            var vm = new ContractCheckVm
            {
                Contract = new ContractDto
                {
                    ContractNumber = contract.ContractNumber,
                    DomesticNumber = contract.DomesticNumber,
                    Name = contract.Name
                }
            };

            foreach (var item in contract.HardwareList)
            {
                var hardware = _mapper.Map<HardwareCheckDto>(item);

                switch (item.HardwareType)
                {
                    case HardwareType.Cabinet:
                        hardware.CheckParameters = new HashSet<CheckParameterDto>
                        {
                            new CheckParameterDto { Description = "Наличие \"Протокола проверки изделия\", подписанного БТК и СбМР"},
                            new CheckParameterDto { Description = "\"Холодный\" пуск"},
                            new CheckParameterDto { Description = "Работоспособность ИБП"}
                        };
                        break;

                    case HardwareType.FlowComputer:
                        hardware.CheckParameters = new HashSet<CheckParameterDto>
                        {
                            new CheckParameterDto { Description = "Соответствие реализованной схемы подключения прибора проектной документации"},
                            new CheckParameterDto { Description = "Включение и выход на рабочий режим"},
                            new CheckParameterDto { Description = "Контроль уровней доступа"},
                            new CheckParameterDto { Description = "Сопоставление выставленных диапазонов и единиц измерения с фактическими настройками датчиков"},
                            new CheckParameterDto { Description = "Фиксирование настроек каналов ввода-вывода"},
                            new CheckParameterDto { Description = "Контроль алгоритмов учета"},
                            new CheckParameterDto { Description = "Контроль алгоритмов работы плотномера (-ов)"},
                            new CheckParameterDto { Description = "Контроль алгоритмов работы влагомера (-ов)"},
                            new CheckParameterDto { Description = "Контроль алгоритмов работы гигрометра (-ов)"},
                            new CheckParameterDto { Description = "Контроль алгоритмов работы хроматографа (-ов)"},
                            new CheckParameterDto { Description = "Контроль алгоритмов работы вискозиметра (-ов)"},
                            new CheckParameterDto { Description = "Контроль параметров накоплений и архивирования данных"},
                            new CheckParameterDto { Description = "Контроль параметров среды"},
                            new CheckParameterDto { Description = "Фиксирование  настроек связи"},
                            new CheckParameterDto { Description = "Контроль текущей даты и времени"},
                            new CheckParameterDto { Description = "Фиксирование  контрольных сумм и версий внутреннего  ПО"},
                            new CheckParameterDto { Description = "Контроль функции синхронизации ИВК"},
                            new CheckParameterDto { Description = "Создание резервной копии конфигурации ИВК или отчета по конфигурации"},
                            new CheckParameterDto { Description = "Восстановление с резервной копии конфигурации ИВК или сопоставление отчета по конфигурации с его фактическими настройками"}
                        };
                        break;

                    case HardwareType.Flowmeter:
                        hardware.CheckParameters = new HashSet<CheckParameterDto>
                        {
                            new CheckParameterDto { Description = "Соответствие реализованной схемы подключения прибора проектной документации"},
                            new CheckParameterDto { Description = "Включение и выход на рабочий режим"},
                            new CheckParameterDto { Description = "Имитация выходного сигнала в диапазоне 0-100 % шкалы"},
                            new CheckParameterDto { Description = "Контроль уровней доступа"},
                            new CheckParameterDto { Description = "Сопоставление выставленных диапазонов и единиц измерения с документацией на прибор"},
                            new CheckParameterDto { Description = "Фиксирование настроек каналов ввода-вывода"},
                            new CheckParameterDto { Description = "Фиксирование настроек параметров среды"},
                            new CheckParameterDto { Description = "Фиксирование настроек связи"},
                            new CheckParameterDto { Description = "Контроль текущей даты и времени"},
                            new CheckParameterDto { Description = "Фиксирование контрольных сумм и версий внутреннего  ПО"},
                            new CheckParameterDto { Description = "Создание отчета о конфигурации устройства"},
                            new CheckParameterDto { Description = "Сопоставление отчета о конфигурации устройства с его фактическими настройками"}
                        };
                        break;

                    case HardwareType.Network:
                        hardware.CheckParameters = new HashSet<CheckParameterDto>
                        {
                            new CheckParameterDto { Description = "Включение и выход на рабочий режим"},
                            new CheckParameterDto { Description = "Наличие связи со всеми устройствами в локальной сети"},
                            new CheckParameterDto { Description = "Создание резервной копии конфигурации сетевого оборудования или отчета по конфигурации"},
                            new CheckParameterDto { Description = "Восстановление с резервной копии конфигурации сетевого оборудования или сопоставление отчета по конфигурации с его фактическими настройками"}
                        };
                        break;

                    case HardwareType.PLC:
                        hardware.CheckParameters = new HashSet<CheckParameterDto>
                        {
                            new CheckParameterDto { Description = "Соответствие реализованной схемы подключения прибора проектной документации"},
                            new CheckParameterDto { Description = "Включение и выход на рабочий режим"},
                            new CheckParameterDto { Description = "Контроль уровней доступа"},
                            new CheckParameterDto { Description = "Фиксирование настроек каналов ввода-вывода"},
                            new CheckParameterDto { Description = "Контроль алгоритмов управления системы пожарной сигнализации"},
                            new CheckParameterDto { Description = "Контроль алгоритмов управления системой загазованности"},
                            new CheckParameterDto { Description = "Контроль алгоритмов управления элекроприводными кранами и регуляторами"},
                            new CheckParameterDto { Description = "Контроль алгоритмов управления системой обогрева блок-боксов"},
                            new CheckParameterDto { Description = "Контроль алгоритмов управления системой вентиляции"},
                            new CheckParameterDto { Description = "Контроль алгоритмов управления автоматическим пробоотбором"},
                            new CheckParameterDto { Description = "Контроль алгоритмов управления насосами"},
                            new CheckParameterDto { Description = "Контроль алгоритмов управления электропитанием ШК и ШП"},
                            new CheckParameterDto { Description = "Фиксирование настроек связи"},
                            new CheckParameterDto { Description = "Контроль текущей даты и времени"},
                            new CheckParameterDto { Description = "Фиксирование  контрольных сумм и версий внутреннего  ПО"},
                            new CheckParameterDto { Description = "Контроль резервирования ПЛК"},
                            new CheckParameterDto { Description = "Создание резервной копии конфигурации ПЛК или отчета по конфигурации"},
                            new CheckParameterDto { Description = "Восстановление с резервной копии конфигурации ПЛК или сопоставление отчета по конфигурации с его фактическими настройками"}
                        };
                        break;

                    case HardwareType.Pressure:
                    case HardwareType.Temperature:

                        hardware.CheckParameters = new HashSet<CheckParameterDto>
                        {
                            new CheckParameterDto { Description = "Соответствие реализованной схемы подключения прибора проектной документации"},
                            new CheckParameterDto { Description = "Включение и выход на рабочий режим"},
                            new CheckParameterDto { Description = "Сопоставление выставленных диапазонов и единиц измерения с документацией на прибор"},
                            new CheckParameterDto { Description = "Контроль текущего измерения на воздухе"},
                            new CheckParameterDto { Description = "Имитация выходного сигнала в диапазоне 0-100 % шкалы"}
                        };
                        break;

                    case HardwareType.Valve:
                        hardware.CheckParameters = new HashSet<CheckParameterDto>
                        {
                            new CheckParameterDto { Description = "Сответствие реализованной схемы подключения прибора проектной документации"},
                            new CheckParameterDto { Description = "Включение и выход на рабочий режим"},
                            new CheckParameterDto { Description = "Контроль сработки концевых выключателей"},
                            new CheckParameterDto { Description = "Фиксирование настроек связи"},
                            new CheckParameterDto { Description = "Контроль управления в местном режиме"},
                            new CheckParameterDto { Description = "Контроль управления в дистанционном режиме"}
                        };
                        break;
                }

                vm.HardwareChecks.Add(hardware);
            }

            return vm;
        }
    }
}
