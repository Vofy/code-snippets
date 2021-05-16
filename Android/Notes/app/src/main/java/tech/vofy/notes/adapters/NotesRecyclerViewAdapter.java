package tech.vofy.notes.adapters;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.graphics.Color;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.google.android.material.snackbar.Snackbar;

import java.util.List;

import tech.vofy.notes.R;
import tech.vofy.notes.ui.EditNoteActivity;
import tech.vofy.notes.interfaces.ItemManager;
import tech.vofy.notes.objects.DeletedObject;
import tech.vofy.notes.objects.Note;

public class NotesRecyclerViewAdapter extends RecyclerView.Adapter<NotesRecyclerViewAdapter.ViewHolder> implements ItemManager {
    private final List<Note> notes;
    private final Context context;
    private DeletedObject<Note> deletedNote;

    public NotesRecyclerViewAdapter(Context context, List<Note> notes) {
        this.context = context;
        this.notes = notes;
    }

    @NonNull
    @Override
    public NotesRecyclerViewAdapter.ViewHolder onCreateViewHolder(ViewGroup viewGroup, int viewType) {
        View view = LayoutInflater.from(viewGroup.getContext()).inflate(R.layout.note_list_item, viewGroup, false);
        return new ViewHolder(view);
    }

    @Override
    public void onBindViewHolder(@NonNull NotesRecyclerViewAdapter.ViewHolder viewHolder, int position) {
        if (notes.size() > 0) {
            viewHolder.title.setText(notes.get(position).title);
            viewHolder.content.setText(notes.get(position).content);

            viewHolder.itemView.setOnClickListener(v -> {
                Intent editNote = new Intent(context, EditNoteActivity.class);
                editNote.putExtra("itemId", notes.get(position).noteId);
                context.startActivity(editNote);
            });
        }
    }
    private void undoDelete() {

    }

    @Override
    public void deleteItem(int position) {
        deletedNote = new DeletedObject<>(position, notes.get(position));

        //new Thread(() -> NotesDatabase.getInstance(context).notesDao().deleteNote(deletedNote.getObject())).start();

        notes.remove(position);
        notifyItemRemoved(position);

        View view = ((Activity) context).findViewById(R.id.snackbar);
        Snackbar snackbar = Snackbar.make(view, R.string.note_deleted, Snackbar.LENGTH_LONG);
        snackbar.setActionTextColor(Color.WHITE);
        snackbar.setAction(R.string.undo, v -> undoDelete());
        snackbar.show();

        //new Thread(() -> NotesDatabase.getInstance(context).notesDao().insertNote(deletedNote.getObject())).start();

        notes.add(deletedNote.getPosition(), deletedNote.getObject());
        notifyItemInserted(deletedNote.getPosition());
    }

    public static class ViewHolder extends RecyclerView.ViewHolder {
        private final TextView title;
        private final TextView content;

        public ViewHolder(View view) {
            super(view);

            this.title = view.findViewById(R.id.noteTitle);
            this.content = view.findViewById(R.id.noteContent);
        }
    }

    @Override
    public int getItemCount() {
        return notes == null ? 0 : notes.size();
    }
}