namespace LibraryManager.Lending_Manager
{
    partial class frmLendingManager
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnReturnBook = new System.Windows.Forms.Button();
            this.dgvBookLendingData = new System.Windows.Forms.DataGridView();
            this.btnMuon = new System.Windows.Forms.Button();
            this.lbSearch = new System.Windows.Forms.Label();
            this.txtLendStudent = new System.Windows.Forms.TextBox();
            this.txtStudentID = new System.Windows.Forms.TextBox();
            this.lbTitle = new System.Windows.Forms.Label();
            this.gbStudentID = new System.Windows.Forms.GroupBox();
            this.lbNotFound = new System.Windows.Forms.Label();
            this.lbLate = new System.Windows.Forms.Label();
            this.cbReturnNull = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookLendingData)).BeginInit();
            this.gbStudentID.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnReturnBook
            // 
            this.btnReturnBook.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReturnBook.Location = new System.Drawing.Point(794, 382);
            this.btnReturnBook.Name = "btnReturnBook";
            this.btnReturnBook.Size = new System.Drawing.Size(179, 74);
            this.btnReturnBook.TabIndex = 0;
            this.btnReturnBook.Text = "Trả sách";
            this.btnReturnBook.UseVisualStyleBackColor = true;
            this.btnReturnBook.Click += new System.EventHandler(this.btnReturnBook_Click);
            // 
            // dgvBookLendingData
            // 
            this.dgvBookLendingData.AllowUserToAddRows = false;
            this.dgvBookLendingData.AllowUserToDeleteRows = false;
            this.dgvBookLendingData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBookLendingData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBookLendingData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBookLendingData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBookLendingData.Location = new System.Drawing.Point(38, 154);
            this.dgvBookLendingData.Name = "dgvBookLendingData";
            this.dgvBookLendingData.ReadOnly = true;
            this.dgvBookLendingData.RowHeadersVisible = false;
            this.dgvBookLendingData.RowHeadersWidth = 51;
            this.dgvBookLendingData.RowTemplate.Height = 29;
            this.dgvBookLendingData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBookLendingData.Size = new System.Drawing.Size(711, 442);
            this.dgvBookLendingData.TabIndex = 1;
            this.dgvBookLendingData.SelectionChanged += new System.EventHandler(this.dgvBookLendingData_SelectionChanged);
            // 
            // btnMuon
            // 
            this.btnMuon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMuon.Enabled = false;
            this.btnMuon.Location = new System.Drawing.Point(18, 94);
            this.btnMuon.Name = "btnMuon";
            this.btnMuon.Size = new System.Drawing.Size(179, 74);
            this.btnMuon.TabIndex = 0;
            this.btnMuon.Text = "Mượn sách";
            this.btnMuon.UseVisualStyleBackColor = true;
            this.btnMuon.Click += new System.EventHandler(this.btnMuon_Click);
            // 
            // lbSearch
            // 
            this.lbSearch.AutoSize = true;
            this.lbSearch.Location = new System.Drawing.Point(47, 112);
            this.lbSearch.Name = "lbSearch";
            this.lbSearch.Size = new System.Drawing.Size(70, 20);
            this.lbSearch.TabIndex = 2;
            this.lbSearch.Text = "Tìm kiếm";
            // 
            // txtLendStudent
            // 
            this.txtLendStudent.Location = new System.Drawing.Point(133, 109);
            this.txtLendStudent.Name = "txtLendStudent";
            this.txtLendStudent.PlaceholderText = "Nhập mã số học sinh";
            this.txtLendStudent.Size = new System.Drawing.Size(156, 27);
            this.txtLendStudent.TabIndex = 3;
            this.txtLendStudent.TextChanged += new System.EventHandler(this.txtLendStudent_TextChanged);
            // 
            // txtStudentID
            // 
            this.txtStudentID.Location = new System.Drawing.Point(18, 51);
            this.txtStudentID.Name = "txtStudentID";
            this.txtStudentID.PlaceholderText = "Mã sô học sinh";
            this.txtStudentID.Size = new System.Drawing.Size(179, 27);
            this.txtStudentID.TabIndex = 3;
            this.txtStudentID.TextChanged += new System.EventHandler(this.txtStudentID_TextChanged);
            // 
            // lbTitle
            // 
            this.lbTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbTitle.Location = new System.Drawing.Point(287, 29);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(414, 54);
            this.lbTitle.TabIndex = 4;
            this.lbTitle.Text = "Lịch sử mượn/trả sách";
            // 
            // gbStudentID
            // 
            this.gbStudentID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbStudentID.Controls.Add(this.btnMuon);
            this.gbStudentID.Controls.Add(this.txtStudentID);
            this.gbStudentID.Location = new System.Drawing.Point(776, 169);
            this.gbStudentID.Name = "gbStudentID";
            this.gbStudentID.Size = new System.Drawing.Size(208, 186);
            this.gbStudentID.TabIndex = 5;
            this.gbStudentID.TabStop = false;
            this.gbStudentID.Text = "Cho mượn sách";
            // 
            // lbNotFound
            // 
            this.lbNotFound.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbNotFound.AutoSize = true;
            this.lbNotFound.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lbNotFound.Font = new System.Drawing.Font("Segoe UI Semibold", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbNotFound.Location = new System.Drawing.Point(133, 340);
            this.lbNotFound.Name = "lbNotFound";
            this.lbNotFound.Size = new System.Drawing.Size(488, 50);
            this.lbNotFound.TabIndex = 6;
            this.lbNotFound.Text = "Không có kết quả thích hợp";
            this.lbNotFound.Visible = false;
            // 
            // lbLate
            // 
            this.lbLate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbLate.AutoSize = true;
            this.lbLate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbLate.ForeColor = System.Drawing.Color.Red;
            this.lbLate.Location = new System.Drawing.Point(630, 109);
            this.lbLate.Name = "lbLate";
            this.lbLate.Size = new System.Drawing.Size(119, 28);
            this.lbLate.TabIndex = 7;
            this.lbLate.Text = "*Đã quá hạn";
            this.lbLate.Visible = false;
            // 
            // cbReturnNull
            // 
            this.cbReturnNull.AutoSize = true;
            this.cbReturnNull.Location = new System.Drawing.Point(340, 111);
            this.cbReturnNull.Name = "cbReturnNull";
            this.cbReturnNull.Size = new System.Drawing.Size(120, 24);
            this.cbReturnNull.TabIndex = 8;
            this.cbReturnNull.Text = "Chưa trả sách";
            this.cbReturnNull.UseVisualStyleBackColor = true;
            this.cbReturnNull.CheckedChanged += new System.EventHandler(this.cbReturnNull_CheckedChanged);
            // 
            // frmLendingManager
            // 
            this.AcceptButton = this.btnMuon;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 624);
            this.ControlBox = false;
            this.Controls.Add(this.cbReturnNull);
            this.Controls.Add(this.lbLate);
            this.Controls.Add(this.lbNotFound);
            this.Controls.Add(this.gbStudentID);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.txtLendStudent);
            this.Controls.Add(this.lbSearch);
            this.Controls.Add(this.dgvBookLendingData);
            this.Controls.Add(this.btnReturnBook);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLendingManager";
            this.Text = "Trình cho mượn sách";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmLendingManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookLendingData)).EndInit();
            this.gbStudentID.ResumeLayout(false);
            this.gbStudentID.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnReturnBook;
        private DataGridView dgvBookLendingData;
        private Button btnMuon;
        private Label lbSearch;
        private TextBox txtLendStudent;
        private TextBox txtStudentID;
        private Label lbTitle;
        private GroupBox gbStudentID;
        private Label lbNotFound;
        private Label lbLate;
        private CheckBox cbReturnNull;
    }
}