namespace DHCI
{
    partial class Text
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
            this.TextContent = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TextContent
            // 
            this.TextContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextContent.Location = new System.Drawing.Point(0, 0);
            this.TextContent.Name = "TextContent";
            this.TextContent.Size = new System.Drawing.Size(800, 450);
            this.TextContent.TabIndex = 0;
            this.TextContent.Text = "Homo";
            this.TextContent.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Text
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TextContent);
            this.Name = "Text";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Een belangrijk bericht";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label TextContent;
    }
}