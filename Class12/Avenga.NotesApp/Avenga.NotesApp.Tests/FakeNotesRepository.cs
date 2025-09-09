using Avenga.NotesApp.DataAccess.Implementations;
using Avenga.NotesApp.DataAccess.Interfaces;
using Avenga.NotesApp.Domain.Models;

namespace Avenga.NotesApp.Tests
{
    public class FakeNotesRepository : INoteRepository
    {
        private List<Note> _notes; // Simulated in-memory data store
        public FakeNotesRepository()
        {
            _notes = new List<Note>()
            {
                new Note 
                { Id = 1,
                    Text = "Do something",
                    Priority = Domain.Enums.Priority.High, 
                    Tag = Domain.Enums.Tag.Health,
                    UserId = 1 },
                new Note 
                { Id = 2,
                    Text = "Second Note",
                    Priority = Domain.Enums.Priority.Medium, 
                    Tag = Domain.Enums.Tag.SocialLife,
                    UserId = 1 },

            };
        }
    }
}
