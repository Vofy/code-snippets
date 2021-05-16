package tech.vofy.notes.ui;

import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;
import android.widget.TextView;

import androidx.appcompat.app.ActionBarDrawerToggle;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.view.GravityCompat;
import androidx.drawerlayout.widget.DrawerLayout;
import androidx.recyclerview.widget.DefaultItemAnimator;
import androidx.recyclerview.widget.ItemTouchHelper;
import androidx.recyclerview.widget.RecyclerView;
import androidx.swiperefreshlayout.widget.SwipeRefreshLayout;

import com.arlib.floatingsearchview.FloatingSearchView;
import com.getbase.floatingactionbutton.FloatingActionsMenu;
import com.google.android.material.navigation.NavigationView;
import com.google.firebase.auth.FirebaseAuth;
import com.google.firebase.firestore.FirebaseFirestore;
import com.google.firebase.firestore.Query;

import java.util.List;

import tech.vofy.notes.R;
import tech.vofy.notes.adapters.NotesRecyclerViewAdapter;
import tech.vofy.notes.callbacks.SwipeToDeleteCallback;
import tech.vofy.notes.data.NoteDaoFirestoreImpl;
import tech.vofy.notes.data.NotesDao;
import tech.vofy.notes.objects.Note;
import tech.vofy.notes.objects.SearchQueryItem;
import tech.vofy.notes.ui.login.LoginActivity;

public class MainActivity extends AppCompatActivity {

    private List<SearchQueryItem> lastSearchQueryItems;
    public DrawerLayout drawerLayout;
    public ActionBarDrawerToggle actionBarDrawerToggle;
    private FirebaseAuth mAuth;
    private List<Note> notes;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        mAuth = FirebaseAuth.getInstance();

        FloatingSearchView floatingSearchView = findViewById(R.id.floating_search_view);

        drawerLayout = findViewById(R.id.main_drawer);
        actionBarDrawerToggle = new ActionBarDrawerToggle(this, drawerLayout, R.string.nav_open, R.string.nav_close);

        setupDrawerListener(findViewById(R.id.nav_view));
        drawerLayout.addDrawerListener(actionBarDrawerToggle);
        actionBarDrawerToggle.syncState();

        floatingSearchView.attachNavigationDrawerToMenuButton(drawerLayout);

        NotesDao notesDao = NoteDaoFirestoreImpl.getInstance();


        FirebaseFirestore firestore = FirebaseFirestore.getInstance();

        if(mAuth.getUid() != null) {
            Query query = firestore.collection("users").document(mAuth.getUid()).collection("notes");
            /*query.addSnapshotListener(
                    new ValueEventListener() {
                        @Override
                        public void onDataChange(@NonNull DataSnapshot snapshot) {
                            // for example: if you're expecting your user's data as an object of the "User" class.
                            this.notes = dataSnapshot.getValue(Note);
                        }

                        @Override
                        public void onCancelled(@NonNull DatabaseError error) {
                            // read query is cancelled.
                        }
                    }
            );*/
        }



        NotesRecyclerViewAdapter notesRecyclerViewAdapter = new NotesRecyclerViewAdapter(this, notesDao.getAllNotes());
        /*notesDao.getGroupsWithNotes().observe(this, groupsWithNotes -> {
            notesRecyclerViewAdapter.setData(notes);

            if (notes.size() == 0) {
                findViewById(R.id.groups_recyclerView).setVisibility(View.GONE);
                findViewById(R.id.groups_noItems).setVisibility(View.VISIBLE);
            } else {
                findViewById(R.id.groups_recyclerView).setVisibility(View.VISIBLE);
                findViewById(R.id.groups_noItems).setVisibility(View.GONE);
            }
        });*/

        RecyclerView recyclerView = findViewById(R.id.groups_recyclerView);
        recyclerView.setItemAnimator(new DefaultItemAnimator());
        recyclerView.setAdapter(notesRecyclerViewAdapter);

        new ItemTouchHelper(new SwipeToDeleteCallback<>(this, notesRecyclerViewAdapter)).attachToRecyclerView(recyclerView);

        SwipeRefreshLayout swipeRefreshLayout = findViewById(R.id.swipeRefreshLayout);
        swipeRefreshLayout.setOnRefreshListener(() -> {
            Handler mHandler = new Handler(getMainLooper());
            mHandler.postDelayed(() -> swipeRefreshLayout.setRefreshing(false), 1000);
        });

        findViewById(R.id.fab_newGroup).setOnClickListener(view -> {
            Intent editNoteActivity = new Intent(this, EditNoteActivity.class);
            startActivity(editNoteActivity);
            ((FloatingActionsMenu)findViewById(R.id.fab_menu)).collapse();
        });


        findViewById(R.id.fab_newNote).setOnClickListener(view -> {
            Intent editNoteActivity = new Intent(this, EditNoteActivity.class);
            startActivity(editNoteActivity);
            ((FloatingActionsMenu)findViewById(R.id.fab_menu)).collapse();
        });

        floatingSearchView.setOnQueryChangeListener((oldQuery, newQuery) -> {
            /*this.notesDao.getGroupsAndNotesLike(newQuery).observe(MainActivity.this, (searchQueryItems) -> {
                floatingSearchView.swapSuggestions(searchQueryItems);
                this.lastSearchQueryItems = searchQueryItems;
                floatingSearchView.closeMenu(false);
            });*/
        });

        floatingSearchView.setOnBindSuggestionCallback((suggestionView, leftIcon, textView, item, itemPosition) -> leftIcon.setImageResource(R.drawable.ic_list_24dp));

        floatingSearchView.setOnMenuItemClickListener(item -> {
            Intent editActivity = new Intent(this, EditNoteActivity.class);
            editActivity.putExtra("itemId", item.getItemId());
            startActivity(editActivity);
        });
    }

    private void setupDrawerListener(NavigationView navigationView) {
        mAuth.addAuthStateListener(firebaseAuth -> onAuthStateChanged(navigationView));
        onAuthStateChanged(navigationView);

        navigationView.setNavigationItemSelectedListener(
            item -> {
                int id = item.getItemId();
                if (id == R.id.nav_user_login) {
                    Intent login = new Intent(this, LoginActivity.class);
                    this.startActivity(login);
                } else if (id == R.id.nav_user_logout) {
                    FirebaseAuth.getInstance().signOut();
                }

                drawerLayout.closeDrawer(GravityCompat.START);

                return super.onOptionsItemSelected(item);
            }
        );
    }

    private void onAuthStateChanged(NavigationView navigationView) {

        if(mAuth.getCurrentUser() != null) {
            String username = mAuth.getCurrentUser().getDisplayName();
            String email = mAuth.getCurrentUser().getEmail();

            if(username != null && !username.isEmpty())
                ((TextView) navigationView.getHeaderView(0).findViewById(R.id.user_name)).setText(username);
            else {
                assert email != null;
                ((TextView) navigationView.getHeaderView(0).findViewById(R.id.user_name)).setText(email.substring( 0, email.indexOf("@")));
            }

            ((TextView) navigationView.getHeaderView(0).findViewById(R.id.email)).setText(email);

            navigationView.getMenu().findItem(R.id.nav_user_login).setVisible(false);
            navigationView.getMenu().findItem(R.id.nav_user_logout).setVisible(true);
        } else {
            ((TextView) navigationView.getHeaderView(0).findViewById(R.id.user_name)).setText(getText(R.string.not_logged_in));
            ((TextView) navigationView.getHeaderView(0).findViewById(R.id.email)).setText("");

            navigationView.getMenu().findItem(R.id.nav_user_login).setVisible(true);
            navigationView.getMenu().findItem(R.id.nav_user_logout).setVisible(false);
        }
    }
}