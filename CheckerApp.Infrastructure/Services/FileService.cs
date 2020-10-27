using CheckerApp.Application.Checks.Queries.GetCheckResultFile;
using CheckerApp.Application.Common.Interfaces;
using CheckerApp.Application.Hardwares.Queries;
using CheckerApp.Domain.Enums;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CheckerApp.Infrastructure.Services
{
    public class FileService : IFileService
    {
        public async Task<byte[]> BuildExcelFileAsync(CheckResultDto checkResult)
        {
            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (ExcelPackage excelPackage = new ExcelPackage())
                {
                    //Общие настройки книги
                    excelPackage.Workbook.Properties.Author = "Incomsystem";
                    excelPackage.Workbook.Properties.Title = "Акт заводских испытаний";
                    excelPackage.Workbook.Properties.Subject = "Какая-то тема";
                    excelPackage.Workbook.Properties.Created = DateTime.Now;

                    // Создаем лист документа
                    ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Акт");

                    worksheet.Cells.Style.Font.Size = 14;
                    worksheet.Cells.Style.Font.Name = "Times New Roman";
                    
                    // Заголовок документа
                    var contract = checkResult.Contract;

                    worksheet.Cells["A1:F4"].Merge = true;
                    worksheet.Cells["A1"].Value = $"Протокол \r\n испытаний оборудования СОИ \"{contract.Name}\",  дог.{contract.ContractNumber}, вн.проект {contract.DomesticNumber}";
                    worksheet.Cells["A1"].Style.Font.Bold = true;
                    worksheet.Cells["A1"].Style.Font.Size = 16;
                    worksheet.Cells["A1"].Style.Font.Name = "Times New Roman";
                    worksheet.Cells["A1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    // Дата и место
                    worksheet.Cells["A6:B6"].Merge = true;
                    worksheet.Cells["A6:F6"].Style.Font.UnderLine = true;
                    worksheet.Cells["A6:F6"].Style.Font.Bold = true;
                    worksheet.Cells["A6"].Value = "г.Казань, ЗАО НИЦ \"ИНКОМСИСТЕМ\"";
                    worksheet.Cells["F6"].Value = $"Дата: {DateTime.Now.ToShortDateString()}";

                    // Заголовок таблицы. 1 строка
                    worksheet.Cells["A8"].Value = "п/п";
                    worksheet.Cells["B8"].Value = "Вид контроля (испытаний)";
                    worksheet.Cells["C8"].Value = "Метод проверки";
                    worksheet.Cells["D8"].Value = "Результат проверки";
                    worksheet.Cells["E8"].Value = "Дата проведения";
                    worksheet.Cells["F8"].Value = "Примечание";

                    // Заголовок таблицы. 2 строка
                    worksheet.Cells["A9"].Value = "1";
                    worksheet.Cells["B9"].Value = "2";
                    worksheet.Cells["C9"].Value = "3";
                    worksheet.Cells["D9"].Value = "4";
                    worksheet.Cells["E9"].Value = "5";
                    worksheet.Cells["F9"].Value = "6";

                    worksheet.Cells["A8:F9"].Style.Font.Bold = true;
                    worksheet.Cells["A8:F9"].Style.Font.Name = "Times New Roman";
                    worksheet.Cells["A8:F9"].Style.Font.Size = 14;
                    worksheet.Cells["A8:F9"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    worksheet.Cells["A8:F9"].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    
                    var hardwares = checkResult.HardwareChecks.ToArray();
                    var row = 10;

                    for (int i = 0; i < hardwares.Length; i++)
                    {
                        var parameters = hardwares[i].CheckParameters.ToArray();
                        
                        worksheet.Cells[$"A{row}"].Value = $"{i+1}";
                        worksheet.Cells[$"B{row}:F{row}"].Merge = true;
                        worksheet.Cells[$"A{row}:B{row}"].Style.Font.Bold = true;
                        worksheet.Cells[$"B{row}"].Value = GetHardwareHeader(hardwares[i]);

                        for (int j = 0; j < parameters.Length; j++)
                        {
                            var subRow = row + 1 + j;
                            worksheet.Cells[$"A{subRow}"].Value = $"{i+1}.{j+1}";
                            worksheet.Cells[$"B{subRow}"].Value = parameters[j].Description;
                            worksheet.Cells[$"C{subRow}"].Value = parameters[j].Method;
                            worksheet.Cells[$"D{subRow}"].Value = parameters[j].Result ? "Соответствует" : "Не соответствует";
                            worksheet.Cells[$"E{subRow}"].Value = parameters[j].Date.ToShortDateString();
                            worksheet.Cells[$"F{subRow}"].Value = parameters[j].Comment;
                        }
                        row += parameters.Length + 1;
                    }

                    worksheet.Cells[$"A8:F{row}"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[$"A8:F{row}"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[$"A8:F{row}"].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[$"A8:F{row}"].Style.Border.Right.Style = ExcelBorderStyle.Thin;

                    worksheet.Cells[$"A8:A{row}"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    worksheet.Cells[$"A8:A{row}"].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    worksheet.Cells[$"C8:F{row}"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    worksheet.Cells[$"C8:F{row}"].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    worksheet.Cells[$"F10:F{row}"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

                    worksheet.Cells[$"A6:F{row}"].Style.Font.Name = "Times New Roman";                    
                    worksheet.Cells[$"A6:F{row}"].Style.Font.Size = 14;                    

                    worksheet.Cells.AutoFitColumns();

                    worksheet.PrinterSettings.PaperSize = ePaperSize.A4;
                    worksheet.PrinterSettings.Orientation = eOrientation.Portrait;
                    worksheet.PrinterSettings.FitToPage = true;

                    var bytes = await excelPackage.GetAsByteArrayAsync();
                    return bytes;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        private string GetHardwareHeader(HardwareCheckDto check)
        {
            var device = check.Hardware;
            string header = "";
            string mbSettings = "";
            switch (device.HardwareType)
            {
                case HardwareType.Cabinet:
                    var cabinet = (CabinetDto)device;
                    header = cabinet.Position +
                        $"( зав.№{cabinet.SerialNumber}, " +
                        $"завершение монтажа {cabinet.Constructed.ToShortDateString()}, " +
                        $"ответственный - {cabinet.ConstructedBy})";
                    break;

                case HardwareType.FlowComputer:
                    var flowcomputer = (FlowComputerDto)device;
                    header = $"{flowcomputer.HardwareType.GetDisplayName()} {flowcomputer.Position} " +
                        $"({flowcomputer.DeviceModel} " +
                        $"- №{flowcomputer.SerialNumber} " +
                        $"- IP={flowcomputer.IP} " +
                        $"- ASSEMBLY_VERSION={flowcomputer.AssemblyVersion} " +
                        $"- PRG_CRC32={flowcomputer.CRC32} " +
                        $"- LASTDATECFG={flowcomputer.LastConfigDate}):";
                    break;

                case HardwareType.Flowmeter:
                    var flowmeter = (FlowmeterDto)device;
                    var flowmeterMb = flowmeter.ModbusSettings;
                    mbSettings = flowmeter.SignalType == SignalType.RS485 ?
                        $"({flowmeterMb.Address}/{flowmeterMb.BoudRate}/Modbus RTU/{Enum.GetName(typeof(Parity), flowmeterMb.Parity)[0]}/{flowmeterMb.DataBits}/{flowmeterMb.StopBit})"
                        : "";

                    header = $"{flowmeter.HardwareType.GetDisplayName()} {flowmeter.Position}" +
                        $"(тип {flowmeter.DeviceType} " +
                        $"- серия {flowmeter.DeviceModel} " +
                        $"- зав.№{flowmeter.SerialNumber} " +
                        $"- диап. {flowmeter.MinValue}...{flowmeter.MaxValue} {flowmeter.EU} " +
                        $"- {flowmeter.Kfactor} имп/{flowmeter.EU} " +
                        $"- {flowmeter.SignalType.GetDisplayName()} " +
                        $"{mbSettings}):";
                    break;

                case HardwareType.Network:
                    var network = (NetworkHardwareDto)device;
                    header = $"{network.HardwareType.GetDisplayName()}: {network.Position}, " +
                        $"тип {network.DeviceType}, " +
                        $"модель {network.DeviceModel}, " +
                        $"зав.№{network.SerialNumber}:";
                    break;

                case HardwareType.PLC:
                    var plc = (PlcDto)device;
                    header = $"{plc.HardwareType.GetDisplayName()} {plc.Position} " +
                        $"({plc.DeviceModel} " +
                        $"- №{plc.SerialNumber} " +
                        $"- IP={plc.IP} " +
                        $"- ASSEMBLY={plc.AssemblyVersion}):";
                    break;

                case HardwareType.Pressure:
                case HardwareType.Temperature:
                    var measurement = (MeasurementDto)device;
                    header = $"{measurement.HardwareType.GetDisplayName()} {measurement.Position}" +
                        $"(тип {measurement.DeviceType} " +
                        $"- модель {measurement.DeviceModel} " +
                        $"- зав.№{measurement.SerialNumber} " +
                        $"- диап. {measurement.MinValue}...{measurement.MaxValue} {measurement.EU} " +
                        $"- {measurement.SignalType.GetDisplayName()} ):";
                    break;

                case HardwareType.Valve:
                    var valve = (ValveDto)device;
                    var valveMb = valve.ModbusSettings;
                    mbSettings = valve.SignalType == SignalType.RS485 ?
                        $"({valveMb.Address}/{valveMb.BoudRate}/Modbus RTU/{Enum.GetName(typeof(Parity), valveMb.Parity)[0]}/{valveMb.DataBits}/{valveMb.StopBit})"
                        : "";

                    header = $"{valve.HardwareType.GetDisplayName()} {valve.Position} " +
                        $"(тип {valve.DeviceType}, " +
                        $"модель {valve.DeviceModel}, " +
                        $"зав.№{valve.SerialNumber}, " +
                        $"{valve.SignalType.GetDisplayName()} " +
                        $"{mbSettings}):";
                    break;
            };

            return header;
        }
    }
}
