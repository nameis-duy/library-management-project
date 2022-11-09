using BusinessObject;
using DataAccess.Repository;
using LibraryManager.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManager.ChildForm.Personal_Info
{
    public partial class frmInfo : Form
    {
        public frmInfo()
        {
            InitializeComponent();
        }
        Librarian librarian;
        ILibrarianRepository librarianRepository = new LibrarianRepository();
        public Librarian Librarian { get => librarian; set => librarian = value; }

        private void frmInfo_Load(object sender, EventArgs e)
        {
            lbLibrarianID.Text = librarian.LibrarianID.ToString();
            txtName.Text = librarian.Name;
            txtUsername.Text = librarian.Username;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            librarian.Name = txtName.Text;
            if (txtPassword.Text.Length > 5) librarian.Password = txtPassword.Text;
            librarianRepository.UpdateInfo(librarian);
            MessageBox.Show("Đã cập nhật thông tin mới. Hệ thống sẽ tự động đăng xuất", "Quản lý thư viện - Thay đổi thông tin cá nhân", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.ParentForm.Close();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            checkAllFieldValid();
        }
        private void checkAllFieldValid()
        {
            bool enabled = true;
            if (!ValidateHelper.validateVietnamese(txtName.Text)) enabled = false;
            int length = txtPassword.Text.Length;
            if (length > 0 && length < 6) enabled = false;
            if (txtConfirm.Text != txtPassword.Text) enabled = false;
            btnSave.Enabled = enabled;
        }
        private void txtName_Validated(object sender, EventArgs e)
        {
            infoError.SetError(txtName, "");
        }
        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidateHelper.validateVietnamese(txtName.Text))
            {
                e.Cancel = true;
                infoError.SetError(txtName, "Họ và tên không thể chứa các chữ số và ký tự đặc biệt");
            }
        }

        private void txtPassword_Validated(object sender, EventArgs e)
        {
            infoError.SetError(txtPassword, "");
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            int length = txtPassword.Text.Length;
            if (length > 0 && length < 6)
            {
                e.Cancel = true;
                infoError.SetError(txtPassword, "Vui lòng đặt mật khẩu dài 6-15 ký tự");
            }
        }
        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            checkAllFieldValid();
        }

        private void txtConfirm_TextChanged(object sender, EventArgs e)
        {
            checkAllFieldValid();
        }

        private void txtConfirm_Validated(object sender, EventArgs e)
        {
            infoError.SetError(txtConfirm, "");
        }

        private void txtConfirm_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirm.Text != txtPassword.Text)
            {
                e.Cancel = true;
                infoError.SetError(txtConfirm, "Không trùng khớp với mật khẩu mới");
            }
        }
    }
}