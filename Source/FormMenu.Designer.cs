namespace Source
{
    partial class FormMenu
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
            this.btnLopHoc = new System.Windows.Forms.Button();
            this.btnSinhVien = new System.Windows.Forms.Button();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnLopHoc
            // 
            this.btnLopHoc.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLopHoc.Location = new System.Drawing.Point(130, 76);
            this.btnLopHoc.Name = "btnLopHoc";
            this.btnLopHoc.Size = new System.Drawing.Size(75, 38);
            this.btnLopHoc.TabIndex = 0;
            this.btnLopHoc.Text = "Lớp học";
            this.btnLopHoc.UseVisualStyleBackColor = true;
            this.btnLopHoc.Click += new System.EventHandler(this.btnLopHoc_Click);
            // 
            // btnSinhVien
            // 
            this.btnSinhVien.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSinhVien.Location = new System.Drawing.Point(257, 76);
            this.btnSinhVien.Name = "btnSinhVien";
            this.btnSinhVien.Size = new System.Drawing.Size(75, 38);
            this.btnSinhVien.TabIndex = 1;
            this.btnSinhVien.Text = "Sinh viên";
            this.btnSinhVien.UseVisualStyleBackColor = true;
            // 
            // txtMaNV
            // 
            this.txtMaNV.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaNV.Location = new System.Drawing.Point(33, 12);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(100, 26);
            this.txtMaNV.TabIndex = 3;
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 144);
            this.Controls.Add(this.txtMaNV);
            this.Controls.Add(this.btnSinhVien);
            this.Controls.Add(this.btnLopHoc);
            this.Name = "FormMenu";
            this.Text = "FormMenu";
            this.Load += new System.EventHandler(this.FormMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLopHoc;
        private System.Windows.Forms.Button btnSinhVien;
        private System.Windows.Forms.TextBox txtMaNV;
    }
}