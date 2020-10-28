using CheckerApp.Application.Checks.Queries.GetCheckResult;
using CheckerApp.Domain.Enums;

namespace CheckerApp.Application.Hardwares.Helpers
{
    public static class HardwareCheckHelper
    {
        public static HardwareCheckDto GetHardwareCheckDto(HardwareType type)
        {
            var hardwareCheck = new HardwareCheckDto();
            switch (type)
            {
                case HardwareType.Cabinet:
                    hardwareCheck.CheckParameters.Add(new CheckParameterDto { Description = "Наличие \"Протокола проверки изделия\", подписанного БТК и СбМР" });
                    hardwareCheck.CheckParameters.Add(new CheckParameterDto { Description = "\"Холодный\" пуск" });
                    hardwareCheck.CheckParameters.Add(new CheckParameterDto { Description = "Работоспособность ИБП" });
                    break;

                case HardwareType.FlowComputer:
                    hardwareCheck.CheckParameters.Add(new CheckParameterDto { Description = "Соответствие реализованной схемы подключения прибора проектной документации" });
                    hardwareCheck.CheckParameters.Add(new CheckParameterDto { Description = "Включение и выход на рабочий режим" });
                    hardwareCheck.CheckParameters.Add(new CheckParameterDto { Description = "Контроль уровней доступа" });
                    hardwareCheck.CheckParameters.Add(new CheckParameterDto { Description = "Сопоставление выставленных диапазонов и единиц измерения с фактическими настройками датчиков" });
                    hardwareCheck.CheckParameters.Add(new CheckParameterDto { Description = "Фиксирование настроек каналов ввода-вывода" });
                    hardwareCheck.CheckParameters.Add(new CheckParameterDto { Description = "Контроль алгоритмов учета" });
                    hardwareCheck.CheckParameters.Add(new CheckParameterDto { Description = "Контроль алгоритмов работы плотномера (-ов)" });
                    hardwareCheck.CheckParameters.Add(new CheckParameterDto { Description = "Контроль алгоритмов работы влагомера (-ов)" });
                    hardwareCheck.CheckParameters.Add(new CheckParameterDto { Description = "Контроль алгоритмов работы гигрометра (-ов)" });
                    hardwareCheck.CheckParameters.Add(new CheckParameterDto { Description = "Контроль алгоритмов работы хроматографа (-ов)" });
                    hardwareCheck.CheckParameters.Add(new CheckParameterDto { Description = "Контроль алгоритмов работы вискозиметра (-ов)" });
                    hardwareCheck.CheckParameters.Add(new CheckParameterDto { Description = "Контроль параметров накоплений и архивирования данных" });
                    hardwareCheck.CheckParameters.Add(new CheckParameterDto { Description = "Контроль параметров среды" });
                    hardwareCheck.CheckParameters.Add(new CheckParameterDto { Description = "Фиксирование настроек связи" });
                    hardwareCheck.CheckParameters.Add(new CheckParameterDto { Description = "Контроль текущей даты и времени" });
                    hardwareCheck.CheckParameters.Add(new CheckParameterDto { Description = "Фиксирование контрольных сумм и версий внутреннего ПО" });
                    hardwareCheck.CheckParameters.Add(new CheckParameterDto { Description = "Контроль функции синхронизации ИВК" });
                    hardwareCheck.CheckParameters.Add(new CheckParameterDto { Description = "Создание резервной копии конфигурации ИВК или отчета по конфигурации" });
                    hardwareCheck.CheckParameters.Add(new CheckParameterDto { Description = "Восстановление с резервной копии конфигурации ИВК или сопоставление отчета по конфигурации с его фактическими настройками" });
                    break;

                case HardwareType.Flowmeter:
                    hardwareCheck.CheckParameters.Add(new CheckParameterDto { Description = "Соответствие реализованной схемы подключения прибора проектной документации" });
                    hardwareCheck.CheckParameters.Add(new CheckParameterDto { Description = "Включение и выход на рабочий режим" });
                    hardwareCheck.CheckParameters.Add(new CheckParameterDto { Description = "Имитация выходного сигнала в диапазоне 0-100 % шкалы" });
                    hardwareCheck.CheckParameters.Add(new CheckParameterDto { Description = "Контроль уровней доступа" });
                    hardwareCheck.CheckParameters.Add(new CheckParameterDto { Description = "Сопоставление выставленных диапазонов и единиц измерения с документацией на прибор" });
                    hardwareCheck.CheckParameters.Add(new CheckParameterDto { Description = "Фиксирование настроек каналов ввода-вывода" });
                    hardwareCheck.CheckParameters.Add(new CheckParameterDto { Description = "Фиксирование настроек параметров среды" });
                    hardwareCheck.CheckParameters.Add(new CheckParameterDto { Description = "Фиксирование настроек связи" });
                    hardwareCheck.CheckParameters.Add(new CheckParameterDto { Description = "Контроль текущей даты и времени" });
                    hardwareCheck.CheckParameters.Add(new CheckParameterDto { Description = "Фиксирование контрольных сумм и версий внутреннего  ПО" });
                    hardwareCheck.CheckParameters.Add(new CheckParameterDto { Description = "Создание отчета о конфигурации устройства" });
                    hardwareCheck.CheckParameters.Add(new CheckParameterDto { Description = "Сопоставление отчета о конфигурации устройства с его фактическими настройками" });
                    break;

                case HardwareType.Network:

                    hardwareCheck.CheckParameters.Add(new CheckParameterDto { Description = "Включение и выход на рабочий режим" });
                    hardwareCheck.CheckParameters.Add(new CheckParameterDto { Description = "Наличие связи со всеми устройствами в локальной сети" });
                    hardwareCheck.CheckParameters.Add(new CheckParameterDto { Description = "Создание резервной копии конфигурации сетевого оборудования или отчета по конфигурации" });
                    hardwareCheck.CheckParameters.Add(new CheckParameterDto { Description = "Восстановление с резервной копии конфигурации сетевого оборудования или сопоставление отчета по конфигурации с его фактическими настройками" });
                    break;

                case HardwareType.PLC:

                    hardwareCheck.CheckParameters.Add(new CheckParameterDto { Description = "Соответствие реализованной схемы подключения прибора проектной документации" });
                    hardwareCheck.CheckParameters.Add(new CheckParameterDto { Description = "Включение и выход на рабочий режим" });
                    hardwareCheck.CheckParameters.Add(new CheckParameterDto { Description = "Контроль уровней доступа" });
                    hardwareCheck.CheckParameters.Add(new CheckParameterDto { Description = "Фиксирование настроек каналов ввода-вывода" });
                    hardwareCheck.CheckParameters.Add(new CheckParameterDto { Description = "Контроль алгоритмов управления системы пожарной сигнализации" });
                    hardwareCheck.CheckParameters.Add(new CheckParameterDto { Description = "Контроль алгоритмов управления системой загазованности" });
                    hardwareCheck.CheckParameters.Add(new CheckParameterDto { Description = "Контроль алгоритмов управления элекроприводными кранами и регуляторами" });
                    hardwareCheck.CheckParameters.Add(new CheckParameterDto { Description = "Контроль алгоритмов управления системой обогрева блок-боксов" });
                    hardwareCheck.CheckParameters.Add(new CheckParameterDto { Description = "Контроль алгоритмов управления системой вентиляции" });
                    hardwareCheck.CheckParameters.Add(new CheckParameterDto { Description = "Контроль алгоритмов управления автоматическим пробоотбором" });
                    hardwareCheck.CheckParameters.Add(new CheckParameterDto { Description = "Контроль алгоритмов управления насосами" });
                    hardwareCheck.CheckParameters.Add(new CheckParameterDto { Description = "Контроль алгоритмов управления электропитанием ШК и ШП" });
                    hardwareCheck.CheckParameters.Add(new CheckParameterDto { Description = "Фиксирование настроек связи" });
                    hardwareCheck.CheckParameters.Add(new CheckParameterDto { Description = "Контроль текущей даты и времени" });
                    hardwareCheck.CheckParameters.Add(new CheckParameterDto { Description = "Фиксирование контрольных сумм и версий внутреннего  ПО" });
                    hardwareCheck.CheckParameters.Add(new CheckParameterDto { Description = "Контроль резервирования ПЛК" });
                    hardwareCheck.CheckParameters.Add(new CheckParameterDto { Description = "Создание резервной копии конфигурации ПЛК или отчета по конфигурации" });
                    hardwareCheck.CheckParameters.Add(new CheckParameterDto { Description = "Восстановление с резервной копии конфигурации ПЛК или сопоставление отчета по конфигурации с его фактическими настройками" });
                    break;

                case HardwareType.Pressure:
                case HardwareType.Temperature:

                    hardwareCheck.CheckParameters.Add(new CheckParameterDto { Description = "Соответствие реализованной схемы подключения прибора проектной документации" });
                    hardwareCheck.CheckParameters.Add(new CheckParameterDto { Description = "Включение и выход на рабочий режим" });
                    hardwareCheck.CheckParameters.Add(new CheckParameterDto { Description = "Сопоставление выставленных диапазонов и единиц измерения с документацией на прибор" });
                    hardwareCheck.CheckParameters.Add(new CheckParameterDto { Description = "Контроль текущего измерения на воздухе" });
                    hardwareCheck.CheckParameters.Add(new CheckParameterDto { Description = "Имитация выходного сигнала в диапазоне 0-100 % шкалы" });
                    break;

                case HardwareType.Valve:

                    hardwareCheck.CheckParameters.Add(new CheckParameterDto { Description = "Сответствие реализованной схемы подключения прибора проектной документации" });
                    hardwareCheck.CheckParameters.Add(new CheckParameterDto { Description = "Включение и выход на рабочий режим" });
                    hardwareCheck.CheckParameters.Add(new CheckParameterDto { Description = "Контроль сработки концевых выключателей" });
                    hardwareCheck.CheckParameters.Add(new CheckParameterDto { Description = "Фиксирование настроек связи" });
                    hardwareCheck.CheckParameters.Add(new CheckParameterDto { Description = "Контроль управления в местном режиме" });
                    hardwareCheck.CheckParameters.Add(new CheckParameterDto { Description = "Контроль управления в дистанционном режиме" });
                    break;
            }

            return hardwareCheck;
        }
    }
}
