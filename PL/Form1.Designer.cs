namespace PL
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtName = new TextBox();
            txtRssUrl = new TextBox();
            lblName = new Label();
            lblRss = new Label();
            btnLaggTill = new Button();
            lstPoddar = new ListBox();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Location = new Point(32, 71);
            txtName.Name = "txtName";
            txtName.Size = new Size(200, 39);
            txtName.TabIndex = 0;
            // 
            // txtRssUrl
            // 
            txtRssUrl.Location = new Point(276, 71);
            txtRssUrl.Name = "txtRssUrl";
            txtRssUrl.Size = new Size(200, 39);
            txtRssUrl.TabIndex = 1;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(32, 30);
            lblName.Name = "lblName";
            lblName.Size = new Size(83, 32);
            lblName.TabIndex = 2;
            lblName.Text = "Name:";
            // 
            // lblRss
            // 
            lblRss.AutoSize = true;
            lblRss.Location = new Point(276, 30);
            lblRss.Name = "lblRss";
            lblRss.Size = new Size(107, 32);
            lblRss.TabIndex = 3;
            lblRss.Text = "RSS URL:";
            // 
            // btnLaggTill
            // 
            btnLaggTill.Location = new Point(32, 331);
            btnLaggTill.Name = "btnLaggTill";
            btnLaggTill.Size = new Size(150, 46);
            btnLaggTill.TabIndex = 4;
            btnLaggTill.Text = "Lagg Till";
            btnLaggTill.UseVisualStyleBackColor = true;
            btnLaggTill.Click += btnLaggTill_Click;
            // 
            // lstPoddar
            // 
            lstPoddar.FormattingEnabled = true;
            lstPoddar.Location = new Point(32, 147);
            lstPoddar.Name = "lstPoddar";
            lstPoddar.Size = new Size(240, 164);
            lstPoddar.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lstPoddar);
            Controls.Add(btnLaggTill);
            Controls.Add(lblRss);
            Controls.Add(lblName);
            Controls.Add(txtRssUrl);
            Controls.Add(txtName);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtName;
        private TextBox txtRssUrl;
        private Label lblName;
        private Label lblRss;
        private Button btnLaggTill;
        private ListBox lstPoddar;
    }
}
