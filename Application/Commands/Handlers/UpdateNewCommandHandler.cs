using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Exceptions;
using Abstractions.Interfaces;
using MediatR;
using Domain.Entities;

namespace Application.Commands.Handlers
{
    public class UpdateNewCommandHandler : IRequestHandler<UpdateNewCommand>
    {
        private readonly IRepository<News> _repository;
        private readonly IRepository<Menu> _menuRepository;

        public UpdateNewCommandHandler(IRepository<News> repository, IRepository<Menu> menuRepository)
        {
            _repository = repository;
            _menuRepository = menuRepository;
        }

        public async Task Handle(UpdateNewCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id);
            if (entity is null)
                throw new NotFoundException($"New not found with Id {request.Id}");

            var menu = await _menuRepository.GetByIdAsync(request.MenuId);
            if (menu is null)
                throw new NotFoundException($"MenuId not found with Id {request.MenuId}");

            entity.MenuId = request.MenuId;
            entity.Title = request.Title;
            entity.Content = request.Content;
            await _repository.UpdateAsync(entity, cancellationToken);
        }
    }
}
