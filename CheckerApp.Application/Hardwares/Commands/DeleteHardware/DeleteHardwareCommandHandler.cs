﻿using CheckerApp.Application.Common.Exceptions;
using CheckerApp.Application.Common.Interfaces;
using CheckerApp.Domain.Entities.HardwareEntities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CheckerApp.Application.Hardwares.Commands.DeleteHardware
{
    public class DeleteHardwareCommandHandler : IRequestHandler<DeleteHardwareCommand>
    {
        private readonly IAppDbContext _context;

        public DeleteHardwareCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteHardwareCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Hardwares.FindAsync(request.Id);
            
            if (entity == null)
            {
                throw new NotFoundException(nameof(Hardware), request.Id);
            }

            _context.Hardwares.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}