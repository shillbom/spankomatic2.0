namespace Spankomatic
{
    partial class Spankomatic
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.labelTotalPrice = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loggaInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loggautToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.avslutaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verktygToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registreraSomArbetsglädjeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hämtaUtmackbarsbiljetterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrerajobbareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fipplaMedInköpslistanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewButtons = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.registerSalesButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.labelLoggedIn = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.textBoxSearchString = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewButtons)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(598, 27);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.Size = new System.Drawing.Size(249, 385);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
            // 
            // labelTotalPrice
            // 
            this.labelTotalPrice.AutoSize = true;
            this.labelTotalPrice.Font = new System.Drawing.Font("Tahoma", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalPrice.Location = new System.Drawing.Point(510, 458);
            this.labelTotalPrice.Name = "labelTotalPrice";
            this.labelTotalPrice.Size = new System.Drawing.Size(337, 52);
            this.labelTotalPrice.TabIndex = 3;
            this.labelTotalPrice.Text = "Totalpris: 0.00";
            this.labelTotalPrice.TextChanged += new System.EventHandler(this.labelTotalPrice_TextChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.verktygToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(859, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loggaInToolStripMenuItem,
            this.loggautToolStripMenuItem,
            this.toolStripMenuItem1,
            this.avslutaToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.fileToolStripMenuItem.Text = "&Arkiv";
            // 
            // loggaInToolStripMenuItem
            // 
            this.loggaInToolStripMenuItem.Name = "loggaInToolStripMenuItem";
            this.loggaInToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.loggaInToolStripMenuItem.Text = "Logga &in...";
            this.loggaInToolStripMenuItem.Click += new System.EventHandler(this.loggaInToolStripMenuItem_Click);
            // 
            // loggautToolStripMenuItem
            // 
            this.loggautToolStripMenuItem.Enabled = false;
            this.loggautToolStripMenuItem.Name = "loggautToolStripMenuItem";
            this.loggautToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.loggautToolStripMenuItem.Text = "Logga &ut";
            this.loggautToolStripMenuItem.Click += new System.EventHandler(this.loggautToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(126, 6);
            // 
            // avslutaToolStripMenuItem
            // 
            this.avslutaToolStripMenuItem.Name = "avslutaToolStripMenuItem";
            this.avslutaToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.avslutaToolStripMenuItem.Text = "&Avsluta";
            this.avslutaToolStripMenuItem.Click += new System.EventHandler(this.avslutaToolStripMenuItem_Click);
            // 
            // verktygToolStripMenuItem
            // 
            this.verktygToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registreraSomArbetsglädjeToolStripMenuItem,
            this.hämtaUtmackbarsbiljetterToolStripMenuItem,
            this.registrerajobbareToolStripMenuItem,
            this.fipplaMedInköpslistanToolStripMenuItem});
            this.verktygToolStripMenuItem.Name = "verktygToolStripMenuItem";
            this.verktygToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.verktygToolStripMenuItem.Text = "&Verktyg";
            // 
            // registreraSomArbetsglädjeToolStripMenuItem
            // 
            this.registreraSomArbetsglädjeToolStripMenuItem.Name = "registreraSomArbetsglädjeToolStripMenuItem";
            this.registreraSomArbetsglädjeToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.registreraSomArbetsglädjeToolStripMenuItem.Text = "&Registrera som arbetsglädje";
            this.registreraSomArbetsglädjeToolStripMenuItem.Click += new System.EventHandler(this.registreraSomArbetsglädjeToolStripMenuItem_Click);
            // 
            // hämtaUtmackbarsbiljetterToolStripMenuItem
            // 
            this.hämtaUtmackbarsbiljetterToolStripMenuItem.Name = "hämtaUtmackbarsbiljetterToolStripMenuItem";
            this.hämtaUtmackbarsbiljetterToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.hämtaUtmackbarsbiljetterToolStripMenuItem.Text = "Hämta ut &mackbarsbiljetter...";
            this.hämtaUtmackbarsbiljetterToolStripMenuItem.Click += new System.EventHandler(this.hämtaUtmackbarsbiljetterToolStripMenuItem_Click);
            // 
            // registrerajobbareToolStripMenuItem
            // 
            this.registrerajobbareToolStripMenuItem.Enabled = false;
            this.registrerajobbareToolStripMenuItem.Name = "registrerajobbareToolStripMenuItem";
            this.registrerajobbareToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.registrerajobbareToolStripMenuItem.Text = "Registrera &jobbare...";
            this.registrerajobbareToolStripMenuItem.Click += new System.EventHandler(this.registrerajobbareToolStripMenuItem_Click);
            // 
            // fipplaMedInköpslistanToolStripMenuItem
            // 
            this.fipplaMedInköpslistanToolStripMenuItem.Enabled = false;
            this.fipplaMedInköpslistanToolStripMenuItem.Name = "fipplaMedInköpslistanToolStripMenuItem";
            this.fipplaMedInköpslistanToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.fipplaMedInköpslistanToolStripMenuItem.Text = "Fippla med &inköpslistan...";
            this.fipplaMedInköpslistanToolStripMenuItem.Click += new System.EventHandler(this.fipplaMedInköpslistanToolStripMenuItem_Click);
            // 
            // dataGridViewButtons
            // 
            this.dataGridViewButtons.AllowUserToResizeColumns = false;
            this.dataGridViewButtons.AllowUserToResizeRows = false;
            this.dataGridViewButtons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewButtons.ColumnHeadersVisible = false;
            this.dataGridViewButtons.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dataGridViewButtons.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewButtons.Location = new System.Drawing.Point(12, 27);
            this.dataGridViewButtons.Name = "dataGridViewButtons";
            this.dataGridViewButtons.RowHeadersVisible = false;
            this.dataGridViewButtons.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewButtons.Size = new System.Drawing.Size(580, 385);
            this.dataGridViewButtons.TabIndex = 5;
            this.dataGridViewButtons.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewButtons_CellContentClick);
            this.dataGridViewButtons.Click += new System.EventHandler(this.dataGridViewButtons_Click);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Column3";
            this.Column3.Name = "Column3";
            // 
            // registerSalesButton
            // 
            this.registerSalesButton.Location = new System.Drawing.Point(598, 418);
            this.registerSalesButton.Name = "registerSalesButton";
            this.registerSalesButton.Size = new System.Drawing.Size(249, 31);
            this.registerSalesButton.TabIndex = 8;
            this.registerSalesButton.Text = "Registrera försäljning (CTRL+Enter)";
            this.registerSalesButton.UseVisualStyleBackColor = true;
            this.registerSalesButton.Click += new System.EventHandler(this.registerSalesButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(338, 467);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Fusk";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // labelLoggedIn
            // 
            this.labelLoggedIn.AutoSize = true;
            this.labelLoggedIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLoggedIn.ForeColor = System.Drawing.Color.LawnGreen;
            this.labelLoggedIn.Location = new System.Drawing.Point(12, 490);
            this.labelLoggedIn.Name = "labelLoggedIn";
            this.labelLoggedIn.Size = new System.Drawing.Size(0, 13);
            this.labelLoggedIn.TabIndex = 10;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(241, 467);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Visible = false;
            this.okButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxSearchString
            // 
            this.textBoxSearchString.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSearchString.Location = new System.Drawing.Point(15, 423);
            this.textBoxSearchString.Name = "textBoxSearchString";
            this.textBoxSearchString.Size = new System.Drawing.Size(577, 26);
            this.textBoxSearchString.TabIndex = 2;
            this.textBoxSearchString.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Spankomatic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 519);
            this.Controls.Add(this.labelLoggedIn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.registerSalesButton);
            this.Controls.Add(this.dataGridViewButtons);
            this.Controls.Add(this.labelTotalPrice);
            this.Controls.Add(this.textBoxSearchString);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Spankomatic";
            this.Text = "Spankomatic";
            this.Load += new System.EventHandler(this.Spankomatic_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Spankomatic_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Spankomatic_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewButtons)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label labelTotalPrice;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem avslutaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verktygToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registreraSomArbetsglädjeToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridViewButtons;
        private System.Windows.Forms.DataGridViewButtonColumn Column1;
        private System.Windows.Forms.DataGridViewButtonColumn Column2;
        private System.Windows.Forms.DataGridViewButtonColumn Column3;
        private System.Windows.Forms.ToolStripMenuItem hämtaUtmackbarsbiljetterToolStripMenuItem;
        private System.Windows.Forms.Button registerSalesButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem loggaInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrerajobbareToolStripMenuItem;
        private System.Windows.Forms.Label labelLoggedIn;
        private System.Windows.Forms.ToolStripMenuItem loggautToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TextBox textBoxSearchString;
        private System.Windows.Forms.ToolStripMenuItem fipplaMedInköpslistanToolStripMenuItem;

    }
}

