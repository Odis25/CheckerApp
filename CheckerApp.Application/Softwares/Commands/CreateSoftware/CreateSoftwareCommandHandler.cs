using CheckerApp.Application.Common.Interfaces;
using CheckerApp.Domain.Entities.SoftwareEntities;
using CheckerApp.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CheckerApp.Application.Softwares.Commands.CreateSoftware
{
    public class CreateSoftwareCommandHandler : IRequestHandler<CreateSoftwareCommand, int>
    {
        private readonly IAppDbContext _context;

        public CreateSoftwareCommandHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateSoftwareCommand request, CancellationToken cancellationToken)
        {
            var contract = await _context.Contracts.FirstOrDefaultAsync(c => c.Id == request.ContractId);

            if (contract == null)
            {
                throw new NullReferenceException("Договор с таким Id не найден.");
            }

            Software entity;

            switch (request.SoftwareType)
            {
                case SoftwareType.SCADA:
                    entity = new SCADA();
                    break;
                case SoftwareType.Other:
                default:
                    entity = new Software();
                    break;
            }

            entity.Name = request.Name;
            entity.Version = request.Version;

            contract.SoftwareList.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
