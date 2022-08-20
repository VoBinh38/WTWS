
namespace PURCHASE
{
    partial class Form1CF5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1CF5));
            this.label1 = new System.Windows.Forms.Label();
            this.tb1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tb4 = new System.Windows.Forms.TextBox();
            this.btok = new System.Windows.Forms.Button();
            this.btdong = new System.Windows.Forms.Button();
            this.Data1CF5 = new System.Windows.Forms.DataGridView();
            this.P_NAME1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UNIT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_NAME3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_NAME2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRICE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bttk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Data1CF5)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Name = "label1";
            // 
            // tb1
            // 
            resources.ApplyResources(this.tb1, "tb1");
            this.tb1.Name = "tb1";
            this.tb1.TextChanged += new System.EventHandler(this.tb1_TextChanged);
            this.tb1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb1_KeyDown);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label2.Name = "label2";
            // 
            // tb2
            // 
            resources.ApplyResources(this.tb2, "tb2");
            this.tb2.Name = "tb2";
            this.tb2.TextChanged += new System.EventHandler(this.tb2_TextChanged);
            this.tb2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb2_KeyDown);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label3.Name = "label3";
            // 
            // tb3
            // 
            resources.ApplyResources(this.tb3, "tb3");
            this.tb3.Name = "tb3";
            this.tb3.TextChanged += new System.EventHandler(this.tb3_TextChanged);
            this.tb3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb3_KeyDown);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label4.Name = "label4";
            // 
            // tb4
            // 
            resources.ApplyResources(this.tb4, "tb4");
            this.tb4.Name = "tb4";
            this.tb4.TextChanged += new System.EventHandler(this.tb4_TextChanged);
            this.tb4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb4_KeyDown);
            // 
            // btok
            // 
            resources.ApplyResources(this.btok, "btok");
            this.btok.ForeColor = System.Drawing.Color.Black;
            this.btok.Name = "btok";
            this.btok.UseVisualStyleBackColor = true;
            this.btok.Click += new System.EventHandler(this.btok_Click);
            // 
            // btdong
            // 
            resources.ApplyResources(this.btdong, "btdong");
            this.btdong.ForeColor = System.Drawing.Color.Black;
            this.btdong.Name = "btdong";
            this.btdong.UseVisualStyleBackColor = true;
            this.btdong.Click += new System.EventHandler(this.btdong_Click);
            // 
            // Data1CF5
            // 
            this.Data1CF5.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.Data1CF5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Data1CF5.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.P_NAME1,
            this.P_NO,
            this.UNIT,
            this.P_NAME3,
            this.P_NAME2,
            this.PRICE});
            resources.ApplyResources(this.Data1CF5, "Data1CF5");
            this.Data1CF5.Name = "Data1CF5";
            this.Data1CF5.RowTemplate.Height = 28;
            this.Data1CF5.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Data1CF5.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Data1CF5_CellMouseDoubleClick);
            // 
            // P_NAME1
            // 
            this.P_NAME1.DataPropertyName = "P_NAME1";
            resources.ApplyResources(this.P_NAME1, "P_NAME1");
            this.P_NAME1.Name = "P_NAME1";
            // 
            // P_NO
            // 
            this.P_NO.DataPropertyName = "P_NO";
            resources.ApplyResources(this.P_NO, "P_NO");
            this.P_NO.Name = "P_NO";
            // 
            // UNIT
            // 
            this.UNIT.DataPropertyName = "UNIT";
            resources.ApplyResources(this.UNIT, "UNIT");
            this.UNIT.Name = "UNIT";
            // 
            // P_NAME3
            // 
            this.P_NAME3.DataPropertyName = "P_NAME3";
            resources.ApplyResources(this.P_NAME3, "P_NAME3");
            this.P_NAME3.Name = "P_NAME3";
            // 
            // P_NAME2
            // 
            this.P_NAME2.DataPropertyName = "P_NAME2";
            resources.ApplyResources(this.P_NAME2, "P_NAME2");
            this.P_NAME2.Name = "P_NAME2";
            // 
            // PRICE
            // 
            this.PRICE.DataPropertyName = "PRICE";
            resources.ApplyResources(this.PRICE, "PRICE");
            this.PRICE.Name = "PRICE";
            // 
            // bttk
            // 
            resources.ApplyResources(this.bttk, "bttk");
            this.bttk.ForeColor = System.Drawing.Color.Black;
            this.bttk.Name = "bttk";
            this.bttk.UseVisualStyleBackColor = true;
            this.bttk.Click += new System.EventHandler(this.bttk_Click);
            // 
            // Form1CF5
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bttk);
            this.Controls.Add(this.Data1CF5);
            this.Controls.Add(this.btdong);
            this.Controls.Add(this.btok);
            this.Controls.Add(this.tb4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb1);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "Form1CF5";
            this.Load += new System.EventHandler(this.Form1CF5timkiemdulieusanpham_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Data1CF5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb4;
        private System.Windows.Forms.Button btok;
        private System.Windows.Forms.Button btdong;
        private System.Windows.Forms.DataGridView Data1CF5;
        private System.Windows.Forms.Button bttk;
        private System.Windows.Forms.DataGridViewTextBoxColumn P_NAME1;
        private System.Windows.Forms.DataGridViewTextBoxColumn P_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn UNIT;
        private System.Windows.Forms.DataGridViewTextBoxColumn P_NAME3;
        private System.Windows.Forms.DataGridViewTextBoxColumn P_NAME2;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRICE;
    }
}