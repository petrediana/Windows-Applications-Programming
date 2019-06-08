namespace DeToate
{
    partial class FormularPrincipal
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
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aAaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bBBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cCCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graficLinii1 = new DeToate.GraficLinii();
            this.graficBare1 = new DeToate.GraficBare();
            this.treeViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView1.Location = new System.Drawing.Point(0, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(800, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Cod";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 120;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Nume";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Medie";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 174);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(800, 10);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.graficLinii1);
            this.panel1.Controls.Add(this.graficBare1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 184);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 266);
            this.panel1.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aAaToolStripMenuItem,
            this.bBBToolStripMenuItem,
            this.cCCToolStripMenuItem,
            this.listViewToolStripMenuItem,
            this.treeViewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // aAaToolStripMenuItem
            // 
            this.aAaToolStripMenuItem.Name = "aAaToolStripMenuItem";
            this.aAaToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.aAaToolStripMenuItem.Text = "Printeaza Date";
            this.aAaToolStripMenuItem.Click += new System.EventHandler(this.aAaToolStripMenuItem_Click);
            // 
            // bBBToolStripMenuItem
            // 
            this.bBBToolStripMenuItem.Name = "bBBToolStripMenuItem";
            this.bBBToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.bBBToolStripMenuItem.Text = "Salveaza in BD";
            this.bBBToolStripMenuItem.Click += new System.EventHandler(this.bBBToolStripMenuItem_Click);
            // 
            // cCCToolStripMenuItem
            // 
            this.cCCToolStripMenuItem.Name = "cCCToolStripMenuItem";
            this.cCCToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.cCCToolStripMenuItem.Text = "Inchide";
            this.cCCToolStripMenuItem.Click += new System.EventHandler(this.cCCToolStripMenuItem_Click);
            // 
            // listViewToolStripMenuItem
            // 
            this.listViewToolStripMenuItem.Name = "listViewToolStripMenuItem";
            this.listViewToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.listViewToolStripMenuItem.Text = "ListView ";
            this.listViewToolStripMenuItem.Click += new System.EventHandler(this.listViewToolStripMenuItem_Click);
            // 
            // graficLinii1
            // 
            this.graficLinii1.Location = new System.Drawing.Point(420, 18);
            this.graficLinii1.Name = "graficLinii1";
            this.graficLinii1.Size = new System.Drawing.Size(333, 224);
            this.graficLinii1.TabIndex = 1;
            this.graficLinii1.Text = "graficLinii1";
            this.graficLinii1.Valori = new decimal[0];
            // 
            // graficBare1
            // 
            this.graficBare1.Location = new System.Drawing.Point(12, 18);
            this.graficBare1.Name = "graficBare1";
            this.graficBare1.Size = new System.Drawing.Size(333, 224);
            this.graficBare1.TabIndex = 0;
            this.graficBare1.Text = "graficBare1";
            this.graficBare1.Valori = new decimal[0];
            // 
            // treeViewToolStripMenuItem
            // 
            this.treeViewToolStripMenuItem.Name = "treeViewToolStripMenuItem";
            this.treeViewToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.treeViewToolStripMenuItem.Text = "TreeView";
            this.treeViewToolStripMenuItem.Click += new System.EventHandler(this.treeViewToolStripMenuItem_Click);
            // 
            // FormularPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormularPrincipal";
            this.Text = "FormularPrincipal";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aAaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bBBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cCCToolStripMenuItem;
        private GraficBare graficBare1;
        private GraficLinii graficLinii1;
        private System.Windows.Forms.ToolStripMenuItem listViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem treeViewToolStripMenuItem;
    }
}