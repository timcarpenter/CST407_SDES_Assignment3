namespace CST407_SDES_Assignment3
{
    partial class SDES_Program
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
            this.txtbx_Key = new System.Windows.Forms.TextBox();
            this.txtbx_toEncrypt = new System.Windows.Forms.TextBox();
            this.txtbx_toDecrypt = new System.Windows.Forms.TextBox();
            this.btn_Key = new System.Windows.Forms.Button();
            this.btn_toEncrypt = new System.Windows.Forms.Button();
            this.btn_toDecrypt = new System.Windows.Forms.Button();
            this.txtbx_Result = new System.Windows.Forms.TextBox();
            this.txtbx_K2 = new System.Windows.Forms.TextBox();
            this.txtbx_K1 = new System.Windows.Forms.TextBox();
            this.lbl_Key = new System.Windows.Forms.Label();
            this.lbl_toEncrypt = new System.Windows.Forms.Label();
            this.lbl_toDecrypt = new System.Windows.Forms.Label();
            this.lbl_result = new System.Windows.Forms.Label();
            this.lbl_K1 = new System.Windows.Forms.Label();
            this.lbl_K2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtbx_Key
            // 
            this.txtbx_Key.Location = new System.Drawing.Point(134, 70);
            this.txtbx_Key.Name = "txtbx_Key";
            this.txtbx_Key.Size = new System.Drawing.Size(134, 20);
            this.txtbx_Key.TabIndex = 0;
            // 
            // txtbx_toEncrypt
            // 
            this.txtbx_toEncrypt.Location = new System.Drawing.Point(134, 128);
            this.txtbx_toEncrypt.Name = "txtbx_toEncrypt";
            this.txtbx_toEncrypt.Size = new System.Drawing.Size(134, 20);
            this.txtbx_toEncrypt.TabIndex = 1;
            // 
            // txtbx_toDecrypt
            // 
            this.txtbx_toDecrypt.Location = new System.Drawing.Point(134, 186);
            this.txtbx_toDecrypt.Name = "txtbx_toDecrypt";
            this.txtbx_toDecrypt.Size = new System.Drawing.Size(134, 20);
            this.txtbx_toDecrypt.TabIndex = 2;
            // 
            // btn_Key
            // 
            this.btn_Key.Location = new System.Drawing.Point(361, 67);
            this.btn_Key.Name = "btn_Key";
            this.btn_Key.Size = new System.Drawing.Size(119, 24);
            this.btn_Key.TabIndex = 3;
            this.btn_Key.Text = "Generate Key";
            this.btn_Key.UseVisualStyleBackColor = true;
            this.btn_Key.Click += new System.EventHandler(this.btn_Key_Click);
            // 
            // btn_toEncrypt
            // 
            this.btn_toEncrypt.Location = new System.Drawing.Point(361, 125);
            this.btn_toEncrypt.Name = "btn_toEncrypt";
            this.btn_toEncrypt.Size = new System.Drawing.Size(119, 24);
            this.btn_toEncrypt.TabIndex = 4;
            this.btn_toEncrypt.Text = "Encrypt";
            this.btn_toEncrypt.UseVisualStyleBackColor = true;
            this.btn_toEncrypt.Click += new System.EventHandler(this.btn_toEncrypt_Click);
            // 
            // btn_toDecrypt
            // 
            this.btn_toDecrypt.Location = new System.Drawing.Point(361, 183);
            this.btn_toDecrypt.Name = "btn_toDecrypt";
            this.btn_toDecrypt.Size = new System.Drawing.Size(119, 24);
            this.btn_toDecrypt.TabIndex = 5;
            this.btn_toDecrypt.Text = "Decrypt";
            this.btn_toDecrypt.UseVisualStyleBackColor = true;
            this.btn_toDecrypt.Click += new System.EventHandler(this.btn_toDecrypt_Click);
            // 
            // txtbx_Result
            // 
            this.txtbx_Result.Location = new System.Drawing.Point(134, 314);
            this.txtbx_Result.Name = "txtbx_Result";
            this.txtbx_Result.ReadOnly = true;
            this.txtbx_Result.Size = new System.Drawing.Size(134, 20);
            this.txtbx_Result.TabIndex = 6;
            // 
            // txtbx_K2
            // 
            this.txtbx_K2.Location = new System.Drawing.Point(355, 370);
            this.txtbx_K2.Name = "txtbx_K2";
            this.txtbx_K2.ReadOnly = true;
            this.txtbx_K2.Size = new System.Drawing.Size(158, 20);
            this.txtbx_K2.TabIndex = 7;
            // 
            // txtbx_K1
            // 
            this.txtbx_K1.Location = new System.Drawing.Point(355, 314);
            this.txtbx_K1.Name = "txtbx_K1";
            this.txtbx_K1.ReadOnly = true;
            this.txtbx_K1.Size = new System.Drawing.Size(158, 20);
            this.txtbx_K1.TabIndex = 8;
            // 
            // lbl_Key
            // 
            this.lbl_Key.AutoSize = true;
            this.lbl_Key.Location = new System.Drawing.Point(54, 73);
            this.lbl_Key.Name = "lbl_Key";
            this.lbl_Key.Size = new System.Drawing.Size(31, 13);
            this.lbl_Key.TabIndex = 9;
            this.lbl_Key.Text = "Key: ";
            // 
            // lbl_toEncrypt
            // 
            this.lbl_toEncrypt.AutoSize = true;
            this.lbl_toEncrypt.Location = new System.Drawing.Point(54, 131);
            this.lbl_toEncrypt.Name = "lbl_toEncrypt";
            this.lbl_toEncrypt.Size = new System.Drawing.Size(65, 13);
            this.lbl_toEncrypt.TabIndex = 10;
            this.lbl_toEncrypt.Text = "To Encrypt: ";
            // 
            // lbl_toDecrypt
            // 
            this.lbl_toDecrypt.AutoSize = true;
            this.lbl_toDecrypt.Location = new System.Drawing.Point(54, 189);
            this.lbl_toDecrypt.Name = "lbl_toDecrypt";
            this.lbl_toDecrypt.Size = new System.Drawing.Size(66, 13);
            this.lbl_toDecrypt.TabIndex = 11;
            this.lbl_toDecrypt.Text = "To Decrypt: ";
            // 
            // lbl_result
            // 
            this.lbl_result.AutoSize = true;
            this.lbl_result.Location = new System.Drawing.Point(54, 317);
            this.lbl_result.Name = "lbl_result";
            this.lbl_result.Size = new System.Drawing.Size(37, 13);
            this.lbl_result.TabIndex = 12;
            this.lbl_result.Text = "Result";
            // 
            // lbl_K1
            // 
            this.lbl_K1.AutoSize = true;
            this.lbl_K1.Location = new System.Drawing.Point(320, 317);
            this.lbl_K1.Name = "lbl_K1";
            this.lbl_K1.Size = new System.Drawing.Size(20, 13);
            this.lbl_K1.TabIndex = 13;
            this.lbl_K1.Text = "K1";
            // 
            // lbl_K2
            // 
            this.lbl_K2.AutoSize = true;
            this.lbl_K2.Location = new System.Drawing.Point(320, 373);
            this.lbl_K2.Name = "lbl_K2";
            this.lbl_K2.Size = new System.Drawing.Size(20, 13);
            this.lbl_K2.TabIndex = 14;
            this.lbl_K2.Text = "K2";
            // 
            // SDES_Program
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 461);
            this.Controls.Add(this.lbl_K2);
            this.Controls.Add(this.lbl_K1);
            this.Controls.Add(this.lbl_result);
            this.Controls.Add(this.lbl_toDecrypt);
            this.Controls.Add(this.lbl_toEncrypt);
            this.Controls.Add(this.lbl_Key);
            this.Controls.Add(this.txtbx_K1);
            this.Controls.Add(this.txtbx_K2);
            this.Controls.Add(this.txtbx_Result);
            this.Controls.Add(this.btn_toDecrypt);
            this.Controls.Add(this.btn_toEncrypt);
            this.Controls.Add(this.btn_Key);
            this.Controls.Add(this.txtbx_toDecrypt);
            this.Controls.Add(this.txtbx_toEncrypt);
            this.Controls.Add(this.txtbx_Key);
            this.Name = "SDES_Program";
            this.Text = "SDES - Assignment 3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtbx_Key;
        private System.Windows.Forms.TextBox txtbx_toEncrypt;
        private System.Windows.Forms.TextBox txtbx_toDecrypt;
        private System.Windows.Forms.Button btn_Key;
        private System.Windows.Forms.Button btn_toEncrypt;
        private System.Windows.Forms.Button btn_toDecrypt;
        private System.Windows.Forms.TextBox txtbx_Result;
        private System.Windows.Forms.TextBox txtbx_K2;
        private System.Windows.Forms.TextBox txtbx_K1;
        private System.Windows.Forms.Label lbl_Key;
        private System.Windows.Forms.Label lbl_toEncrypt;
        private System.Windows.Forms.Label lbl_toDecrypt;
        private System.Windows.Forms.Label lbl_result;
        private System.Windows.Forms.Label lbl_K1;
        private System.Windows.Forms.Label lbl_K2;
    }
}

