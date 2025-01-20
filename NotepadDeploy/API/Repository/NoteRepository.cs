using API.Data;
using API.Helpers;
using API.Models;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace API.Repository
{
    public class NoteRepository : INoteRepository
    {
        private readonly ApplicationDbContext _context;
        public NoteRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Note> CreateNote(Note note)
        {
            await _context.AddAsync(note);
            await _context.SaveChangesAsync();
            return note;

        }

        public async Task<Note> DeleteNote(int id)
        {
            var noteToDelete = await _context.Notes.FindAsync(id);
            _context.Remove(noteToDelete);
            await _context.SaveChangesAsync();
            return noteToDelete;
        }

        public async Task<List<Note>> GetAllNotes(QueryObject query)
        {
            var notes = _context.Notes.AsQueryable();
            if (!string.IsNullOrWhiteSpace(query.keyword))
            {
                notes =  _context.Notes.Where(s => s.Title.Contains(query.keyword));
            }

            return await notes.ToListAsync();
        }

        public async Task<Note> GetNoteById(int id)
        {
            return await _context.Notes.FindAsync(id);
        }

        public async Task<bool> NoteExist(int id)
        {
            return true ? await _context.Notes.AnyAsync(x => x.Id == id) : false;
        }

        

        public async Task<Note> UpdateNote(Note note, int id)
        {
            var noteToUpdate = await _context.Notes.FindAsync(id);
            noteToUpdate.Title = note.Title;
            noteToUpdate.Description = note.Description;
            await _context.SaveChangesAsync();
            return noteToUpdate;

        }
    }
}
