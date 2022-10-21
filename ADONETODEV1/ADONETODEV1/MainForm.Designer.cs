namespace ADONETODEV1
{
    partial class MainForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Products = new System.Windows.Forms.TabPage();
            this.grdProducts = new System.Windows.Forms.DataGridView();
            this.Categories = new System.Windows.Forms.TabPage();
            this.grdCategories = new System.Windows.Forms.DataGridView();
            this.Customers = new System.Windows.Forms.TabPage();
            this.gridCustomer = new System.Windows.Forms.DataGridView();
            this.Shippers = new System.Windows.Forms.TabPage();
            this.grdShipper = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.Products.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdProducts)).BeginInit();
            this.Categories.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCategories)).BeginInit();
            this.Customers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCustomer)).BeginInit();
            this.Shippers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdShipper)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Products);
            this.tabControl1.Controls.Add(this.Categories);
            this.tabControl1.Controls.Add(this.Customers);
            this.tabControl1.Controls.Add(this.Shippers);
            this.tabControl1.Location = new System.Drawing.Point(26, 26);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1162, 654);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.Tag = "";
            // 
            // Products
            // 
            this.Products.Controls.Add(this.grdProducts);
            this.Products.Location = new System.Drawing.Point(4, 29);
            this.Products.Name = "Products";
            this.Products.Padding = new System.Windows.Forms.Padding(3);
            this.Products.Size = new System.Drawing.Size(1154, 621);
            this.Products.TabIndex = 0;
            this.Products.Text = "Products";
            this.Products.UseVisualStyleBackColor = true;
            // 
            // grdProducts
            // 
            this.grdProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdProducts.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdProducts.Location = new System.Drawing.Point(7, 8);
            this.grdProducts.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grdProducts.MultiSelect = false;
            this.grdProducts.Name = "grdProducts";
            this.grdProducts.RowHeadersWidth = 62;
            this.grdProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdProducts.Size = new System.Drawing.Size(1140, 605);
            this.grdProducts.TabIndex = 1;
            this.grdProducts.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdProducts_CellDoubleClick);
            // 
            // Categories
            // 
            this.Categories.Controls.Add(this.grdCategories);
            this.Categories.Location = new System.Drawing.Point(4, 29);
            this.Categories.Name = "Categories";
            this.Categories.Padding = new System.Windows.Forms.Padding(3);
            this.Categories.Size = new System.Drawing.Size(1154, 621);
            this.Categories.TabIndex = 1;
            this.Categories.Text = "Categories";
            this.Categories.UseVisualStyleBackColor = true;
            // 
            // grdCategories
            // 
            this.grdCategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdCategories.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdCategories.Location = new System.Drawing.Point(7, 8);
            this.grdCategories.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grdCategories.MultiSelect = false;
            this.grdCategories.Name = "grdCategories";
            this.grdCategories.RowHeadersWidth = 62;
            this.grdCategories.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdCategories.Size = new System.Drawing.Size(1140, 605);
            this.grdCategories.TabIndex = 2;
            this.grdCategories.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdCategories_CellDoubleClick);
            // 
            // Customers
            // 
            this.Customers.Controls.Add(this.gridCustomer);
            this.Customers.Location = new System.Drawing.Point(4, 29);
            this.Customers.Name = "Customers";
            this.Customers.Padding = new System.Windows.Forms.Padding(3);
            this.Customers.Size = new System.Drawing.Size(1154, 621);
            this.Customers.TabIndex = 2;
            this.Customers.Text = "Customers";
            this.Customers.UseVisualStyleBackColor = true;
            // 
            // gridCustomer
            // 
            this.gridCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCustomer.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridCustomer.Location = new System.Drawing.Point(7, 8);
            this.gridCustomer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gridCustomer.MultiSelect = false;
            this.gridCustomer.Name = "gridCustomer";
            this.gridCustomer.RowHeadersWidth = 62;
            this.gridCustomer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridCustomer.Size = new System.Drawing.Size(1140, 605);
            this.gridCustomer.TabIndex = 3;
            this.gridCustomer.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridCustomer_CellDoubleClick);
            // 
            // Shippers
            // 
            this.Shippers.Controls.Add(this.grdShipper);
            this.Shippers.Location = new System.Drawing.Point(4, 29);
            this.Shippers.Name = "Shippers";
            this.Shippers.Padding = new System.Windows.Forms.Padding(3);
            this.Shippers.Size = new System.Drawing.Size(1154, 621);
            this.Shippers.TabIndex = 3;
            this.Shippers.Text = "Shippers";
            this.Shippers.UseVisualStyleBackColor = true;
            // 
            // grdShipper
            // 
            this.grdShipper.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdShipper.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdShipper.Location = new System.Drawing.Point(7, 8);
            this.grdShipper.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grdShipper.MultiSelect = false;
            this.grdShipper.Name = "grdShipper";
            this.grdShipper.RowHeadersWidth = 62;
            this.grdShipper.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdShipper.Size = new System.Drawing.Size(1140, 605);
            this.grdShipper.TabIndex = 4;
            this.grdShipper.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdShipper_CellDoubleClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.Products.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdProducts)).EndInit();
            this.Categories.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCategories)).EndInit();
            this.Customers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCustomer)).EndInit();
            this.Shippers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdShipper)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Products;
        private System.Windows.Forms.DataGridView grdProducts;
        private System.Windows.Forms.TabPage Categories;
        private System.Windows.Forms.TabPage Customers;
        private System.Windows.Forms.DataGridView grdCategories;
        private System.Windows.Forms.DataGridView gridCustomer;
        private System.Windows.Forms.TabPage Shippers;
        private System.Windows.Forms.DataGridView grdShipper;
    }
}

