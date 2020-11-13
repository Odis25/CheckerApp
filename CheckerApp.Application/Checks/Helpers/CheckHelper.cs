using CheckerApp.Application.Checks.Queries.GetCheckList;
using CheckerApp.Domain.Enums;

namespace CheckerApp.Application.Hardwares.Helpers
{
    public static class CheckHelper
    {
        public static HardwareCheckDto GetHardwareCheckDto(HardwareType type)
        {
            var check = new HardwareCheckDto();
            switch (type)
            {
                case HardwareType.Cabinet:
                    check.CheckParameters.Add(new CheckParameterDto
                    {
                        Description = "Наличие \"Протокола проверки изделия\", подписанного БТК и СбМР",
                        Method = "-"
                    });
                    check.CheckParameters.Add(new CheckParameterDto
                    {
                        Description = "\"Холодный\" пуск",
                        Method = "-"
                    });
                    check.CheckParameters.Add(new CheckParameterDto { Description = "Работоспособность ИБП" });
                    break;

                case HardwareType.FlowComputer:
                    check.CheckParameters.Add(new CheckParameterDto
                    {
                        Description = "Соответствие реализованной схемы подключения прибора проектной документации",
                        Method = "-"
                    });
                    check.CheckParameters.Add(new CheckParameterDto { Description = "Включение и выход на рабочий режим" });
                    check.CheckParameters.Add(new CheckParameterDto { Description = "Контроль уровней доступа" });
                    check.CheckParameters.Add(new CheckParameterDto { Description = "Сопоставление выставленных диапазонов и единиц измерения с фактическими настройками датчиков" });
                    check.CheckParameters.Add(new CheckParameterDto { Description = "Фиксирование настроек каналов ввода-вывода" });
                    check.CheckParameters.Add(new CheckParameterDto { Description = "Контроль алгоритмов учета" });
                    check.CheckParameters.Add(new CheckParameterDto
                    {
                        Description = "Контроль алгоритмов работы плотномера (-ов)",
                        Method = "Имитация данных"
                    });
                    check.CheckParameters.Add(new CheckParameterDto
                    {
                        Description = "Контроль алгоритмов работы влагомера (-ов)",
                        Method = "Имитация данных"
                    });
                    check.CheckParameters.Add(new CheckParameterDto
                    {
                        Description = "Контроль алгоритмов работы гигрометра (-ов)",
                        Method = "Имитация данных"
                    });
                    check.CheckParameters.Add(new CheckParameterDto
                    {
                        Description = "Контроль алгоритмов работы хроматографа (-ов)",
                        Method = "Имитация данных"
                    });
                    check.CheckParameters.Add(new CheckParameterDto
                    {
                        Description = "Контроль алгоритмов работы вискозиметра (-ов)",
                        Method = "Имитация данных"
                    });
                    check.CheckParameters.Add(new CheckParameterDto { Description = "Контроль параметров накоплений и архивирования данных" });
                    check.CheckParameters.Add(new CheckParameterDto { Description = "Контроль параметров среды" });
                    check.CheckParameters.Add(new CheckParameterDto { Description = "Фиксирование настроек связи" });
                    check.CheckParameters.Add(new CheckParameterDto { Description = "Контроль текущей даты и времени" });
                    check.CheckParameters.Add(new CheckParameterDto { Description = "Фиксирование контрольных сумм и версий внутреннего ПО" });
                    check.CheckParameters.Add(new CheckParameterDto { Description = "Контроль функции синхронизации ИВК" });
                    check.CheckParameters.Add(new CheckParameterDto { Description = "Создание резервной копии конфигурации ИВК или отчета по конфигурации" });
                    check.CheckParameters.Add(new CheckParameterDto { Description = "Восстановление с резервной копии конфигурации ИВК или сопоставление отчета по конфигурации с его фактическими настройками" });
                    break;

                case HardwareType.Flowmeter:
                    check.CheckParameters.Add(new CheckParameterDto
                    {
                        Description = "Соответствие реализованной схемы подключения прибора проектной документации",
                        Method = "-"
                    });
                    check.CheckParameters.Add(new CheckParameterDto { Description = "Включение и выход на рабочий режим" });
                    check.CheckParameters.Add(new CheckParameterDto { Description = "Имитация выходного сигнала в диапазоне 0-100 % шкалы" });
                    check.CheckParameters.Add(new CheckParameterDto { Description = "Контроль уровней доступа" });
                    check.CheckParameters.Add(new CheckParameterDto { Description = "Сопоставление выставленных диапазонов и единиц измерения с документацией на прибор" });
                    check.CheckParameters.Add(new CheckParameterDto { Description = "Фиксирование настроек каналов ввода-вывода" });
                    check.CheckParameters.Add(new CheckParameterDto { Description = "Фиксирование настроек параметров среды" });
                    check.CheckParameters.Add(new CheckParameterDto { Description = "Фиксирование настроек связи" });
                    check.CheckParameters.Add(new CheckParameterDto { Description = "Контроль текущей даты и времени" });
                    check.CheckParameters.Add(new CheckParameterDto { Description = "Фиксирование контрольных сумм и версий внутреннего  ПО" });
                    check.CheckParameters.Add(new CheckParameterDto { Description = "Создание отчета о конфигурации устройства" });
                    check.CheckParameters.Add(new CheckParameterDto { Description = "Сопоставление отчета о конфигурации устройства с его фактическими настройками" });
                    break;

                case HardwareType.Network:

                    check.CheckParameters.Add(new CheckParameterDto { Description = "Включение и выход на рабочий режим" });
                    check.CheckParameters.Add(new CheckParameterDto { Description = "Наличие связи со всеми устройствами в локальной сети" });
                    check.CheckParameters.Add(new CheckParameterDto
                    {
                        Description = "Создание резервной копии конфигурации сетевого оборудования или отчета по конфигурации",
                        Method = "-"
                    });
                    check.CheckParameters.Add(new CheckParameterDto
                    {
                        Description = "Восстановление с резервной копии конфигурации сетевого оборудования или сопоставление отчета по конфигурации с его фактическими настройками",
                        Method = "-"
                    });
                    break;

                case HardwareType.PLC:

                    check.CheckParameters.Add(new CheckParameterDto
                    {
                        Description = "Соответствие реализованной схемы подключения прибора проектной документации",
                        Method = "-"
                    });
                    check.CheckParameters.Add(new CheckParameterDto { Description = "Включение и выход на рабочий режим" });
                    check.CheckParameters.Add(new CheckParameterDto { Description = "Контроль уровней доступа" });
                    check.CheckParameters.Add(new CheckParameterDto { Description = "Фиксирование настроек каналов ввода-вывода" });
                    check.CheckParameters.Add(new CheckParameterDto { Description = "Контроль алгоритмов управления системы пожарной сигнализации" });
                    check.CheckParameters.Add(new CheckParameterDto { Description = "Контроль алгоритмов управления системой загазованности" });
                    check.CheckParameters.Add(new CheckParameterDto { Description = "Контроль алгоритмов управления элекроприводными кранами и регуляторами" });
                    check.CheckParameters.Add(new CheckParameterDto { Description = "Контроль алгоритмов управления системой обогрева блок-боксов" });
                    check.CheckParameters.Add(new CheckParameterDto { Description = "Контроль алгоритмов управления системой вентиляции" });
                    check.CheckParameters.Add(new CheckParameterDto
                    {
                        Description = "Контроль алгоритмов управления автоматическим пробоотбором",
                        Method = "Имитация данных"
                    });
                    check.CheckParameters.Add(new CheckParameterDto
                    {
                        Description = "Контроль алгоритмов управления насосами",
                        Method = "Имитация данных"
                    });
                    check.CheckParameters.Add(new CheckParameterDto
                    {
                        Description = "Контроль алгоритмов управления электропитанием ШК и ШП",
                        Method = "Имитация данных"
                    });
                    check.CheckParameters.Add(new CheckParameterDto { Description = "Фиксирование настроек связи" });
                    check.CheckParameters.Add(new CheckParameterDto { Description = "Контроль текущей даты и времени" });
                    check.CheckParameters.Add(new CheckParameterDto { Description = "Фиксирование контрольных сумм и версий внутреннего  ПО" });
                    check.CheckParameters.Add(new CheckParameterDto { Description = "Контроль резервирования ПЛК" });
                    check.CheckParameters.Add(new CheckParameterDto { Description = "Создание резервной копии конфигурации ПЛК или отчета по конфигурации" });
                    check.CheckParameters.Add(new CheckParameterDto { Description = "Восстановление с резервной копии конфигурации ПЛК или сопоставление отчета по конфигурации с его фактическими настройками" });
                    break;

                case HardwareType.Pressure:
                case HardwareType.Temperature:

                    check.CheckParameters.Add(new CheckParameterDto
                    {
                        Description = "Соответствие реализованной схемы подключения прибора проектной документации",
                        Method = "-"
                    });
                    check.CheckParameters.Add(new CheckParameterDto { Description = "Включение и выход на рабочий режим" });
                    check.CheckParameters.Add(new CheckParameterDto { Description = "Сопоставление выставленных диапазонов и единиц измерения с документацией на прибор" });
                    check.CheckParameters.Add(new CheckParameterDto { Description = "Контроль текущего измерения на воздухе" });
                    check.CheckParameters.Add(new CheckParameterDto { Description = "Имитация выходного сигнала в диапазоне 0-100 % шкалы" });
                    break;

                case HardwareType.Valve:

                    check.CheckParameters.Add(new CheckParameterDto
                    {
                        Description = "Сответствие реализованной схемы подключения прибора проектной документации",
                        Method = "-"
                    });
                    check.CheckParameters.Add(new CheckParameterDto { Description = "Включение и выход на рабочий режим" });
                    check.CheckParameters.Add(new CheckParameterDto { Description = "Контроль сработки концевых выключателей" });
                    check.CheckParameters.Add(new CheckParameterDto { Description = "Фиксирование настроек связи" });
                    check.CheckParameters.Add(new CheckParameterDto { Description = "Контроль управления в местном режиме" });
                    check.CheckParameters.Add(new CheckParameterDto { Description = "Контроль управления в дистанционном режиме" });
                    break;

                case HardwareType.ARM:

                    check.CheckParameters.Add(new CheckParameterDto
                    {
                        Description = "Включение и автозапуск программ и служб",
                        Method = "-"
                    });
                    check.CheckParameters.Add(new CheckParameterDto
                    {
                        Description = "Создание резервной копии ОС и прикладного ПО",
                        Method = "-"
                    });
                    check.CheckParameters.Add(new CheckParameterDto
                    {
                        Description = "Восстановление ОС и прикладного ПО с резервной копии",
                        Method = "-"
                    });
                    break;
            }

            return check;
        }

        public static SoftwareCheckDto GetSoftwareCheckDto(SoftwareType type)
        {
            var check = new SoftwareCheckDto();

            if (type == SoftwareType.SCADA)
            {
                check.CheckParameters.Add(new CheckParameterDto { Description = "Контроль уровней доступа к SCADA-системе" });
                check.CheckParameters.Add(new CheckParameterDto { Description = "Сопоставление мгновенных данных с ИВК/ПЛК" });
                check.CheckParameters.Add(new CheckParameterDto { Description = "Сопоставление архивных данных с ИВК/ПЛК" });
                check.CheckParameters.Add(new CheckParameterDto
                {
                    Description = "Контроль работы трендов",
                    Method = "-"
                });
                check.CheckParameters.Add(new CheckParameterDto
                {
                    Description = "Контроль работы журнала тревог и событий",
                    Method = "Имитация данных"
                });
                check.CheckParameters.Add(new CheckParameterDto { Description = "Формирование отчетных форм" });
                check.CheckParameters.Add(new CheckParameterDto
                {
                    Description = "Контроль передачи данных в АСУТП/MES и другие системы верхнего уровня",
                    Method = "Имитация данных"
                });
                check.CheckParameters.Add(new CheckParameterDto
                {
                    Description = "Контроль индикации резервирования ИВК/ПЛК",
                    Method = "-"
                });
                check.CheckParameters.Add(new CheckParameterDto
                {
                    Description = "Контроль индикации и управления системы пожарной сигнализации",
                    Method = "Имитация данных"
                });
                check.CheckParameters.Add(new CheckParameterDto
                {
                    Description = "Контроль индикации и управления системы загазованности",
                    Method = "Имитация данных"
                });
                check.CheckParameters.Add(new CheckParameterDto { Description = "Контроль индикации и управления элекроприводными кранами и регуляторами" });
                check.CheckParameters.Add(new CheckParameterDto { Description = "Контроль индикации и управления системы обогрева блок-боксов" });
                check.CheckParameters.Add(new CheckParameterDto { Description = "Контроль индикации и управления системы вентиляции" });
                check.CheckParameters.Add(new CheckParameterDto
                {
                    Description = "Контроль индикации и управления системы автоматического пробоотбора",
                    Method = "Имитация данных"
                });
                check.CheckParameters.Add(new CheckParameterDto
                {
                    Description = "Контроль индикации и управления насосов",
                    Method = "Имитация данных"
                });
                check.CheckParameters.Add(new CheckParameterDto
                {
                    Description = "Контроль индикации и управления электропитанием ШК и ШП",
                    Method = "Имитация данных"
                });
            }

            return check;
        }
    }
}
