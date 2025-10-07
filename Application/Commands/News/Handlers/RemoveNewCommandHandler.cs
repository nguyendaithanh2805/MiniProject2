using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction.Commands;
using Application.Exceptions;
using Application.Interfaces;

namespace Application.Commands.News.Handlers
{
    public class RemoveNewCommandHandler : ICommandHandler<RemoveNewCommand>
    {
        private readonly IRepository<Domain.Entities.News> _repository;

        public RemoveNewCommandHandler(IRepository<Domain.Entities.News> repository)
        {
            _repository = repository;
        }

        public async Task HandleAsync(RemoveNewCommand command)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity is null)
                throw new NotFoundException($"New not found with Id {command.Id}");

            await _repository.DeleteAsync(entity);
        }
    }
}
