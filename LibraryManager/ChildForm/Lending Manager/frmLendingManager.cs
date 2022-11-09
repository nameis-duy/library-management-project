using BusinessObject;
using DataAccess.Repository;
using LibraryManager.ChildForm.Lending_Manager;
using LibraryManager.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManager.Lending_Manager
{
    public partial class frmLendingManager : Form
    {
        IBookLendingRepository bookLendingRepository = new BookLendingRepository();
        IStudentRepository studentRepository = new StudentRepository();
        BindingSource source;
        public Librarian Librarian { get; set; }
        public frmLendingManager()
        {
            InitializeComponent();
        }

        private void frmLendingManager_Load(object sender, EventArgs e)
        {
            LoadLendingList();
        }

        private void btnReturnBook_Click(object sender, EventArgs e)
        {
            BookLending bookLending = dgvBookLendingData.CurrentRow.DataBoundItem as BookLending;
            frmReturnBookLending frm = new frmReturnBookLending
            {
                bookLendingRepository = bookLendingRepository,
                bookLending = bookLending
            };
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadLendingList();
                source.Position = dgvBookLendingData.Rows.Cast<DataGridViewRow>().Where(row => (int)row.Cells[0].Value == bookLending.LendingID).FirstOrDefault().Index; ;
            }

        }

        private void btnMuon_Click(object sender, EventArgs e)
        {
            if (studentRepository.GetAllStudents().Where(stu => stu.StudentID == Convert.ToInt32(txtStudentID.Text)).FirstOrDefault() != null)
            {
                frmLendingBook frm = new frmLendingBook
                {
                    Text = "Quản lý thư viện - Mượn sách",
                    StudentID = txtStudentID.Text,
                    Librarian = Librarian,
                    bookLendingRepository = bookLendingRepository
                };
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadLendingList();
                    source.Position = source.Count - 1;
                }
            }
            else
            {
                MessageBox.Show("Mã số sinh viên không tồn tại", "Quản lý thư viện - Mượn sách", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void LoadLendingList()
        {
            var lendings = bookLendingRepository.GetListLending().OrderBy(lending => lending.returnDate);
            LoadLendingList(lendings);
        }
        private void txtLendStudent_TextChanged(object sender, EventArgs e)
        {
            filterLending();
        }
        private void LoadLendingList(IEnumerable<BookLending> list)
        {
            var lendings = list.ToList();
            try
            {
                source = new BindingSource();
                source.DataSource = lendings;
                dgvBookLendingData.DataSource = null;
                dgvBookLendingData.DataSource = source;
                dgvBookLendingData.Columns[0].HeaderText = "Mã số";
                dgvBookLendingData.Columns[1].HeaderText = "Học sinh mượn sách";
                dgvBookLendingData.Columns[2].HeaderText = "Thủ thư phụ trách";
                dgvBookLendingData.Columns[3].HeaderText = "Ngày mượn";
                dgvBookLendingData.Columns[4].HeaderText = "Ngày trả";
                dgvBookLendingData.Columns[5].HeaderText = "Hạn trả";
                for (int i = 3; i < 6; i++)
                {
                    dgvBookLendingData.Columns[i].DefaultCellStyle.Format = "dd/MM/yyyy";
                }
                if (lendings.Count == 0)
                {
                    lbNotFound.Visible = true;
                }
                else
                {
                    lbNotFound.Visible = false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void txtStudentID_TextChanged(object sender, EventArgs e)
        {
            if (ValidateHelper.validateInteger(txtStudentID.Text)) btnMuon.Enabled = true; else btnMuon.Enabled = false;
        }
        private void dgvBookLendingData_SelectionChanged(object sender, EventArgs e)
        {
            BookLending bookLending = dgvBookLendingData.CurrentRow.DataBoundItem as BookLending;
            if (bookLending.returnDate == null)
            {
                btnReturnBook.Enabled = true;
                if (bookLending.deadline < DateTime.Now)
                {
                    lbLate.Visible = true;
                }
                else
                {
                    lbLate.Visible = false;
                }
            }
            else
            {
                btnReturnBook.Enabled = false;

            }          
        }
        private void filterLending()
        {
            var result = bookLendingRepository.GetListLending();
            if (txtLendStudent.Text.Length > 0) result = result.Where(lending => lending.Student.StudentID.ToString().StartsWith(txtLendStudent.Text));
            if (cbReturnNull.Checked) result = result.Where(lending => lending.returnDate == null);
            result = result.OrderBy(lending => lending.returnDate);
            LoadLendingList(result);
        }
        private void cbReturnNull_CheckedChanged(object sender, EventArgs e)
        {
            filterLending();
        }
    }
}
