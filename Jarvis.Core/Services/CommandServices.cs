using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Jarvis.Domain.Entities;
using Jarvis.Domain.IRepositories;

namespace Jarvis.Core.Services
{
    public class CommandServices : ICommandServices
    {
        private IGenericRepositories<Command> _commandRepositories;
        public CommandServices(IGenericRepositories<Command> commandRepositories)
        {
            _commandRepositories = commandRepositories;
        }

        public async Task<IEnumerable<Command>> GetAllCommands()
        {
            return await _commandRepositories.GetAll();
        }

        public async Task<Command> GetCommandById(Guid commandId)
        {
            return await _commandRepositories.GetById(commandId);
        }

        public async Task<Command> AddCommand(Command command)
        {
            return await _commandRepositories.Add(command);
        }

        public async Task UpdateCommand(Command command)
        {
            await _commandRepositories.Update(command);
        }

        public async Task DeleteCommand(Guid commandId)
        {
            var command = await GetCommandById(commandId);

            await DeleteCommand(command);
        }

        public async Task DeleteCommand(Command command)
        {
            await _commandRepositories.Delete(command);
        }
    }
}
