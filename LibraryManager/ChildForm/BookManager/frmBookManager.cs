using BusinessObject;
using DataAccess.Repository;
using LibraryManager.ChildForm.BookManager;
using LibraryManager.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManager.BookManager
{
    public partial class frmBookManager : Form
    {
        public frmBookManager()
        {
            InitializeComponent();
        }
        BindingSource source;
        IBookRepository bookRepository = new BookRepository();
        private void frmBookManager_Load(object sender, EventArgs e)
        {
            var bookList = bookRepository.GetAllBooks();
            LoadBookList(bookList);
            LoadComboBoxFilter();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmUpdateBook addBook = new frmUpdateBook
            {
                BookRepository = bookRepository,
                InsertOrUpdate = true
            };
            if (addBook.ShowDialog() == DialogResult.OK)
            {
                LoadBookList(bookRepository.GetAllBooks());
                LoadComboBoxFilter();
                source.Position = source.Count - 1;
                MessageBox.Show("Đã thêm thành công", "Quản lý thư viện - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Book book = dvgData.CurrentRow.DataBoundItem as Book;
            frmUpdateBook updateBook = new frmUpdateBook
            {
                BookRepository = bookRepository,
                InsertOrUpdate = false,
                BookInfo = book
            };
            if (updateBook.ShowDialog() == DialogResult.OK)
            {
                int pos = dvgData.CurrentRow.Index;
                LoadBookList(bookRepository.GetAllBooks());
                LoadComboBoxFilter();
                source.Position = pos;
                MessageBox.Show("Đã cập nhật thành công", "Quản lý thư viện - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtBookID_TextChanged(object sender, EventArgs e)
        {
            filterBook();
        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
            filterBook();
        }

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterBook();
        }
        private void cboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterBook();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtBookID.Clear();
            txtTitle.Clear();
            cboCategory.SelectedIndex = 0;
            cboYear.SelectedIndex = 0;
        }
        public void LoadBookList(IEnumerable<Book> bookList)
        {
            var list = bookList.ToList();
            try
            {
                source = new BindingSource();
                source.DataSource = list;
                dvgData.DataSource = null;
                dvgData.DataSource = source;
                dvgData.Columns[0].HeaderText = "Mã sách";
                dvgData.Columns[1].HeaderText = "Tựa đề";
                dvgData.Columns[2].HeaderText = "Phân loại";
                dvgData.Columns[3].HeaderText = "Nhà xuất bản";
                dvgData.Columns[4].HeaderText = "Tác giả";
                dvgData.Columns[5].HeaderText = "Năm xuất bản";
                dvgData.Columns[6].HeaderText = "Số lượng";
                dvgData.Columns[7].HeaderText = "Giá";
                dvgData.Columns[7].DefaultCellStyle.Format = "c";
                CultureInfo VNstyle = new CultureInfo("vi-VN");
                VNstyle.NumberFormat.CurrencyGroupSeparator = " ";
                dvgData.Columns[7].DefaultCellStyle.FormatProvider = VNstyle;
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
            ICategoryRepository categoryRepository = new CategoryRepository();
            List<Category> categories = categoryRepository.GetCategories().ToList();
            categories.Insert(0, new Category
            {
                CategoryID = 0,
                CategoryTitle = "-- Không chọn --"
            });
            cboCategory.DataSource = categories;
            cboCategory.DisplayMember = "categoryTitle";
            cboCategory.ValueMember = "categoryID";
            cboYear.Items.Clear();
            var years = bookRepository.GetAllBooks().OrderBy(book => book.PublishYear).Select(book => book.PublishYear).Distinct();
            cboYear.Items.AddRange(years.ToArray());
            cboYear.Items.Insert(0, "-- Không chọn --");
            cboYear.SelectedIndex = 0;
        }

        private void filterBook()
        {
            var list = bookRepository.GetAllBooks();
            if (txtBookID.Text.Length > 0) list = list.Where(book => book.BookID.ToString().StartsWith(txtBookID.Text.Trim()));
            if (txtTitle.Text.Length > 0) list = list.Where(book => book.Title.ToLower().Contains(txtTitle.Text.ToLower().Trim()));
            if (cboCategory.SelectedIndex > 0) list = list.Where(book => book.Category.CategoryID == (int)cboCategory.SelectedValue);
            if (cboYear.SelectedIndex > 0) list = list.Where(book => book.PublishYear == cboYear.SelectedItem.ToString());
            if (list.Count() == 0) lbNotFound.Visible = true; else lbNotFound.Visible = false;
            LoadBookList(list);
        }
    }
}
