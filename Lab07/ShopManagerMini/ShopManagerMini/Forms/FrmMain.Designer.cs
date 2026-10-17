namespace ShopManagerMini.Forms
{
    partial class FrmMain
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
            components = new System.ComponentModel.Container();
            menuStrip1 = new MenuStrip();
            menuSystem = new ToolStripMenuItem();
            mnuLogout = new ToolStripMenuItem();
            mnuExit = new ToolStripMenuItem();
            menuCatalog = new ToolStripMenuItem();
            mnuProduct = new ToolStripMenuItem();
            mnuCustomer = new ToolStripMenuItem();
            menuHelp = new ToolStripMenuItem();
            mnuAbout = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            tsslUser = new ToolStripStatusLabel();
            tsslRole = new ToolStripStatusLabel();
            tsslTime = new ToolStripStatusLabel();
            tmrClock = new System.Windows.Forms.Timer(components);
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { menuSystem, menuCatalog, menuHelp });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // menuSystem
            // 
            menuSystem.DropDownItems.AddRange(new ToolStripItem[] { mnuLogout, mnuExit });
            menuSystem.Name = "menuSystem";
            menuSystem.Size = new Size(85, 24);
            menuSystem.Text = "Hệ thống";
            // 
            // mnuLogout
            // 
            mnuLogout.Name = "mnuLogout";
            mnuLogout.Size = new Size(224, 26);
            mnuLogout.Text = "Đăng xuất";
            mnuLogout.Click += mnuLogout_Click;
            // 
            // mnuExit
            // 
            mnuExit.Name = "mnuExit";
            mnuExit.Size = new Size(224, 26);
            mnuExit.Text = "Thoát";
            mnuExit.Click += mnuExit_Click;
            // 
            // menuCatalog
            // 
            menuCatalog.DropDownItems.AddRange(new ToolStripItem[] { mnuProduct, mnuCustomer });
            menuCatalog.Name = "menuCatalog";
            menuCatalog.Size = new Size(90, 24);
            menuCatalog.Text = "Danh mục";
            // 
            // mnuProduct
            // 
            mnuProduct.Name = "mnuProduct";
            mnuProduct.Size = new Size(224, 26);
            mnuProduct.Text = "Quản lý sản phẩm";
            mnuProduct.Click += mnuProduct_Click;
            // 
            // mnuCustomer
            // 
            mnuCustomer.Name = "mnuCustomer";
            mnuCustomer.Size = new Size(224, 26);
            mnuCustomer.Text = "Quản lý khách hàng";
            mnuCustomer.Click += mnuCustomer_Click;
            // 
            // menuHelp
            // 
            menuHelp.DropDownItems.AddRange(new ToolStripItem[] { mnuAbout });
            menuHelp.Name = "menuHelp";
            menuHelp.Size = new Size(78, 24);
            menuHelp.Text = "Trợ giúp";
            // 
            // mnuAbout
            // 
            mnuAbout.Name = "mnuAbout";
            mnuAbout.Size = new Size(224, 26);
            mnuAbout.Text = "Giới thiệu";
            mnuAbout.Click += mnuAbout_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { tsslUser, tsslRole, tsslTime });
            statusStrip1.Location = new Point(0, 424);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 26);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // tsslUser
            // 
            tsslUser.Name = "tsslUser";
            tsslUser.Size = new Size(151, 20);
            tsslUser.Text = "toolStripStatusLabel1";
            // 
            // tsslRole
            // 
            tsslRole.Name = "tsslRole";
            tsslRole.Size = new Size(151, 20);
            tsslRole.Text = "toolStripStatusLabel2";
            // 
            // tsslTime
            // 
            tsslTime.Name = "tsslTime";
            tsslTime.Size = new Size(151, 20);
            tsslTime.Text = "toolStripStatusLabel3";
            // 
            // tmrClock
            // 
            tmrClock.Enabled = true;
            tmrClock.Interval = 1000;
            tmrClock.Tick += tmrClock_Tick;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "FrmMain";
            Text = "ShopManagerMini";
            WindowState = FormWindowState.Maximized;
            FormClosing += FrmMain_FormClosing;
            Load += FrmMain_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem menuSystem;
        private ToolStripMenuItem mnuLogout;
        private ToolStripMenuItem mnuExit;
        private ToolStripMenuItem menuCatalog;
        private ToolStripMenuItem mnuProduct;
        private ToolStripMenuItem mnuCustomer;
        private ToolStripMenuItem menuHelp;
        private ToolStripMenuItem mnuAbout;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel tsslUser;
        private ToolStripStatusLabel tsslRole;
        private ToolStripStatusLabel tsslTime;
        private System.Windows.Forms.Timer tmrClock;
    }
}