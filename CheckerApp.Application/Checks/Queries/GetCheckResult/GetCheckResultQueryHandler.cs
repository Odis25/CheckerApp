using AutoMapper;
using CheckerApp.Application.Common.Interfaces;
using CheckerApp.Application.Hardwares.Queries;
using CheckerApp.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CheckerApp.Application.Checks.Queries.GetCheckResult
{
    public class GetCheckResultQueryHandler : IRequestHandler<GetCheckResultQuery, CheckResultDto>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetCheckResultQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<CheckResultDto> Handle(GetCheckResultQuery request, CancellationToken cancellationToken)
        {
            var contract = await _context.Contracts.FirstOrDefaultAsync(c => c.Id == request.ContractId);

            if (contract.CheckResult != null)
            {
                return _mapper.Map<CheckResultDto>(contract.CheckResult);
            }

            var hardwareChecks = contract.HardwareList.Select(h => new HardwareCheckDto
            {
                Hardware = _mapper.Map<HardwareDto>(h),
                CheckParameters = SetCheckParameters(h.HardwareType)
            });

            var vm = new CheckResultDto
            {
                Contract = _mapper.Map<ContractDto>(contract),
                HardwareChecks = hardwareChecks
            };

            return vm;
        }

        private IEnumerable<CheckParameterDto> SetCheckParameters(HardwareType type)
        {
            switch (type)
            {
                case HardwareType.Cabinet:
                    return new HashSet<CheckParameterDto>
                        {
                            new CheckParameterDto { Description = "Наличие \"Протокола проверки изделия\", подписанного БТК и СбМР"},
                            new CheckParameterDto { Description = "\"Холодный\" пуск"},
                            new CheckParameterDto { Description = "Работоспособность ИБП"}
                        };

                case HardwareType.FlowComputer:
                    return new HashSet<CheckParameterDto>
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
                            new CheckParameterDto { Description = "Фиксирование настроек связи"},
                            new CheckParameterDto { Description = "Контроль текущей даты и времени"},
                            new CheckParameterDto { Description = "Фиксирование контрольных сумм и версий внутреннего ПО"},
                            new CheckParameterDto { Description = "Контроль функции синхронизации ИВК"},
                            new CheckParameterDto { Description = "Создание резервной копии конфигурации ИВК или отчета по конфигурации"},
                            new CheckParameterDto { Description = "Восстановление с резервной копии конфигурации ИВК или сопоставление отчета по конфигурации с его фактическими настройками"}
                        };

                case HardwareType.Flowmeter:
                    return new HashSet<CheckParameterDto>
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

                case HardwareType.Network:
                    return new HashSet<CheckParameterDto>
                        {
                            new CheckParameterDto { Description = "Включение и выход на рабочий режим"},
                            new CheckParameterDto { Description = "Наличие связи со всеми устройствами в локальной сети"},
                            new CheckParameterDto { Description = "Создание резервной копии конфигурации сетевого оборудования или отчета по конфигурации"},
                            new CheckParameterDto { Description = "Восстановление с резервной копии конфигурации сетевого оборудования или сопоставление отчета по конфигурации с его фактическими настройками"}
                        };

                case HardwareType.PLC:
                    return new HashSet<CheckParameterDto>
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
                            new CheckParameterDto { Description = "Фиксирование контрольных сумм и версий внутреннего  ПО"},
                            new CheckParameterDto { Description = "Контроль резервирования ПЛК"},
                            new CheckParameterDto { Description = "Создание резервной копии конфигурации ПЛК или отчета по конфигурации"},
                            new CheckParameterDto { Description = "Восстановление с резервной копии конфигурации ПЛК или сопоставление отчета по конфигурации с его фактическими настройками"}
                        };

                case HardwareType.Pressure:
                case HardwareType.Temperature:
                    return new HashSet<CheckParameterDto>
                        {
                            new CheckParameterDto { Description = "Соответствие реализованной схемы подключения прибора проектной документации"},
                            new CheckParameterDto { Description = "Включение и выход на рабочий режим"},
                            new CheckParameterDto { Description = "Сопоставление выставленных диапазонов и единиц измерения с документацией на прибор"},
                            new CheckParameterDto { Description = "Контроль текущего измерения на воздухе"},
                            new CheckParameterDto { Description = "Имитация выходного сигнала в диапазоне 0-100 % шкалы"}
                        };

                case HardwareType.Valve:
                    return new HashSet<CheckParameterDto>
                        {
                            new CheckParameterDto { Description = "Сответствие реализованной схемы подключения прибора проектной документации"},
                            new CheckParameterDto { Description = "Включение и выход на рабочий режим"},
                            new CheckParameterDto { Description = "Контроль сработки концевых выключателей"},
                            new CheckParameterDto { Description = "Фиксирование настроек связи"},
                            new CheckParameterDto { Description = "Контроль управления в местном режиме"},
                            new CheckParameterDto { Description = "Контроль управления в дистанционном режиме"}
                        };
                default:
                    return null;
            }
        }
    }
}
