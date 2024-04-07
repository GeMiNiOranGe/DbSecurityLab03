namespace Source
{
    partial class FormInputPoints
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbMaSV = new System.Windows.Forms.TextBox();
            this.tbHP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rtbDiemThi = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtgvPoints = new System.Windows.Forms.DataGridView();
            this.MaSV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaHP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvPoints)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Update Points";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.rtbDiemThi);
            this.panel1.Controls.Add(this.tbHP);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.tbMaSV);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Location = new System.Drawing.Point(221, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(553, 168);
            this.panel1.TabIndex = 2;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(217, 126);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "MaSV:";
            // 
            // tbMaSV
            // 
            this.tbMaSV.Location = new System.Drawing.Point(75, 22);
            this.tbMaSV.Name = "tbMaSV";
            this.tbMaSV.ReadOnly = true;
            this.tbMaSV.Size = new System.Drawing.Size(100, 20);
            this.tbMaSV.TabIndex = 4;
            // 
            // tbHP
            // 
            this.tbHP.Location = new System.Drawing.Point(75, 68);
            this.tbHP.Name = "tbHP";
            this.tbHP.ReadOnly = true;
            this.tbHP.Size = new System.Drawing.Size(100, 20);
            this.tbHP.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "MaHP:";
            // 
            // rtbDiemThi
            // 
            this.rtbDiemThi.Location = new System.Drawing.Point(318, 36);
            this.rtbDiemThi.Name = "rtbDiemThi";
            this.rtbDiemThi.Size = new System.Drawing.Size(110, 26);
            this.rtbDiemThi.TabIndex = 7;
            this.rtbDiemThi.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(260, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Điểm Thi:";
            // 
            // dtgvPoints
            // 
            this.dtgvPoints.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvPoints.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaSV,
            this.MaHP});
            this.dtgvPoints.Location = new System.Drawing.Point(221, 242);
            this.dtgvPoints.Name = "dtgvPoints";
            this.dtgvPoints.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvPoints.Size = new System.Drawing.Size(553, 204);
            this.dtgvPoints.TabIndex = 3;
            this.dtgvPoints.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvPoints_CellContentClick);
            // 
            // MaSV
            // 
            this.MaSV.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MaSV.DataPropertyName = "MaSV";
            this.MaSV.HeaderText = "Mã Sinh Viên";
            this.MaSV.Name = "MaSV";
            this.MaSV.ReadOnly = true;
            // 
            // MaHP
            // 
            this.MaHP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MaHP.DataPropertyName = "MaHP";
            this.MaHP.HeaderText = "Mã Học Phần";
            this.MaHP.Name = "MaHP";
            this.MaHP.ReadOnly = true;
            // 
            // FormInputPoints
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 479);
            this.Controls.Add(this.dtgvPoints);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "FormInputPoints";
            this.Text = "FormInputPoints";
            this.Load += new System.EventHandler(this.FormInputPoints_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvPoints)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox rtbDiemThi;
        private System.Windows.Forms.TextBox tbHP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbMaSV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dtgvPoints;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaSV;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHP;
    }
}