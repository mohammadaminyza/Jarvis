using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jarvis.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Jarvis.Domain.Entities;
using Jarvis.Domain.IRepositories;
using Jarvis.Infra.Data.Context;

namespace Jarvis.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandController : ControllerBase
    {
        private ICommandServices _commandServices;

        public CommandController(ICommandServices commandServices)
        {
            _commandServices = commandServices;
        }

        // GET: api/Command
        [HttpGet]
        public async Task<IActionResult> GetCommand()
        {
            return Ok(await _commandServices.GetAllCommands());
        }

        // GET: api/Command/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Command>> GetCommand(Guid id)
        {
            var command = await _commandServices.GetCommandById(id);

            if (command == null)
            {
                return NotFound();
            }

            return command;
        }

        // PUT: api/Command/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommand(Guid id, Command command)
        {
            if (id != command.CommandId)
            {
                return BadRequest();
            }

            await _commandServices.UpdateCommand(command);

            return CreatedAtAction("GetCommand", new { id = command.CommandId }, command);
        }

        // DELETE: api/Command/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommand(Guid id)
        {
            var command = await _commandServices.GetCommandById(id);
            if (command == null)
            {
                return NotFound();
            }

            await _commandServices.DeleteCommand(command);

            return NoContent();
        }
    }
}
