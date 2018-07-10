using MyEvernote.DataAccessLayer.EFRepositories;
using MyEvernote.DTO.Notes;
using MyEvernote.Entities;
using System.Collections.Generic;
using System.Linq;

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
        public List<NoteListDto> GetNotesOrderByDescByModifiedOn()
        {
            return repo.ListQueryable().OrderByDescending(p => p.ModifiedOn).Select(p => new NoteListDto
            {
                NoteId = p.Id,
                LikeCount = p.LikeCount == null ? 0 : p.LikeCount.Value,
                ModifiedOn = p.ModifiedOn,
                Owner = p.Owner.Username,
                Text = p.Text,
                Title = p.Title
            }).ToList();
        }
        public List<NoteListDto> GetNotesOrderByDescByLikeCount()
        {
            return repo.ListQueryable().OrderByDescending(p => p.LikeCount).Select(p => new NoteListDto
            {
                NoteId = p.Id,
                LikeCount = p.LikeCount == null ? 0 : p.LikeCount.Value,
                ModifiedOn = p.ModifiedOn,
                Owner = p.Owner.Username,
                Text = p.Text,
                Title = p.Title
            }).ToList();
        }
        public List<NoteListDto> GetNotesByCategoryId(int categoryId)
        {
            var data = repo.ListQueryableWithWhere(p => p.IsDeleted == false && p.CategoryId == categoryId).Select(p => new NoteListDto
            {
                NoteId = p.Id,
                LikeCount = p.LikeCount == null ? 0 : p.LikeCount.Value,
                ModifiedOn = p.ModifiedOn,
                Owner=p.Owner.Username,
                Text=p.Text,
                Title=p.Title
            }).ToList();

            return data;
        }
    }
}
