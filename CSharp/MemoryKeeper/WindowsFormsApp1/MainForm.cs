using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Timers;
using System.Windows.Forms;

namespace MemoryKeeper
{
    public partial class MainForm : Form
    {
        private static readonly NoteDao noteDao = NoteDaoImpl.GetDatabaseAccess();
        private List<Note> notes;
        private Note editedNote;
        private EditMode currentEditMode = EditMode.None;

        public EditMode CurrentEditMode
        {
            get { return currentEditMode; }
            set
            {
                currentEditMode = value;

                switch (currentEditMode)
                {
                    case EditMode.None:
                        noteEditorToolStripMenuItem_save.Visible = false;
                        noteEditorToolStripMenuItem_edit.Visible = false;
                        noteEditorToolStripMenuItem_delete.Visible = false;
                        break;
                    case EditMode.Preview:
                        noteEditor.SetReadOnly(true);
                        noteEditorToolStripMenuItem_save.Visible = false;
                        noteEditorToolStripMenuItem_edit.Visible = true;
                        noteEditorToolStripMenuItem_delete.Visible = true;
                        break;
                    case EditMode.Edit:
                        noteEditor.SetReadOnly(false);
                        noteEditorToolStripMenuItem_save.Visible = true;
                        noteEditorToolStripMenuItem_edit.Visible = false;
                        noteEditorToolStripMenuItem_delete.Visible = true;
                        break;
                }
            }
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            NotesListView_updateSize(sender, e);
            CurrentEditMode = EditMode.None;

            DataReload();
        }

        private void DataReload()
        {
            notes = noteDao.GetAllNotes();

            List<ListViewItem> listViewItems = new List<ListViewItem>();

            ListViewItem listViewItem;
            foreach (Note note in notes)
            {
                listViewItem = new ListViewItem(note.Title);
                listViewItem.SubItems.Add(new StringReader(note.Content).ReadLine());

                listViewItems.Add(listViewItem);
            }

            notesListView.Items.Clear();
            notesListView.Items.AddRange(listViewItems.ToArray());
        }

        private void NotesListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CurrentEditMode == EditMode.Edit && notesListView.SelectedItems.Count != 0)
            {
                switch (MessageBox.Show("Přejete si je uložit", "Máte neuložené úpravy", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning))
                {
                    case DialogResult.Yes:
                        SaveNote();
                        CurrentEditMode = EditMode.Preview;
                        break;
                    case DialogResult.No:
                        CurrentEditMode = EditMode.Preview;
                        break;
                    case DialogResult.Cancel:
                        notesListView.SelectedItems.Clear();
                        break;
                }
            }
            if (notesListView.SelectedItems.Count != 0)
            {
                int noteIndex = notesListView.Items.IndexOf(notesListView.SelectedItems[0]);
                editedNote = notes.ElementAt(noteIndex);

                noteEditor.Title = editedNote.Title;
                noteEditor.Content = editedNote.Content;
                noteEditor.Deadline = editedNote.Deadline;

                noteEditor.Visible = true;

                CurrentEditMode = EditMode.Preview;
            }
        }

        private void NoteListMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "noteListToolStripMenuItem_add":
                    noteEditor.Show();
                    noteEditor.Clear();

                    notesListView.SelectedItems.Clear();

                    CurrentEditMode = EditMode.Edit;
                    editedNote = new Note();
                    break;
            }
        }

        private void NoteEditorMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "noteEditorToolStripMenuItem_save":
                    SaveNote();
                    CurrentEditMode = EditMode.Preview;
                    noteEditor.Hide();
                    noteEditor.Clear();
                    break;
                case "noteEditorToolStripMenuItem_edit":
                    noteEditor.Show();
                    CurrentEditMode = EditMode.Edit;
                    break;
                case "noteEditorToolStripMenuItem_delete":
                    noteDao.DeleteNote(editedNote);
                    noteEditor.Hide();
                    noteEditor.Clear();
                    CurrentEditMode = EditMode.None;
                    DataReload();
                    break;
            }
        }

        private void SaveNote()
        {
            editedNote.Title = noteEditor.Title;
            editedNote.Content = noteEditor.Content;
            editedNote.Deadline = noteEditor.Deadline;

            if (editedNote.Id == default)
                noteDao.AddNote(editedNote);
            else
                noteDao.UpdateNote(editedNote);

            DataReload();
        }

        private void NotesListView_updateSize(object sender, EventArgs e)
        {
            if (notesListView.Width < 500)
            {
                columnHeaderTitle.Width = notesListView.Width;
                columnHeaderContent.Width = 0;
            }
            else
            {
                columnHeaderTitle.Width = notesListView.Width - 2 * (notesListView.Width / 3);
                columnHeaderContent.Width = notesListView.Width - columnHeaderTitle.Width;
            }
        }
    }
}
