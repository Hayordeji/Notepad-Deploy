using API.DTO.NoteDto;
using API.Models;

namespace API.Mapper
{
    public static class NoteMapper
    {
        public static NoteGetDto ToNoteGetDto(this Note noteModel)
        {
           return new NoteGetDto
           {
               Id = noteModel.Id,
               Title = noteModel.Title,
               Description = noteModel.Description

           };
        }

        public static Note ToNoteCreateDto(this NoteCreateDto noteModel)
        {
           return new Note
           {
               Description = noteModel.Description,

               Title = noteModel.Title,

           };
        }

    }
}
