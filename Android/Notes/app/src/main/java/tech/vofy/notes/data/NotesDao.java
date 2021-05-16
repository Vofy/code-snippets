package tech.vofy.notes.data;

import java.util.List;

import tech.vofy.notes.objects.Note;

public interface NotesDao {
    List<Note> getAllNotes();
    void deleteNote(Note note);
    Note getNote();
    void addNote(Note note);
}
