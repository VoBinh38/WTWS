﻿
namespace PURCHASE.MAINCODE.Search
{
    partial class SearchVENDC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchVENDC));
            this.txtC_NO = new System.Windows.Forms.TextBox();
            this.txtC_NAME = new System.Windows.Forms.TextBox();
            this.lbC_NO = new System.Windows.Forms.Label();
            this.lbC_NAME = new System.Windows.Forms.Label();
            this.btok = new System.Windows.Forms.Button();
            this.btdong = new System.Windows.Forms.Button();
            this.btnUnSelectAll = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.DGV1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.C_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BOSS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SPEAK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ACCOUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TEL1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DGV1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtC_NO
            // 
            this.txtC_NO.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtC_NO.Location = new System.Drawing.Point(242, 8);
            this.txtC_NO.Name = "txtC_NO";
            this.txtC_NO.Size = new System.Drawing.Size(309, 30);
            this.txtC_NO.TabIndex = 0;
            this.txtC_NO.TextChanged += new System.EventHandler(this.txtC_NO_TextChanged);
            // 
            // txtC_NAME
            // 
            this.txtC_NAME.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtC_NAME.Location = new System.Drawing.Point(242, 47);
            this.txtC_NAME.Name = "txtC_NAME";
            this.txtC_NAME.Size = new System.Drawing.Size(309, 30);
            this.txtC_NAME.TabIndex = 0;
            this.txtC_NAME.TextChanged += new System.EventHandler(this.txtC_NAME_TextChanged);
            // 
            // lbC_NO
            // 
            this.lbC_NO.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbC_NO.Location = new System.Drawing.Point(12, 11);
            this.lbC_NO.Name = "lbC_NO";
            this.lbC_NO.Size = new System.Drawing.Size(224, 27);
            this.lbC_NO.TabIndex = 1;
            this.lbC_NO.Text = "Số nhà sản xuất";
            this.lbC_NO.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbC_NAME
            // 
            this.lbC_NAME.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbC_NAME.Location = new System.Drawing.Point(12, 49);
            this.lbC_NAME.Name = "lbC_NAME";
            this.lbC_NAME.Size = new System.Drawing.Size(224, 27);
            this.lbC_NAME.TabIndex = 1;
            this.lbC_NAME.Text = "Tên nhà sản xuất";
            this.lbC_NAME.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btok
            // 
            this.btok.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.btok.Image = ((System.Drawing.Image)(resources.GetObject("btok.Image")));
            this.btok.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btok.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btok.Location = new System.Drawing.Point(939, 19);
            this.btok.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btok.Name = "btok";
            this.btok.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btok.Size = new System.Drawing.Size(176, 41);
            this.btok.TabIndex = 344;
            this.btok.Text = "OK";
            this.btok.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btok.UseVisualStyleBackColor = true;
            this.btok.Click += new System.EventHandler(this.btok_Click);
            // 
            // btdong
            // 
            this.btdong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.btdong.Image = ((System.Drawing.Image)(resources.GetObject("btdong.Image")));
            this.btdong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btdong.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btdong.Location = new System.Drawing.Point(1121, 19);
            this.btdong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btdong.Name = "btdong";
            this.btdong.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btdong.Size = new System.Drawing.Size(189, 41);
            this.btdong.TabIndex = 345;
            this.btdong.Text = "Đóng";
            this.btdong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btdong.UseVisualStyleBackColor = true;
            this.btdong.Click += new System.EventHandler(this.btdong_Click);
            // 
            // btnUnSelectAll
            // 
            this.btnUnSelectAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.btnUnSelectAll.Image = ((System.Drawing.Image)(resources.GetObject("btnUnSelectAll.Image")));
            this.btnUnSelectAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUnSelectAll.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnUnSelectAll.Location = new System.Drawing.Point(763, 19);
            this.btnUnSelectAll.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUnSelectAll.Name = "btnUnSelectAll";
            this.btnUnSelectAll.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnUnSelectAll.Size = new System.Drawing.Size(170, 41);
            this.btnUnSelectAll.TabIndex = 345;
            this.btnUnSelectAll.Text = "Bỏ chọn";
            this.btnUnSelectAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUnSelectAll.UseVisualStyleBackColor = true;
            this.btnUnSelectAll.Click += new System.EventHandler(this.btnUnSelectAll_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.btnSelectAll.Image = ((System.Drawing.Image)(resources.GetObject("btnSelectAll.Image")));
            this.btnSelectAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelectAll.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSelectAll.Location = new System.Drawing.Point(572, 19);
            this.btnSelectAll.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnSelectAll.Size = new System.Drawing.Size(185, 41);
            this.btnSelectAll.TabIndex = 344;
            this.btnSelectAll.Text = "Chọn tất cả";
            this.btnSelectAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // DGV1
            // 
            this.DGV1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.C_NO,
            this.C_NAME,
            this.BOSS,
            this.SPEAK,
            this.ACCOUNT,
            this.NUMBER,
            this.TEL1});
            this.DGV1.Location = new System.Drawing.Point(12, 87);
            this.DGV1.Name = "DGV1";
            this.DGV1.RowHeadersWidth = 51;
            this.DGV1.RowTemplate.Height = 24;
            this.DGV1.Size = new System.Drawing.Size(1298, 587);
            this.DGV1.TabIndex = 346;
            this.DGV1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGV1_CellMouseDoubleClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Chon";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 125;
            // 
            // C_NO
            // 
            this.C_NO.DataPropertyName = "C_NO";
            this.C_NO.HeaderText = "C_NO";
            this.C_NO.MinimumWidth = 6;
            this.C_NO.Name = "C_NO";
            this.C_NO.Width = 125;
            // 
            // C_NAME
            // 
            this.C_NAME.DataPropertyName = "C_NAME";
            this.C_NAME.HeaderText = "C_NAME";
            this.C_NAME.MinimumWidth = 6;
            this.C_NAME.Name = "C_NAME";
            this.C_NAME.Width = 125;
            // 
            // BOSS
            // 
            this.BOSS.DataPropertyName = "BOSS";
            this.BOSS.HeaderText = "BOSS";
            this.BOSS.MinimumWidth = 6;
            this.BOSS.Name = "BOSS";
            this.BOSS.Width = 125;
            // 
            // SPEAK
            // 
            this.SPEAK.DataPropertyName = "SPEAK";
            this.SPEAK.HeaderText = "SPEAK";
            this.SPEAK.MinimumWidth = 6;
            this.SPEAK.Name = "SPEAK";
            this.SPEAK.Width = 125;
            // 
            // ACCOUNT
            // 
            this.ACCOUNT.DataPropertyName = "ACCOUNT";
            this.ACCOUNT.HeaderText = "ACCOUNT";
            this.ACCOUNT.MinimumWidth = 6;
            this.ACCOUNT.Name = "ACCOUNT";
            this.ACCOUNT.Width = 125;
            // 
            // NUMBER
            // 
            this.NUMBER.DataPropertyName = "NUMBER";
            this.NUMBER.HeaderText = "NUMBER";
            this.NUMBER.MinimumWidth = 6;
            this.NUMBER.Name = "NUMBER";
            this.NUMBER.Width = 125;
            // 
            // TEL1
            // 
            this.TEL1.DataPropertyName = "TEL1";
            this.TEL1.HeaderText = "TEL1";
            this.TEL1.MinimumWidth = 6;
            this.TEL1.Name = "TEL1";
            this.TEL1.Width = 125;
            // 
            // SearchVENDC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1322, 682);
            this.Controls.Add(this.DGV1);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.btnUnSelectAll);
            this.Controls.Add(this.btok);
            this.Controls.Add(this.btdong);
            this.Controls.Add(this.lbC_NAME);
            this.Controls.Add(this.lbC_NO);
            this.Controls.Add(this.txtC_NAME);
            this.Controls.Add(this.txtC_NO);
            this.Name = "SearchVENDC";
            this.Text = "SearchVENDC";
            this.Load += new System.EventHandler(this.SearchVENDC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtC_NO;
        private System.Windows.Forms.TextBox txtC_NAME;
        private System.Windows.Forms.Label lbC_NO;
        private System.Windows.Forms.Label lbC_NAME;
        private System.Windows.Forms.Button btok;
        private System.Windows.Forms.Button btdong;
        private System.Windows.Forms.Button btnUnSelectAll;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.DataGridView DGV1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn BOSS;
        private System.Windows.Forms.DataGridViewTextBoxColumn SPEAK;
        private System.Windows.Forms.DataGridViewTextBoxColumn ACCOUNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn NUMBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn TEL1;
    }
}