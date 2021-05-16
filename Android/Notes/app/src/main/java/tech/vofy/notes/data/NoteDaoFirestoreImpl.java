package tech.vofy.notes.data;

import com.google.firebase.auth.FirebaseAuth;
import com.google.firebase.firestore.FirebaseFirestore;

import java.util.List;

import tech.vofy.notes.objects.Note;

public class NoteDaoFirestoreImpl implements NotesDao {
    private final FirebaseFirestore db;
    private static NoteDaoFirestoreImpl instance = null;
    private final String userId;

    private NoteDaoFirestoreImpl() {
        this.db = FirebaseFirestore.getInstance();
        this.userId = FirebaseAuth.getInstance().getUid();
    }

    public static NoteDaoFirestoreImpl getInstance() {
        if(instance == null)
            instance = new NoteDaoFirestoreImpl();

        return instance;
    }

    @Override
    public void addNote(Note note) {
        db.collection("users").document(userId).collection("notes").add(note);
    }

    @Override
    public List<Note> getAllNotes() {
        return null;
    }

    @Override
    public void deleteNote(Note note) {

    }

    @Override
    public Note getNote() {
        return null;
    }
}
