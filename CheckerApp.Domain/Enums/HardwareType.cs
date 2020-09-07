using System.ComponentModel.DataAnnotations;

namespace CheckerApp.Domain.Enums
{
    public enum HardwareType
    {
        [Display(Name = "Шкаф")]
        Cabinet,
        [Display(Name = "ИВК")]
        FlowComuter,
        [Display(Name = "Расходомер")]
        FlowMeter,
        [Display(Name = "Сетевое оборудование")]
        Network,
        [Display(Name = "ПЛК")]
        PLC,
        [Display(Name = "Датчик давления")]
        Pressure,
        [Display(Name = "Датчик температуры")]
        Temperature,
        [Display(Name = "Кран с электроприводом")]
        Valve
    }
}
