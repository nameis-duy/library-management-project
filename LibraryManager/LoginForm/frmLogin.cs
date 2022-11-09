using BusinessObject;
using DataAccess.Repository;

namespace LibraryManager
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        private ILibrarianRepository librarianRepository = new LibrarianRepository();
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Librarian? librarian = librarianRepository.GetLibrarian(txtUsername.Text.Trim(), txtPassword.Text.Trim());
            if (librarian != null)
            {
                frmContainer MainManager = new frmContainer
                {
                    Librarian = librarian
                };
                MainManager.Show();
                MainManager.FormClosed += new FormClosedEventHandler(MainManagerClose);
                this.Hide();
            }
            else
            {
                txtPassword.Clear();
                MessageBox.Show("Thông tin đăng nhập không chính xác !", "Quản lý thư viện - Đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void MainManagerClose(object? sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}