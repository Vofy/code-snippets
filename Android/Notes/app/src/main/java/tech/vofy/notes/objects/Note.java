package tech.vofy.notes.objects;

import androidx.room.ColumnInfo;
import androidx.room.Entity;
import androidx.room.Ignore;
import androidx.room.PrimaryKey;

@Entity
public class Note {

    @PrimaryKey(autoGenerate = true)
    public int noteId;
    public String title;
    public String content;
    @ColumnInfo(defaultValue = "CURRENT_TIMESTAMP")
    public String lastModifiedTime;

    public Note() {

    }

    @Ignore
    public Note(String title, String content) {
        this.title = title;
        this.content = content;
    }

    @Ignore
    public void updateNote(String title, String content) {
        this.title = title;
        this.content = content;
    }
}