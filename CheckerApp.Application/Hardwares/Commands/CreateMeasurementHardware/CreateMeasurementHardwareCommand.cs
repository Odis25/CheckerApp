using CheckerApp.Domain.Enums;
using MediatR;

namespace CheckerApp.Application.Hardwares.Commands.CreateMeasurementHardware
{
    public class CreateMeasurementHardwareCommand : IRequest<int>
    {
        public string SerialNumber { get; set; }
        public string Position { get; set; }
        public HardwareType HardwareType { get; set; }
        public int ContractId { get; set; }
        public string DeviceType { get; set; }
        public string DeviceModel { get; set; }
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
        public string EU { get; set; }
        public SignalType SignalType { get; set; }
    }
}
