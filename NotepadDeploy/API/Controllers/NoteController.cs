﻿using API.DTO.NoteDto;
using API.Helpers;
using API.Mapper;
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
            var notesMapped = notes.Select(n => n.ToNoteGetDto());
            return Ok(notesMapped);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateNote([FromBody] NoteCreateDto noteModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var noteCreateMap = noteModel.ToNoteCreateDto();
            var noteTocreate = await _noteService.CreateNote(noteCreateMap);

            return Created("Successfully Created Note",noteTocreate);
        }
    }
}
