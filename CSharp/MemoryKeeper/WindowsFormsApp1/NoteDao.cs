using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryKeeper
{
    interface NoteDao
    {
        List<Note> GetAllNotes();
        Note GetNote(int id);
        void AddNote(Note note);
        void UpdateNote(Note note);
        void DeleteNote(Note note);
    }
}
