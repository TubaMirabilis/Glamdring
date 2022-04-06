using Glamdring.DTOs;
using Glamdring.Filters;
using Glamdring.Models;
using Glamdring.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Glamdring.Controllers
{
    // GET /chars
    [ApiController]
    [Route("chars")]
    public class ItemsController : ControllerBase
    {
        private readonly IRepository repository;
        private readonly ILogger<ItemsController> logger;
        public ItemsController(IRepository repository, ILogger<ItemsController> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }
        // GET /chars
        [HttpGet]
        public async Task<IEnumerable<CharDTO>> GetItemsAsync() => (await repository
                                                                    .GetItemsAsync())
                                                                    .Select(c => c.AsDTO());
        // GET /chars/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<CharDTO>> GetItemAsync(Guid id)
        {
            var c = await repository.GetItemAsync(id);
            if (c is null)
            {
                return NotFound();
            }
            return c.AsDTO();
        }
        // POST /chars
        [ApiKeyAuth]
        [HttpPost]
        public async Task<ActionResult<CharDTO>> CreateItemAsync(CreateItemDTO charDTO)
        {
            Character c = new() {
                Id = Guid.NewGuid(),
                Name = charDTO.Name,
                Race = charDTO.Race,
                ResistanceToTheRing = charDTO.ResistanceToTheRing,
                Age = charDTO.Age,
                Resilience = charDTO.Resilience,
                Ferocity = charDTO.Ferocity,
                Magic = charDTO.Magic,
                CreatedDate = DateTimeOffset.UtcNow
            };
            await repository.CreateItemAsync(c);
            logger.LogInformation($"{DateTime.UtcNow.ToString("hh:mm:ss")}: Created new item '{c.Name}'");
            return CreatedAtAction(nameof(GetItemAsync), new {id = c.Id}, c.AsDTO());
        }
        // PUT /chars/{id}
        [ApiKeyAuth]
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateItemAsync(Guid id, UpdateItemDTO charDTO)
        {
            var existingCharacter = await repository.GetItemAsync(id);
            if (existingCharacter is null)
            {
                return NotFound();
            }
            Character updatedCharacter = existingCharacter with {
                Name = charDTO.Name,
                Race = charDTO.Race,
                ResistanceToTheRing = charDTO.ResistanceToTheRing,
                Age = charDTO.Age,
                Resilience = charDTO.Resilience,
                Ferocity = charDTO.Ferocity,
                Magic = charDTO.Magic,
            };
            await repository.UpdateItemAsync(updatedCharacter);
            return NoContent();
        }
        // Delete /chars/{id}
        [ApiKeyAuth]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItemAsync(Guid id)
        {
            var existingCharacter = await repository.GetItemAsync(id);
            if (existingCharacter is null)
            {
                return NotFound();
            }
            await repository.DeleteItemAsync(id);
            return NoContent();
        }
    }
}