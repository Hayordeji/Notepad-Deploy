using API.Helpers;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly INoteService _noteService;
        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet("notes")]
        public async Task<IActionResult> GetNotes([FromQuery] QueryObject query)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var notes = await _noteService.GetAllNotes(query);
            return Ok(notes);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateNote([FromBody] Note noteModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var noteTocreate = await _noteService.CreateNote(noteModel);
            return Created("Successfully Created Note",noteTocreate);
        }
    }
}
