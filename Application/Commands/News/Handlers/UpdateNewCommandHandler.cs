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
    public class UpdateNewCommandHandler : ICommandHandler<UpdateNewCommand>
    {
        private readonly IRepository<Domain.Entities.News> _repository;

        public UpdateNewCommandHandler(IRepository<Domain.Entities.News> repository)
        {
            _repository = repository;
        }

        public async Task HandleAsync(UpdateNewCommand command)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity is null)
                throw new NotFoundException($"New not found with Id {command.Id}");

            entity.MenuId = command.MenuId;
            entity.Title = command.Title;
            entity.Content = command.Content;
            await _repository.UpdateAsync(entity);
        }
    }
}
