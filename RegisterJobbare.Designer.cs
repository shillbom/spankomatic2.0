namespace Spankomatic
{
    partial class RegisterJobbare
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
            this.dataGridViewAddedUsers = new System.Windows.Forms.DataGridView();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxCommonUsers = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labelError = new System.Windows.Forms.Label();
            this.buttonRegister = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dataGridViewSenaste = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAddedUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSenaste)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewAddedUsers
            // 
            this.dataGridViewAddedUsers.AllowUserToAddRows = false;
            this.dataGridViewAddedUsers.AllowUserToDeleteRows = false;
            this.dataGridViewAddedUsers.AllowUserToResizeColumns = false;
            this.dataGridViewAddedUsers.AllowUserToResizeRows = false;
            this.dataGridViewAddedUsers.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewAddedUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAddedUsers.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewAddedUsers.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dataGridViewAddedUsers.Location = new System.Drawing.Point(256, 12);
            this.dataGridViewAddedUsers.Name = "dataGridViewAddedUsers";
            this.dataGridViewAddedUsers.ReadOnly = true;
            this.dataGridViewAddedUsers.RowHeadersVisible = false;
            this.dataGridViewAddedUsers.Size = new System.Drawing.Size(300, 268);
            this.dataGridViewAddedUsers.TabIndex = 0;
            this.dataGridViewAddedUsers.SelectionChanged += new System.EventHandler(this.dataGridViewAddedUsers_SelectionChanged);
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.Location = new System.Drawing.Point(12, 64);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(160, 20);
            this.textBoxLogin.TabIndex = 1;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(175, 12);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 110);
            this.buttonAdd.TabIndex = 2;
            this.buttonAdd.Text = "Lägg till";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ange login:";
            // 
            // comboBoxCommonUsers
            // 
            this.comboBoxCommonUsers.FormattingEnabled = true;
            this.comboBoxCommonUsers.Location = new System.Drawing.Point(12, 104);
            this.comboBoxCommonUsers.Name = "comboBoxCommonUsers";
            this.comboBoxCommonUsers.Size = new System.Drawing.Size(160, 21);
            this.comboBoxCommonUsers.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Eller välj de vanligaste från listan:";
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.ForeColor = System.Drawing.Color.Red;
            this.labelError.Location = new System.Drawing.Point(9, 58);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(0, 13);
            this.labelError.TabIndex = 6;
            // 
            // buttonRegister
            // 
            this.buttonRegister.Location = new System.Drawing.Point(99, 257);
            this.buttonRegister.Name = "buttonRegister";
            this.buttonRegister.Size = new System.Drawing.Size(151, 23);
            this.buttonRegister.TabIndex = 7;
            this.buttonRegister.Text = "Klar! Registrera slafvarna!";
            this.buttonRegister.UseVisualStyleBackColor = true;
            this.buttonRegister.Click += new System.EventHandler(this.buttonRegister_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Datum:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(12, 25);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(160, 20);
            this.dateTimePicker1.TabIndex = 9;
            // 
            // dataGridViewSenaste
            // 
            this.dataGridViewSenaste.AllowUserToAddRows = false;
            this.dataGridViewSenaste.AllowUserToDeleteRows = false;
            this.dataGridViewSenaste.AllowUserToResizeColumns = false;
            this.dataGridViewSenaste.AllowUserToResizeRows = false;
            this.dataGridViewSenaste.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewSenaste.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSenaste.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewSenaste.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dataGridViewSenaste.Location = new System.Drawing.Point(562, 28);
            this.dataGridViewSenaste.Name = "dataGridViewSenaste";
            this.dataGridViewSenaste.ReadOnly = true;
            this.dataGridViewSenaste.RowHeadersVisible = false;
            this.dataGridViewSenaste.Size = new System.Drawing.Size(300, 252);
            this.dataGridViewSenaste.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(559, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Senaste registreringarna:";
            // 
            // RegisterJobbare
            // 
            this.AcceptButton = this.buttonAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 292);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridViewSenaste);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonRegister);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxCommonUsers);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.textBoxLogin);
            this.Controls.Add(this.dataGridViewAddedUsers);
            this.Name = "RegisterJobbare";
            this.Text = "RegisterJobbare";
            this.Load += new System.EventHandler(this.RegisterJobbare_Load);
            this.Shown += new System.EventHandler(this.RegisterJobbare_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAddedUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSenaste)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewAddedUsers;
        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxCommonUsers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.Button buttonRegister;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DataGridView dataGridViewSenaste;
        private System.Windows.Forms.Label label4;
    }
}