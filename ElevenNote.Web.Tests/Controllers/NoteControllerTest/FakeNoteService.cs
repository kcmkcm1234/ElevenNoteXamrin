using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElevenNote.Models;
using ElevenNote.Services;

namespace ElevenNote.Web.Tests.Controllers.NoteControllerTest
{
    public class FakeNoteService : INoteService
    {

        public int CreateNoteCallCount { get; private set; }
        public bool CreateNoteReturnValue { private get; set; } = true; //default is 'false' so change default for property to 'true'

        public bool CreateNote(NoteCreate model)
        {
            CreateNoteCallCount++;

            return CreateNoteReturnValue;
        }

        public IEnumerable<NoteListItem> GetNotes()
        {
            throw new NotImplementedException();
        }

        public NoteDetail GetNoteById(int noteId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateNote(NoteEdit model)
        {
            throw new NotImplementedException();
        }

        public bool DeletNote(int noteId)
        {
            throw new NotImplementedException();
        }

        public bool DeleteNote(int noteId)
        {
            throw new NotImplementedException();
        }
    }
}
