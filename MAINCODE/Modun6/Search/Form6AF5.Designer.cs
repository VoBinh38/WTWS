
namespace PURCHASE.MAINCODE.Modun6.Search
{
    partial class Form6AF5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form6AF5));
            this.dataF6F5 = new System.Windows.Forms.DataGridView();
            this.WSNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WSDATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.USER_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btdong = new System.Windows.Forms.Button();
            this.bttk = new System.Windows.Forms.Button();
            this.tb4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tb3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb2 = new System.Windows.Forms.TextBox();
            this.tb1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataF6F5)).BeginInit();
            this.SuspendLayout();
            // 
            // dataF6F5
            // 
            this.dataF6F5.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataF6F5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataF6F5.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.WSNO,
            this.WSDATE,
            this.USER_ID,
            this.NAME});
            this.dataF6F5.Location = new System.Drawing.Point(25, 119);
            this.dataF6F5.Margin = new System.Windows.Forms.Padding(4);
            this.dataF6F5.Name = "dataF6F5";
            this.dataF6F5.RowHeadersWidth = 51;
            this.dataF6F5.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataF6F5.Size = new System.Drawing.Size(1243, 528);
            this.dataF6F5.TabIndex = 21;
            this.dataF6F5.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataF6F5_CellMouseDoubleClick);
            // 
            // WSNO
            // 
            this.WSNO.DataPropertyName = "WSNO";
            this.WSNO.HeaderText = "Mã Số Tài Khoản";
            this.WSNO.MinimumWidth = 6;
            this.WSNO.Name = "WSNO";
            this.WSNO.Width = 250;
            // 
            // WSDATE
            // 
            this.WSDATE.DataPropertyName = "WSDATE";
            this.WSDATE.HeaderText = " Ngày Lập";
            this.WSDATE.MinimumWidth = 6;
            this.WSDATE.Name = "WSDATE";
            this.WSDATE.Width = 125;
            // 
            // USER_ID
            // 
            this.USER_ID.DataPropertyName = "USER_ID";
            this.USER_ID.HeaderText = "Tài Khoản Người Dùng";
            this.USER_ID.MinimumWidth = 6;
            this.USER_ID.Name = "USER_ID";
            this.USER_ID.Width = 200;
            // 
            // NAME
            // 
            this.NAME.DataPropertyName = "NAME";
            this.NAME.HeaderText = "Tên Người Dùng";
            this.NAME.MinimumWidth = 6;
            this.NAME.Name = "NAME";
            this.NAME.Width = 250;
            // 
            // btdong
            // 
            this.btdong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btdong.Image = ((System.Drawing.Image)(resources.GetObject("btdong.Image")));
            this.btdong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btdong.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btdong.Location = new System.Drawing.Point(1113, 56);
            this.btdong.Margin = new System.Windows.Forms.Padding(4);
            this.btdong.Name = "btdong";
            this.btdong.Size = new System.Drawing.Size(155, 38);
            this.btdong.TabIndex = 20;
            this.btdong.Text = "ĐÓNG";
            this.btdong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btdong.UseVisualStyleBackColor = true;
            this.btdong.Click += new System.EventHandler(this.btdong_Click);
            // 
            // bttk
            // 
            this.bttk.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bttk.Image = ((System.Drawing.Image)(resources.GetObject("bttk.Image")));
            this.bttk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bttk.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bttk.Location = new System.Drawing.Point(1113, 17);
            this.bttk.Margin = new System.Windows.Forms.Padding(4);
            this.bttk.Name = "bttk";
            this.bttk.Size = new System.Drawing.Size(155, 37);
            this.bttk.TabIndex = 19;
            this.bttk.Text = "TÌM KIẾM";
            this.bttk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bttk.UseVisualStyleBackColor = true;
            this.bttk.Click += new System.EventHandler(this.bttk_Click);
            // 
            // tb4
            // 
            this.tb4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.tb4.Location = new System.Drawing.Point(744, 60);
            this.tb4.Margin = new System.Windows.Forms.Padding(4);
            this.tb4.Name = "tb4";
            this.tb4.Size = new System.Drawing.Size(318, 29);
            this.tb4.TabIndex = 18;
            this.tb4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb4_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label4.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(507, 65);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 24);
            this.label4.TabIndex = 17;
            this.label4.Text = "Tên người dùng:";
            // 
            // tb3
            // 
            this.tb3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.tb3.Location = new System.Drawing.Point(744, 18);
            this.tb3.Margin = new System.Windows.Forms.Padding(4);
            this.tb3.Name = "tb3";
            this.tb3.Size = new System.Drawing.Size(318, 29);
            this.tb3.TabIndex = 16;
            this.tb3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb3_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(507, 21);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(200, 24);
            this.label3.TabIndex = 15;
            this.label3.Text = "Tài khoản người dùng:";
            // 
            // tb2
            // 
            this.tb2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.tb2.Location = new System.Drawing.Point(199, 62);
            this.tb2.Margin = new System.Windows.Forms.Padding(4);
            this.tb2.Name = "tb2";
            this.tb2.Size = new System.Drawing.Size(206, 29);
            this.tb2.TabIndex = 14;
            this.tb2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb2_KeyDown);
            // 
            // tb1
            // 
            this.tb1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.tb1.Location = new System.Drawing.Point(199, 21);
            this.tb1.Margin = new System.Windows.Forms.Padding(4);
            this.tb1.Name = "tb1";
            this.tb1.Size = new System.Drawing.Size(206, 29);
            this.tb1.TabIndex = 13;
            this.tb1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb1_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(21, 68);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 24);
            this.label2.TabIndex = 12;
            this.label2.Text = "Ngày lập: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(21, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 24);
            this.label1.TabIndex = 11;
            this.label1.Text = "Mã số tài khoản:";
            // 
            // Form6AF5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1295, 664);
            this.Controls.Add(this.dataF6F5);
            this.Controls.Add(this.btdong);
            this.Controls.Add(this.bttk);
            this.Controls.Add(this.tb4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb2);
            this.Controls.Add(this.tb1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form6AF5";
            this.Text = "Form6AF5";
            this.Load += new System.EventHandler(this.Form6AF5_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataF6F5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataF6F5;
        private System.Windows.Forms.DataGridViewTextBoxColumn WSNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn WSDATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn USER_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NAME;
        private System.Windows.Forms.Button btdong;
        private System.Windows.Forms.Button bttk;
        private System.Windows.Forms.TextBox tb4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb2;
        private System.Windows.Forms.TextBox tb1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}