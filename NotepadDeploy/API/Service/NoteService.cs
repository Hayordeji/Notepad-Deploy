using API.Helpers;
using API.Mapper;
using API.Models;
using API.Repository;

namespace API.Services
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _noteRepository;
        public NoteService(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }
        public async Task<Note> CreateNote(Note note)
        {
            var newNote = new Note();
            newNote.Title = note.Title;
            newNote.Description = note.Description;
            await _noteRepository.CreateNote(newNote);
            return newNote;
        }

        public async Task<Note> DeleteNote(int id)
        {
            if (!await _noteRepository.NoteExist(id))
            {
                return null;
            }
            var noteToDelete = await _noteRepository.DeleteNote(id);
            return noteToDelete;
        }

        public async Task<List<Note>> GetAllNotes(QueryObject query)
        {
            var notes = await _noteRepository.GetAllNotes(query);
            
            return notes;
        }

        public async Task<Note> GetNoteById(int id)
        {
            if (!await _noteRepository.NoteExist(id))
            {
                return null;
            }
            var note = await _noteRepository.GetNoteById(id);
            return note;
        }

        public Task<Note> UpdateNote(Note note, int id)
        {
            throw new NotImplementedException();
        }
    }
}
