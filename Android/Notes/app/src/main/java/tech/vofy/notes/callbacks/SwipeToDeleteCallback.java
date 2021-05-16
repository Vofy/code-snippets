package tech.vofy.notes.callbacks;

import android.content.Context;
import android.graphics.Canvas;
import android.graphics.drawable.Drawable;
import android.view.View;

import androidx.annotation.NonNull;
import androidx.appcompat.content.res.AppCompatResources;
import androidx.core.content.ContextCompat;
import androidx.recyclerview.widget.ItemTouchHelper;
import androidx.recyclerview.widget.RecyclerView;

import tech.vofy.notes.R;
import tech.vofy.notes.adapters.NotesRecyclerViewAdapter;

public class SwipeToDeleteCallback<RecyclerViewAdapter> extends ItemTouchHelper.SimpleCallback {
    private final RecyclerViewAdapter recyclerViewAdapter;
    private final Drawable icon;
    private final Drawable background;

    public SwipeToDeleteCallback(Context context, RecyclerViewAdapter notesRecyclerViewAdapter) {
        super(0,ItemTouchHelper.LEFT /*| ItemTouchHelper.RIGHT*/);
        this.recyclerViewAdapter = notesRecyclerViewAdapter;
        icon = ContextCompat.getDrawable(context, R.drawable.ic_delete_24dp);
        background = AppCompatResources.getDrawable(context, R.drawable.swipe_to_delete_background);
    }

    @Override
    public void onChildDraw(@NonNull Canvas c, @NonNull RecyclerView recyclerView, @NonNull RecyclerView.ViewHolder viewHolder, float dX, float dY, int actionState, boolean isCurrentlyActive) {
        super.onChildDraw(c, recyclerView, viewHolder, dX, dY, actionState, isCurrentlyActive);
        View itemView = viewHolder.itemView;
        int backgroundCornerOffset = 20;

        int iconMargin = 64;
        int iconTop = itemView.getTop() + (itemView.getHeight() - icon.getIntrinsicHeight()) / 2;
        int iconBottom = iconTop + icon.getIntrinsicHeight();

        if (dX > 0) { // Swiping to the right
            int iconLeft = itemView.getLeft() + iconMargin + icon.getIntrinsicWidth();
            int iconRight = itemView.getLeft() + iconMargin;
            icon.setBounds(iconLeft, iconTop, iconRight, iconBottom);

            background.setBounds(itemView.getLeft(), itemView.getTop(), itemView.getLeft() + ((int) dX) + backgroundCornerOffset, itemView.getBottom());
        } else if (dX < 0) { // Swiping to the left
            int iconLeft = itemView.getRight() - iconMargin - icon.getIntrinsicWidth();
            int iconRight = itemView.getRight() - iconMargin;
            icon.setBounds(iconLeft, iconTop, iconRight, iconBottom);

            background.setBounds(itemView.getRight() + ((int) dX) - backgroundCornerOffset, itemView.getTop(), itemView.getRight(), itemView.getBottom());
        } else { // view is unSwiped
            background.setBounds(0, 0, 0, 0);
        }

        background.draw(c);
        icon.draw(c);
    }

    @Override
    public boolean onMove(@NonNull RecyclerView recyclerView, @NonNull RecyclerView.ViewHolder viewHolder, @NonNull RecyclerView.ViewHolder target) {
        return false;
    }

    @Override
    public void onSwiped(@NonNull RecyclerView.ViewHolder viewHolder, int direction) {
        int position = viewHolder.getAdapterPosition();

        if (this.recyclerViewAdapter instanceof NotesRecyclerViewAdapter) {
            ((NotesRecyclerViewAdapter) this.recyclerViewAdapter).deleteItem(position);
        }
    }
}