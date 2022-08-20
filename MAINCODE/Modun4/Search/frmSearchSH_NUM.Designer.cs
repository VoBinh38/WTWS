
namespace PURCHASE.MAINCODE.Modun4.Search
{
    partial class frmSearchSH_NUM
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearchSH_NUM));
            this.DGV1 = new System.Windows.Forms.DataGridView();
            this.SH_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SH_NUM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnok = new System.Windows.Forms.Button();
            this.btnUpdata = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGV1)).BeginInit();
            this.SuspendLayout();
            // 
            // DGV1
            // 
            this.DGV1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SH_NO,
            this.SH_NUM});
            this.DGV1.Location = new System.Drawing.Point(12, 12);
            this.DGV1.Name = "DGV1";
            this.DGV1.RowHeadersWidth = 51;
            this.DGV1.RowTemplate.Height = 24;
            this.DGV1.Size = new System.Drawing.Size(520, 834);
            this.DGV1.TabIndex = 0;
            // 
            // SH_NO
            // 
            this.SH_NO.DataPropertyName = "SH_NO";
            this.SH_NO.HeaderText = "Số Seri";
            this.SH_NO.MinimumWidth = 6;
            this.SH_NO.Name = "SH_NO";
            this.SH_NO.Width = 125;
            // 
            // SH_NUM
            // 
            this.SH_NUM.DataPropertyName = "SH_NUM";
            this.SH_NUM.HeaderText = "Đã sử dụng C/NO";
            this.SH_NUM.MinimumWidth = 6;
            this.SH_NUM.Name = "SH_NUM";
            this.SH_NUM.Width = 125;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(688, 276);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnClose.Size = new System.Drawing.Size(180, 52);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Đóng [&C]";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnok
            // 
            this.btnok.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnok.ForeColor = System.Drawing.Color.Black;
            this.btnok.Image = ((System.Drawing.Image)(resources.GetObject("btnok.Image")));
            this.btnok.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnok.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnok.Location = new System.Drawing.Point(688, 129);
            this.btnok.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnok.Name = "btnok";
            this.btnok.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnok.Size = new System.Drawing.Size(180, 52);
            this.btnok.TabIndex = 9;
            this.btnok.Text = "OK [&O]";
            this.btnok.UseVisualStyleBackColor = true;
            // 
            // btnUpdata
            // 
            this.btnUpdata.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnUpdata.ForeColor = System.Drawing.Color.Black;
            this.btnUpdata.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdata.Image")));
            this.btnUpdata.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdata.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnUpdata.Location = new System.Drawing.Point(688, 421);
            this.btnUpdata.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUpdata.Name = "btnUpdata";
            this.btnUpdata.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnUpdata.Size = new System.Drawing.Size(180, 52);
            this.btnUpdata.TabIndex = 10;
            this.btnUpdata.Text = "Sửa đổi";
            this.btnUpdata.UseVisualStyleBackColor = true;
            // 
            // frmSearchSH_NUM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 858);
            this.Controls.Add(this.btnUpdata);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnok);
            this.Controls.Add(this.DGV1);
            this.Name = "frmSearchSH_NUM";
            this.Text = "frmSearchSH_NUM";
            this.Load += new System.EventHandler(this.frmSearchSH_NUM_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SH_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn SH_NUM;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnok;
        private System.Windows.Forms.Button btnUpdata;
    }
}