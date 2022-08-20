
namespace PURCHASE
{
    partial class frmSearchSale
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearchSale));
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTenNV = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.DGV2 = new System.Windows.Forms.DataGridView();
            this.S_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.S_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DGV2)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMaNV
            // 
            resources.ApplyResources(this.txtMaNV, "txtMaNV");
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.TextChanged += new System.EventHandler(this.txtMaNV_TextChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Name = "label1";
            // 
            // txtTenNV
            // 
            resources.ApplyResources(this.txtTenNV, "txtTenNV");
            this.txtTenNV.Name = "txtTenNV";
            this.txtTenNV.TextChanged += new System.EventHandler(this.txtTenNV_TextChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label2.Name = "label2";
            // 
            // btnOk
            // 
            resources.ApplyResources(this.btnOk, "btnOk");
            this.btnOk.Name = "btnOk";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnDong
            // 
            resources.ApplyResources(this.btnDong, "btnDong");
            this.btnDong.Name = "btnDong";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // DGV2
            // 
            this.DGV2.AllowUserToAddRows = false;
            this.DGV2.AllowUserToDeleteRows = false;
            this.DGV2.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.DGV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.S_NO,
            this.S_NAME});
            this.DGV2.GridColor = System.Drawing.SystemColors.ButtonShadow;
            resources.ApplyResources(this.DGV2, "DGV2");
            this.DGV2.Name = "DGV2";
            this.DGV2.ReadOnly = true;
            this.DGV2.RowTemplate.Height = 28;
            this.DGV2.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV2_CellDoubleClick);
            // 
            // S_NO
            // 
            this.S_NO.DataPropertyName = "S_NO";
            resources.ApplyResources(this.S_NO, "S_NO");
            this.S_NO.Name = "S_NO";
            this.S_NO.ReadOnly = true;
            // 
            // S_NAME
            // 
            this.S_NAME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.S_NAME.DataPropertyName = "S_NAME";
            resources.ApplyResources(this.S_NAME, "S_NAME");
            this.S_NAME.Name = "S_NAME";
            this.S_NAME.ReadOnly = true;
            // 
            // frm2LF7_Sale
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DGV2);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTenNV);
            this.Controls.Add(this.txtMaNV);
            this.Name = "frm2LF7_Sale";
            this.Load += new System.EventHandler(this.frm2LF7_Sale_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTenNV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.DataGridView DGV2;
        private System.Windows.Forms.DataGridViewTextBoxColumn S_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn S_NAME;
    }
}