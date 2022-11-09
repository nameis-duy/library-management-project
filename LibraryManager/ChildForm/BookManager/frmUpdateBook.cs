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
using System.Xml.Linq;
using StringFormat = LibraryManager.Utils.StringFormat;

namespace LibraryManager.ChildForm.BookManager
{
    public partial class frmUpdateBook : Form
    {
        public frmUpdateBook()
        {
            InitializeComponent();
        }
        internal IBookRepository BookRepository;
        internal bool InsertOrUpdate;
        internal Book BookInfo;       
        private void frmUpdate_Load(object sender, EventArgs e)
        {
            txtBookID.Text = BookRepository.GetNewProperBookID().ToString();
            txtPrice.Text = StringFormat.ConvertToVNDString(0);
            if (!InsertOrUpdate)
            {
                this.Text = "Quản lý thư viện - Cập nhật thông tin sách";
                txtBookID.Text = BookInfo.BookID.ToString();
                txtTitle.Text = BookInfo.Title;
                txtPrinter.Text = BookInfo.Printer;
                txtQuantity.Text = BookInfo.Quantity.ToString();
                txtPrice.Text = StringFormat.ConvertToVNDString(BookInfo.Price);
                txtAuthor.Text = BookInfo.Author;
                txtYear.Text = BookInfo.PublishYear;
                btnConfirm.Text = "Cập nhật";
            }
            LoadComboBoxFilter();
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            BookInfo = new Book
            {
                Author = txtAuthor.Text,
                BookID = int.Parse(txtBookID.Text),
                Title = txtTitle.Text,
                Category = (Category)cboCategory.SelectedItem,
                Price = StringFormat.ConvertToVND(txtPrice.Text),
                Printer = txtPrinter.Text,
                PublishYear = txtYear.Text,
                Quantity = int.Parse(txtQuantity.Text)
            };
            if (InsertOrUpdate)
            {
                BookRepository.AddBook(BookInfo);
            } else
            {
                BookRepository.UpdateBook(BookInfo);               
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtTitle.Clear();
            txtQuantity.Clear();
            txtPrice.Clear();
            txtPrinter.Clear();
            txtAuthor.Clear();
            txtYear.Clear();
            cboCategory.SelectedIndex = 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
            validateBookInfo();
        }

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            validateBookInfo();
        }

        private void txtPrinter_TextChanged(object sender, EventArgs e)
        {
            validateBookInfo();
        }

        private void txtAuthor_TextChanged(object sender, EventArgs e)
        {
            validateBookInfo();
        }

        private void txtYear_TextChanged(object sender, EventArgs e)
        {
            validateBookInfo();
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            validateBookInfo();
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            validateBookInfo();
        }

        private void txtTitle_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidateHelper.validateVietnameseWithNum(txtTitle.Text.Trim()))
            {
                e.Cancel = true;
                infoError.SetError(txtTitle, "Tựa đề không thể chứa các ký tự đặc biệt");
            }
            if (txtTitle.Text.Trim().Length == 0)
            {
                e.Cancel = true;
                infoError.SetError(txtTitle, "Tựa đề không thể để trống");
            }
        }

        private void txtTitle_Validated(object sender, EventArgs e)
        {
            infoError.SetError(txtTitle, "");
        }

        private void txtPrinter_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidateHelper.validateVietnamese(txtPrinter.Text.Trim()))
            {
                e.Cancel = true;
                infoError.SetError(txtPrinter, "Tên nhà xuất bản không thể chứa các chữ số và ký tự đặc biệt");
            }
            if (txtPrinter.Text.Trim().Length == 0)
            {
                e.Cancel = true;
                infoError.SetError(txtPrinter, "Tên nhà xuất bản không thể để trống");
            }

        }

        private void txtPrinter_Validated(object sender, EventArgs e)
        {
            infoError.SetError(txtPrinter, "");
        }

        private void txtAuthor_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidateHelper.validateVietnamese(txtAuthor.Text.Trim()))
            {
                e.Cancel = true;
                infoError.SetError(txtAuthor, "Tên tác giả không thể chứa các chữ số và ký tự đặc biệt");
            }
            if (txtAuthor.Text.Trim().Length == 0)
            {
                e.Cancel = true;
                infoError.SetError(txtAuthor, "Tên tác giả không thể để trống");
            }
        }

        private void txtAuthor_Validated(object sender, EventArgs e)
        {
            infoError.SetError(txtAuthor, "");
        }

        private void txtYear_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidateHelper.validateInteger(txtYear.Text.Trim()))
            {
                e.Cancel = true;
                infoError.SetError(txtYear, "Năm xuất bản không thể chứa các chữ cái và kí tự đặc biệt");
            } else if ((DateTime.Now.Year - int.Parse(txtYear.Text.Trim())) < 0) {
                e.Cancel = true;
                infoError.SetError(txtYear, "Năm xuất bản không thể ở tương lai");
            }
            if (txtYear.Text.Trim().Length == 0)
            {
                e.Cancel= true;
                infoError.SetError(txtYear, "Năm xuất bản không thể để trống");
            }
            
        }

        private void txtYear_Validated(object sender, EventArgs e)
        {
            infoError.SetError(txtYear, "");
        }

        private void txtQuantity_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidateHelper.validateInteger(txtQuantity.Text))
            {
                e.Cancel = true;
                infoError.SetError(txtQuantity, "Số lượng không thể chứa các chữ cái và ký tự đặc biệt");
            }
        }

        private void txtQuantity_Validated(object sender, EventArgs e)
        {
            infoError.SetError(txtQuantity, "");
        }

        private void txtPrice_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidateHelper.validateDecimal(StringFormat.ConvertToVND(txtPrice.Text).ToString()))
            {
                e.Cancel = true;
                infoError.SetError(txtPrice, "Giá tiền không thể chứa các chữ số và ký tự đặc biệt");
            }
        }

        private void txtPrice_Validated(object sender, EventArgs e)
        {
            Double price = StringFormat.ConvertToVND(txtPrice.Text);
            txtPrice.Text = StringFormat.ConvertToVNDString(price);
            infoError.SetError(txtPrice, "");
        }
        private void cboCategory_Validating(object sender, CancelEventArgs e)
        {
            if (cboCategory.SelectedIndex == 0)
            {
                e.Cancel = true;
                infoError.SetError(cboCategory, "Phân loại không thể để trống");
            }
        }

        private void cboCategory_Validated(object sender, EventArgs e)
        {
            infoError.SetError(cboCategory, "");
        }
        private void LoadComboBoxFilter()
        {
            cboCategory.Items.Clear();
            ICategoryRepository categoryRepository = new CategoryRepository();
            List<Category> categories = categoryRepository.GetCategories().ToList();
            categories.Insert(0, new Category
            {
                CategoryID = 0,
                CategoryTitle = "-- Chọn 1 phân vùng --"
            });
            cboCategory.DataSource = categories;
            cboCategory.DisplayMember = "categoryTitle";
            cboCategory.ValueMember = "categoryID";
            cboCategory.SelectedIndex = 0;
            if (!InsertOrUpdate) cboCategory.SelectedValue = BookInfo.Category.CategoryID;
        }
        private void validateBookInfo()
        {
            bool enabled = true;
            if (!ValidateHelper.validateVietnameseWithNum(txtTitle.Text)) enabled = false;
            if (!ValidateHelper.validateVietnamese(txtPrinter.Text)) enabled = false;
            if (!ValidateHelper.validateVietnamese(txtAuthor.Text)) enabled = false;
            if (!ValidateHelper.validateDecimal(StringFormat.ConvertToVND(txtPrice.Text).ToString())) enabled = false;
            if (!ValidateHelper.validateInteger(txtYear.Text)) enabled = false;
            if (!ValidateHelper.validateInteger(txtQuantity.Text)) enabled = false;
            if (cboCategory.SelectedIndex == 0) enabled = false;
            btnConfirm.Enabled = enabled;
        }

        private void txtPrice_Enter(object sender, EventArgs e)
        {
            txtPrice.Text = txtPrice.Text.Replace(" ", "").Replace("₫", "");
        }
    }
}
