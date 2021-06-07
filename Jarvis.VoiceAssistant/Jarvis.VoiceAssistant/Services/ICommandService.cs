using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Jarvis.Domain.Entities;

namespace Jarvis.VoiceAssistant.Services
{
    public interface ICommandService
    {
        Task<IEnumerable<Command>> GetAllCommands();
        Task<Command> GetCommand(Guid commandId);
    }
}
