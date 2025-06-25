using DittoBox.API.GroupManagement.Domain.Models.Commands;

namespace DittoBox.API.GroupManagement.Infrastructure.Handlers
{
    public class RegisterUserCommandHandler : IRegisterUserCommandHandler
    {
        public Task Handle(RegisterUserCommand command)
        {
            Console.WriteLine($"[RegisterUser] User {command.Email} registered to group {command.GroupId}");
            return Task.CompletedTask;
        }
    }
}