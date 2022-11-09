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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using StringFormat = LibraryManager.Utils.StringFormat;

namespace LibraryManager.ChildForm.Lending_Manager
{
    public partial class frmReturnBookLending : Form
    {
        BindingSource detailSource;
        public IBookLendingRepository bookLendingRepository { get; set; }
        IBookLendingDetailRepository bookLendingDetailRepository = new BookLendingDetailRepository();
        IStudentRepository studentRepository = new StudentRepository();
        internal BookLending bookLending { get; set; }
        public frmReturnBookLending()
        {
            InitializeComponent();
        }

        private void frmReturnBookLending_Load(object sender, EventArgs e)
        {
            var details = bookLendingDetailRepository.GetListDetails().Where(detail => detail.LendID == bookLending.LendingID);
            LoadLendingDetailList(details);
        }
        private void btnXacNhan_Click(object sender, EventArgs e)
        {

            DialogResult d = MessageBox.Show("Xác nhận trả sách?", "Quản lý thư viện - Trả sách", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (d == DialogResult.OK)
            {
                bookLending.returnDate = DateTime.Now;
                bookLendingRepository.UpdateLending(bookLending);
                if (bookLending.returnDate > bookLending.deadline)
                {
                    int numOfBook = bookLendingDetailRepository.GetListDetails().Where(detail => detail.LendID == bookLending.LendingID).Select(detail => detail.quantity).Sum();
                    double difference = 0;
                    double debt = penaltyFee(numOfBook, out difference);
                    MessageBox.Show("Học sinh " + bookLending.Student.Name + " đã trả sách quá hạn " +
                        difference.ToString() + " ngày nên bị phạt\n " + 
                        StringFormat.ConvertToVNDString(debt),
                        "Quản lý thư viện - Thông báo", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Information);
                    Student student = bookLending.Student;
                    student.Debt += debt;
                    studentRepository.UpdateStudent(student);
                }
            }
        }

        public double penaltyFee(int numOfBook, out double difference)
        {
            double fee = 0;
            difference = DateTime.Today.Subtract(bookLending.deadline).TotalDays;
            fee = (difference* 5000) * numOfBook;
            return fee;
        }

        private void btnThoat_Click(object sender, EventArgs e) => Close();
        private void LoadLendingDetailList(IEnumerable<BookLendingDetail> detailList)
        {
            var list = detailList.ToList();
            try
            {
                detailSource = new BindingSource();
                detailSource.DataSource = list;
                dgvLendingDetailData.DataSource = null;
                dgvLendingDetailData.DataSource = detailSource;
                dgvLendingDetailData.Columns[0].Visible = false;
                dgvLendingDetailData.Columns[1].HeaderText = "Mã sách";
                dgvLendingDetailData.Columns[2].HeaderText = "Tiêu đề";
                dgvLendingDetailData.Columns[3].HeaderText = "Số lượng";              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Quản lý thư viện - Trả sách", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLost_Click(object sender, EventArgs e)
        {
            BookLendingDetail bookLending = dgvLendingDetailData.CurrentRow.DataBoundItem as BookLendingDetail;
        }
    }
}
