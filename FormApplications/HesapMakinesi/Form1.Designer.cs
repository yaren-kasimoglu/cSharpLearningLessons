namespace HesapMakinesi
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
            this.txtS1 = new System.Windows.Forms.TextBox();
            this.txts2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnTopla = new System.Windows.Forms.Button();
            this.btnCarp = new System.Windows.Forms.Button();
            this.btnCikar = new System.Windows.Forms.Button();
            this.btnBol = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtS1
            // 
            this.txtS1.Location = new System.Drawing.Point(123, 70);
            this.txtS1.Name = "txtS1";
            this.txtS1.Size = new System.Drawing.Size(59, 26);
            this.txtS1.TabIndex = 0;
            // 
            // txts2
            // 
            this.txts2.Location = new System.Drawing.Point(122, 194);
            this.txts2.Name = "txts2";
            this.txts2.Size = new System.Drawing.Size(59, 26);
            this.txts2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(119, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sayı 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(130, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Sayı 2";
            // 
            // btnTopla
            // 
            this.btnTopla.Location = new System.Drawing.Point(390, 28);
            this.btnTopla.Name = "btnTopla";
            this.btnTopla.Size = new System.Drawing.Size(90, 68);
            this.btnTopla.TabIndex = 4;
            this.btnTopla.Text = "Topla";
            this.btnTopla.UseVisualStyleBackColor = true;
            this.btnTopla.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCarp
            // 
            this.btnCarp.Location = new System.Drawing.Point(390, 227);
            this.btnCarp.Name = "btnCarp";
            this.btnCarp.Size = new System.Drawing.Size(90, 68);
            this.btnCarp.TabIndex = 5;
            this.btnCarp.Text = "Çarp";
            this.btnCarp.UseVisualStyleBackColor = true;
            this.btnCarp.Click += new System.EventHandler(this.btnCarp_Click);
            // 
            // btnCikar
            // 
            this.btnCikar.Location = new System.Drawing.Point(390, 127);
            this.btnCikar.Name = "btnCikar";
            this.btnCikar.Size = new System.Drawing.Size(90, 68);
            this.btnCikar.TabIndex = 6;
            this.btnCikar.Text = "Çıkar";
            this.btnCikar.UseVisualStyleBackColor = true;
            this.btnCikar.Click += new System.EventHandler(this.btnCikar_Click);
            // 
            // btnBol
            // 
            this.btnBol.Location = new System.Drawing.Point(390, 337);
            this.btnBol.Name = "btnBol";
            this.btnBol.Size = new System.Drawing.Size(90, 68);
            this.btnBol.TabIndex = 7;
            this.btnBol.Text = "Böl";
            this.btnBol.UseVisualStyleBackColor = true;
            this.btnBol.Click += new System.EventHandler(this.btnBol_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnBol);
            this.Controls.Add(this.btnCikar);
            this.Controls.Add(this.btnCarp);
            this.Controls.Add(this.btnTopla);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txts2);
            this.Controls.Add(this.txtS1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtS1;
        private System.Windows.Forms.TextBox txts2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnTopla;
        private System.Windows.Forms.Button btnCarp;
        private System.Windows.Forms.Button btnCikar;
        private System.Windows.Forms.Button btnBol;
    }
}

