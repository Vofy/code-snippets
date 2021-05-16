using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace MemoryKeeper
{
    public partial class NoteEditor : UserControl
    {
        public string Title { get => titleTextBox.Text; set => titleTextBox.Text = value; }
        public string Content { get => contentRichTextBox.Text; set => contentRichTextBox.Text = value; }
        public string Deadline
        {
            get
            {
                //DateTime deadline = DateTime.ParseExact(alertTimedateTimePicker.Text, "dd.MM.yyyy hh:mm:ss", CultureInfo.InvariantCulture);
                /*if (deadline >= DateTime.Now)
                    return null; //deadline.ToString("yyyy-MM-dd hh:mm:ss");
                else*/
                    return null;

            }
            set => alertTimedateTimePicker.Text = value;
        }

        public NoteEditor()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            titleTextBox.Text = "";
            contentRichTextBox.Text = "";
            titleTextBox.ReadOnly = contentRichTextBox.ReadOnly = true;
        }

        public void SetReadOnly(bool readOnly)
        {
            titleTextBox.ReadOnly = contentRichTextBox.ReadOnly = readOnly;
            alertTimedateTimePicker.Enabled = !readOnly;

            if (readOnly)
            {
                titleTextBox.ForeColor = contentRichTextBox.ForeColor = alertTimedateTimePicker.CalendarTitleForeColor = Color.White;
                titleTextBox.BackColor = contentRichTextBox.BackColor = alertTimedateTimePicker.CalendarTitleBackColor = Color.FromArgb(64, 64, 64);
            }
            else
            {
                titleTextBox.ForeColor = contentRichTextBox.ForeColor = alertTimedateTimePicker.CalendarTitleForeColor = SystemColors.ControlText;
                titleTextBox.BackColor = contentRichTextBox.BackColor = alertTimedateTimePicker.CalendarTitleBackColor = SystemColors.Control;
            }
        }
    }
}
