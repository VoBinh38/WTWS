
namespace PURCHASE
{
    partial class Form8R
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form8R));
            this.btnClose = new System.Windows.Forms.Button();
            this.btnTimeNow = new System.Windows.Forms.Button();
            this.btndateNow = new System.Windows.Forms.Button();
            this.btketthuc = new System.Windows.Forms.Button();
            this.btsau = new System.Windows.Forms.Button();
            this.bttruoc = new System.Windows.Forms.Button();
            this.btdau = new System.Windows.Forms.Button();
            this.bt = new System.Windows.Forms.Button();
            this.btnok = new System.Windows.Forms.Button();
            this.DGV1 = new System.Windows.Forms.DataGridView();
            this.lbDEPT_NO = new System.Windows.Forms.Label();
            this.lbDEPT_NAME = new System.Windows.Forms.Label();
            this.lbSH_NO = new System.Windows.Forms.Label();
            this.lbSH_NAME = new System.Windows.Forms.Label();
            this.txtSH_NAME = new System.Windows.Forms.TextBox();
            this.txtSH_NO = new System.Windows.Forms.TextBox();
            this.txtDEPT_NAME = new System.Windows.Forms.TextBox();
            this.txtDEPT_NO = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbUserName = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbNamePC = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbIP = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.DEPT_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DEPT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SH_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SH_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.f1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.f2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.f3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.f4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.f5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.f6ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.f7ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.f8ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.f10ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.f9ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.f11ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.f12ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.DGV1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(1010, 44);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnClose.Size = new System.Drawing.Size(118, 39);
            this.btnClose.TabIndex = 325;
            this.btnClose.Text = "Đóng";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Visible = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnTimeNow
            // 
            this.btnTimeNow.BackColor = System.Drawing.Color.Transparent;
            this.btnTimeNow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnTimeNow.ForeColor = System.Drawing.Color.DarkMagenta;
            this.btnTimeNow.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnTimeNow.Location = new System.Drawing.Point(626, 44);
            this.btnTimeNow.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTimeNow.Name = "btnTimeNow";
            this.btnTimeNow.Size = new System.Drawing.Size(225, 39);
            this.btnTimeNow.TabIndex = 324;
            this.btnTimeNow.Text = "HH: MM:SS";
            this.btnTimeNow.UseVisualStyleBackColor = false;
            // 
            // btndateNow
            // 
            this.btndateNow.BackColor = System.Drawing.Color.Transparent;
            this.btndateNow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btndateNow.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btndateNow.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btndateNow.Location = new System.Drawing.Point(353, 44);
            this.btndateNow.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btndateNow.Name = "btndateNow";
            this.btndateNow.Size = new System.Drawing.Size(266, 39);
            this.btndateNow.TabIndex = 323;
            this.btndateNow.Text = "yyyy/MM/dd";
            this.btndateNow.UseVisualStyleBackColor = false;
            // 
            // btketthuc
            // 
            this.btketthuc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btketthuc.Image = ((System.Drawing.Image)(resources.GetObject("btketthuc.Image")));
            this.btketthuc.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btketthuc.Location = new System.Drawing.Point(306, 45);
            this.btketthuc.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.btketthuc.Name = "btketthuc";
            this.btketthuc.Size = new System.Drawing.Size(43, 39);
            this.btketthuc.TabIndex = 322;
            this.btketthuc.UseVisualStyleBackColor = true;
            this.btketthuc.Click += new System.EventHandler(this.btketthuc_Click);
            // 
            // btsau
            // 
            this.btsau.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btsau.Image = ((System.Drawing.Image)(resources.GetObject("btsau.Image")));
            this.btsau.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btsau.Location = new System.Drawing.Point(258, 45);
            this.btsau.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.btsau.Name = "btsau";
            this.btsau.Size = new System.Drawing.Size(45, 39);
            this.btsau.TabIndex = 321;
            this.btsau.UseVisualStyleBackColor = true;
            this.btsau.Click += new System.EventHandler(this.btsau_Click);
            // 
            // bttruoc
            // 
            this.bttruoc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bttruoc.Image = ((System.Drawing.Image)(resources.GetObject("bttruoc.Image")));
            this.bttruoc.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bttruoc.Location = new System.Drawing.Point(210, 45);
            this.bttruoc.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.bttruoc.Name = "bttruoc";
            this.bttruoc.Size = new System.Drawing.Size(46, 39);
            this.bttruoc.TabIndex = 320;
            this.bttruoc.UseVisualStyleBackColor = true;
            this.bttruoc.Click += new System.EventHandler(this.bttruoc_Click);
            // 
            // btdau
            // 
            this.btdau.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btdau.Image = ((System.Drawing.Image)(resources.GetObject("btdau.Image")));
            this.btdau.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btdau.Location = new System.Drawing.Point(165, 45);
            this.btdau.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.btdau.Name = "btdau";
            this.btdau.Size = new System.Drawing.Size(43, 39);
            this.btdau.TabIndex = 319;
            this.btdau.UseVisualStyleBackColor = true;
            this.btdau.Click += new System.EventHandler(this.btdau_Click);
            // 
            // bt
            // 
            this.bt.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.bt.ForeColor = System.Drawing.Color.Green;
            this.bt.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bt.Location = new System.Drawing.Point(16, 45);
            this.bt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bt.Name = "bt";
            this.bt.Size = new System.Drawing.Size(145, 39);
            this.bt.TabIndex = 318;
            this.bt.Text = "NÚT DUYỆT";
            this.bt.UseVisualStyleBackColor = true;
            // 
            // btnok
            // 
            this.btnok.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnok.Image = ((System.Drawing.Image)(resources.GetObject("btnok.Image")));
            this.btnok.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnok.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnok.Location = new System.Drawing.Point(858, 44);
            this.btnok.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnok.Name = "btnok";
            this.btnok.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnok.Size = new System.Drawing.Size(145, 39);
            this.btnok.TabIndex = 317;
            this.btnok.Text = "OK";
            this.btnok.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnok.UseVisualStyleBackColor = true;
            this.btnok.Visible = false;
            this.btnok.Click += new System.EventHandler(this.btnok_Click);
            // 
            // DGV1
            // 
            this.DGV1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DEPT_NO,
            this.DEPT_NAME,
            this.SH_NAME,
            this.SH_NO});
            this.DGV1.Location = new System.Drawing.Point(16, 90);
            this.DGV1.Name = "DGV1";
            this.DGV1.RowHeadersWidth = 51;
            this.DGV1.RowTemplate.Height = 24;
            this.DGV1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV1.Size = new System.Drawing.Size(630, 510);
            this.DGV1.TabIndex = 326;
            this.DGV1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV1_CellClick);
            // 
            // lbDEPT_NO
            // 
            this.lbDEPT_NO.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbDEPT_NO.ForeColor = System.Drawing.Color.Brown;
            this.lbDEPT_NO.Location = new System.Drawing.Point(652, 145);
            this.lbDEPT_NO.Name = "lbDEPT_NO";
            this.lbDEPT_NO.Size = new System.Drawing.Size(199, 45);
            this.lbDEPT_NO.TabIndex = 327;
            this.lbDEPT_NO.Text = "Mã bộ phận";
            this.lbDEPT_NO.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbDEPT_NO.Click += new System.EventHandler(this.lbDEPT_NO_Click);
            // 
            // lbDEPT_NAME
            // 
            this.lbDEPT_NAME.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbDEPT_NAME.ForeColor = System.Drawing.Color.Brown;
            this.lbDEPT_NAME.Location = new System.Drawing.Point(652, 208);
            this.lbDEPT_NAME.Name = "lbDEPT_NAME";
            this.lbDEPT_NAME.Size = new System.Drawing.Size(199, 45);
            this.lbDEPT_NAME.TabIndex = 327;
            this.lbDEPT_NAME.Text = "Tên bộ phận";
            this.lbDEPT_NAME.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbSH_NO
            // 
            this.lbSH_NO.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbSH_NO.ForeColor = System.Drawing.Color.Brown;
            this.lbSH_NO.Location = new System.Drawing.Point(652, 269);
            this.lbSH_NO.Name = "lbSH_NO";
            this.lbSH_NO.Size = new System.Drawing.Size(199, 45);
            this.lbSH_NO.TabIndex = 327;
            this.lbSH_NO.Text = "Mã kho";
            this.lbSH_NO.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbSH_NAME
            // 
            this.lbSH_NAME.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbSH_NAME.ForeColor = System.Drawing.Color.Brown;
            this.lbSH_NAME.Location = new System.Drawing.Point(652, 328);
            this.lbSH_NAME.Name = "lbSH_NAME";
            this.lbSH_NAME.Size = new System.Drawing.Size(199, 45);
            this.lbSH_NAME.TabIndex = 327;
            this.lbSH_NAME.Text = "Tên kho";
            this.lbSH_NAME.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSH_NAME
            // 
            this.txtSH_NAME.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtSH_NAME.Location = new System.Drawing.Point(857, 335);
            this.txtSH_NAME.MaxLength = 20;
            this.txtSH_NAME.Name = "txtSH_NAME";
            this.txtSH_NAME.Size = new System.Drawing.Size(234, 30);
            this.txtSH_NAME.TabIndex = 328;
            // 
            // txtSH_NO
            // 
            this.txtSH_NO.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtSH_NO.Location = new System.Drawing.Point(857, 276);
            this.txtSH_NO.MaxLength = 10;
            this.txtSH_NO.Name = "txtSH_NO";
            this.txtSH_NO.Size = new System.Drawing.Size(234, 30);
            this.txtSH_NO.TabIndex = 328;
            // 
            // txtDEPT_NAME
            // 
            this.txtDEPT_NAME.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtDEPT_NAME.Location = new System.Drawing.Point(857, 215);
            this.txtDEPT_NAME.MaxLength = 30;
            this.txtDEPT_NAME.Name = "txtDEPT_NAME";
            this.txtDEPT_NAME.Size = new System.Drawing.Size(234, 30);
            this.txtDEPT_NAME.TabIndex = 328;
            // 
            // txtDEPT_NO
            // 
            this.txtDEPT_NO.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtDEPT_NO.Location = new System.Drawing.Point(857, 152);
            this.txtDEPT_NO.MaxLength = 4;
            this.txtDEPT_NO.Name = "txtDEPT_NO";
            this.txtDEPT_NO.Size = new System.Drawing.Size(234, 30);
            this.txtDEPT_NO.TabIndex = 328;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lbUserName,
            this.toolStripStatusLabel2,
            this.lbNamePC,
            this.toolStripStatusLabel3,
            this.lbIP});
            this.statusStrip1.Location = new System.Drawing.Point(0, 604);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 12, 0);
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.Size = new System.Drawing.Size(1138, 26);
            this.statusStrip1.TabIndex = 329;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Padding = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(175, 20);
            this.toolStripStatusLabel1.Text = "Người Sử Dụng: ";
            // 
            // lbUserName
            // 
            this.lbUserName.ForeColor = System.Drawing.Color.Brown;
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(63, 20);
            this.lbUserName.Text = "XXXXXX";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(153, 20);
            this.toolStripStatusLabel2.Text = "     Computer Name: ";
            // 
            // lbNamePC
            // 
            this.lbNamePC.ForeColor = System.Drawing.Color.Brown;
            this.lbNamePC.Name = "lbNamePC";
            this.lbNamePC.Size = new System.Drawing.Size(72, 20);
            this.lbNamePC.Text = "xxxxxxxxx";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(92, 20);
            this.toolStripStatusLabel3.Text = "       IP Add: ";
            // 
            // lbIP
            // 
            this.lbIP.ForeColor = System.Drawing.Color.Brown;
            this.lbIP.Name = "lbIP";
            this.lbIP.Size = new System.Drawing.Size(116, 20);
            this.lbIP.Text = "xxx.xxx.xxxx.xxxx";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // DEPT_NO
            // 
            this.DEPT_NO.DataPropertyName = "DEPT_NO";
            this.DEPT_NO.HeaderText = "DEPT_NO";
            this.DEPT_NO.MinimumWidth = 6;
            this.DEPT_NO.Name = "DEPT_NO";
            this.DEPT_NO.Width = 125;
            // 
            // DEPT_NAME
            // 
            this.DEPT_NAME.DataPropertyName = "DEPT_NAME";
            this.DEPT_NAME.HeaderText = "DEPT_NAME";
            this.DEPT_NAME.MinimumWidth = 6;
            this.DEPT_NAME.Name = "DEPT_NAME";
            this.DEPT_NAME.Width = 125;
            // 
            // SH_NAME
            // 
            this.SH_NAME.DataPropertyName = "SH_NAME";
            this.SH_NAME.HeaderText = "SH_NAME";
            this.SH_NAME.MinimumWidth = 6;
            this.SH_NAME.Name = "SH_NAME";
            this.SH_NAME.Width = 125;
            // 
            // SH_NO
            // 
            this.SH_NO.DataPropertyName = "SH_NO";
            this.SH_NO.HeaderText = "SH_NO";
            this.SH_NO.MinimumWidth = 6;
            this.SH_NO.Name = "SH_NO";
            this.SH_NO.Width = 125;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.LightBlue;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.f2ToolStripMenuItem,
            this.f3ToolStripMenuItem,
            this.f4ToolStripMenuItem,
            this.f6ToolStripMenuItem,
            this.f8ToolStripMenuItem,
            this.f12ToolStripMenuItem,
            this.f10ToolStripMenuItem,
            this.f9ToolStripMenuItem,
            this.f11ToolStripMenuItem,
            this.f1ToolStripMenuItem,
            this.f7ToolStripMenuItem,
            this.f5ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1138, 32);
            this.menuStrip1.TabIndex = 330;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Click += new System.EventHandler(this.f3ToolStripMenuItem_Click);
            // 
            // f1ToolStripMenuItem
            // 
            this.f1ToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.f1ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("f1ToolStripMenuItem.Image")));
            this.f1ToolStripMenuItem.Name = "f1ToolStripMenuItem";
            this.f1ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.f1ToolStripMenuItem.Size = new System.Drawing.Size(134, 28);
            this.f1ToolStripMenuItem.Text = "F1. Kiểm Tra";
            this.f1ToolStripMenuItem.Visible = false;
            // 
            // f2ToolStripMenuItem
            // 
            this.f2ToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.f2ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("f2ToolStripMenuItem.Image")));
            this.f2ToolStripMenuItem.Name = "f2ToolStripMenuItem";
            this.f2ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.f2ToolStripMenuItem.Size = new System.Drawing.Size(112, 28);
            this.f2ToolStripMenuItem.Text = "F2. Thêm";
            this.f2ToolStripMenuItem.Click += new System.EventHandler(this.f2ToolStripMenuItem_Click);
            // 
            // f3ToolStripMenuItem
            // 
            this.f3ToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.f3ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("f3ToolStripMenuItem.Image")));
            this.f3ToolStripMenuItem.Name = "f3ToolStripMenuItem";
            this.f3ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.f3ToolStripMenuItem.Size = new System.Drawing.Size(99, 28);
            this.f3ToolStripMenuItem.Text = "F3. Xóa";
            // 
            // f4ToolStripMenuItem
            // 
            this.f4ToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.f4ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("f4ToolStripMenuItem.Image")));
            this.f4ToolStripMenuItem.Name = "f4ToolStripMenuItem";
            this.f4ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.f4ToolStripMenuItem.Size = new System.Drawing.Size(98, 28);
            this.f4ToolStripMenuItem.Text = "F4. Sửa";
            this.f4ToolStripMenuItem.Click += new System.EventHandler(this.f4ToolStripMenuItem_Click);
            // 
            // f5ToolStripMenuItem
            // 
            this.f5ToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.f5ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("f5ToolStripMenuItem.Image")));
            this.f5ToolStripMenuItem.Name = "f5ToolStripMenuItem";
            this.f5ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.f5ToolStripMenuItem.Size = new System.Drawing.Size(139, 28);
            this.f5ToolStripMenuItem.Text = "F5. Tìm Kiếm";
            this.f5ToolStripMenuItem.Visible = false;
            // 
            // f6ToolStripMenuItem
            // 
            this.f6ToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.f6ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("f6ToolStripMenuItem.Image")));
            this.f6ToolStripMenuItem.Name = "f6ToolStripMenuItem";
            this.f6ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.f6ToolStripMenuItem.Size = new System.Drawing.Size(107, 28);
            this.f6ToolStripMenuItem.Text = "F6. Copy";
            this.f6ToolStripMenuItem.Click += new System.EventHandler(this.f6ToolStripMenuItem_Click);
            // 
            // f7ToolStripMenuItem
            // 
            this.f7ToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.f7ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("f7ToolStripMenuItem.Image")));
            this.f7ToolStripMenuItem.Name = "f7ToolStripMenuItem";
            this.f7ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F7;
            this.f7ToolStripMenuItem.Size = new System.Drawing.Size(86, 28);
            this.f7ToolStripMenuItem.Text = "F7. In";
            this.f7ToolStripMenuItem.Visible = false;
            // 
            // f8ToolStripMenuItem
            // 
            this.f8ToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.f8ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("f8ToolStripMenuItem.Image")));
            this.f8ToolStripMenuItem.Name = "f8ToolStripMenuItem";
            this.f8ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.f8ToolStripMenuItem.Size = new System.Drawing.Size(99, 28);
            this.f8ToolStripMenuItem.Text = "F8. Lưu";
            // 
            // f10ToolStripMenuItem
            // 
            this.f10ToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.f10ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("f10ToolStripMenuItem.Image")));
            this.f10ToolStripMenuItem.Name = "f10ToolStripMenuItem";
            this.f10ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10;
            this.f10ToolStripMenuItem.Size = new System.Drawing.Size(140, 32);
            this.f10ToolStripMenuItem.Text = "F10. Kết thúc";
            this.f10ToolStripMenuItem.Visible = false;
            // 
            // f9ToolStripMenuItem
            // 
            this.f9ToolStripMenuItem.Name = "f9ToolStripMenuItem";
            this.f9ToolStripMenuItem.Size = new System.Drawing.Size(47, 32);
            this.f9ToolStripMenuItem.Text = "F9";
            this.f9ToolStripMenuItem.Visible = false;
            // 
            // f11ToolStripMenuItem
            // 
            this.f11ToolStripMenuItem.Name = "f11ToolStripMenuItem";
            this.f11ToolStripMenuItem.Size = new System.Drawing.Size(58, 32);
            this.f11ToolStripMenuItem.Text = "F11";
            this.f11ToolStripMenuItem.Visible = false;
            // 
            // f12ToolStripMenuItem
            // 
            this.f12ToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.f12ToolStripMenuItem.Image = global::PURCHASE.Properties.Resources.shutdown;
            this.f12ToolStripMenuItem.Name = "f12ToolStripMenuItem";
            this.f12ToolStripMenuItem.Size = new System.Drawing.Size(140, 28);
            this.f12ToolStripMenuItem.Text = "F12. Kết thúc";
            this.f12ToolStripMenuItem.Click += new System.EventHandler(this.f12ToolStripMenuItem_Click_1);
            // 
            // Form8R
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1138, 630);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.txtDEPT_NO);
            this.Controls.Add(this.txtDEPT_NAME);
            this.Controls.Add(this.txtSH_NO);
            this.Controls.Add(this.txtSH_NAME);
            this.Controls.Add(this.lbSH_NAME);
            this.Controls.Add(this.lbSH_NO);
            this.Controls.Add(this.lbDEPT_NAME);
            this.Controls.Add(this.lbDEPT_NO);
            this.Controls.Add(this.DGV1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnTimeNow);
            this.Controls.Add(this.btndateNow);
            this.Controls.Add(this.btketthuc);
            this.Controls.Add(this.btsau);
            this.Controls.Add(this.bttruoc);
            this.Controls.Add(this.btdau);
            this.Controls.Add(this.bt);
            this.Controls.Add(this.btnok);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.Name = "Form8R";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm8R";
            this.Load += new System.EventHandler(this.Form8R_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnTimeNow;
        private System.Windows.Forms.Button btndateNow;
        private System.Windows.Forms.Button btketthuc;
        private System.Windows.Forms.Button btsau;
        private System.Windows.Forms.Button bttruoc;
        private System.Windows.Forms.Button btdau;
        private System.Windows.Forms.Button bt;
        private System.Windows.Forms.Button btnok;
        private System.Windows.Forms.DataGridView DGV1;
        private System.Windows.Forms.Label lbDEPT_NO;
        private System.Windows.Forms.Label lbDEPT_NAME;
        private System.Windows.Forms.Label lbSH_NO;
        private System.Windows.Forms.Label lbSH_NAME;
        private System.Windows.Forms.TextBox txtSH_NAME;
        private System.Windows.Forms.TextBox txtSH_NO;
        private System.Windows.Forms.TextBox txtDEPT_NAME;
        private System.Windows.Forms.TextBox txtDEPT_NO;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lbUserName;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel lbNamePC;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel lbIP;
        public System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DEPT_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DEPT_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn SH_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn SH_NO;
        public System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem f1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem f2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem f3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem f4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem f5ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem f6ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem f7ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem f8ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem f10ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem f9ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem f11ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem f12ToolStripMenuItem;
    }
}