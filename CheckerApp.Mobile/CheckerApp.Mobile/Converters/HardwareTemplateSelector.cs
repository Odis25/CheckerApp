using CheckerApp.Mobile.Models.Hardware;
using Xamarin.Forms;

namespace CheckerApp.Mobile.Converters
{
    public class HardwareTemplateSelector : DataTemplateSelector
    {
        public DataTemplate HardwareTemplate { get; set; }
        public DataTemplate CabinetTemplate { get; set; }
        public DataTemplate MeasurementTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            switch (item)
            {
                case CabinetDto entity:
                    return CabinetTemplate;
                case MeasurementDto entity:
                    return MeasurementTemplate;
                default:
                    return HardwareTemplate;
            }
        }
    }
}
