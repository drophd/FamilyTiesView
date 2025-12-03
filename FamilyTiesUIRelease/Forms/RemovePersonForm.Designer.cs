namespace FamilyTiesUIRelease.Forms
{
    partial class RemovePersonForm
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
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DeletePersonButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox
            // 
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Location = new System.Drawing.Point(216, 12);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(229, 21);
            this.comboBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Выберите человека для удаления:";
            // 
            // DeletePersonButton
            // 
            this.DeletePersonButton.Location = new System.Drawing.Point(12, 53);
            this.DeletePersonButton.Name = "DeletePersonButton";
            this.DeletePersonButton.Size = new System.Drawing.Size(433, 54);
            this.DeletePersonButton.TabIndex = 2;
            this.DeletePersonButton.Text = "Удалить человека";
            this.DeletePersonButton.UseVisualStyleBackColor = true;
            this.DeletePersonButton.Click += new System.EventHandler(this.DeletePerson);
            // 
            // RemovePersonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 119);
            this.Controls.Add(this.DeletePersonButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox);
            this.Name = "RemovePersonForm";
            this.Text = "RemovePersonForm";
            this.Load += new System.EventHandler(this.RemovePersonForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button DeletePersonButton;
    }
}