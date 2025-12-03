namespace FamilyTiesUIRelease
{
    partial class MainForm
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
            this.AddPersonButton = new System.Windows.Forms.Button();
            this.OpenAddRelationFormButton = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.RemovePerson = new System.Windows.Forms.Button();
            this.OpenDeleteRolesFormButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // AddPersonButton
            // 
            this.AddPersonButton.Location = new System.Drawing.Point(12, 12);
            this.AddPersonButton.Name = "AddPersonButton";
            this.AddPersonButton.Size = new System.Drawing.Size(172, 68);
            this.AddPersonButton.TabIndex = 0;
            this.AddPersonButton.Text = "Добавить человека";
            this.AddPersonButton.UseVisualStyleBackColor = true;
            this.AddPersonButton.Click += new System.EventHandler(this.OpenAddPersonForm);
            // 
            // OpenAddRelationFormButton
            // 
            this.OpenAddRelationFormButton.Location = new System.Drawing.Point(12, 86);
            this.OpenAddRelationFormButton.Name = "OpenAddRelationFormButton";
            this.OpenAddRelationFormButton.Size = new System.Drawing.Size(173, 68);
            this.OpenAddRelationFormButton.TabIndex = 1;
            this.OpenAddRelationFormButton.Text = "Создать связь";
            this.OpenAddRelationFormButton.UseVisualStyleBackColor = true;
            this.OpenAddRelationFormButton.Click += new System.EventHandler(this.OpenAddRelationForm);
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.Location = new System.Drawing.Point(217, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(1098, 575);
            this.pictureBox.TabIndex = 2;
            this.pictureBox.TabStop = false;
            this.pictureBox.Click += new System.EventHandler(this.pictureBox_Click);
            // 
            // RemovePerson
            // 
            this.RemovePerson.Location = new System.Drawing.Point(13, 160);
            this.RemovePerson.Name = "RemovePerson";
            this.RemovePerson.Size = new System.Drawing.Size(172, 68);
            this.RemovePerson.TabIndex = 3;
            this.RemovePerson.Text = "Удалить человека";
            this.RemovePerson.UseVisualStyleBackColor = true;
            this.RemovePerson.Click += new System.EventHandler(this.OpenRemovePersonForm);
            // 
            // OpenDeleteRolesFormButton
            // 
            this.OpenDeleteRolesFormButton.Location = new System.Drawing.Point(12, 234);
            this.OpenDeleteRolesFormButton.Name = "OpenDeleteRolesFormButton";
            this.OpenDeleteRolesFormButton.Size = new System.Drawing.Size(171, 68);
            this.OpenDeleteRolesFormButton.TabIndex = 4;
            this.OpenDeleteRolesFormButton.Text = "Удалить связь";
            this.OpenDeleteRolesFormButton.UseVisualStyleBackColor = true;
            this.OpenDeleteRolesFormButton.Click += new System.EventHandler(this.OpenDeleteRoleForm);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1327, 599);
            this.Controls.Add(this.OpenDeleteRolesFormButton);
            this.Controls.Add(this.RemovePerson);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.OpenAddRelationFormButton);
            this.Controls.Add(this.AddPersonButton);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AddPersonButton;
        private System.Windows.Forms.Button OpenAddRelationFormButton;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button RemovePerson;
        private System.Windows.Forms.Button OpenDeleteRolesFormButton;
    }
}

