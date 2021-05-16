
namespace MemoryKeeper
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ParentSplitContainer = new System.Windows.Forms.SplitContainer();
            this.notesListView = new System.Windows.Forms.ListView();
            this.columnHeaderTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderContent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.noteListMenuStrip = new System.Windows.Forms.MenuStrip();
            this.noteListToolStripMenuItem_add = new System.Windows.Forms.ToolStripMenuItem();
            this.editPanel = new System.Windows.Forms.Panel();
            this.noteEditor = new MemoryKeeper.NoteEditor();
            this.noteMenuStrip = new System.Windows.Forms.MenuStrip();
            this.noteEditorToolStripMenuItem_save = new System.Windows.Forms.ToolStripMenuItem();
            this.noteEditorToolStripMenuItem_edit = new System.Windows.Forms.ToolStripMenuItem();
            this.noteEditorToolStripMenuItem_delete = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ParentSplitContainer)).BeginInit();
            this.ParentSplitContainer.Panel1.SuspendLayout();
            this.ParentSplitContainer.Panel2.SuspendLayout();
            this.ParentSplitContainer.SuspendLayout();
            this.noteListMenuStrip.SuspendLayout();
            this.editPanel.SuspendLayout();
            this.noteMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ParentSplitContainer
            // 
            this.ParentSplitContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.ParentSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ParentSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.ParentSplitContainer.Margin = new System.Windows.Forms.Padding(50);
            this.ParentSplitContainer.Name = "ParentSplitContainer";
            // 
            // ParentSplitContainer.Panel1
            // 
            this.ParentSplitContainer.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ParentSplitContainer.Panel1.Controls.Add(this.notesListView);
            this.ParentSplitContainer.Panel1.Controls.Add(this.noteListMenuStrip);
            this.ParentSplitContainer.Panel1MinSize = 150;
            // 
            // ParentSplitContainer.Panel2
            // 
            this.ParentSplitContainer.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ParentSplitContainer.Panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ParentSplitContainer.Panel2.BackgroundImage")));
            this.ParentSplitContainer.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ParentSplitContainer.Panel2.Controls.Add(this.editPanel);
            this.ParentSplitContainer.Panel2.Controls.Add(this.noteMenuStrip);
            this.ParentSplitContainer.Panel2MinSize = 150;
            this.ParentSplitContainer.Size = new System.Drawing.Size(953, 461);
            this.ParentSplitContainer.SplitterDistance = 473;
            this.ParentSplitContainer.TabIndex = 0;
            // 
            // notesListView
            // 
            this.notesListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.notesListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.notesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderTitle,
            this.columnHeaderContent});
            this.notesListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.notesListView.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.notesListView.ForeColor = System.Drawing.Color.White;
            this.notesListView.FullRowSelect = true;
            this.notesListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.notesListView.HideSelection = false;
            this.notesListView.Location = new System.Drawing.Point(0, 0);
            this.notesListView.Margin = new System.Windows.Forms.Padding(16);
            this.notesListView.MultiSelect = false;
            this.notesListView.Name = "notesListView";
            this.notesListView.Scrollable = false;
            this.notesListView.Size = new System.Drawing.Size(473, 411);
            this.notesListView.TabIndex = 3;
            this.notesListView.UseCompatibleStateImageBehavior = false;
            this.notesListView.View = System.Windows.Forms.View.Details;
            this.notesListView.SelectedIndexChanged += new System.EventHandler(this.NotesListView_SelectedIndexChanged);
            this.notesListView.SizeChanged += new System.EventHandler(this.NotesListView_updateSize);
            // 
            // columnHeaderTitle
            // 
            this.columnHeaderTitle.Text = "Title";
            this.columnHeaderTitle.Width = 120;
            // 
            // columnHeaderContent
            // 
            this.columnHeaderContent.Text = "Content";
            this.columnHeaderContent.Width = 360;
            // 
            // noteListMenuStrip
            // 
            this.noteListMenuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.noteListMenuStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.noteListMenuStrip.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.noteListMenuStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.noteListMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.noteListToolStripMenuItem_add});
            this.noteListMenuStrip.Location = new System.Drawing.Point(0, 411);
            this.noteListMenuStrip.MinimumSize = new System.Drawing.Size(0, 50);
            this.noteListMenuStrip.Name = "noteListMenuStrip";
            this.noteListMenuStrip.Size = new System.Drawing.Size(473, 50);
            this.noteListMenuStrip.TabIndex = 2;
            this.noteListMenuStrip.Text = "menuStrip2";
            this.noteListMenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.NoteListMenuStrip_ItemClicked);
            // 
            // noteListToolStripMenuItem_add
            // 
            this.noteListToolStripMenuItem_add.BackColor = System.Drawing.Color.Transparent;
            this.noteListToolStripMenuItem_add.ForeColor = System.Drawing.Color.White;
            this.noteListToolStripMenuItem_add.Image = ((System.Drawing.Image)(resources.GetObject("noteListToolStripMenuItem_add.Image")));
            this.noteListToolStripMenuItem_add.Name = "noteListToolStripMenuItem_add";
            this.noteListToolStripMenuItem_add.Size = new System.Drawing.Size(117, 46);
            this.noteListToolStripMenuItem_add.Text = "Add item";
            // 
            // editPanel
            // 
            this.editPanel.AutoSize = true;
            this.editPanel.BackColor = System.Drawing.Color.Transparent;
            this.editPanel.Controls.Add(this.noteEditor);
            this.editPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editPanel.Location = new System.Drawing.Point(0, 0);
            this.editPanel.Name = "editPanel";
            this.editPanel.Size = new System.Drawing.Size(476, 411);
            this.editPanel.TabIndex = 4;
            // 
            // noteEditor
            // 
            this.noteEditor.AutoSize = true;
            this.noteEditor.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.noteEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.noteEditor.Content = "";
            this.noteEditor.Deadline = null;
            this.noteEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.noteEditor.Location = new System.Drawing.Point(0, 0);
            this.noteEditor.Name = "noteEditor";
            this.noteEditor.Padding = new System.Windows.Forms.Padding(14);
            this.noteEditor.Size = new System.Drawing.Size(476, 411);
            this.noteEditor.TabIndex = 0;
            this.noteEditor.Title = "";
            this.noteEditor.Visible = false;
            // 
            // noteMenuStrip
            // 
            this.noteMenuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.noteMenuStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.noteMenuStrip.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.noteMenuStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.noteMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.noteEditorToolStripMenuItem_save,
            this.noteEditorToolStripMenuItem_edit,
            this.noteEditorToolStripMenuItem_delete});
            this.noteMenuStrip.Location = new System.Drawing.Point(0, 411);
            this.noteMenuStrip.MinimumSize = new System.Drawing.Size(0, 50);
            this.noteMenuStrip.Name = "noteMenuStrip";
            this.noteMenuStrip.Size = new System.Drawing.Size(476, 50);
            this.noteMenuStrip.TabIndex = 3;
            this.noteMenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.NoteEditorMenuStrip_ItemClicked);
            // 
            // noteEditorToolStripMenuItem_save
            // 
            this.noteEditorToolStripMenuItem_save.BackColor = System.Drawing.Color.Transparent;
            this.noteEditorToolStripMenuItem_save.ForeColor = System.Drawing.Color.White;
            this.noteEditorToolStripMenuItem_save.Image = ((System.Drawing.Image)(resources.GetObject("noteEditorToolStripMenuItem_save.Image")));
            this.noteEditorToolStripMenuItem_save.Name = "noteEditorToolStripMenuItem_save";
            this.noteEditorToolStripMenuItem_save.Size = new System.Drawing.Size(87, 46);
            this.noteEditorToolStripMenuItem_save.Text = "Save";
            // 
            // noteEditorToolStripMenuItem_edit
            // 
            this.noteEditorToolStripMenuItem_edit.ForeColor = System.Drawing.Color.White;
            this.noteEditorToolStripMenuItem_edit.Image = ((System.Drawing.Image)(resources.GetObject("noteEditorToolStripMenuItem_edit.Image")));
            this.noteEditorToolStripMenuItem_edit.Name = "noteEditorToolStripMenuItem_edit";
            this.noteEditorToolStripMenuItem_edit.Size = new System.Drawing.Size(80, 46);
            this.noteEditorToolStripMenuItem_edit.Text = "Edit";
            // 
            // noteEditorToolStripMenuItem_delete
            // 
            this.noteEditorToolStripMenuItem_delete.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.noteEditorToolStripMenuItem_delete.Image = ((System.Drawing.Image)(resources.GetObject("noteEditorToolStripMenuItem_delete.Image")));
            this.noteEditorToolStripMenuItem_delete.Name = "noteEditorToolStripMenuItem_delete";
            this.noteEditorToolStripMenuItem_delete.Size = new System.Drawing.Size(44, 46);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(953, 461);
            this.Controls.Add(this.ParentSplitContainer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "MemoryKeeper";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ParentSplitContainer.Panel1.ResumeLayout(false);
            this.ParentSplitContainer.Panel1.PerformLayout();
            this.ParentSplitContainer.Panel2.ResumeLayout(false);
            this.ParentSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ParentSplitContainer)).EndInit();
            this.ParentSplitContainer.ResumeLayout(false);
            this.noteListMenuStrip.ResumeLayout(false);
            this.noteListMenuStrip.PerformLayout();
            this.editPanel.ResumeLayout(false);
            this.editPanel.PerformLayout();
            this.noteMenuStrip.ResumeLayout(false);
            this.noteMenuStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer ParentSplitContainer;
        private System.Windows.Forms.MenuStrip noteListMenuStrip;
        private System.Windows.Forms.ListView notesListView;
        private System.Windows.Forms.ColumnHeader columnHeaderTitle;
        private System.Windows.Forms.MenuStrip noteMenuStrip;
        private System.Windows.Forms.ColumnHeader columnHeaderContent;
        private System.Windows.Forms.Panel editPanel;
        private NoteEditor noteEditor;
        private System.Windows.Forms.ToolStripMenuItem noteListToolStripMenuItem_add;
        private System.Windows.Forms.ToolStripMenuItem noteEditorToolStripMenuItem_save;
        private System.Windows.Forms.ToolStripMenuItem noteEditorToolStripMenuItem_delete;
        private System.Windows.Forms.ToolStripMenuItem noteEditorToolStripMenuItem_edit;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}

