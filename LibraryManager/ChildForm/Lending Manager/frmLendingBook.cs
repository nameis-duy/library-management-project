using BusinessObject;
using DataAccess.Repository;
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

namespace LibraryManager.ChildForm.Lending_Manager
{
    public partial class frmLendingBook : Form
    {
        public IBookLendingDetailRepository bookLendingDetailRepository = new BookLendingDetailRepository();
        public IBookLendingRepository bookLendingRepository { get; set; }
        IBookRepository bookRepository = new BookRepository();
        Librarian librarian;
        BindingSource source;
        internal IStudentRepository studentRepository { get; set; }
        public string StudentID { get; set; }
        public Librarian Librarian { get => librarian; set => librarian = value; }

        List<BookLendingDetail> lendingList = new List<BookLendingDetail>();

        public frmLendingBook()
        {
            InitializeComponent();
        }

        private void frmLendingBook_Load(object sender, EventArgs e)
        {
            txtLendID.Text = bookLendingRepository.GetNextSeed().ToString();
            txtStudentID.Text = StudentID;
            txtLibrarianID.Text = librarian.LibrarianID.ToString();

            btnXacNhan.Enabled = false;
            btnHoanTat.Enabled = false;
            btnXoa.Enabled = false;
            txtLibrarianID.Enabled = false;
            txtStudentID.Enabled = false;
            txtLendID.Enabled = false;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                source = new BindingSource();
                lendingList.Add(new BookLendingDetail
                {
                    LendID = int.Parse(txtLendID.Text),
                    bookID = int.Parse(txtBookID.Text),
                    bookTitle = txtBookTitle.Text,
                    quantity = int.Parse(txtQuantity.Text)
                });
                source.DataSource = lendingList;

                dgvDetailData.DataSource = null;
                dgvDetailData.DataSource = source;

                btnHoanTat.Enabled = true;
                btnXoa.Enabled = true;
                btnXacNhan.Enabled = false;
                txtBookTitle.Text = "";
                txtBookID.Clear();
                txtQuantity.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Quản lý thư viện - Mượn sách", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnHoanTat_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Hoàn tất thủ tục mượn sách?", "Quản lý thư viện - Mượn sách", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (d == DialogResult.OK)
            {
                Student? student = studentRepository.GetAllStudents().Where(std => std.StudentID == int.Parse(txtStudentID.Text)).First();
                var lending = new BookLending
                {
                    LendingID = int.Parse(txtLendID.Text),
                    Student = student,
                    Librarian = librarian,
                    lendDate = DateTime.Today,
                    returnDate = null,
                    deadline = DateTime.Today.AddDays(7),
                };
                bookLendingRepository.AddLending(lending);
                foreach (var item in lendingList)
                {
                    bookLendingDetailRepository.AddBookLendingDetail(item);
                }
                MessageBox.Show("Mượn sách thành công", "Quản lý thư viện - Mượn sách", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lendingList.Count() != 0)
            {
                int lendID = Convert.ToInt32(dgvDetailData.CurrentRow.Cells[0].Value);
                var lendObj = lendingList.Where(lend => lend.LendID == lendID).First();
                DialogResult d = MessageBox.Show($"Xác nhận xóa sách mượn mã số #{lendObj.bookID}", "Quản lý thư viện - Mượn sách", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (d == DialogResult.OK)
                {
                    lendingList.Remove(lendObj);
                    if (lendingList.Count() == 0)
                    {
                        dgvDetailData.ClearSelection();
                        dgvDetailData.DataSource = null;
                        btnXoa.Enabled = false;
                        btnHoanTat.Enabled = false;
                    }
                    else
                    {
                        source = new BindingSource();
                        source.DataSource = lendingList;

                        dgvDetailData.DataSource = null;
                        dgvDetailData.DataSource = source;
                    }
                }
            }
        }

        private void txtBookID_Validating(object sender, CancelEventArgs e)
        {
            if (txtBookID.Text.Length != 0)
            {
                if (!ValidateHelper.validateInteger(txtBookID.Text))
                {
                    e.Cancel = true;
                    errorProvider.SetError(txtBookID, "Mã số sách chỉ chứa kí tự chữ số.");
                }
                var book = bookRepository.GetAllBooks().Where(b => b.BookID == int.Parse(txtBookID.Text)).FirstOrDefault();
                if (book == null)
                {
                    e.Cancel = true;
                    errorProvider.SetError(txtBookID, "Mã số sách này không tồn tại.");
                }
            }
        }

        private void txtBookID_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(txtBookID, "");
        }

        private void txtQuantity_Validating(object sender, CancelEventArgs e)
        {
            if (txtQuantity.Text.Length != 0)
            {
                if (!ValidateHelper.validateInteger(txtQuantity.Text))
                {
                    e.Cancel = true;
                    errorProvider.SetError(txtQuantity, "Số lượng phải là kí tự chữ số.");
                }
                if (Convert.ToInt32(txtQuantity.Text) <= 0)
                {
                    e.Cancel = true;
                    errorProvider.SetError(txtQuantity, "Số lượng phải lớn hơn 0.");
                }
            }
        }

        private void txtQuantity_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(txtQuantity, "");
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            if (txtBookID.Text.Length != 0 && txtQuantity.Text.Length != 0)
            {
                btnXacNhan.Enabled = true;
            }
        }

        private void txtBookID_TextChanged(object sender, EventArgs e)
        {
            if (ValidateHelper.validateInteger(txtBookID.Text))
            {
                var book = bookRepository.GetAllBooks().Where(b => b.BookID == int.Parse(txtBookID.Text)).FirstOrDefault();
                if (book != null) txtBookTitle.Text = book.Title;
            }
            
        }
    }
}
