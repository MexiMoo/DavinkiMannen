namespace DHCI
{
    partial class Home
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
            this.SDbar = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Logo = new System.Windows.Forms.PictureBox();
            this.BTN1 = new System.Windows.Forms.Button();
            this.BTN2 = new System.Windows.Forms.Button();
            this.BTN3 = new System.Windows.Forms.Button();
            this.BTN4 = new System.Windows.Forms.Button();
            this.SDbar.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // SDbar
            // 
            this.SDbar.Controls.Add(this.BTN4);
            this.SDbar.Controls.Add(this.BTN3);
            this.SDbar.Controls.Add(this.BTN2);
            this.SDbar.Controls.Add(this.BTN1);
            this.SDbar.Controls.Add(this.panel1);
            this.SDbar.Dock = System.Windows.Forms.DockStyle.Left;
            this.SDbar.Location = new System.Drawing.Point(0, 0);
            this.SDbar.Name = "SDbar";
            this.SDbar.Size = new System.Drawing.Size(120, 450);
            this.SDbar.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Logo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(120, 100);
            this.panel1.TabIndex = 0;
            // 
            // Logo
            // 
            this.Logo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Logo.Image = global::DHCI.Properties.Resources.rbg_big;
            this.Logo.Location = new System.Drawing.Point(0, 0);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(120, 100);
            this.Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Logo.TabIndex = 0;
            this.Logo.TabStop = false;
            // 
            // BTN1
            // 
            this.BTN1.Dock = System.Windows.Forms.DockStyle.Top;
            this.BTN1.Font = new System.Drawing.Font("Showcard Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN1.ForeColor = System.Drawing.Color.Coral;
            this.BTN1.Location = new System.Drawing.Point(0, 100);
            this.BTN1.Name = "BTN1";
            this.BTN1.Size = new System.Drawing.Size(120, 51);
            this.BTN1.TabIndex = 1;
            this.BTN1.Text = "BTN";
            this.BTN1.UseVisualStyleBackColor = true;
            this.BTN1.Click += new System.EventHandler(this.BTN1_Click);
            // 
            // BTN2
            // 
            this.BTN2.Dock = System.Windows.Forms.DockStyle.Top;
            this.BTN2.Font = new System.Drawing.Font("Showcard Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN2.ForeColor = System.Drawing.Color.Coral;
            this.BTN2.Location = new System.Drawing.Point(0, 151);
            this.BTN2.Name = "BTN2";
            this.BTN2.Size = new System.Drawing.Size(120, 51);
            this.BTN2.TabIndex = 2;
            this.BTN2.Text = "BTN";
            this.BTN2.UseVisualStyleBackColor = true;
            this.BTN2.Click += new System.EventHandler(this.BTN2_Click);
            // 
            // BTN3
            // 
            this.BTN3.Dock = System.Windows.Forms.DockStyle.Top;
            this.BTN3.Font = new System.Drawing.Font("Showcard Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN3.ForeColor = System.Drawing.Color.Coral;
            this.BTN3.Location = new System.Drawing.Point(0, 202);
            this.BTN3.Name = "BTN3";
            this.BTN3.Size = new System.Drawing.Size(120, 51);
            this.BTN3.TabIndex = 3;
            this.BTN3.Text = "BTN";
            this.BTN3.UseVisualStyleBackColor = true;
            this.BTN3.Click += new System.EventHandler(this.BTN3_Click);
            // 
            // BTN4
            // 
            this.BTN4.Dock = System.Windows.Forms.DockStyle.Top;
            this.BTN4.Font = new System.Drawing.Font("Showcard Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN4.ForeColor = System.Drawing.Color.Coral;
            this.BTN4.Location = new System.Drawing.Point(0, 253);
            this.BTN4.Name = "BTN4";
            this.BTN4.Size = new System.Drawing.Size(120, 51);
            this.BTN4.TabIndex = 4;
            this.BTN4.Text = "BTN";
            this.BTN4.UseVisualStyleBackColor = true;
            this.BTN4.Click += new System.EventHandler(this.BTN4_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SDbar);
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.SDbar.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel SDbar;
        private System.Windows.Forms.Button BTN1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox Logo;
        private System.Windows.Forms.Button BTN4;
        private System.Windows.Forms.Button BTN3;
        private System.Windows.Forms.Button BTN2;
    }
}

