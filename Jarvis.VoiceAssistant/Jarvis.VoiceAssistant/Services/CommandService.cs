using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Jarvis.Domain.Entities;
using Jarvis.VoiceAssistant.Data;
using Jarvis.VoiceAssistant.Helpers;
using Newtonsoft.Json;
using Xamarin.Essentials;

namespace Jarvis.VoiceAssistant.Services
{
    class CommandService : ICommandService
    {
        private HttpClient _httpClient;
        private SqliteContext _sqlite;
        private Uri _apiUrl;

        public CommandService()
        {
            _httpClient = new HttpClient();
            _sqlite = new SqliteContext(SqliteHelper.GetSqlitePath());
            _apiUrl = new Uri("http://localhost:37214/api/command/");
        }

        public IEnumerable<Command> GetAllCommands()
        {
            List<Command> obj = new List<Command>();
            var current = Connectivity.NetworkAccess;

            if (current == NetworkAccess.Internet)
            {
                obj.AddRange(new List<Command>{
                    new Command()
                    {
                        CommandId = Guid.Parse("c8bd76e6-4836-4c6e-892a-cff4d52cbbcc"),
                        CommandSentence = "hello Jarvis",
                        ResultSentence = "Hello Boss"
                    },new Command()
                    {
                        CommandId = Guid.Parse("c8bd76e6-4836-4c6e-892a-cff4d52cbbcd"),
                        CommandSentence = "how are you?",
                        ResultSentence = "Oh, I'm Fine Thanks!"
                    }
                });

                _sqlite.Commands.UpdateRange(obj);
            }

            else
            {
                var localData = _sqlite.Commands.ToList();

                obj.AddRange(localData);
            }

            return obj;
        }

        public async Task<Command> GetCommand(Guid commandId)
        {
            var result = await _httpClient.GetStringAsync(_apiUrl + commandId.ToString());
            var deserialize = JsonConvert.DeserializeObject<Command>(result);

            return deserialize;
        }
    }
}
