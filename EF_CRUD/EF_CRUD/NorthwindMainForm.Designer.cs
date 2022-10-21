namespace EF_CRUD
{
    partial class NorthwindMainForm
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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.tabProduct = new System.Windows.Forms.TabPage();
            this.dataGridViewProduct = new System.Windows.Forms.DataGridView();
            this.tabSuppplier = new System.Windows.Forms.TabPage();
            this.dataGridViewSupplier = new System.Windows.Forms.DataGridView();
            this.tabCategories = new System.Windows.Forms.TabPage();
            this.dataGridViewCategory = new System.Windows.Forms.DataGridView();
            this.tabEmployees = new System.Windows.Forms.TabPage();
            this.dataGridViewEmployee = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProduct)).BeginInit();
            this.tabSuppplier.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSupplier)).BeginInit();
            this.tabCategories.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCategory)).BeginInit();
            this.tabEmployees.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployee)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabProduct);
            this.tabControl1.Controls.Add(this.tabSuppplier);
            this.tabControl1.Controls.Add(this.tabCategories);
            this.tabControl1.Controls.Add(this.tabEmployees);
            this.tabControl1.Location = new System.Drawing.Point(47, 14);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1866, 883);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1858, 845);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Northwind Veri Tabanı Giriş Sayfası";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Rockwell", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(506, 352);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(909, 68);
            this.label1.TabIndex = 0;
            this.label1.Text = "Northwind Veri Tabanı Menüler";
            // 
            // tabProduct
            // 
            this.tabProduct.Controls.Add(this.dataGridViewProduct);
            this.tabProduct.Location = new System.Drawing.Point(4, 34);
            this.tabProduct.Name = "tabProduct";
            this.tabProduct.Padding = new System.Windows.Forms.Padding(3);
            this.tabProduct.Size = new System.Drawing.Size(1858, 845);
            this.tabProduct.TabIndex = 1;
            this.tabProduct.Text = "Product";
            this.tabProduct.UseVisualStyleBackColor = true;
            // 
            // dataGridViewProduct
            // 
            this.dataGridViewProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProduct.Location = new System.Drawing.Point(12, 8);
            this.dataGridViewProduct.Name = "dataGridViewProduct";
            this.dataGridViewProduct.RowHeadersWidth = 62;
            this.dataGridViewProduct.RowTemplate.Height = 33;
            this.dataGridViewProduct.Size = new System.Drawing.Size(1822, 831);
            this.dataGridViewProduct.TabIndex = 0;
            this.dataGridViewProduct.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewProduct_CellDoubleClick);
            // 
            // tabSuppplier
            // 
            this.tabSuppplier.Controls.Add(this.dataGridViewSupplier);
            this.tabSuppplier.Location = new System.Drawing.Point(4, 34);
            this.tabSuppplier.Name = "tabSuppplier";
            this.tabSuppplier.Padding = new System.Windows.Forms.Padding(3);
            this.tabSuppplier.Size = new System.Drawing.Size(1858, 845);
            this.tabSuppplier.TabIndex = 2;
            this.tabSuppplier.Text = "Supplier";
            this.tabSuppplier.UseVisualStyleBackColor = true;
            // 
            // dataGridViewSupplier
            // 
            this.dataGridViewSupplier.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSupplier.Location = new System.Drawing.Point(6, 6);
            this.dataGridViewSupplier.Name = "dataGridViewSupplier";
            this.dataGridViewSupplier.RowHeadersWidth = 62;
            this.dataGridViewSupplier.RowTemplate.Height = 33;
            this.dataGridViewSupplier.Size = new System.Drawing.Size(1846, 833);
            this.dataGridViewSupplier.TabIndex = 0;
            this.dataGridViewSupplier.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSupplier_CellDoubleClick);
            // 
            // tabCategories
            // 
            this.tabCategories.Controls.Add(this.dataGridViewCategory);
            this.tabCategories.Location = new System.Drawing.Point(4, 34);
            this.tabCategories.Name = "tabCategories";
            this.tabCategories.Padding = new System.Windows.Forms.Padding(3);
            this.tabCategories.Size = new System.Drawing.Size(1858, 845);
            this.tabCategories.TabIndex = 3;
            this.tabCategories.Text = "Categories";
            this.tabCategories.UseVisualStyleBackColor = true;
            // 
            // dataGridViewCategory
            // 
            this.dataGridViewCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCategory.Location = new System.Drawing.Point(12, 14);
            this.dataGridViewCategory.Name = "dataGridViewCategory";
            this.dataGridViewCategory.RowHeadersWidth = 62;
            this.dataGridViewCategory.RowTemplate.Height = 33;
            this.dataGridViewCategory.Size = new System.Drawing.Size(1840, 825);
            this.dataGridViewCategory.TabIndex = 0;
            this.dataGridViewCategory.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCategory_CellDoubleClick);
            // 
            // tabEmployees
            // 
            this.tabEmployees.Controls.Add(this.dataGridViewEmployee);
            this.tabEmployees.Location = new System.Drawing.Point(4, 34);
            this.tabEmployees.Name = "tabEmployees";
            this.tabEmployees.Padding = new System.Windows.Forms.Padding(3);
            this.tabEmployees.Size = new System.Drawing.Size(1858, 845);
            this.tabEmployees.TabIndex = 4;
            this.tabEmployees.Text = "Employees";
            this.tabEmployees.UseVisualStyleBackColor = true;
            // 
            // dataGridViewEmployee
            // 
            this.dataGridViewEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEmployee.Location = new System.Drawing.Point(4, 8);
            this.dataGridViewEmployee.Name = "dataGridViewEmployee";
            this.dataGridViewEmployee.RowHeadersWidth = 62;
            this.dataGridViewEmployee.RowTemplate.Height = 33;
            this.dataGridViewEmployee.Size = new System.Drawing.Size(1831, 821);
            this.dataGridViewEmployee.TabIndex = 0;
            this.dataGridViewEmployee.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewEmployee_CellDoubleClick);
            // 
            // NorthwindMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1925, 909);
            this.Controls.Add(this.tabControl1);
            this.Name = "NorthwindMainForm";
            this.Text = "NorthwindMainForm";
            this.Load += new System.EventHandler(this.NorthwindMainForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabProduct.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProduct)).EndInit();
            this.tabSuppplier.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSupplier)).EndInit();
            this.tabCategories.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCategory)).EndInit();
            this.tabEmployees.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployee)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private Label label1;
        private TabPage tabProduct;
        private DataGridView dataGridViewProduct;
        private TabPage tabSuppplier;
        private DataGridView dataGridViewSupplier;
        private TabPage tabCategories;
        private TabPage tabEmployees;
        private DataGridView dataGridViewCategory;
        private DataGridView dataGridViewEmployee;
    }
}