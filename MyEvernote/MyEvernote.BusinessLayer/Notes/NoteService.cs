using MyEvernote.DataAccessLayer.EFRepositories;
using MyEvernote.Entities;
using System.Collections.Generic;

namespace MyEvernote.BusinessLayer.Notes
{
    public class NoteService
    {
        private Repository<Note> repo;
        public NoteService()
        {
            repo = new Repository<Note>();
        }
        public List<Note> GetNotes()
        {
            return repo.List();
        }
    }
}
