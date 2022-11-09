using BusinessObject;
using LibraryManager.BookManager;
using LibraryManager.ChildForm.Personal_Info;
using LibraryManager.Lending_Manager;
using LibraryManager.StudentManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManager
{
    public partial class frmContainer : Form
    {
        public frmContainer()
        {
            InitializeComponent();
        }
        frmStudentManager StudentManager;
        frmBookManager BookManager;
        frmLendingManager LendingManager;
        frmInfo InfoManager;
        Librarian librarian;

        public Librarian Librarian { get => librarian; set => librarian = value; }

        private void frmContainer_Load(object sender, EventArgs e)
        {
            txtName.Text = librarian.Name;
            studentsToolStripMenuItem_Click(null, null);
        }
        private void studentsToolStripMenuItem_Click(object sender, EventArgs e)
        {           
            CloseAllChildForm();
            studentsToolStripMenuItem.ForeColor = Color.White;
            studentsToolStripMenuItem.BackColor = Color.Black;
            StudentManager = new frmStudentManager();
            StudentManager.MdiParent = this;
            StudentManager.Dock = DockStyle.Fill;
            StudentManager.Show();
        }

        private void booksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllChildForm();
            booksToolStripMenuItem.ForeColor = Color.White;
            booksToolStripMenuItem.BackColor = Color.Black;
            BookManager = new frmBookManager();
            BookManager.MdiParent = this;
            BookManager.Dock = DockStyle.Fill;
            BookManager.Show();
        }

        private void lendToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllChildForm();
            lendToolStripMenuItem.ForeColor = Color.White;
            lendToolStripMenuItem.BackColor = Color.Black;
            LendingManager = new frmLendingManager
            {
                Librarian = librarian
            };         
            LendingManager.MdiParent = this;
            LendingManager.Dock = DockStyle.Fill;
            LendingManager.Show();
        }
        private void CloseAllChildForm()
        {
            if (StudentManager != null)
            {
                studentsToolStripMenuItem.BackColor = SystemColors.Control;
                studentsToolStripMenuItem.ForeColor = SystemColors.ControlText;
                StudentManager.Close();
            }
            if (BookManager != null)
            {
                booksToolStripMenuItem.BackColor = SystemColors.Control;
                booksToolStripMenuItem.ForeColor = SystemColors.ControlText;
                BookManager.Close();
            }
            if (LendingManager != null)
            {
                lendToolStripMenuItem.BackColor = SystemColors.Control;
                lendToolStripMenuItem.ForeColor = SystemColors.ControlText;
                LendingManager.Close();
            }               
            if (InfoManager != null)
            {
                infoToolStripMenuItem.BackColor = SystemColors.Control;
                infoToolStripMenuItem.ForeColor = SystemColors.ControlText;
                InfoManager.Close();
            }
           
        }

        private void thayDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllChildForm();
            infoToolStripMenuItem.ForeColor = Color.White;
            infoToolStripMenuItem.BackColor = Color.Black;
            InfoManager = new frmInfo
            {
               Librarian = librarian
            };           
            InfoManager.MdiParent = this;
            InfoManager.Dock = DockStyle.Fill;
            InfoManager.Show();
        }
    }
}
