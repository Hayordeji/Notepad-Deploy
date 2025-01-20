using API.Helpers;
using API.Models;

namespace API.Repository
{
    public interface INoteRepository
    {
        Task<Note> CreateNote(Note note);
        Task<Note> UpdateNote(Note note, int id);
        Task<Note> DeleteNote(int id);
        Task<Note> GetNoteById(int id);
        Task<List<Note>> GetAllNotes(QueryObject query);
        Task<bool> NoteExist(int id);
    }
}
