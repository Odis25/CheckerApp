using System.ComponentModel.DataAnnotations;

namespace CheckerApp.Shared.Enums
{
    public enum HardwareType
    {
        [Display(Name = "Шкаф")]
        Cabinet,
        [Display(Name = "ИВК")]
        FlowComputer,
        [Display(Name = "Расходомер")]
        Flowmeter,
        [Display(Name = "Сетевое оборудование")]
        Network,
        [Display(Name = "ПЛК")]
        PLC,
        [Display(Name = "Датчик давления")]
        Pressure,
        [Display(Name = "Датчик температуры")]
        Temperature,
        [Display(Name = "Кран с электроприводом")]
        Valve,
        [Display(Name = "АРМ оператора")]
        ARM
    }
}
