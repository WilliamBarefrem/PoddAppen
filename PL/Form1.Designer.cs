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
            lblBiblotek = new Label();
            cmbCategoryFilter = new ComboBox();
            btnChangePoddCategory = new Button();
            btnShowRenamePodd = new Button();
            btnTaBortPodd = new Button();
            lstPoddar = new ListBox();
            txtEpisodeInfo = new TextBox();
            lstAvsnitt = new ListBox();
            btnLaddaRss = new Button();
            tabPage1 = new TabPage();
            btnRenameCategory = new Button();
            btnDeleteCategory = new Button();
            btnAddCategory = new Button();
            lstCategories = new ListBox();
            txtCategoryName = new TextBox();
            lblCategoryName = new Label();
            lblRss = new Label();
            txtRssUrl = new TextBox();
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
            L.Location = new Point(12, 8);
            L.Name = "L";
            L.SelectedIndex = 0;
            L.Size = new Size(2041, 1031);
            L.TabIndex = 15;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(lblBiblotek);
            tabPage2.Controls.Add(cmbCategoryFilter);
            tabPage2.Controls.Add(btnChangePoddCategory);
            tabPage2.Controls.Add(btnShowRenamePodd);
            tabPage2.Controls.Add(btnTaBortPodd);
            tabPage2.Controls.Add(lstPoddar);
            tabPage2.Controls.Add(txtEpisodeInfo);
            tabPage2.Controls.Add(lstAvsnitt);
            tabPage2.Controls.Add(btnLaddaRss);
            tabPage2.Location = new Point(8, 46);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(2025, 977);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Biblotek";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // lblBiblotek
            // 
            lblBiblotek.Font = new Font("Segoe UI Black", 28.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBiblotek.Location = new Point(3, 0);
            lblBiblotek.Name = "lblBiblotek";
            lblBiblotek.Size = new Size(358, 102);
            lblBiblotek.TabIndex = 23;
            lblBiblotek.Text = "Biblotek";
            lblBiblotek.Click += lblBiblotek_Click;
            // 
            // cmbCategoryFilter
            // 
            cmbCategoryFilter.FormattingEnabled = true;
            cmbCategoryFilter.Location = new Point(165, 121);
            cmbCategoryFilter.Name = "cmbCategoryFilter";
            cmbCategoryFilter.Size = new Size(242, 40);
            cmbCategoryFilter.TabIndex = 22;
            cmbCategoryFilter.SelectedIndexChanged += cmbCategoryFilter_SelectedIndexChanged;
            // 
            // btnChangePoddCategory
            // 
            btnChangePoddCategory.Location = new Point(393, 704);
            btnChangePoddCategory.Name = "btnChangePoddCategory";
            btnChangePoddCategory.Size = new Size(159, 46);
            btnChangePoddCategory.TabIndex = 21;
            btnChangePoddCategory.Text = "Byt Kategori";
            btnChangePoddCategory.UseVisualStyleBackColor = true;
            btnChangePoddCategory.Click += btnChangePoddCategory_Click;
            // 
            // btnShowRenamePodd
            // 
            btnShowRenamePodd.Location = new Point(182, 703);
            btnShowRenamePodd.Name = "btnShowRenamePodd";
            btnShowRenamePodd.Size = new Size(159, 46);
            btnShowRenamePodd.TabIndex = 20;
            btnShowRenamePodd.Text = "Byt Namn";
            btnShowRenamePodd.UseVisualStyleBackColor = true;
            btnShowRenamePodd.Click += btnShowRenamePodd_Click;
            // 
            // btnTaBortPodd
            // 
            btnTaBortPodd.Location = new Point(182, 755);
            btnTaBortPodd.Name = "btnTaBortPodd";
            btnTaBortPodd.Size = new Size(159, 46);
            btnTaBortPodd.TabIndex = 19;
            btnTaBortPodd.Text = "Ta Bort Podd";
            btnTaBortPodd.UseVisualStyleBackColor = true;
            btnTaBortPodd.Click += btnTaBortPodd_Click_1;
            // 
            // lstPoddar
            // 
            lstPoddar.FormattingEnabled = true;
            lstPoddar.Location = new Point(165, 181);
            lstPoddar.Name = "lstPoddar";
            lstPoddar.Size = new Size(428, 484);
            lstPoddar.TabIndex = 18;
            // 
            // txtEpisodeInfo
            // 
            txtEpisodeInfo.Font = new Font("Segoe UI", 11F);
            txtEpisodeInfo.Location = new Point(1302, 184);
            txtEpisodeInfo.Multiline = true;
            txtEpisodeInfo.Name = "txtEpisodeInfo";
            txtEpisodeInfo.ReadOnly = true;
            txtEpisodeInfo.ScrollBars = ScrollBars.Vertical;
            txtEpisodeInfo.Size = new Size(646, 473);
            txtEpisodeInfo.TabIndex = 17;
            txtEpisodeInfo.TextChanged += txtEpisodeInfo_TextChanged;
            // 
            // lstAvsnitt
            // 
            lstAvsnitt.FormattingEnabled = true;
            lstAvsnitt.Location = new Point(653, 184);
            lstAvsnitt.Name = "lstAvsnitt";
            lstAvsnitt.Size = new Size(513, 484);
            lstAvsnitt.TabIndex = 16;
            lstAvsnitt.SelectedIndexChanged += lstAvsnitt_SelectedIndexChanged;
            // 
            // btnLaddaRss
            // 
            btnLaddaRss.Location = new Point(666, 704);
            btnLaddaRss.Name = "btnLaddaRss";
            btnLaddaRss.Size = new Size(150, 46);
            btnLaddaRss.TabIndex = 15;
            btnLaddaRss.Text = "Ladda RSS";
            btnLaddaRss.UseVisualStyleBackColor = true;
            btnLaddaRss.Click += btnLaddaRss_Click;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(btnRenameCategory);
            tabPage1.Controls.Add(btnDeleteCategory);
            tabPage1.Controls.Add(btnAddCategory);
            tabPage1.Controls.Add(lstCategories);
            tabPage1.Controls.Add(txtCategoryName);
            tabPage1.Controls.Add(lblCategoryName);
            tabPage1.Controls.Add(lblRss);
            tabPage1.Controls.Add(txtRssUrl);
            tabPage1.Controls.Add(btnLaggTill);
            tabPage1.Controls.Add(lblName);
            tabPage1.Controls.Add(txtName);
            tabPage1.Location = new Point(8, 46);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(2025, 977);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Add Podd";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnRenameCategory
            // 
            btnRenameCategory.Location = new Point(1054, 616);
            btnRenameCategory.Name = "btnRenameCategory";
            btnRenameCategory.Size = new Size(303, 46);
            btnRenameCategory.TabIndex = 19;
            btnRenameCategory.Text = "Byt Kategori Namn";
            btnRenameCategory.UseVisualStyleBackColor = true;
            btnRenameCategory.Click += btnRenameCategory_Click;
            // 
            // btnDeleteCategory
            // 
            btnDeleteCategory.Location = new Point(1054, 541);
            btnDeleteCategory.Name = "btnDeleteCategory";
            btnDeleteCategory.Size = new Size(303, 46);
            btnDeleteCategory.TabIndex = 18;
            btnDeleteCategory.Text = "Ta Bort Kategori";
            btnDeleteCategory.UseVisualStyleBackColor = true;
            btnDeleteCategory.Click += btnDeleteCategory_Click_1;
            // 
            // btnAddCategory
            // 
            btnAddCategory.Location = new Point(1054, 460);
            btnAddCategory.Name = "btnAddCategory";
            btnAddCategory.Size = new Size(303, 46);
            btnAddCategory.TabIndex = 17;
            btnAddCategory.Text = "Lagg Till Kategori";
            btnAddCategory.UseVisualStyleBackColor = true;
            btnAddCategory.Click += btnAddCategory_Click_1;
            // 
            // lstCategories
            // 
            lstCategories.FormattingEnabled = true;
            lstCategories.Location = new Point(1094, 246);
            lstCategories.Name = "lstCategories";
            lstCategories.Size = new Size(240, 164);
            lstCategories.TabIndex = 16;
            // 
            // txtCategoryName
            // 
            txtCategoryName.Location = new Point(1094, 178);
            txtCategoryName.Name = "txtCategoryName";
            txtCategoryName.Size = new Size(200, 39);
            txtCategoryName.TabIndex = 15;
            // 
            // lblCategoryName
            // 
            lblCategoryName.AutoSize = true;
            lblCategoryName.Location = new Point(1094, 137);
            lblCategoryName.Name = "lblCategoryName";
            lblCategoryName.Size = new Size(103, 32);
            lblCategoryName.TabIndex = 14;
            lblCategoryName.Text = "Kategori";
            // 
            // lblRss
            // 
            lblRss.AutoSize = true;
            lblRss.Location = new Point(858, 137);
            lblRss.Name = "lblRss";
            lblRss.Size = new Size(107, 32);
            lblRss.TabIndex = 13;
            lblRss.Text = "RSS URL:";
            // 
            // txtRssUrl
            // 
            txtRssUrl.Location = new Point(858, 178);
            txtRssUrl.Name = "txtRssUrl";
            txtRssUrl.Size = new Size(200, 39);
            txtRssUrl.TabIndex = 12;
            // 
            // btnLaggTill
            // 
            btnLaggTill.Location = new Point(609, 283);
            btnLaggTill.Name = "btnLaggTill";
            btnLaggTill.Size = new Size(356, 115);
            btnLaggTill.TabIndex = 9;
            btnLaggTill.Text = "Lagg Till Podd";
            btnLaggTill.UseVisualStyleBackColor = true;
            btnLaggTill.Click += btnLaggTill_Click;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(609, 137);
            lblName.Name = "lblName";
            lblName.Size = new Size(83, 32);
            lblName.TabIndex = 8;
            lblName.Text = "Name:";
            // 
            // txtName
            // 
            txtName.Location = new Point(609, 178);
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
        private ListBox lstCategories;
        private TextBox txtCategoryName;
        private Label lblCategoryName;
        private Label lblRss;
        private TextBox txtRssUrl;
        private Button btnLaggTill;
        private Label lblName;
        private TextBox txtName;
        private Button btnTaBortPodd;
        private ListBox lstPoddar;
        private Button btnShowRenamePodd;
        private Button btnChangePoddCategory;
        private Button btnRenameCategory;
        private Button btnAddCategory;
        private ComboBox cmbCategoryFilter;
        private Label lblBiblotek;
    }
}
