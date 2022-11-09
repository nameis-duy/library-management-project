namespace LibraryManager.ChildForm.Lending_Manager
{
    partial class frmLendingBook
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lbLendingID = new System.Windows.Forms.Label();
            this.lbLibrarianID = new System.Windows.Forms.Label();
            this.lbStudentID = new System.Windows.Forms.Label();
            this.lbQuantity = new System.Windows.Forms.Label();
            this.lbBookID = new System.Windows.Forms.Label();
            this.lbBookTitle = new System.Windows.Forms.Label();
            this.txtLendID = new System.Windows.Forms.TextBox();
            this.txtStudentID = new System.Windows.Forms.TextBox();
            this.txtLibrarianID = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.txtBookID = new System.Windows.Forms.TextBox();
            this.dgvDetailData = new System.Windows.Forms.DataGridView();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.btnHoanTat = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnXoa = new System.Windows.Forms.Button();
            this.txtBookTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetailData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // lbLendingID
            // 
            this.lbLendingID.AutoSize = true;
            this.lbLendingID.Location = new System.Drawing.Point(39, 30);
            this.lbLendingID.Name = "lbLendingID";
            this.lbLendingID.Size = new System.Drawing.Size(73, 20);
            this.lbLendingID.TabIndex = 0;
            this.lbLendingID.Text = "Mã mượn";
            // 
            // lbLibrarianID
            // 
            this.lbLibrarianID.AutoSize = true;
            this.lbLibrarianID.Location = new System.Drawing.Point(524, 30);
            this.lbLibrarianID.Name = "lbLibrarianID";
            this.lbLibrarianID.Size = new System.Drawing.Size(81, 20);
            this.lbLibrarianID.TabIndex = 0;
            this.lbLibrarianID.Text = "Mã thủ thư";
            // 
            // lbStudentID
            // 
            this.lbStudentID.AutoSize = true;
            this.lbStudentID.Location = new System.Drawing.Point(222, 30);
            this.lbStudentID.Name = "lbStudentID";
            this.lbStudentID.Size = new System.Drawing.Size(88, 20);
            this.lbStudentID.TabIndex = 0;
            this.lbStudentID.Text = "Mã học sinh";
            // 
            // lbQuantity
            // 
            this.lbQuantity.AutoSize = true;
            this.lbQuantity.Location = new System.Drawing.Point(524, 73);
            this.lbQuantity.Name = "lbQuantity";
            this.lbQuantity.Size = new System.Drawing.Size(69, 20);
            this.lbQuantity.TabIndex = 0;
            this.lbQuantity.Text = "Số lượng";
            // 
            // lbBookID
            // 
            this.lbBookID.AutoSize = true;
            this.lbBookID.Location = new System.Drawing.Point(39, 73);
            this.lbBookID.Name = "lbBookID";
            this.lbBookID.Size = new System.Drawing.Size(63, 20);
            this.lbBookID.TabIndex = 0;
            this.lbBookID.Text = "Mã sách";
            // 
            // lbBookTitle
            // 
            this.lbBookTitle.AutoSize = true;
            this.lbBookTitle.Location = new System.Drawing.Point(222, 73);
            this.lbBookTitle.Name = "lbBookTitle";
            this.lbBookTitle.Size = new System.Drawing.Size(58, 20);
            this.lbBookTitle.TabIndex = 0;
            this.lbBookTitle.Text = "Tiêu đề";
            // 
            // txtLendID
            // 
            this.txtLendID.Location = new System.Drawing.Point(118, 27);
            this.txtLendID.Name = "txtLendID";
            this.txtLendID.Size = new System.Drawing.Size(75, 27);
            this.txtLendID.TabIndex = 1;
            // 
            // txtStudentID
            // 
            this.txtStudentID.Location = new System.Drawing.Point(316, 27);
            this.txtStudentID.Name = "txtStudentID";
            this.txtStudentID.Size = new System.Drawing.Size(125, 27);
            this.txtStudentID.TabIndex = 2;
            // 
            // txtLibrarianID
            // 
            this.txtLibrarianID.Location = new System.Drawing.Point(611, 27);
            this.txtLibrarianID.Name = "txtLibrarianID";
            this.txtLibrarianID.Size = new System.Drawing.Size(125, 27);
            this.txtLibrarianID.TabIndex = 3;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(611, 70);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(125, 27);
            this.txtQuantity.TabIndex = 2;
            this.txtQuantity.TextChanged += new System.EventHandler(this.txtQuantity_TextChanged);
            this.txtQuantity.Validating += new System.ComponentModel.CancelEventHandler(this.txtQuantity_Validating);
            this.txtQuantity.Validated += new System.EventHandler(this.txtQuantity_Validated);
            // 
            // txtBookID
            // 
            this.txtBookID.Location = new System.Drawing.Point(120, 70);
            this.txtBookID.Name = "txtBookID";
            this.txtBookID.Size = new System.Drawing.Size(73, 27);
            this.txtBookID.TabIndex = 1;
            this.txtBookID.TextChanged += new System.EventHandler(this.txtBookID_TextChanged);
            this.txtBookID.Validating += new System.ComponentModel.CancelEventHandler(this.txtBookID_Validating);
            this.txtBookID.Validated += new System.EventHandler(this.txtBookID_Validated);
            // 
            // dgvDetailData
            // 
            this.dgvDetailData.AllowUserToAddRows = false;
            this.dgvDetailData.AllowUserToDeleteRows = false;
            this.dgvDetailData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetailData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetailData.Location = new System.Drawing.Point(39, 129);
            this.dgvDetailData.Name = "dgvDetailData";
            this.dgvDetailData.ReadOnly = true;
            this.dgvDetailData.RowHeadersWidth = 51;
            this.dgvDetailData.RowTemplate.Height = 29;
            this.dgvDetailData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetailData.Size = new System.Drawing.Size(606, 291);
            this.dgvDetailData.TabIndex = 5;
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Location = new System.Drawing.Point(678, 129);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(94, 29);
            this.btnXacNhan.TabIndex = 3;
            this.btnXacNhan.Text = "Xác nhận";
            this.btnXacNhan.UseVisualStyleBackColor = true;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // btnHoanTat
            // 
            this.btnHoanTat.Location = new System.Drawing.Point(678, 219);
            this.btnHoanTat.Name = "btnHoanTat";
            this.btnHoanTat.Size = new System.Drawing.Size(94, 29);
            this.btnHoanTat.TabIndex = 4;
            this.btnHoanTat.Text = "Hoàn tất";
            this.btnHoanTat.UseVisualStyleBackColor = true;
            this.btnHoanTat.Click += new System.EventHandler(this.btnHoanTat_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(678, 174);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(94, 29);
            this.btnXoa.TabIndex = 5;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // txtBookTitle
            // 
            this.txtBookTitle.AutoSize = true;
            this.txtBookTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtBookTitle.Location = new System.Drawing.Point(316, 73);
            this.txtBookTitle.Name = "txtBookTitle";
            this.txtBookTitle.Size = new System.Drawing.Size(0, 20);
            this.txtBookTitle.TabIndex = 6;
            // 
            // frmLendingBook
            // 
            this.AcceptButton = this.btnXacNhan;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtBookTitle);
            this.Controls.Add(this.btnHoanTat);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.dgvDetailData);
            this.Controls.Add(this.txtBookID);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.txtLibrarianID);
            this.Controls.Add(this.txtStudentID);
            this.Controls.Add(this.txtLendID);
            this.Controls.Add(this.lbBookTitle);
            this.Controls.Add(this.lbBookID);
            this.Controls.Add(this.lbQuantity);
            this.Controls.Add(this.lbStudentID);
            this.Controls.Add(this.lbLibrarianID);
            this.Controls.Add(this.lbLendingID);
            this.Name = "frmLendingBook";
            this.Text = "frmLendingBook";
            this.Load += new System.EventHandler(this.frmLendingBook_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetailData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lbLendingID;
        private Label lbLibrarianID;
        private Label lbStudentID;
        private Label lbQuantity;
        private Label lbBookID;
        private Label lbBookTitle;
        private TextBox txtLendID;
        private TextBox txtStudentID;
        private TextBox txtLibrarianID;
        private TextBox txtQuantity;
        private TextBox txtBookID;
        private DataGridView dgvDetailData;
        private Button btnXacNhan;
        private Button btnHoanTat;
        private ErrorProvider errorProvider;
        private Button btnXoa;
        private Label txtBookTitle;
    }
}