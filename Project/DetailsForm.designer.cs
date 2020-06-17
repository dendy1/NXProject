namespace NXProject
{
    partial class DetailsForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetailsForm));
            this.detailsTabControl = new System.Windows.Forms.TabControl();
            this.boltTabPage = new System.Windows.Forms.TabPage();
            this.boltLengthComboBox = new System.Windows.Forms.ComboBox();
            this.boltTextBox = new System.Windows.Forms.TextBox();
            this.boltComboBox = new System.Windows.Forms.ComboBox();
            this.boltPictureBox = new System.Windows.Forms.PictureBox();
            this.screwTabPage = new System.Windows.Forms.TabPage();
            this.screwLengthComboBox = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.screwTextBox = new System.Windows.Forms.TextBox();
            this.screwComboBox = new System.Windows.Forms.ComboBox();
            this.nutTabPage = new System.Windows.Forms.TabPage();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.nutTextBox = new System.Windows.Forms.TextBox();
            this.nutComboBox = new System.Windows.Forms.ComboBox();
            this.buildButton = new System.Windows.Forms.Button();
            this.detailsTabControl.SuspendLayout();
            this.boltTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.boltPictureBox)).BeginInit();
            this.screwTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.nutTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // detailsTabControl
            // 
            this.detailsTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.detailsTabControl.Controls.Add(this.boltTabPage);
            this.detailsTabControl.Controls.Add(this.screwTabPage);
            this.detailsTabControl.Controls.Add(this.nutTabPage);
            this.detailsTabControl.Location = new System.Drawing.Point(0, 1);
            this.detailsTabControl.Name = "detailsTabControl";
            this.detailsTabControl.SelectedIndex = 0;
            this.detailsTabControl.Size = new System.Drawing.Size(1334, 516);
            this.detailsTabControl.TabIndex = 0;
            // 
            // boltTabPage
            // 
            this.boltTabPage.Controls.Add(this.boltLengthComboBox);
            this.boltTabPage.Controls.Add(this.boltTextBox);
            this.boltTabPage.Controls.Add(this.boltComboBox);
            this.boltTabPage.Controls.Add(this.boltPictureBox);
            this.boltTabPage.Location = new System.Drawing.Point(4, 29);
            this.boltTabPage.Name = "boltTabPage";
            this.boltTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.boltTabPage.Size = new System.Drawing.Size(1326, 483);
            this.boltTabPage.TabIndex = 0;
            this.boltTabPage.Text = "Болты";
            this.boltTabPage.UseVisualStyleBackColor = true;
            // 
            // boltLengthComboBox
            // 
            this.boltLengthComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.boltLengthComboBox.FormattingEnabled = true;
            this.boltLengthComboBox.Items.AddRange(new object[] {
            "M10",
            "M12",
            "M16",
            "M20",
            "M24",
            "M30"});
            this.boltLengthComboBox.Location = new System.Drawing.Point(722, 40);
            this.boltLengthComboBox.Name = "boltLengthComboBox";
            this.boltLengthComboBox.Size = new System.Drawing.Size(596, 28);
            this.boltLengthComboBox.TabIndex = 3;
            // 
            // boltTextBox
            // 
            this.boltTextBox.Location = new System.Drawing.Point(722, 74);
            this.boltTextBox.Multiline = true;
            this.boltTextBox.Name = "boltTextBox";
            this.boltTextBox.ReadOnly = true;
            this.boltTextBox.Size = new System.Drawing.Size(596, 397);
            this.boltTextBox.TabIndex = 2;
            // 
            // boltComboBox
            // 
            this.boltComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.boltComboBox.FormattingEnabled = true;
            this.boltComboBox.Items.AddRange(new object[] {
            "M10",
            "M12",
            "M16",
            "M20",
            "M24",
            "M30"});
            this.boltComboBox.Location = new System.Drawing.Point(722, 6);
            this.boltComboBox.Name = "boltComboBox";
            this.boltComboBox.Size = new System.Drawing.Size(596, 28);
            this.boltComboBox.TabIndex = 1;
            this.boltComboBox.SelectedIndexChanged += new System.EventHandler(this.boltComboBox_SelectedIndexChanged);
            // 
            // boltPictureBox
            // 
            this.boltPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.boltPictureBox.Image = global::NXProject.Properties.Resources.болт;
            this.boltPictureBox.InitialImage = ((System.Drawing.Image)(resources.GetObject("boltPictureBox.InitialImage")));
            this.boltPictureBox.Location = new System.Drawing.Point(8, 6);
            this.boltPictureBox.Name = "boltPictureBox";
            this.boltPictureBox.Size = new System.Drawing.Size(708, 465);
            this.boltPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.boltPictureBox.TabIndex = 0;
            this.boltPictureBox.TabStop = false;
            // 
            // screwTabPage
            // 
            this.screwTabPage.Controls.Add(this.screwLengthComboBox);
            this.screwTabPage.Controls.Add(this.pictureBox1);
            this.screwTabPage.Controls.Add(this.screwTextBox);
            this.screwTabPage.Controls.Add(this.screwComboBox);
            this.screwTabPage.Location = new System.Drawing.Point(4, 29);
            this.screwTabPage.Name = "screwTabPage";
            this.screwTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.screwTabPage.Size = new System.Drawing.Size(1326, 483);
            this.screwTabPage.TabIndex = 1;
            this.screwTabPage.Text = "Винты";
            this.screwTabPage.UseVisualStyleBackColor = true;
            // 
            // screwLengthComboBox
            // 
            this.screwLengthComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.screwLengthComboBox.FormattingEnabled = true;
            this.screwLengthComboBox.Location = new System.Drawing.Point(722, 40);
            this.screwLengthComboBox.Name = "screwLengthComboBox";
            this.screwLengthComboBox.Size = new System.Drawing.Size(596, 28);
            this.screwLengthComboBox.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Image = global::NXProject.Properties.Resources.винт;
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(8, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(708, 465);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // screwTextBox
            // 
            this.screwTextBox.Location = new System.Drawing.Point(722, 74);
            this.screwTextBox.Multiline = true;
            this.screwTextBox.Name = "screwTextBox";
            this.screwTextBox.ReadOnly = true;
            this.screwTextBox.Size = new System.Drawing.Size(596, 397);
            this.screwTextBox.TabIndex = 3;
            // 
            // screwComboBox
            // 
            this.screwComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.screwComboBox.FormattingEnabled = true;
            this.screwComboBox.Items.AddRange(new object[] {
            "M8",
            "M10",
            "M12",
            "M16",
            "M20"});
            this.screwComboBox.Location = new System.Drawing.Point(722, 6);
            this.screwComboBox.Name = "screwComboBox";
            this.screwComboBox.Size = new System.Drawing.Size(596, 28);
            this.screwComboBox.TabIndex = 2;
            this.screwComboBox.SelectedIndexChanged += new System.EventHandler(this.screwComboBox_SelectedIndexChanged);
            // 
            // nutTabPage
            // 
            this.nutTabPage.Controls.Add(this.pictureBox2);
            this.nutTabPage.Controls.Add(this.nutTextBox);
            this.nutTabPage.Controls.Add(this.nutComboBox);
            this.nutTabPage.Location = new System.Drawing.Point(4, 29);
            this.nutTabPage.Name = "nutTabPage";
            this.nutTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.nutTabPage.Size = new System.Drawing.Size(1326, 483);
            this.nutTabPage.TabIndex = 2;
            this.nutTabPage.Text = "Гайки";
            this.nutTabPage.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox2.Image = global::NXProject.Properties.Resources.гайка;
            this.pictureBox2.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.InitialImage")));
            this.pictureBox2.Location = new System.Drawing.Point(8, 6);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(708, 465);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // nutTextBox
            // 
            this.nutTextBox.Location = new System.Drawing.Point(722, 40);
            this.nutTextBox.Multiline = true;
            this.nutTextBox.Name = "nutTextBox";
            this.nutTextBox.ReadOnly = true;
            this.nutTextBox.Size = new System.Drawing.Size(596, 431);
            this.nutTextBox.TabIndex = 4;
            // 
            // nutComboBox
            // 
            this.nutComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nutComboBox.FormattingEnabled = true;
            this.nutComboBox.Items.AddRange(new object[] {
            "M6",
            "M8",
            "M10",
            "M12",
            "M16",
            "M20"});
            this.nutComboBox.Location = new System.Drawing.Point(722, 6);
            this.nutComboBox.Name = "nutComboBox";
            this.nutComboBox.Size = new System.Drawing.Size(596, 28);
            this.nutComboBox.TabIndex = 3;
            this.nutComboBox.SelectedIndexChanged += new System.EventHandler(this.nutComboBox_SelectedIndexChanged);
            // 
            // buildButton
            // 
            this.buildButton.Location = new System.Drawing.Point(546, 543);
            this.buildButton.Name = "buildButton";
            this.buildButton.Size = new System.Drawing.Size(268, 61);
            this.buildButton.TabIndex = 4;
            this.buildButton.Text = "build";
            this.buildButton.UseVisualStyleBackColor = true;
            this.buildButton.Click += new System.EventHandler(this.buildButton_Click);
            // 
            // DetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1334, 639);
            this.Controls.Add(this.buildButton);
            this.Controls.Add(this.detailsTabControl);
            this.Name = "DetailsForm";
            this.Text = "Details Info";
            this.Load += new System.EventHandler(this.DetailsForm_Load);
            this.detailsTabControl.ResumeLayout(false);
            this.boltTabPage.ResumeLayout(false);
            this.boltTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.boltPictureBox)).EndInit();
            this.screwTabPage.ResumeLayout(false);
            this.screwTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.nutTabPage.ResumeLayout(false);
            this.nutTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl detailsTabControl;
        private System.Windows.Forms.TabPage boltTabPage;
        private System.Windows.Forms.TabPage screwTabPage;
        private System.Windows.Forms.TabPage nutTabPage;
        private System.Windows.Forms.PictureBox boltPictureBox;
        private System.Windows.Forms.ComboBox boltComboBox;
        private System.Windows.Forms.ComboBox screwComboBox;
        private System.Windows.Forms.ComboBox nutComboBox;
        private System.Windows.Forms.TextBox boltTextBox;
        private System.Windows.Forms.TextBox screwTextBox;
        private System.Windows.Forms.TextBox nutTextBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button buildButton;
        private System.Windows.Forms.ComboBox boltLengthComboBox;
        private System.Windows.Forms.ComboBox screwLengthComboBox;
    }
}

