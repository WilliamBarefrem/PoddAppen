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
            L = new TabControl();
            tabPage2 = new TabPage();
            txtEpisodeInfo = new TextBox();
            lstAvsnitt = new ListBox();
            btnLaddaRss = new Button();
            tabPage1 = new TabPage();
            btnDeleteCategory = new Button();
            btnAddCategory = new Button();
            lstCategories = new ListBox();
            txtCategoryName = new TextBox();
            lblCategoryName = new Label();
            lblRss = new Label();
            txtRssUrl = new TextBox();
            btnTaBortPodd = new Button();
            lstPoddar = new ListBox();
            btnLaggTill = new Button();
            lblName = new Label();
            txtName = new TextBox();
            L.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage1.SuspendLayout();
            SuspendLayout();
            // 
            // L
            // 
            L.Controls.Add(tabPage2);
            L.Controls.Add(tabPage1);
            L.Location = new Point(12, 12);
            L.Name = "L";
            L.SelectedIndex = 0;
            L.Size = new Size(2041, 1031);
            L.TabIndex = 15;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(txtEpisodeInfo);
            tabPage2.Controls.Add(lstAvsnitt);
            tabPage2.Controls.Add(btnLaddaRss);
            tabPage2.Location = new Point(8, 46);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(2025, 977);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtEpisodeInfo
            // 
            txtEpisodeInfo.Font = new Font("Segoe UI", 11F);
            txtEpisodeInfo.Location = new Point(387, 79);
            txtEpisodeInfo.Multiline = true;
            txtEpisodeInfo.Name = "txtEpisodeInfo";
            txtEpisodeInfo.ReadOnly = true;
            txtEpisodeInfo.ScrollBars = ScrollBars.Vertical;
            txtEpisodeInfo.Size = new Size(300, 200);
            txtEpisodeInfo.TabIndex = 17;
            // 
            // lstAvsnitt
            // 
            lstAvsnitt.FormattingEnabled = true;
            lstAvsnitt.Location = new Point(128, 79);
            lstAvsnitt.Name = "lstAvsnitt";
            lstAvsnitt.Size = new Size(240, 164);
            lstAvsnitt.TabIndex = 16;
            lstAvsnitt.SelectedIndexChanged += lstAvsnitt_SelectedIndexChanged;
            // 
            // btnLaddaRss
            // 
            btnLaddaRss.Location = new Point(98, 277);
            btnLaddaRss.Name = "btnLaddaRss";
            btnLaddaRss.Size = new Size(150, 46);
            btnLaddaRss.TabIndex = 15;
            btnLaddaRss.Text = "Ladda RSS";
            btnLaddaRss.UseVisualStyleBackColor = true;
            btnLaddaRss.Click += btnLaddaRss_Click;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(btnDeleteCategory);
            tabPage1.Controls.Add(btnAddCategory);
            tabPage1.Controls.Add(lstCategories);
            tabPage1.Controls.Add(txtCategoryName);
            tabPage1.Controls.Add(lblCategoryName);
            tabPage1.Controls.Add(lblRss);
            tabPage1.Controls.Add(txtRssUrl);
            tabPage1.Controls.Add(btnTaBortPodd);
            tabPage1.Controls.Add(lstPoddar);
            tabPage1.Controls.Add(btnLaggTill);
            tabPage1.Controls.Add(lblName);
            tabPage1.Controls.Add(txtName);
            tabPage1.Location = new Point(8, 46);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(2025, 977);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnDeleteCategory
            // 
            btnDeleteCategory.Location = new Point(506, 354);
            btnDeleteCategory.Name = "btnDeleteCategory";
            btnDeleteCategory.Size = new Size(220, 46);
            btnDeleteCategory.TabIndex = 18;
            btnDeleteCategory.Text = "Ta Bort Kategori";
            btnDeleteCategory.UseVisualStyleBackColor = true;
            btnDeleteCategory.Click += btnDeleteCategory_Click_1;
            // 
            // btnAddCategory
            // 
            btnAddCategory.Location = new Point(507, 292);
            btnAddCategory.Name = "btnAddCategory";
            btnAddCategory.Size = new Size(219, 46);
            btnAddCategory.TabIndex = 17;
            btnAddCategory.Text = "Lagg Till Kategori";
            btnAddCategory.UseVisualStyleBackColor = true;
            btnAddCategory.Click += btnAddCategory_Click_1;
            // 
            // lstCategories
            // 
            lstCategories.FormattingEnabled = true;
            lstCategories.Location = new Point(505, 115);
            lstCategories.Name = "lstCategories";
            lstCategories.Size = new Size(240, 164);
            lstCategories.TabIndex = 16;
            // 
            // txtCategoryName
            // 
            txtCategoryName.Location = new Point(520, 54);
            txtCategoryName.Name = "txtCategoryName";
            txtCategoryName.Size = new Size(200, 39);
            txtCategoryName.TabIndex = 15;
            // 
            // lblCategoryName
            // 
            lblCategoryName.AutoSize = true;
            lblCategoryName.Location = new Point(520, 13);
            lblCategoryName.Name = "lblCategoryName";
            lblCategoryName.Size = new Size(103, 32);
            lblCategoryName.TabIndex = 14;
            lblCategoryName.Text = "Kategori";
            // 
            // lblRss
            // 
            lblRss.AutoSize = true;
            lblRss.Location = new Point(284, 13);
            lblRss.Name = "lblRss";
            lblRss.Size = new Size(107, 32);
            lblRss.TabIndex = 13;
            lblRss.Text = "RSS URL:";
            // 
            // txtRssUrl
            // 
            txtRssUrl.Location = new Point(284, 54);
            txtRssUrl.Name = "txtRssUrl";
            txtRssUrl.Size = new Size(200, 39);
            txtRssUrl.TabIndex = 12;
            // 
            // btnTaBortPodd
            // 
            btnTaBortPodd.Location = new Point(31, 299);
            btnTaBortPodd.Name = "btnTaBortPodd";
            btnTaBortPodd.Size = new Size(159, 46);
            btnTaBortPodd.TabIndex = 11;
            btnTaBortPodd.Text = "Ta Bort Podd";
            btnTaBortPodd.UseVisualStyleBackColor = true;
            btnTaBortPodd.Click += btnTaBortPodd_Click_1;
            // 
            // lstPoddar
            // 
            lstPoddar.FormattingEnabled = true;
            lstPoddar.Location = new Point(35, 130);
            lstPoddar.Name = "lstPoddar";
            lstPoddar.Size = new Size(240, 164);
            lstPoddar.TabIndex = 10;
            lstPoddar.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // btnLaggTill
            // 
            btnLaggTill.Location = new Point(31, 351);
            btnLaggTill.Name = "btnLaggTill";
            btnLaggTill.Size = new Size(175, 46);
            btnLaggTill.TabIndex = 9;
            btnLaggTill.Text = "Lagg Till Podd";
            btnLaggTill.UseVisualStyleBackColor = true;
            btnLaggTill.Click += btnLaggTill_Click;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(35, 13);
            lblName.Name = "lblName";
            lblName.Size = new Size(83, 32);
            lblName.TabIndex = 8;
            lblName.Text = "Name:";
            // 
            // txtName
            // 
            txtName.Location = new Point(35, 54);
            txtName.Name = "txtName";
            txtName.Size = new Size(200, 39);
            txtName.TabIndex = 7;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2065, 1051);
            Controls.Add(L);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            L.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private TabControl L;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TextBox txtEpisodeInfo;
        private ListBox lstAvsnitt;
        private Button btnLaddaRss;
        private Button btnDeleteCategory;
        private Button btnAddCategory;
        private ListBox lstCategories;
        private TextBox txtCategoryName;
        private Label lblCategoryName;
        private Label lblRss;
        private TextBox txtRssUrl;
        private Button btnTaBortPodd;
        private ListBox lstPoddar;
        private Button btnLaggTill;
        private Label lblName;
        private TextBox txtName;
    }
}
