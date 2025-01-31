﻿using Copilot.Application.TodoItems.Repositories;
using Copilot.Domain.Entities;

namespace Copilot.Application.TodoItems.Commands.CreateTodoItem;

public record CreateTodoItemCommand : IRequest<int>
{
    public string? Title { get; init; }
}

public class CreateTodoItemCommandHandler(ITodoItemRepository todoItemRepository) : IRequestHandler<CreateTodoItemCommand, int>
{
    private readonly ITodoItemRepository _todoItemRepository = todoItemRepository;

    public async Task<int> Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
    {
        var entity = new TodoItem
        {
            Title = request.Title,
            Done = false
        };

        TodoItem createdEntity = await _todoItemRepository.CreateAsync(entity);

        return createdEntity.Id;
    }
}
