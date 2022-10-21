namespace EF_CRUD
{
    partial class ProductForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.cmbSupplierId = new System.Windows.Forms.ComboBox();
            this.cmbCategoryId = new System.Windows.Forms.ComboBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.nuUnitsOnOrder = new System.Windows.Forms.NumericUpDown();
            this.nuUnitsInStock = new System.Windows.Forms.NumericUpDown();
            this.nuUnitPrice = new System.Windows.Forms.NumericUpDown();
            this.nuReOrderLevel = new System.Windows.Forms.NumericUpDown();
            this.txtQuantityPerUnit = new System.Windows.Forms.TextBox();
            this.chkDiscontinues = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.nuUnitsOnOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuUnitsInStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuUnitPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuReOrderLevel)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(81, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "ProductName";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(81, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "SupplierId";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(81, 228);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "CategoryId";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(81, 292);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "QuantityPerUnit";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(81, 374);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "UnitPrice";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(81, 456);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 25);
            this.label6.TabIndex = 5;
            this.label6.Text = "UnitsInStock";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(81, 548);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 25);
            this.label7.TabIndex = 6;
            this.label7.Text = "UnitsOnOrder";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(81, 628);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(113, 25);
            this.label8.TabIndex = 7;
            this.label8.Text = "ReorderLevel";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(81, 715);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(116, 25);
            this.label9.TabIndex = 8;
            this.label9.Text = "Discontinued";
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(210, 84);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(259, 31);
            this.txtProductName.TabIndex = 9;
            // 
            // cmbSupplierId
            // 
            this.cmbSupplierId.FormattingEnabled = true;
            this.cmbSupplierId.Location = new System.Drawing.Point(211, 146);
            this.cmbSupplierId.Name = "cmbSupplierId";
            this.cmbSupplierId.Size = new System.Drawing.Size(261, 33);
            this.cmbSupplierId.TabIndex = 10;
            // 
            // cmbCategoryId
            // 
            this.cmbCategoryId.FormattingEnabled = true;
            this.cmbCategoryId.Location = new System.Drawing.Point(208, 225);
            this.cmbCategoryId.Name = "cmbCategoryId";
            this.cmbCategoryId.Size = new System.Drawing.Size(261, 33);
            this.cmbCategoryId.TabIndex = 11;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(664, 67);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(151, 130);
            this.btnNew.TabIndex = 18;
            this.btnNew.Text = "YENİ";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(664, 307);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(151, 130);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "KAYDET";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(664, 548);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(151, 130);
            this.btnDelete.TabIndex = 20;
            this.btnDelete.Text = "SİL";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // nuUnitsOnOrder
            // 
            this.nuUnitsOnOrder.DecimalPlaces = 2;
            this.nuUnitsOnOrder.Location = new System.Drawing.Point(266, 532);
            this.nuUnitsOnOrder.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nuUnitsOnOrder.Name = "nuUnitsOnOrder";
            this.nuUnitsOnOrder.Size = new System.Drawing.Size(139, 31);
            this.nuUnitsOnOrder.TabIndex = 22;
            // 
            // nuUnitsInStock
            // 
            this.nuUnitsInStock.DecimalPlaces = 2;
            this.nuUnitsInStock.Location = new System.Drawing.Point(266, 450);
            this.nuUnitsInStock.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nuUnitsInStock.Name = "nuUnitsInStock";
            this.nuUnitsInStock.Size = new System.Drawing.Size(139, 31);
            this.nuUnitsInStock.TabIndex = 23;
            // 
            // nuUnitPrice
            // 
            this.nuUnitPrice.DecimalPlaces = 2;
            this.nuUnitPrice.Location = new System.Drawing.Point(266, 369);
            this.nuUnitPrice.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nuUnitPrice.Name = "nuUnitPrice";
            this.nuUnitPrice.Size = new System.Drawing.Size(139, 31);
            this.nuUnitPrice.TabIndex = 24;
            // 
            // nuReOrderLevel
            // 
            this.nuReOrderLevel.DecimalPlaces = 2;
            this.nuReOrderLevel.Location = new System.Drawing.Point(266, 621);
            this.nuReOrderLevel.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nuReOrderLevel.Name = "nuReOrderLevel";
            this.nuReOrderLevel.Size = new System.Drawing.Size(139, 31);
            this.nuReOrderLevel.TabIndex = 25;
            // 
            // txtQuantityPerUnit
            // 
            this.txtQuantityPerUnit.Location = new System.Drawing.Point(257, 292);
            this.txtQuantityPerUnit.Name = "txtQuantityPerUnit";
            this.txtQuantityPerUnit.Size = new System.Drawing.Size(212, 31);
            this.txtQuantityPerUnit.TabIndex = 26;
            // 
            // chkDiscontinues
            // 
            this.chkDiscontinues.AutoSize = true;
            this.chkDiscontinues.Location = new System.Drawing.Point(258, 712);
            this.chkDiscontinues.Name = "chkDiscontinues";
            this.chkDiscontinues.Size = new System.Drawing.Size(123, 29);
            this.chkDiscontinues.TabIndex = 27;
            this.chkDiscontinues.Text = "Satışta Mı?";
            this.chkDiscontinues.UseVisualStyleBackColor = true;
            // 
            // ProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 928);
            this.Controls.Add(this.chkDiscontinues);
            this.Controls.Add(this.txtQuantityPerUnit);
            this.Controls.Add(this.nuReOrderLevel);
            this.Controls.Add(this.nuUnitPrice);
            this.Controls.Add(this.nuUnitsInStock);
            this.Controls.Add(this.nuUnitsOnOrder);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.cmbCategoryId);
            this.Controls.Add(this.cmbSupplierId);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ProductForm";
            this.Text = "ProductForm";
            this.Load += new System.EventHandler(this.ProductForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nuUnitsOnOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuUnitsInStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuUnitPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuReOrderLevel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private TextBox txtProductName;
        private ComboBox cmbSupplierId;
        private ComboBox cmbCategoryId;
        private Button btnNew;
        private Button btnSave;
        private Button btnDelete;
        private NumericUpDown nuUnitsOnOrder;
        private NumericUpDown nuUnitsInStock;
        private NumericUpDown nuUnitPrice;
        private NumericUpDown nuReOrderLevel;
        private TextBox txtQuantityPerUnit;
        private CheckBox chkDiscontinues;
    }
}