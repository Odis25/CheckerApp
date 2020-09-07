using AutoMapper;
using CheckerApp.Application.Common.Exceptions;
using CheckerApp.Application.Common.Interfaces;
using CheckerApp.Domain.Entities.HardwareEntities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CheckerApp.Application.Hardwares.Commands.CreateMeasurementHardware
{
    public class CreateMeasurementHardwareCommandHandler : IRequestHandler<CreateMeasurementHardwareCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateMeasurementHardwareCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateMeasurementHardwareCommand request, CancellationToken cancellationToken)
        {
            var contract = await _context.Contracts.FirstOrDefaultAsync(c => c.Id == request.ContractId);
            
            if (contract == null)
            {
                throw new NullReferenceException("Договор с таким Id не найден.");
            }

            var entity = new MeasurementHardware
            {
                Position = request.Position,
                DeviceModel = request.DeviceModel,
                DeviceType = request.DeviceType,
                SerialNumber = request.SerialNumber,
                HardwareType = request.HardwareType,
                EU = request.EU,
                MinValue = request.MinValue,
                MaxValue = request.MaxValue,
                SignalType = request.SignalType
            };

            contract.HardwareList.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
