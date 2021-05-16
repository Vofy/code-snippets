package tech.vofy.notes.ui;

import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.inputmethod.InputMethodManager;
import android.widget.AutoCompleteTextView;

import androidx.appcompat.app.AppCompatActivity;

import com.google.android.material.dialog.MaterialAlertDialogBuilder;
import com.google.android.material.textfield.TextInputEditText;

import java.util.Objects;

import tech.vofy.notes.R;
import tech.vofy.notes.data.NoteDaoFirestoreImpl;
import tech.vofy.notes.data.NotesDao;
import tech.vofy.notes.objects.Note;

public class EditNoteActivity extends AppCompatActivity {
    private Note note = new Note();
    private NotesDao notesDao;

    TextInputEditText input_title;
    TextInputEditText input_content;
    AutoCompleteTextView input_group;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_editnote);

        this.notesDao = NoteDaoFirestoreImpl.getInstance();

        this.input_title = findViewById(R.id.textView_name);
        this.input_content = findViewById(R.id.textView_content);
        this.input_group = findViewById(R.id.autoCompleteTextView_group);

        if(getIntent().hasExtra("itemId")) {
            final int itemId = getIntent().getExtras().getInt("itemId");

            new Thread(() -> {
                //this.noteWithGroup = notesDao.getNoteWithGroupById(itemId);

                runOnUiThread(() -> {
                    input_title.setText(note.title);
                    input_content.setText(note.content);
                });
            }).start();
        }

        this.input_group.setOnItemClickListener((parent, view, position, rowId) -> {
            input_group.clearFocus();

            ((InputMethodManager)getSystemService(INPUT_METHOD_SERVICE)).hideSoftInputFromWindow(input_group.getWindowToken(), 0);
        });
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        getMenuInflater().inflate(R.menu.editnote_menu, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        if(item.getItemId() == R.id.save) {

            String title = Objects.requireNonNull(input_title.getText()).toString();
            String content = Objects.requireNonNull(input_content.getText()).toString();
            String group = Objects.requireNonNull(input_group.getText()).toString();

            saveItem(title, content, group);

        } else if (item.getItemId() == android.R.id.home)
            finish();
        else if(item.getItemId() == R.id.delete) {
            new MaterialAlertDialogBuilder(this)
                    .setTitle(R.string.confirmation)
                    .setMessage(R.string.note_delete_confirmation)
                    .setPositiveButton(R.string.confirm, (dialogInterface, buttonClicked) -> {
                        finish();
                        deleteItem();
                    })
                    .setNegativeButton(R.string.cancel, null)
                    .show();
        }
        return true;
    }

    private void saveItem(String title, String content, String group) {

            if ((!title.equals("") || !content.equals("")) && !group.equals("")) {

                this.finish();

                new Thread(() -> {
                    if(note.noteId == 0)
                        notesDao.addNote(new Note(title, content));
                    else
                        note.updateNote(title, content);
                }).start();

            }

    }

    private void deleteItem() {
        if(note != null) {
            new Thread(() -> notesDao.deleteNote(note)).start();
        }

        finish();
    }
}