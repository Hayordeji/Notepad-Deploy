using API.Helpers;
using API.Models;

namespace API.Services
{
    public interface INoteService
    {
        Task<Note> CreateNote(Note note);
        Task<Note> UpdateNote(Note note, int id);
        Task<Note> DeleteNote(int id);
        Task<Note> GetNoteById(int id);
        Task<List<Note>> GetAllNotes(QueryObject query);
        
        
    }
}
