
namespace PURCHASE
{
    partial class FormSeachKIND1C
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSeachKIND1C));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb1 = new System.Windows.Forms.TextBox();
            this.tb2 = new System.Windows.Forms.TextBox();
            this.dataGridViewKIND1C = new System.Windows.Forms.DataGridView();
            this.K_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.K_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btdong = new System.Windows.Forms.Button();
            this.btok = new System.Windows.Forms.Button();
            this.bttk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKIND1C)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label2.Name = "label2";
            // 
            // tb1
            // 
            resources.ApplyResources(this.tb1, "tb1");
            this.tb1.Name = "tb1";
            this.tb1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb1_KeyDown);
            // 
            // tb2
            // 
            resources.ApplyResources(this.tb2, "tb2");
            this.tb2.Name = "tb2";
            this.tb2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb2_KeyDown);
            // 
            // dataGridViewKIND1C
            // 
            this.dataGridViewKIND1C.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridViewKIND1C.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewKIND1C.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.K_NO,
            this.K_NAME});
            resources.ApplyResources(this.dataGridViewKIND1C, "dataGridViewKIND1C");
            this.dataGridViewKIND1C.Name = "dataGridViewKIND1C";
            this.dataGridViewKIND1C.RowTemplate.Height = 28;
            this.dataGridViewKIND1C.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewKIND1C.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewKIND1C_CellMouseDoubleClick);
            // 
            // K_NO
            // 
            this.K_NO.DataPropertyName = "K_NO";
            resources.ApplyResources(this.K_NO, "K_NO");
            this.K_NO.Name = "K_NO";
            // 
            // K_NAME
            // 
            this.K_NAME.DataPropertyName = "K_NAME";
            resources.ApplyResources(this.K_NAME, "K_NAME");
            this.K_NAME.Name = "K_NAME";
            // 
            // btdong
            // 
            resources.ApplyResources(this.btdong, "btdong");
            this.btdong.Name = "btdong";
            this.btdong.UseVisualStyleBackColor = true;
            this.btdong.Click += new System.EventHandler(this.btdong_Click);
            // 
            // btok
            // 
            resources.ApplyResources(this.btok, "btok");
            this.btok.Name = "btok";
            this.btok.UseVisualStyleBackColor = true;
            this.btok.Click += new System.EventHandler(this.btok_Click);
            // 
            // bttk
            // 
            resources.ApplyResources(this.bttk, "bttk");
            this.bttk.Name = "bttk";
            this.bttk.UseVisualStyleBackColor = true;
            this.bttk.Click += new System.EventHandler(this.bttk_Click);
            // 
            // FormSeachKIND1C
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btok);
            this.Controls.Add(this.btdong);
            this.Controls.Add(this.bttk);
            this.Controls.Add(this.dataGridViewKIND1C);
            this.Controls.Add(this.tb2);
            this.Controls.Add(this.tb1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormSeachKIND1C";
            this.Load += new System.EventHandler(this.FormSeachKIND1C_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKIND1C)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb1;
        private System.Windows.Forms.TextBox tb2;
        private System.Windows.Forms.Button bttk;
        private System.Windows.Forms.Button btok;
        private System.Windows.Forms.Button btdong;
        private System.Windows.Forms.DataGridView dataGridViewKIND1C;
        private System.Windows.Forms.DataGridViewTextBoxColumn K_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn K_NAME;
    }
}