namespace WindowsFormsApp1
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
            this.grafic1 = new WindowsFormsApp1.Grafic();
            this.SuspendLayout();
            // 
            // grafic1
            // 
            this.grafic1.Location = new System.Drawing.Point(111, 35);
            this.grafic1.Name = "grafic1";
            this.grafic1.Size = new System.Drawing.Size(148, 238);
            this.grafic1.TabIndex = 0;
            this.grafic1.Text = "grafic1";
            this.grafic1.Valori = new int[] {
        6,
        10,
        8,
        4};
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.grafic1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Grafic grafic1;
    }
}

