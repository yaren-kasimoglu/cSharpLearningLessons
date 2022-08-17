namespace Serilization_Examplee
{
    partial class Form1
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
            this.btnBinary = new System.Windows.Forms.Button();
            this.btnjson = new System.Windows.Forms.Button();
            this.btnXml = new System.Windows.Forms.Button();
            this.cmbColor = new System.Windows.Forms.ComboBox();
            this.btnFormConfigsave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOkuconfig = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBinary
            // 
            this.btnBinary.Location = new System.Drawing.Point(883, 410);
            this.btnBinary.Name = "btnBinary";
            this.btnBinary.Size = new System.Drawing.Size(265, 59);
            this.btnBinary.TabIndex = 0;
            this.btnBinary.Text = "Binary";
            this.btnBinary.UseVisualStyleBackColor = true;
            // 
            // btnjson
            // 
            this.btnjson.Location = new System.Drawing.Point(883, 538);
            this.btnjson.Name = "btnjson";
            this.btnjson.Size = new System.Drawing.Size(265, 59);
            this.btnjson.TabIndex = 1;
            this.btnjson.Text = "JSON";
            this.btnjson.UseVisualStyleBackColor = true;
            this.btnjson.Click += new System.EventHandler(this.btnjson_Click);
            // 
            // btnXml
            // 
            this.btnXml.Location = new System.Drawing.Point(883, 663);
            this.btnXml.Name = "btnXml";
            this.btnXml.Size = new System.Drawing.Size(265, 59);
            this.btnXml.TabIndex = 2;
            this.btnXml.Text = "XML";
            this.btnXml.UseVisualStyleBackColor = true;
            // 
            // cmbColor
            // 
            this.cmbColor.FormattingEnabled = true;
            this.cmbColor.Location = new System.Drawing.Point(98, 12);
            this.cmbColor.Name = "cmbColor";
            this.cmbColor.Size = new System.Drawing.Size(316, 28);
            this.cmbColor.TabIndex = 3;
            this.cmbColor.SelectedIndexChanged += new System.EventHandler(this.cmbColor_SelectedIndexChanged);
            // 
            // btnFormConfigsave
            // 
            this.btnFormConfigsave.Location = new System.Drawing.Point(98, 61);
            this.btnFormConfigsave.Name = "btnFormConfigsave";
            this.btnFormConfigsave.Size = new System.Drawing.Size(205, 54);
            this.btnFormConfigsave.TabIndex = 4;
            this.btnFormConfigsave.Text = "ayarları kaydet";
            this.btnFormConfigsave.UseVisualStyleBackColor = true;
            this.btnFormConfigsave.Click += new System.EventHandler(this.btnFormConfigsave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "renk";
            // 
            // btnOkuconfig
            // 
            this.btnOkuconfig.Location = new System.Drawing.Point(358, 66);
            this.btnOkuconfig.Name = "btnOkuconfig";
            this.btnOkuconfig.Size = new System.Drawing.Size(173, 49);
            this.btnOkuconfig.TabIndex = 6;
            this.btnOkuconfig.Text = "Ayarları oku";
            this.btnOkuconfig.UseVisualStyleBackColor = true;
            this.btnOkuconfig.Click += new System.EventHandler(this.btnOkuconfig_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1160, 735);
            this.Controls.Add(this.btnOkuconfig);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFormConfigsave);
            this.Controls.Add(this.cmbColor);
            this.Controls.Add(this.btnXml);
            this.Controls.Add(this.btnjson);
            this.Controls.Add(this.btnBinary);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBinary;
        private System.Windows.Forms.Button btnjson;
        private System.Windows.Forms.Button btnXml;
        private System.Windows.Forms.ComboBox cmbColor;
        private System.Windows.Forms.Button btnFormConfigsave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOkuconfig;
    }
}

