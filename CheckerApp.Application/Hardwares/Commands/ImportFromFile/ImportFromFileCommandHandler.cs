using CheckerApp.Application.Common.Interfaces;
using CheckerApp.Domain.Entities.HardwareEntities;
using CheckerApp.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CheckerApp.Application.Hardwares.Commands.ImportFromFile
{
    public class ImportFromFileCommandHandler : IRequestHandler<ImportFromFileCommand>
    {
        private readonly IAppDbContext _context;

        public ImportFromFileCommandHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(ImportFromFileCommand request, CancellationToken cancellationToken)
        {
            XDocument document;

            using (var stream = new MemoryStream(request.FileContent))
            {
                document = XDocument.Load(stream);
            }

            // Фильтрующий LINQ-запрос. Получаем коллекцию xml-элементов Label, у которых указана позиция по проекту.
            var labels = document.Descendants("Label").Where(l => l.Element("Property").Element("PropertyValue").Value.Any());

            var result = new List<Hardware>();

            // Проходим в цикле по элементам и создаем из них коллекцию объектов
            foreach (var label in labels)
            {
                // Преобразуем элементы Property в словарь, где ключом является значение PropertyName, а значением соответственно значение PropertyValue
                var properties = label.Elements("Property")
                    .ToDictionary(
                    e => e.Element("PropertyName").Value,
                    e => e.Element("PropertyValue").Value);

                var hardware = GetSensorType(properties["Обозначение"]);

                switch (hardware)
                {
                    case Measurement sensor:
                        sensor.ContractId = request.ContractId;
                        sensor.SerialNumber = "----";
                        sensor.DeviceModel = "----";
                        sensor.DeviceType = "----";
                        sensor.Position = properties["Обозначение"];
                        sensor.MinValue = GetMinRange(properties["Диапазон измерений"]);
                        sensor.MaxValue = GetMaxRange(properties["Диапазон измерений"]);
                        sensor.EU = properties["Единица измерения"];
                        sensor.SignalType = GetSignalType(properties["Тип_Сигнала"]);
                        break;

                    default:
                        break;
                }

                // Создаем экземпляр нашей модели, и заполняем ее данными
                //var sens = new Sensor
                //{
                //    ProjectCode = properties["Обозначение"],
                //    MinValue = _parsingService.GetMinRange(properties["Диапазон измерений"]),
                //    MaxValue = _parsingService.GetMaxRange(properties["Диапазон измерений"]),
                //    EU = properties["Единица измерения"],
                //    Channel = Convert.ToUInt32(properties["Обозначения выводов устройства (все)"][2].ToString()),
                //    Module = Convert.ToUInt32(properties["ОУ (идентифицирующее, без структуры проекта)"][3].ToString()),
                //    SignalType = properties["Тип_Сигнала"],
                //    DeviceType = _parsingService.GetSensorType(properties["Обозначение"]),
                //    DevicePosition = _parsingService.GetSensorPosition(properties["Обозначение"])
                //};

                // Добавляем созданную модель в список
                if (hardware != null)
                    result.Add(hardware);
            }

            try
            {
                _context.Hardwares.AddRange(result);
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return Unit.Value;
        }

        private SignalType GetSignalType(string v)
        {
            if (v.Contains("с.к.", StringComparison.OrdinalIgnoreCase))
                return SignalType.Discrete;
            else if (v.Contains("4-20", StringComparison.OrdinalIgnoreCase))
                return SignalType.Current;
            else if (v.Contains("имп", StringComparison.OrdinalIgnoreCase))
                return SignalType.Frequency;
            else
                throw new FormatException("Неизвестный тип сигнала");
        }

        private Hardware GetSensorType(string projectCode)
        {
            if (projectCode.Contains("FT", StringComparison.OrdinalIgnoreCase)
                || projectCode.Contains("FIT", StringComparison.OrdinalIgnoreCase))
            {
                return new Flowmeter();
            }
            else if (projectCode.Contains("PT", StringComparison.OrdinalIgnoreCase)
                || projectCode.Contains("PIT", StringComparison.OrdinalIgnoreCase))
            {
                return new Pressure();
            }
            else if (projectCode.Contains("TT", StringComparison.OrdinalIgnoreCase)
                || projectCode.Contains("TIT", StringComparison.OrdinalIgnoreCase))
            {
                return new Temperature();
            }
            else if (projectCode.Contains("PDT", StringComparison.OrdinalIgnoreCase))
            {
                return new DiffPressure();
            }
            else
            {
                return null;                
            }
        }
        private double GetMaxRange(string value)
        {
            double result = 0;

            if (value.Length > 0)
                double.TryParse(value.Split('-')[1], out result);

            return result;
        }

        private double GetMinRange(string value)
        {
            double.TryParse(value.Split('-')[0], out var result);

            return result;
        }
    }
}
