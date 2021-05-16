using GraphicsEditor.EffectsUserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reactive.Linq;
using System.Windows.Forms;

namespace GraphicsEditor
{
    public partial class MainForm : Form
    {
        Stack<Bitmap> editedBitmap = new Stack<Bitmap>();
        //private ObservableStack<Bitmap> editedBitmap = new ObservableStack<Bitmap>();
        //private BindingSource test = new BindingSource();

        public MainForm()
        {
            InitializeComponent();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void OpenFile(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Image image = Image.FromStream(openFileDialog.OpenFile());
                    pictureBox1.Image = image;
                }
            }
        }

        private void blackAndWhiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenSidePanel(new BlackAndWhiteUserControl());

            editedBitmap.Push(Effects.BlackAndWhite(new Bitmap(pictureBox1.Image), 128));
        }

        private void OpenSidePanel(EffectsUserControl userControl)
        {
            layoutSplitContainer.Panel2Collapsed = false;
            layoutSplitContainer.Panel2.Controls.Add(userControl);
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N)
            {
                switch (e.KeyCode)
                {
                    case Keys.O:
                        OpenFile(sender, e);
                        break;
                }
            }
        }
    }
}
