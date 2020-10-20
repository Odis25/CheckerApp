using AutoMapper;
using CheckerApp.Application.Common.Interfaces;
using CheckerApp.Domain.Enums;
using MediatR;
using System.Collections.Generic;
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
                Name = contract.Name
            };

            foreach (var item in contract.HardwareList)
            {
                var hardware = _mapper.Map<HardwareCheckStatusDto>(item);

                switch (item.HardwareType)
                {
                    case HardwareType.Cabinet:
                        hardware.CheckParameters = new HashSet<CheckParameter>
                        {
                            new CheckParameter { Description = "Наличие \"Протокола проверки изделия\", подписанного БТК и СбМР"},
                            new CheckParameter { Description = "\"Холодный\" пуск"},
                            new CheckParameter { Description = "Работоспособность ИБП"}
                        }; 
                        break;

                    case HardwareType.FlowComputer:
                        hardware.CheckParameters = new HashSet<CheckParameter>
                        {
                            new CheckParameter { Description = "Соответствие реализованной схемы подключения прибора проектной документации"},
                            new CheckParameter { Description = "Включение и выход на рабочий режим"},
                            new CheckParameter { Description = "Контроль уровней доступа"},
                            new CheckParameter { Description = "Сопоставление выставленных диапазонов и единиц измерения с фактическими настройками датчиков"},
                            new CheckParameter { Description = "Фиксирование настроек каналов ввода-вывода"},
                            new CheckParameter { Description = "Контроль алгоритмов учета"},
                            new CheckParameter { Description = "Контроль алгоритмов работы плотномера (-ов)"},
                            new CheckParameter { Description = "Контроль алгоритмов работы влагомера (-ов)"},
                            new CheckParameter { Description = "Контроль алгоритмов работы гигрометра (-ов)"},
                            new CheckParameter { Description = "Контроль алгоритмов работы хроматографа (-ов)"},
                            new CheckParameter { Description = "Контроль алгоритмов работы вискозиметра (-ов)"},
                            new CheckParameter { Description = "Контроль параметров накоплений и архивирования данных"},
                            new CheckParameter { Description = "Контроль параметров среды"},
                            new CheckParameter { Description = "Фиксирование  настроек связи"},
                            new CheckParameter { Description = "Контроль текущей даты и времени"},
                            new CheckParameter { Description = "Фиксирование  контрольных сумм и версий внутреннего  ПО"},
                            new CheckParameter { Description = "Контроль функции синхронизации ИВК"},
                            new CheckParameter { Description = "Создание резервной копии конфигурации ИВК или отчета по конфигурации"},
                            new CheckParameter { Description = "Восстановление с резервной копии конфигурации ИВК или сопоставление отчета по конфигурации с его фактическими настройками"}
                        };
                        break;

                    case HardwareType.Flowmeter:
                        hardware.CheckParameters = new HashSet<CheckParameter>
                        {
                            new CheckParameter { Description = "Соответствие реализованной схемы подключения прибора проектной документации"},
                            new CheckParameter { Description = "Включение и выход на рабочий режим"},
                            new CheckParameter { Description = "Имитация выходного сигнала в диапазоне 0-100 % шкалы"},
                            new CheckParameter { Description = "Контроль уровней доступа"},
                            new CheckParameter { Description = "Сопоставление выставленных диапазонов и единиц измерения с документацией на прибор"},
                            new CheckParameter { Description = "Фиксирование настроек каналов ввода-вывода"},
                            new CheckParameter { Description = "Фиксирование настроек параметров среды"},
                            new CheckParameter { Description = "Фиксирование настроек связи"},
                            new CheckParameter { Description = "Контроль текущей даты и времени"},
                            new CheckParameter { Description = "Фиксирование контрольных сумм и версий внутреннего  ПО"},
                            new CheckParameter { Description = "Создание отчета о конфигурации устройства"},
                            new CheckParameter { Description = "Сопоставление отчета о конфигурации устройства с его фактическими настройками"}
                        };
                        break;

                    case HardwareType.Network:
                        hardware.CheckParameters = new HashSet<CheckParameter>
                        {
                            new CheckParameter { Description = "Включение и выход на рабочий режим"},
                            new CheckParameter { Description = "Наличие связи со всеми устройствами в локальной сети"},
                            new CheckParameter { Description = "Создание резервной копии конфигурации сетевого оборудования или отчета по конфигурации"},
                            new CheckParameter { Description = "Восстановление с резервной копии конфигурации сетевого оборудования или сопоставление отчета по конфигурации с его фактическими настройками"}
                        };
                        break;

                    case HardwareType.PLC:
                        hardware.CheckParameters = new HashSet<CheckParameter>
                        {
                            new CheckParameter { Description = "Соответствие реализованной схемы подключения прибора проектной документации"},
                            new CheckParameter { Description = "Включение и выход на рабочий режим"},
                            new CheckParameter { Description = "Контроль уровней доступа"},
                            new CheckParameter { Description = "Фиксирование настроек каналов ввода-вывода"},
                            new CheckParameter { Description = "Контроль алгоритмов управления системы пожарной сигнализации"},
                            new CheckParameter { Description = "Контроль алгоритмов управления системой загазованности"},
                            new CheckParameter { Description = "Контроль алгоритмов управления элекроприводными кранами и регуляторами"},
                            new CheckParameter { Description = "Контроль алгоритмов управления системой обогрева блок-боксов"},
                            new CheckParameter { Description = "Контроль алгоритмов управления системой вентиляции"},
                            new CheckParameter { Description = "Контроль алгоритмов управления автоматическим пробоотбором"},
                            new CheckParameter { Description = "Контроль алгоритмов управления насосами"},
                            new CheckParameter { Description = "Контроль алгоритмов управления электропитанием ШК и ШП"},
                            new CheckParameter { Description = "Фиксирование настроек связи"},
                            new CheckParameter { Description = "Контроль текущей даты и времени"},
                            new CheckParameter { Description = "Фиксирование  контрольных сумм и версий внутреннего  ПО"},
                            new CheckParameter { Description = "Контроль резервирования ПЛК"},
                            new CheckParameter { Description = "Создание резервной копии конфигурации ПЛК или отчета по конфигурации"},
                            new CheckParameter { Description = "Восстановление с резервной копии конфигурации ПЛК или сопоставление отчета по конфигурации с его фактическими настройками"}
                        };
                        break;

                    case HardwareType.Pressure:
                    case HardwareType.Temperature:

                        hardware.CheckParameters = new HashSet<CheckParameter>
                        {
                            new CheckParameter { Description = "Соответствие реализованной схемы подключения прибора проектной документации"},
                            new CheckParameter { Description = "Включение и выход на рабочий режим"},
                            new CheckParameter { Description = "Сопоставление выставленных диапазонов и единиц измерения с документацией на прибор"},
                            new CheckParameter { Description = "Контроль текущего измерения на воздухе"},
                            new CheckParameter { Description = "Имитация выходного сигнала в диапазоне 0-100 % шкалы"}
                        };
                        break;

                    case HardwareType.Valve:
                        hardware.CheckParameters = new HashSet<CheckParameter>
                        {
                            new CheckParameter { Description = "Сответствие реализованной схемы подключения прибора проектной документации"},
                            new CheckParameter { Description = "Включение и выход на рабочий режим"},
                            new CheckParameter { Description = "Контроль сработки концевых выключателей"},
                            new CheckParameter { Description = "Фиксирование настроек связи"},
                            new CheckParameter { Description = "Контроль управления в местном режиме"},
                            new CheckParameter { Description = "Контроль управления в дистанционном режиме"}
                        };
                        break;
                }

                vm.HardwareChecks.Add(hardware);
            }

            return vm;
        }
    }
}
