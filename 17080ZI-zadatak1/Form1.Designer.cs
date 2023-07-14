namespace _17080ZI_zadatak1
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
            this.cbFileSystemWatcher = new System.Windows.Forms.CheckBox();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.tbxCode = new System.Windows.Forms.TextBox();
            this.tbxAlph = new System.Windows.Forms.TextBox();
            this.tbxCryptS = new System.Windows.Forms.TextBox();
            this.btnCryptF = new System.Windows.Forms.Button();
            this.tbxCrypt = new System.Windows.Forms.TextBox();
            this.btnCryptS = new System.Windows.Forms.Button();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.btnCrypt = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.tbxFindDeck = new System.Windows.Forms.TextBox();
            this.btnDeck = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.rbSS = new System.Windows.Forms.RadioButton();
            this.rbS = new System.Windows.Forms.RadioButton();
            this.cbPCBC = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbFileSystemWatcher
            // 
            this.cbFileSystemWatcher.AutoSize = true;
            this.cbFileSystemWatcher.Location = new System.Drawing.Point(61, 33);
            this.cbFileSystemWatcher.Name = "cbFileSystemWatcher";
            this.cbFileSystemWatcher.Size = new System.Drawing.Size(151, 21);
            this.cbFileSystemWatcher.TabIndex = 4;
            this.cbFileSystemWatcher.Text = "FileSystemWatcher";
            this.cbFileSystemWatcher.UseVisualStyleBackColor = true;
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.Filter = "*txt";
            this.fileSystemWatcher1.IncludeSubdirectories = true;
            this.fileSystemWatcher1.Path = "C:\\Users\\Aleksandra\\source\\repos\\17080ZI-zadatak1\\FileSystemWatcher";
            this.fileSystemWatcher1.SynchronizingObject = this;
            this.fileSystemWatcher1.Changed += new System.IO.FileSystemEventHandler(this.fileSystemWatcher1_Changed);
            this.fileSystemWatcher1.Created += new System.IO.FileSystemEventHandler(this.FileSystemWatcher_Created);
            // 
            // tbxCode
            // 
            this.tbxCode.Location = new System.Drawing.Point(376, 124);
            this.tbxCode.Name = "tbxCode";
            this.tbxCode.Size = new System.Drawing.Size(270, 22);
            this.tbxCode.TabIndex = 1;
            this.tbxCode.Text = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            // 
            // tbxAlph
            // 
            this.tbxAlph.Location = new System.Drawing.Point(52, 124);
            this.tbxAlph.Name = "tbxAlph";
            this.tbxAlph.Size = new System.Drawing.Size(282, 22);
            this.tbxAlph.TabIndex = 0;
            this.tbxAlph.Text = "abcdefghijklmnopqrstuvwxyz";
            // 
            // tbxCryptS
            // 
            this.tbxCryptS.Location = new System.Drawing.Point(52, 230);
            this.tbxCryptS.Name = "tbxCryptS";
            this.tbxCryptS.Size = new System.Drawing.Size(594, 22);
            this.tbxCryptS.TabIndex = 9;
            // 
            // btnCryptF
            // 
            this.btnCryptF.Location = new System.Drawing.Point(705, 167);
            this.btnCryptF.Name = "btnCryptF";
            this.btnCryptF.Size = new System.Drawing.Size(43, 35);
            this.btnCryptF.TabIndex = 5;
            this.btnCryptF.Text = "📁";
            this.btnCryptF.UseVisualStyleBackColor = true;
            this.btnCryptF.Click += new System.EventHandler(this.btnCryptF_Click);
            // 
            // tbxCrypt
            // 
            this.tbxCrypt.Location = new System.Drawing.Point(52, 180);
            this.tbxCrypt.Name = "tbxCrypt";
            this.tbxCrypt.Size = new System.Drawing.Size(594, 22);
            this.tbxCrypt.TabIndex = 2;
            // 
            // btnCryptS
            // 
            this.btnCryptS.Location = new System.Drawing.Point(683, 225);
            this.btnCryptS.Name = "btnCryptS";
            this.btnCryptS.Size = new System.Drawing.Size(91, 27);
            this.btnCryptS.TabIndex = 11;
            this.btnCryptS.Text = "Save";
            this.btnCryptS.UseVisualStyleBackColor = true;
            this.btnCryptS.Click += new System.EventHandler(this.btnCryptS_Click);
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Location = new System.Drawing.Point(444, 326);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(154, 40);
            this.btnDecrypt.TabIndex = 8;
            this.btnDecrypt.Text = "Decrypt";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // btnCrypt
            // 
            this.btnCrypt.Location = new System.Drawing.Point(122, 326);
            this.btnCrypt.Name = "btnCrypt";
            this.btnCrypt.Size = new System.Drawing.Size(154, 40);
            this.btnCrypt.TabIndex = 7;
            this.btnCrypt.Text = "Crypt";
            this.btnCrypt.UseVisualStyleBackColor = true;
            this.btnCrypt.Click += new System.EventHandler(this.btnCrypt_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(52, 416);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(594, 22);
            this.textBox1.TabIndex = 13;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(52, 451);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(594, 22);
            this.textBox2.TabIndex = 16;
            // 
            // tbxFindDeck
            // 
            this.tbxFindDeck.Location = new System.Drawing.Point(52, 286);
            this.tbxFindDeck.Name = "tbxFindDeck";
            this.tbxFindDeck.Size = new System.Drawing.Size(594, 22);
            this.tbxFindDeck.TabIndex = 17;
            // 
            // btnDeck
            // 
            this.btnDeck.Location = new System.Drawing.Point(673, 281);
            this.btnDeck.Name = "btnDeck";
            this.btnDeck.Size = new System.Drawing.Size(115, 27);
            this.btnDeck.TabIndex = 18;
            this.btnDeck.Text = "Find deck";
            this.btnDeck.UseVisualStyleBackColor = true;
            this.btnDeck.Click += new System.EventHandler(this.deck_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 382);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(589, 17);
            this.label1.TabIndex = 19;
            this.label1.Text = "*Spil se prilikom kriptovanja cuva sa kriptovanim fajlom, ovaj spil se koristi pr" +
    "ilikom dekripcije ";
            // 
            // rbSS
            // 
            this.rbSS.AutoSize = true;
            this.rbSS.Location = new System.Drawing.Point(376, 33);
            this.rbSS.Name = "rbSS";
            this.rbSS.Size = new System.Drawing.Size(149, 21);
            this.rbSS.TabIndex = 21;
            this.rbSS.Text = "Simple Substitution";
            this.rbSS.UseVisualStyleBackColor = true;
            this.rbSS.CheckedChanged += new System.EventHandler(this.rbSS_CheckedChanged);
            // 
            // rbS
            // 
            this.rbS.AutoSize = true;
            this.rbS.Checked = true;
            this.rbS.Location = new System.Drawing.Point(376, 72);
            this.rbS.Name = "rbS";
            this.rbS.Size = new System.Drawing.Size(80, 21);
            this.rbS.TabIndex = 22;
            this.rbS.TabStop = true;
            this.rbS.Text = "Solitaire";
            this.rbS.UseVisualStyleBackColor = true;
            this.rbS.CheckedChanged += new System.EventHandler(this.rbS_CheckedChanged);
            // 
            // cbPCBC
            // 
            this.cbPCBC.AutoSize = true;
            this.cbPCBC.Location = new System.Drawing.Point(61, 72);
            this.cbPCBC.Name = "cbPCBC";
            this.cbPCBC.Size = new System.Drawing.Size(66, 21);
            this.cbPCBC.TabIndex = 23;
            this.cbPCBC.Text = "PCBC";
            this.cbPCBC.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 485);
            this.Controls.Add(this.cbPCBC);
            this.Controls.Add(this.rbS);
            this.Controls.Add(this.rbSS);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDeck);
            this.Controls.Add(this.tbxFindDeck);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnDecrypt);
            this.Controls.Add(this.btnCrypt);
            this.Controls.Add(this.tbxCryptS);
            this.Controls.Add(this.tbxCrypt);
            this.Controls.Add(this.btnCryptS);
            this.Controls.Add(this.cbFileSystemWatcher);
            this.Controls.Add(this.tbxAlph);
            this.Controls.Add(this.tbxCode);
            this.Controls.Add(this.btnCryptF);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox cbFileSystemWatcher;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.Button btnCrypt;
        private System.Windows.Forms.TextBox tbxCryptS;
        private System.Windows.Forms.TextBox tbxCrypt;
        private System.Windows.Forms.Button btnCryptS;
        private System.Windows.Forms.TextBox tbxAlph;
        private System.Windows.Forms.TextBox tbxCode;
        private System.Windows.Forms.Button btnCryptF;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDeck;
        private System.Windows.Forms.TextBox tbxFindDeck;
        private System.Windows.Forms.RadioButton rbS;
        private System.Windows.Forms.RadioButton rbSS;
        private System.Windows.Forms.CheckBox cbPCBC;
    }
}

