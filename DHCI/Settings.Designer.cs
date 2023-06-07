namespace DHCI
{
    partial class Settings
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
            this.st_TP = new System.Windows.Forms.Button();
            this.st_AS = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // st_TP
            // 
            this.st_TP.Dock = System.Windows.Forms.DockStyle.Top;
            this.st_TP.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.st_TP.ForeColor = System.Drawing.Color.Red;
            this.st_TP.Location = new System.Drawing.Point(0, 0);
            this.st_TP.Name = "st_TP";
            this.st_TP.Size = new System.Drawing.Size(800, 100);
            this.st_TP.TabIndex = 0;
            this.st_TP.Text = "Stop programma";
            this.st_TP.UseVisualStyleBackColor = true;
            this.st_TP.Click += new System.EventHandler(this.st_TP_Click);
            // 
            // st_AS
            // 
            this.st_AS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.st_AS.Location = new System.Drawing.Point(0, 100);
            this.st_AS.Name = "st_AS";
            this.st_AS.Size = new System.Drawing.Size(800, 100);
            this.st_AS.TabIndex = 1;
            this.st_AS.Text = "Start programma automatisch met Windows";
            this.st_AS.UseVisualStyleBackColor = true;
            this.st_AS.CheckedChanged += new System.EventHandler(this.st_AS_CheckedChanged);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 200);
            this.Controls.Add(this.st_AS);
            this.Controls.Add(this.st_TP);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Settings";
            this.Text = "Settings";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button st_TP;
        private System.Windows.Forms.CheckBox st_AS;
    }
}