using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Jarvis.Domain.Entities;
using Newtonsoft.Json;

namespace Jarvis.VoiceAssistant.Services
{
    class CommandService : ICommandService
    {
        private HttpClient _httpClient;
        private Uri _apiUrl = new Uri("http://localhost:37214/api/command");
        public CommandService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<IEnumerable<Command>> GetAllCommands()
        {
            var result = await _httpClient.GetStringAsync(_apiUrl);

            var deserialize = JsonConvert.DeserializeObject<IEnumerable<Command>>(result);

            return deserialize;
        }

        public async Task<Command> GetCommand(Guid commandId)
        {
            var result = await _httpClient.GetStringAsync(_apiUrl + commandId.ToString());
            var deserialize = JsonConvert.DeserializeObject<Command>(result);

            return deserialize;
        }
    }
}
