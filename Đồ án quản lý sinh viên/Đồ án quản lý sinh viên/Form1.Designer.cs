namespace Đồ_án_quản_lý_sinh_viên
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnQLNganh = new System.Windows.Forms.Button();
            this.btnQLLopHoc = new System.Windows.Forms.Button();
            this.panelClick = new System.Windows.Forms.Panel();
            this.btQLSV = new System.Windows.Forms.Button();
            this.btnGioiThieu = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.pictureClose = new System.Windows.Forms.PictureBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.panelConatainer = new System.Windows.Forms.Panel();
            this.btnTimKiemSV = new System.Windows.Forms.Button();
            this.timKiemSinhVienUC1 = new Đồ_án_quản_lý_sinh_viên.UserControls.TimKiemSinhVienUC();
            this.quanLyNganhUC1 = new Đồ_án_quản_lý_sinh_viên.UserControls.QuanLyNganhUC();
            this.quanLyLopHocUC1 = new Đồ_án_quản_lý_sinh_viên.UserControls.QuanLyLopHocUC();
            this.quanLySinhVienUC1 = new Đồ_án_quản_lý_sinh_viên.UserControls.QuanLySinhVienUC();
            this.gioiThieuUC1 = new Đồ_án_quản_lý_sinh_viên.UserControls.GioiThieuUC();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureClose)).BeginInit();
            this.panelConatainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(25)))), ((int)(((byte)(150)))));
            this.panel1.Controls.Add(this.btnXuatExcel);
            this.panel1.Controls.Add(this.btnTimKiemSV);
            this.panel1.Controls.Add(this.btnQLNganh);
            this.panel1.Controls.Add(this.btnQLLopHoc);
            this.panel1.Controls.Add(this.panelClick);
            this.panel1.Controls.Add(this.btQLSV);
            this.panel1.Controls.Add(this.btnGioiThieu);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(263, 727);
            this.panel1.TabIndex = 0;
            // 
            // btnQLNganh
            // 
            this.btnQLNganh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQLNganh.FlatAppearance.BorderSize = 0;
            this.btnQLNganh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQLNganh.ForeColor = System.Drawing.Color.White;
            this.btnQLNganh.Location = new System.Drawing.Point(0, 373);
            this.btnQLNganh.Name = "btnQLNganh";
            this.btnQLNganh.Size = new System.Drawing.Size(263, 60);
            this.btnQLNganh.TabIndex = 4;
            this.btnQLNganh.Text = "Quản lý ngành";
            this.btnQLNganh.UseVisualStyleBackColor = true;
            this.btnQLNganh.Click += new System.EventHandler(this.btnQLNganh_Click);
            // 
            // btnQLLopHoc
            // 
            this.btnQLLopHoc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQLLopHoc.FlatAppearance.BorderSize = 0;
            this.btnQLLopHoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQLLopHoc.ForeColor = System.Drawing.Color.White;
            this.btnQLLopHoc.Location = new System.Drawing.Point(0, 307);
            this.btnQLLopHoc.Name = "btnQLLopHoc";
            this.btnQLLopHoc.Size = new System.Drawing.Size(263, 60);
            this.btnQLLopHoc.TabIndex = 3;
            this.btnQLLopHoc.Text = "Quản lý lớp học";
            this.btnQLLopHoc.UseVisualStyleBackColor = true;
            this.btnQLLopHoc.Click += new System.EventHandler(this.btnQLLopHoc_Click);
            // 
            // panelClick
            // 
            this.panelClick.BackColor = System.Drawing.Color.White;
            this.panelClick.Location = new System.Drawing.Point(0, 175);
            this.panelClick.Name = "panelClick";
            this.panelClick.Size = new System.Drawing.Size(13, 60);
            this.panelClick.TabIndex = 2;
            // 
            // btQLSV
            // 
            this.btQLSV.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btQLSV.FlatAppearance.BorderSize = 0;
            this.btQLSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btQLSV.ForeColor = System.Drawing.Color.White;
            this.btQLSV.Location = new System.Drawing.Point(-3, 241);
            this.btQLSV.Name = "btQLSV";
            this.btQLSV.Size = new System.Drawing.Size(263, 60);
            this.btQLSV.TabIndex = 1;
            this.btQLSV.Text = "Quản lý sinh viên";
            this.btQLSV.UseVisualStyleBackColor = true;
            this.btQLSV.Click += new System.EventHandler(this.btQLSV_Click);
            // 
            // btnGioiThieu
            // 
            this.btnGioiThieu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGioiThieu.FlatAppearance.BorderSize = 0;
            this.btnGioiThieu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGioiThieu.ForeColor = System.Drawing.Color.White;
            this.btnGioiThieu.Location = new System.Drawing.Point(0, 175);
            this.btnGioiThieu.Name = "btnGioiThieu";
            this.btnGioiThieu.Size = new System.Drawing.Size(263, 60);
            this.btnGioiThieu.TabIndex = 0;
            this.btnGioiThieu.Text = "Giới Thiệu";
            this.btnGioiThieu.UseVisualStyleBackColor = true;
            this.btnGioiThieu.Click += new System.EventHandler(this.btnGioiThieu_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(25)))), ((int)(((byte)(200)))));
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(263, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1143, 27);
            this.panel2.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(1083, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.pictureClose);
            this.panelHeader.Controls.Add(this.labelTitle);
            this.panelHeader.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(263, 27);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1143, 55);
            this.panelHeader.TabIndex = 2;
            // 
            // pictureClose
            // 
            this.pictureClose.Image = ((System.Drawing.Image)(resources.GetObject("pictureClose.Image")));
            this.pictureClose.Location = new System.Drawing.Point(1083, 1);
            this.pictureClose.Name = "pictureClose";
            this.pictureClose.Size = new System.Drawing.Size(50, 46);
            this.pictureClose.TabIndex = 1;
            this.pictureClose.TabStop = false;
            this.pictureClose.Click += new System.EventHandler(this.pictureClose_Click);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.Black;
            this.labelTitle.Location = new System.Drawing.Point(19, 16);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(122, 26);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Giới Thiệu";
            // 
            // panelConatainer
            // 
            this.panelConatainer.BackColor = System.Drawing.Color.White;
            this.panelConatainer.Controls.Add(this.timKiemSinhVienUC1);
            this.panelConatainer.Controls.Add(this.quanLyNganhUC1);
            this.panelConatainer.Controls.Add(this.quanLyLopHocUC1);
            this.panelConatainer.Controls.Add(this.quanLySinhVienUC1);
            this.panelConatainer.Controls.Add(this.gioiThieuUC1);
            this.panelConatainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelConatainer.Location = new System.Drawing.Point(263, 82);
            this.panelConatainer.Name = "panelConatainer";
            this.panelConatainer.Size = new System.Drawing.Size(1143, 645);
            this.panelConatainer.TabIndex = 1;
            // 
            // btnTimKiemSV
            // 
            this.btnTimKiemSV.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTimKiemSV.FlatAppearance.BorderSize = 0;
            this.btnTimKiemSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiemSV.ForeColor = System.Drawing.Color.White;
            this.btnTimKiemSV.Location = new System.Drawing.Point(0, 439);
            this.btnTimKiemSV.Name = "btnTimKiemSV";
            this.btnTimKiemSV.Size = new System.Drawing.Size(263, 60);
            this.btnTimKiemSV.TabIndex = 5;
            this.btnTimKiemSV.Text = "Tìm kiếm sinh viên";
            this.btnTimKiemSV.UseVisualStyleBackColor = true;
            this.btnTimKiemSV.Click += new System.EventHandler(this.btnTimKiemSV_Click);
            // 
            // timKiemSinhVienUC1
            // 
            this.timKiemSinhVienUC1.BackColor = System.Drawing.Color.White;
            this.timKiemSinhVienUC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timKiemSinhVienUC1.Location = new System.Drawing.Point(0, 0);
            this.timKiemSinhVienUC1.Name = "timKiemSinhVienUC1";
            this.timKiemSinhVienUC1.Size = new System.Drawing.Size(1143, 645);
            this.timKiemSinhVienUC1.TabIndex = 4;
            // 
            // quanLyNganhUC1
            // 
            this.quanLyNganhUC1.BackColor = System.Drawing.Color.White;
            this.quanLyNganhUC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.quanLyNganhUC1.Location = new System.Drawing.Point(0, 0);
            this.quanLyNganhUC1.Margin = new System.Windows.Forms.Padding(5);
            this.quanLyNganhUC1.Name = "quanLyNganhUC1";
            this.quanLyNganhUC1.Size = new System.Drawing.Size(1143, 645);
            this.quanLyNganhUC1.TabIndex = 3;
            // 
            // quanLyLopHocUC1
            // 
            this.quanLyLopHocUC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.quanLyLopHocUC1.Location = new System.Drawing.Point(0, 0);
            this.quanLyLopHocUC1.Margin = new System.Windows.Forms.Padding(5);
            this.quanLyLopHocUC1.Name = "quanLyLopHocUC1";
            this.quanLyLopHocUC1.Size = new System.Drawing.Size(1143, 645);
            this.quanLyLopHocUC1.TabIndex = 2;
            // 
            // quanLySinhVienUC1
            // 
            this.quanLySinhVienUC1.BackColor = System.Drawing.Color.White;
            this.quanLySinhVienUC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.quanLySinhVienUC1.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quanLySinhVienUC1.Location = new System.Drawing.Point(0, 0);
            this.quanLySinhVienUC1.Name = "quanLySinhVienUC1";
            this.quanLySinhVienUC1.Size = new System.Drawing.Size(1143, 645);
            this.quanLySinhVienUC1.TabIndex = 1;
            this.quanLySinhVienUC1.Load += new System.EventHandler(this.quanLySinhVienUC1_Load);
            // 
            // gioiThieuUC1
            // 
            this.gioiThieuUC1.BackColor = System.Drawing.Color.White;
            this.gioiThieuUC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gioiThieuUC1.Location = new System.Drawing.Point(0, 0);
            this.gioiThieuUC1.Margin = new System.Windows.Forms.Padding(5);
            this.gioiThieuUC1.Name = "gioiThieuUC1";
            this.gioiThieuUC1.Size = new System.Drawing.Size(1143, 645);
            this.gioiThieuUC1.TabIndex = 0;
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXuatExcel.FlatAppearance.BorderSize = 0;
            this.btnXuatExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuatExcel.ForeColor = System.Drawing.Color.White;
            this.btnXuatExcel.Location = new System.Drawing.Point(0, 505);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(263, 60);
            this.btnXuatExcel.TabIndex = 6;
            this.btnXuatExcel.Text = "Xuất file Excel";
            this.btnXuatExcel.UseVisualStyleBackColor = true;
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1406, 727);
            this.Controls.Add(this.panelConatainer);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureClose)).EndInit();
            this.panelConatainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btQLSV;
        private System.Windows.Forms.Button btnGioiThieu;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Panel panelConatainer;
        private UserControls.GioiThieuUC gioiThieuUC1;
        private UserControls.QuanLySinhVienUC quanLySinhVienUC1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureClose;
        private System.Windows.Forms.Panel panelClick;
        private System.Windows.Forms.Button btnQLLopHoc;
        private UserControls.QuanLyLopHocUC quanLyLopHocUC1;
        private System.Windows.Forms.Button btnQLNganh;
        private UserControls.QuanLyNganhUC quanLyNganhUC1;
        private System.Windows.Forms.Button btnTimKiemSV;
        private UserControls.TimKiemSinhVienUC timKiemSinhVienUC1;
        private System.Windows.Forms.Button btnXuatExcel;
    }
}

