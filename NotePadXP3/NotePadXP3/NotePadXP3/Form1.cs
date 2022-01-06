using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotePadXP3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            Thread t = new Thread(new ThreadStart(Start));
            t.Start();
            Thread.Sleep(5000);
            InitializeComponent();
            t.Abort();
        }

        public void Start()
        {
            Application.Run(new SplashScreen());
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to exit Notepad XP", "Exit Notepad", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                Application.Exit();
            };
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richtextbox1.Clear();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richtextbox1.Cut();
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richtextbox1.Copy();
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richtextbox1.Paste();
        }

        private void UndoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richtextbox1.Undo();
        }

        private void RedoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richtextbox1.Redo();
        }

        private void NotePadXPToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void DrawingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.ShowDialog();

            if (op.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                richtextbox1.LoadFile(op.FileName, RichTextBoxStreamType.PlainText);
                this.Text = op.FileName;
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sv = new SaveFileDialog();
            sv.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (sv.ShowDialog()==DialogResult.OK)
            {
                richtextbox1.SaveFile(sv.FileName, RichTextBoxStreamType.PlainText);
                this.Text = sv.FileName;
            }
        }

        private void FontToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.Font = richtextbox1.SelectionFont;
            if (fd.ShowDialog() == DialogResult.OK)
            {
                richtextbox1.SelectionFont = fd.Font;
            }
        }

        private void AddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("mspaint");
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richtextbox1.Clear();
        }

        private void ColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.ShowDialog();

            richtextbox1.SelectionColor = cd.Color;
        }

        private void BackgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cr = new ColorDialog();
            if (cr.ShowDialog() == DialogResult.OK)
            {
                richtextbox1.BackColor = cr.Color;
            }
        }

        private void BackColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.ShowDialog();

            richtextbox1.SelectionBackColor = cd.Color;
        }
    }
}
