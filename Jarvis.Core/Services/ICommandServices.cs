using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Jarvis.Domain.Entities;

namespace Jarvis.Core.Services
{
    public interface ICommandServices
    {
        Task<IEnumerable<Command>> GetAllCommands();
        Task<Command> GetCommandById(Guid commandId);
        Task<Command> AddCommand(Command command);
        Task UpdateCommand(Command command);
        Task DeleteCommand(Guid commandId);
        Task DeleteCommand(Command command);
    }
}
