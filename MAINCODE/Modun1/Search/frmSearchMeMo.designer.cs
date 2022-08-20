using System;
using System.Data;
using System.Windows.Forms;

namespace PURCHASE.MAINCODE.Modun1
{
    partial class frmSearchMemo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearchMemo));
            this.txtMaCumTu = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNoiDung = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.DGV2 = new System.Windows.Forms.DataGridView();
            this.M_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.M_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DGV2)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMaCumTu
            // 
            resources.ApplyResources(this.txtMaCumTu, "txtMaCumTu");
            this.txtMaCumTu.Name = "txtMaCumTu";
            this.txtMaCumTu.TextChanged += new System.EventHandler(this.txtMaCumTu_TextChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Name = "label1";
            // 
            // txtNoiDung
            // 
            resources.ApplyResources(this.txtNoiDung, "txtNoiDung");
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.TextChanged += new System.EventHandler(this.txtNoiDung_TextChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label2.Name = "label2";
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // DGV2
            // 
            this.DGV2.AllowUserToAddRows = false;
            this.DGV2.AllowUserToDeleteRows = false;
            this.DGV2.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.DGV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.M_NO,
            this.M_NAME});
            resources.ApplyResources(this.DGV2, "DGV2");
            this.DGV2.Name = "DGV2";
            this.DGV2.ReadOnly = true;
            this.DGV2.RowTemplate.Height = 28;
            this.DGV2.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV2_CellDoubleClick);
            // 
            // M_NO
            // 
            this.M_NO.DataPropertyName = "M_NO";
            resources.ApplyResources(this.M_NO, "M_NO");
            this.M_NO.Name = "M_NO";
            this.M_NO.ReadOnly = true;
            // 
            // M_NAME
            // 
            this.M_NAME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.M_NAME.DataPropertyName = "M_NAME";
            resources.ApplyResources(this.M_NAME, "M_NAME");
            this.M_NAME.Name = "M_NAME";
            this.M_NAME.ReadOnly = true;
            // 
            // frmSearchMemo
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DGV2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNoiDung);
            this.Controls.Add(this.txtMaCumTu);
            this.Name = "frmSearchMemo";
            this.Load += new System.EventHandler(this.frmSearchMemo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMaCumTu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNoiDung;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView DGV2;
        private System.Windows.Forms.DataGridViewTextBoxColumn M_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn M_NAME;
    }
}