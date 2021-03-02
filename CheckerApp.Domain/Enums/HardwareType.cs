using System.ComponentModel.DataAnnotations;

namespace CheckerApp.Domain.Enums
{
    public enum HardwareType
    {
        [Display(Name = "Шкаф")]
        Cabinet,
        [Display(Name = "Датчик перепада давления")]
        DiffPressure,
        [Display(Name = "Датчик давления")]
        Pressure,
        [Display(Name = "Датчик температуры")]
        Temperature,
        [Display(Name = "Датчик загазованности")]
        GasAnalyzer,
        [Display(Name = "Расходомер")]
        Flowmeter,
        [Display(Name = "ИВК")]
        FlowComputer,
        [Display(Name = "ПЛК")]
        PLC,
        [Display(Name = "Кран с электроприводом")]
        Valve,
        [Display(Name = "Сетевое оборудование")]
        Network,
        //[Display(Name = "Информационное табло")]
        //InformPanel,
        [Display(Name = "АРМ оператора")]
        ARM
    }
}
