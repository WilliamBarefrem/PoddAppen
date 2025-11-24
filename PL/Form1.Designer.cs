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
            btnTaBortPodd = new Button();
            lblCategoryName = new Label();
            txtCategoryName = new TextBox();
            lstCategories = new ListBox();
            btnAddCategory = new Button();
            btnDeleteCategory = new Button();
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
            btnLaggTill.Location = new Point(28, 368);
            btnLaggTill.Name = "btnLaggTill";
            btnLaggTill.Size = new Size(175, 46);
            btnLaggTill.TabIndex = 4;
            btnLaggTill.Text = "Lagg Till Podd";
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
            // btnTaBortPodd
            // 
            btnTaBortPodd.Location = new Point(28, 316);
            btnTaBortPodd.Name = "btnTaBortPodd";
            btnTaBortPodd.Size = new Size(159, 46);
            btnTaBortPodd.TabIndex = 6;
            btnTaBortPodd.Text = "Ta Bort Podd";
            btnTaBortPodd.UseVisualStyleBackColor = true;
            btnTaBortPodd.Click += btnTaBortPodd_Click_1;
            // 
            // lblCategoryName
            // 
            lblCategoryName.AutoSize = true;
            lblCategoryName.Location = new Point(513, 40);
            lblCategoryName.Name = "lblCategoryName";
            lblCategoryName.Size = new Size(103, 32);
            lblCategoryName.TabIndex = 7;
            lblCategoryName.Text = "Kategori";
            // 
            // txtCategoryName
            // 
            txtCategoryName.Location = new Point(521, 75);
            txtCategoryName.Name = "txtCategoryName";
            txtCategoryName.Size = new Size(200, 39);
            txtCategoryName.TabIndex = 8;
            // 
            // lstCategories
            // 
            lstCategories.FormattingEnabled = true;
            lstCategories.Location = new Point(521, 147);
            lstCategories.Name = "lstCategories";
            lstCategories.Size = new Size(240, 164);
            lstCategories.TabIndex = 9;
            // 
            // btnAddCategory
            // 
            btnAddCategory.Location = new Point(523, 324);
            btnAddCategory.Name = "btnAddCategory";
            btnAddCategory.Size = new Size(219, 46);
            btnAddCategory.TabIndex = 10;
            btnAddCategory.Text = "Lagg Till Kategori";
            btnAddCategory.UseVisualStyleBackColor = true;
            btnAddCategory.Click += btnAddCategory_Click_1;
            // 
            // btnDeleteCategory
            // 
            btnDeleteCategory.Location = new Point(522, 386);
            btnDeleteCategory.Name = "btnDeleteCategory";
            btnDeleteCategory.Size = new Size(220, 46);
            btnDeleteCategory.TabIndex = 11;
            btnDeleteCategory.Text = "Ta Bort Kategori";
            btnDeleteCategory.UseVisualStyleBackColor = true;
            btnDeleteCategory.Click += btnDeleteCategory_Click_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1234, 595);
            Controls.Add(btnDeleteCategory);
            Controls.Add(btnAddCategory);
            Controls.Add(lstCategories);
            Controls.Add(txtCategoryName);
            Controls.Add(lblCategoryName);
            Controls.Add(btnTaBortPodd);
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
        private Button btnTaBortPodd;
        private Label lblCategoryName;
        private TextBox txtCategoryName;
        private ListBox lstCategories;
        private Button btnAddCategory;
        private Button btnDeleteCategory;
    }
}
