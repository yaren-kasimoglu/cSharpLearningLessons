namespace HS6_CRM.UI
{
    partial class FormMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.müşteriİşlemleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemNewCustomer = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemCustomerList = new System.Windows.Forms.ToolStripMenuItem();
            this.kullanıcıIşlemleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yeniKullanıcıToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kullanıcıListesiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.müşteriİşlemleriToolStripMenuItem,
            this.kullanıcıIşlemleriToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1020, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // müşteriİşlemleriToolStripMenuItem
            // 
            this.müşteriİşlemleriToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemNewCustomer,
            this.MenuItemCustomerList});
            this.müşteriİşlemleriToolStripMenuItem.Name = "müşteriİşlemleriToolStripMenuItem";
            this.müşteriİşlemleriToolStripMenuItem.Size = new System.Drawing.Size(157, 29);
            this.müşteriİşlemleriToolStripMenuItem.Text = "Müşteri İşlemleri";
            // 
            // MenuItemNewCustomer
            // 
            this.MenuItemNewCustomer.Name = "MenuItemNewCustomer";
            this.MenuItemNewCustomer.Size = new System.Drawing.Size(270, 34);
            this.MenuItemNewCustomer.Text = "Yeni Müşteri";
            // 
            // MenuItemCustomerList
            // 
            this.MenuItemCustomerList.Name = "MenuItemCustomerList";
            this.MenuItemCustomerList.Size = new System.Drawing.Size(270, 34);
            this.MenuItemCustomerList.Text = "Müşteri Listesi";
            // 
            // kullanıcıIşlemleriToolStripMenuItem
            // 
            this.kullanıcıIşlemleriToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.yeniKullanıcıToolStripMenuItem,
            this.kullanıcıListesiToolStripMenuItem});
            this.kullanıcıIşlemleriToolStripMenuItem.Name = "kullanıcıIşlemleriToolStripMenuItem";
            this.kullanıcıIşlemleriToolStripMenuItem.Size = new System.Drawing.Size(160, 29);
            this.kullanıcıIşlemleriToolStripMenuItem.Text = "Kullanıcı işlemleri";
            // 
            // yeniKullanıcıToolStripMenuItem
            // 
            this.yeniKullanıcıToolStripMenuItem.Name = "yeniKullanıcıToolStripMenuItem";
            this.yeniKullanıcıToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.yeniKullanıcıToolStripMenuItem.Text = "Yeni Kullanıcı";
            // 
            // kullanıcıListesiToolStripMenuItem
            // 
            this.kullanıcıListesiToolStripMenuItem.Name = "kullanıcıListesiToolStripMenuItem";
            this.kullanıcıListesiToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.kullanıcıListesiToolStripMenuItem.Text = "Kullanıcı Listesi";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 768);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "CRM Uygulaması";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem müşteriİşlemleriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuItemNewCustomer;
        private System.Windows.Forms.ToolStripMenuItem MenuItemCustomerList;
        private System.Windows.Forms.ToolStripMenuItem kullanıcıIşlemleriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yeniKullanıcıToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kullanıcıListesiToolStripMenuItem;
    }
}