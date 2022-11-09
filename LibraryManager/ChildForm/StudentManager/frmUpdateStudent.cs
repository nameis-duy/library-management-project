using BusinessObject;
using DataAccess.Repository;
using LibraryManager.Utils;
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
using StringFormat = LibraryManager.Utils.StringFormat;

namespace LibraryManager.ChildForm.StudentManager
{
    public partial class frmUpdateStudent : Form
    {
        public frmUpdateStudent()
        {
            InitializeComponent();
        }
        internal IStudentRepository StudentRepository { get; set; }
        internal bool InsertOrUpdate { get; set; }
        internal Student StudentInfo { get; set; }
        private void frmUpdateStudent_Load(object sender, EventArgs e)
        {
            dobPicker.MaxDate = DateTime.Now;
            txtDebt.Text = string.Format(new CultureInfo("vi-VN"), "{0:c}", 0);
            if (!InsertOrUpdate)
            {
                this.Text = "Quản lý thư viện - Cập nhật thẻ thư viện";
                txtStudentID.Visible = false;
                lbStudentID.Visible = true;
                lbStudentID.Text = StudentInfo.StudentID.ToString();
                txtName.Text = StudentInfo.Name;
                dobPicker.Value = StudentInfo.DOB;
                txtDebt.Text = StringFormat.ConvertToVNDString(StudentInfo.Debt);
                txtDebt.Enabled = true;
                btnConfirm.Text = "Cập nhật";
            }
        }
        private void txtStudentID_TextChanged(object sender, EventArgs e)
        {
            validateStudentInfo();
        }
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            validateStudentInfo();
        }
        private void dobPicker_ValueChanged(object sender, EventArgs e)
        {
            validateStudentInfo();
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            bool isMale = true;
            if (radioFemale.Checked) isMale = false;
            if (InsertOrUpdate)
            {
                int StudentID = int.Parse(txtStudentID.Text.Trim());
                var existed = StudentRepository.GetAllStudents().Where(student => student.StudentID == StudentID);                
                if (existed.Count() == 0)
                {
                    StudentInfo = new Student
                    {
                        StudentID = StudentID,
                        Name = txtName.Text.Trim(),
                        Generation = "K" + txtStudentID.Text.Substring(0, 2),
                        Debt = 0,
                        DOB = dobPicker.Value,
                        Gender = isMale
                    };
                    StudentRepository.AddStudent(StudentInfo);
                }
                else
                {
                    MessageBox.Show("Mã số học sinh đã tồn tại", "Quản lý thư viện - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DialogResult = DialogResult.None;
                }
            } else
            {
                StudentInfo.Name = txtName.Text.Trim();
                StudentInfo.Gender = isMale;
                StudentInfo.DOB = dobPicker.Value;
                StudentInfo.Debt = StringFormat.ConvertToVND(txtDebt.Text);
                StudentRepository.UpdateStudent(StudentInfo);
            }                      
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtStudentID.Clear();
            txtName.Clear();
            radioMale.Checked = true;
            dobPicker.Value = dobPicker.MaxDate;
            txtDebt.Clear();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void txtStudentID_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidateHelper.validateInteger(txtStudentID.Text.Trim()))
            {
                e.Cancel = true;
                infoError.SetError(txtStudentID, "Mã số học sinh không thể chứa các chữ cái và ký tự đặc biệt");
            }
            if (txtStudentID.Text.Trim().Length == 0)
            {
                e.Cancel = true;
                infoError.SetError(txtStudentID, "Mã số học sinh không thể để trống");
            }
        }
        private void txtStudentID_Validated(object sender, EventArgs e)
        {
            infoError.SetError(txtStudentID, "");
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidateHelper.validateVietnamese(txtName.Text.Trim()))
            {
                e.Cancel = true;
                infoError.SetError(txtName, "Họ và tên không thể chứa các chữ số và ký tự đặc biệt");
            }
            if (txtName.Text.Trim().Length == 0)
            {
                e.Cancel = true;
                infoError.SetError(txtName, "Họ và tên không thể để trống");
            }
        }
        private void txtName_Validated(object sender, EventArgs e)
        {
            infoError.SetError(txtName, "");
        }
        private void dobPicker_Validating(object sender, CancelEventArgs e)
        {
            if ((DateTime.Now.Year - dobPicker.Value.Year) < 6)
            {
                e.Cancel = true;
                infoError.SetError(dobPicker, "Người đăng ký thẻ thư viện phải từ 6 tuổi trở lên");
            };
        }
        private void dobPicker_Validated(object sender, EventArgs e)
        {
            infoError.SetError(dobPicker, "");
        }
        private void txtDebt_Enter(object sender, EventArgs e)
        {
            txtDebt.Text = txtDebt.Text.Replace(" ₫", "").Replace(" ","").Trim();
        }
        private void txtDebt_TextChanged(object sender, EventArgs e)
        {
            validateStudentInfo();
        }
        private void validateStudentInfo()
        {
            bool enabled = true;
            if (!ValidateHelper.validateInteger(txtStudentID.Text.Trim()) && InsertOrUpdate) enabled = false;
            if (!ValidateHelper.validateVietnamese(txtName.Text.Trim())) enabled = false;
            if ((DateTime.Now.Year - dobPicker.Value.Year) < 6) enabled = false;
            if (!ValidateHelper.validateDecimal(StringFormat.ConvertToVND(txtDebt.Text).ToString()))
            {
                enabled = false;
            }
            btnConfirm.Enabled = enabled;
        }

        private void txtDebt_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidateHelper.validateDecimal(txtDebt.Text.Trim()))
            {
                e.Cancel = true;
                infoError.SetError(txtDebt, "Định dạng số không thích hợp");
            }
        }

        private void txtDebt_Validated(object sender, EventArgs e)
        {
            Double newDebt = StringFormat.ConvertToVND(txtDebt.Text);
            txtDebt.Text = StringFormat.ConvertToVNDString(newDebt);           
            infoError.SetError(txtDebt, "");
        }
    }
}
