﻿
namespace PURCHASE.MAINCODE.Modun4
{
    partial class frmSelectDateFrm4E
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelectDateFrm4E));
            this.lbCAL_YM = new System.Windows.Forms.Label();
            this.txtCAL_YM = new System.Windows.Forms.MaskedTextBox();
            this.btok = new System.Windows.Forms.Button();
            this.btdong = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbCAL_YM
            // 
            this.lbCAL_YM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbCAL_YM.ForeColor = System.Drawing.Color.Brown;
            this.lbCAL_YM.Location = new System.Drawing.Point(12, 27);
            this.lbCAL_YM.Name = "lbCAL_YM";
            this.lbCAL_YM.Size = new System.Drawing.Size(299, 29);
            this.lbCAL_YM.TabIndex = 0;
            this.lbCAL_YM.Text = "Tháng thanh toán:";
            this.lbCAL_YM.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCAL_YM
            // 
            this.txtCAL_YM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtCAL_YM.Location = new System.Drawing.Point(317, 26);
            this.txtCAL_YM.Mask = "0000/00";
            this.txtCAL_YM.Name = "txtCAL_YM";
            this.txtCAL_YM.Size = new System.Drawing.Size(142, 30);
            this.txtCAL_YM.TabIndex = 1;
            this.txtCAL_YM.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtCAL_YM_MouseDoubleClick);
            // 
            // btok
            // 
            this.btok.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.btok.Image = ((System.Drawing.Image)(resources.GetObject("btok.Image")));
            this.btok.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btok.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btok.Location = new System.Drawing.Point(100, 93);
            this.btok.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btok.Name = "btok";
            this.btok.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btok.Size = new System.Drawing.Size(220, 41);
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
            this.btdong.Location = new System.Drawing.Point(326, 93);
            this.btdong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btdong.Name = "btdong";
            this.btdong.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btdong.Size = new System.Drawing.Size(220, 41);
            this.btdong.TabIndex = 345;
            this.btdong.Text = "Đóng";
            this.btdong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btdong.UseVisualStyleBackColor = true;
            this.btdong.Click += new System.EventHandler(this.btdong_Click);
            // 
            // frmSelectDateFrm4E
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 168);
            this.Controls.Add(this.btok);
            this.Controls.Add(this.btdong);
            this.Controls.Add(this.txtCAL_YM);
            this.Controls.Add(this.lbCAL_YM);
            this.Name = "frmSelectDateFrm4E";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSelectDateFrm4E";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbCAL_YM;
        private System.Windows.Forms.MaskedTextBox txtCAL_YM;
        private System.Windows.Forms.Button btok;
        private System.Windows.Forms.Button btdong;
    }
}