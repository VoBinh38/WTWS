﻿
namespace PURCHASE.MAINCODE.Modun4.Search
{
    partial class SearchDEPT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchDEPT));
            this.lbDEPT_NO = new System.Windows.Forms.Label();
            this.lbDEPT_NAME = new System.Windows.Forms.Label();
            this.txtDEPT_NO = new System.Windows.Forms.TextBox();
            this.txtDEPT_NAME = new System.Windows.Forms.TextBox();
            this.DGV1 = new System.Windows.Forms.DataGridView();
            this.DEPT_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DEPT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnok = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGV1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbDEPT_NO
            // 
            this.lbDEPT_NO.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDEPT_NO.ForeColor = System.Drawing.Color.Brown;
            this.lbDEPT_NO.Location = new System.Drawing.Point(22, 14);
            this.lbDEPT_NO.Name = "lbDEPT_NO";
            this.lbDEPT_NO.Size = new System.Drawing.Size(144, 29);
            this.lbDEPT_NO.TabIndex = 0;
            this.lbDEPT_NO.Text = "Mã bộ phận";
            this.lbDEPT_NO.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbDEPT_NAME
            // 
            this.lbDEPT_NAME.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDEPT_NAME.ForeColor = System.Drawing.Color.Brown;
            this.lbDEPT_NAME.Location = new System.Drawing.Point(17, 64);
            this.lbDEPT_NAME.Name = "lbDEPT_NAME";
            this.lbDEPT_NAME.Size = new System.Drawing.Size(149, 29);
            this.lbDEPT_NAME.TabIndex = 1;
            this.lbDEPT_NAME.Text = "Tên bộ phận";
            this.lbDEPT_NAME.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDEPT_NO
            // 
            this.txtDEPT_NO.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDEPT_NO.Location = new System.Drawing.Point(181, 11);
            this.txtDEPT_NO.Name = "txtDEPT_NO";
            this.txtDEPT_NO.Size = new System.Drawing.Size(239, 30);
            this.txtDEPT_NO.TabIndex = 2;
            this.txtDEPT_NO.TextChanged += new System.EventHandler(this.txtDEPT_NO_TextChanged);
            // 
            // txtDEPT_NAME
            // 
            this.txtDEPT_NAME.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDEPT_NAME.Location = new System.Drawing.Point(181, 61);
            this.txtDEPT_NAME.Name = "txtDEPT_NAME";
            this.txtDEPT_NAME.Size = new System.Drawing.Size(239, 30);
            this.txtDEPT_NAME.TabIndex = 3;
            this.txtDEPT_NAME.TextChanged += new System.EventHandler(this.txtDEPT_NAME_TextChanged);
            // 
            // DGV1
            // 
            this.DGV1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DEPT_NO,
            this.DEPT_NAME});
            this.DGV1.Location = new System.Drawing.Point(17, 116);
            this.DGV1.Name = "DGV1";
            this.DGV1.RowHeadersWidth = 51;
            this.DGV1.RowTemplate.Height = 24;
            this.DGV1.Size = new System.Drawing.Size(685, 533);
            this.DGV1.TabIndex = 4;
            this.DGV1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGV1_CellMouseDoubleClick);
            // 
            // DEPT_NO
            // 
            this.DEPT_NO.DataPropertyName = "DEPT_NO";
            this.DEPT_NO.HeaderText = "Mã bộ phận";
            this.DEPT_NO.MinimumWidth = 6;
            this.DEPT_NO.Name = "DEPT_NO";
            this.DEPT_NO.Width = 125;
            // 
            // DEPT_NAME
            // 
            this.DEPT_NAME.DataPropertyName = "DEPT_NAME";
            this.DEPT_NAME.HeaderText = "Tên bộ phận";
            this.DEPT_NAME.MinimumWidth = 6;
            this.DEPT_NAME.Name = "DEPT_NAME";
            this.DEPT_NAME.Width = 125;
            // 
            // btnok
            // 
            this.btnok.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.btnok.Image = ((System.Drawing.Image)(resources.GetObject("btnok.Image")));
            this.btnok.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnok.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnok.Location = new System.Drawing.Point(426, 11);
            this.btnok.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnok.Name = "btnok";
            this.btnok.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnok.Size = new System.Drawing.Size(131, 44);
            this.btnok.TabIndex = 308;
            this.btnok.Text = "確定(O)";
            this.btnok.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnok.UseVisualStyleBackColor = true;
            this.btnok.Click += new System.EventHandler(this.btnok_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(563, 11);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnClose.Size = new System.Drawing.Size(139, 44);
            this.btnClose.TabIndex = 317;
            this.btnClose.Text = "放棄[C] ";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button1.Location = new System.Drawing.Point(563, 64);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.button1.Size = new System.Drawing.Size(139, 44);
            this.button1.TabIndex = 318;
            this.button1.Text = "新增(A)";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // SearchDEPT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 658);
            this.Controls.Add(this.txtDEPT_NO);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnok);
            this.Controls.Add(this.DGV1);
            this.Controls.Add(this.txtDEPT_NAME);
            this.Controls.Add(this.lbDEPT_NAME);
            this.Controls.Add(this.lbDEPT_NO);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SearchDEPT";
            this.Text = "Tìm kiếm bộ phận";
            this.Load += new System.EventHandler(this.SearchDEPT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbDEPT_NO;
        private System.Windows.Forms.Label lbDEPT_NAME;
        private System.Windows.Forms.TextBox txtDEPT_NO;
        private System.Windows.Forms.TextBox txtDEPT_NAME;
        private System.Windows.Forms.DataGridView DGV1;
        private System.Windows.Forms.Button btnok;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DEPT_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DEPT_NAME;
    }
}