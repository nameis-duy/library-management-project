using BusinessObject;
using DataAccess.Repository;
using LibraryManager.ChildForm.StudentManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManager.StudentManager
{
    public partial class frmStudentManager : Form
    {
        public frmStudentManager()
        {
            InitializeComponent();
        }
        IStudentRepository studentRepository = new StudentRepository();
        BindingSource source;
        private void frmStudentManager_Load(object sender, EventArgs e)
        {
            LoadStudentList(studentRepository.GetAllStudents());
            LoadComboBoxFilter();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmUpdateStudent addStudent = new frmUpdateStudent
            {
                StudentRepository = studentRepository,
                InsertOrUpdate = true
            };
            if (addStudent.ShowDialog() == DialogResult.OK)
            {
                Student newStudent = addStudent.StudentInfo;
                LoadStudentList(studentRepository.GetAllStudents());
                LoadComboBoxFilter();
                source.Position = dvgData.Rows.Cast<DataGridViewRow>().Where(row => (int)row.Cells[0].Value == newStudent.StudentID).FirstOrDefault().Index;
                MessageBox.Show("Đã tạo thẻ thư viện mới", "Quản lý thư viện - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Student student = dvgData.CurrentRow.DataBoundItem as Student;
            frmUpdateStudent updateStudent = new frmUpdateStudent
            {
                StudentInfo = student,
                StudentRepository = studentRepository,
                InsertOrUpdate = false
            };
            if (updateStudent.ShowDialog() == DialogResult.OK)
            {
                int index = dvgData.CurrentRow.Index;
                LoadStudentList(studentRepository.GetAllStudents());
                source.Position = index;
                MessageBox.Show("Đã cập nhật thẻ thư viện", "Quản lý thư viện - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnUpdateDebt_Click(object sender, EventArgs e)
        {
            Student student = dvgData.CurrentRow.DataBoundItem as Student;
        }
        private void txtStudentID_TextChanged(object sender, EventArgs e)
        {
            filterStudent();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            filterStudent();
        }

        private void cboGeneration_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterStudent();
        }
        public void LoadStudentList(IEnumerable<Student> studentList)
        {
            var list = studentList.ToList();
            try
            {
                source = new BindingSource();
                source.DataSource = list;
                dvgData.DataSource = null;
                dvgData.DataSource = source;
                dvgData.Columns[0].HeaderText = "Mã số học sinh";
                dvgData.Columns[1].HeaderText = "Họ và tên";
                dvgData.Columns[2].HeaderText = "Khoá";
                dvgData.Columns[3].HeaderText = "Nam";
                dvgData.Columns[4].HeaderText = "Ngày sinh";
                dvgData.Columns[4].DefaultCellStyle.Format = "dd-MM-yyyy";
                dvgData.Columns[5].HeaderText = "Dư nợ";
                dvgData.Columns[5].DefaultCellStyle.Format = "c";
                CultureInfo VNstyle = new CultureInfo("vi-VN");
                VNstyle.NumberFormat.CurrencyGroupSeparator = " ";
                dvgData.Columns[5].DefaultCellStyle.FormatProvider = VNstyle;
                if (list.Count() == 0)
                {
                    btnUpdate.Enabled = false;
                }
                else
                {
                    btnUpdate.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load member list");
            }
        }
        private void LoadComboBoxFilter()
        {
            List<String> generations = studentRepository.GetAllStudents().Select(student => student.Generation).Distinct().ToList();
            generations.Insert(0,"-- Không chọn --");
            cboGeneration.DataSource = generations;
            cboGeneration.SelectedIndex = 0;
            
        }

        private void filterStudent()
        {
            var list = studentRepository.GetAllStudents();
            if (txtStudentID.Text.Length > 0) list = list.Where(student => student.StudentID.ToString().StartsWith(txtStudentID.Text.Trim()));
            if (txtName.Text.Length > 0) list = list.Where(student => student.Name.ToLower().Contains(txtName.Text.ToLower().Trim()));
            if (cboGeneration.SelectedIndex > 0) list = list.Where(student => student.Generation == cboGeneration.SelectedItem.ToString());
            if (cbDebt.Checked) list = list.Where(student => student.Debt > 0);
            if (list.Count() == 0) lbNotFound.Visible = true; else lbNotFound.Visible = false;
            LoadStudentList(list);
        }
        private void cbDebt_CheckedChanged(object sender, EventArgs e)
        {
            filterStudent();
        }
    }
}
