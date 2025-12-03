namespace FamilyTiesUIRelease.Forms
{
    partial class AddRoleForm
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
            this.FirstMember = new System.Windows.Forms.ComboBox();
            this.SecondMember = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // FirstMember
            // 
            this.FirstMember.AccessibleName = "";
            this.FirstMember.FormattingEnabled = true;
            this.FirstMember.Location = new System.Drawing.Point(175, 12);
            this.FirstMember.Name = "FirstMember";
            this.FirstMember.Size = new System.Drawing.Size(400, 21);
            this.FirstMember.TabIndex = 0;
            this.FirstMember.SelectedIndexChanged += new System.EventHandler(this.FirstMember_SelectedIndexChanged);
            // 
            // SecondMember
            // 
            this.SecondMember.AccessibleName = "";
            this.SecondMember.FormattingEnabled = true;
            this.SecondMember.Location = new System.Drawing.Point(175, 50);
            this.SecondMember.Name = "SecondMember";
            this.SecondMember.Size = new System.Drawing.Size(400, 21);
            this.SecondMember.TabIndex = 1;
            this.SecondMember.SelectedIndexChanged += new System.EventHandler(this.SecondMember_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 91);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(178, 100);
            this.button1.TabIndex = 2;
            this.button1.Text = "Создать связь родителя - ребенка";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.CreateParentRole_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(192, 91);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(191, 100);
            this.button2.TabIndex = 3;
            this.button2.Text = "Создать связь супругов";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.CreateSpouseRole_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(389, 91);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(191, 100);
            this.button3.TabIndex = 4;
            this.button3.Text = "Создать связь братьев/сестер";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.CreateSiblingsRole_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = " Выберите первого человека:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = " Выберите второго человека:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // AddRoleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 202);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.SecondMember);
            this.Controls.Add(this.FirstMember);
            this.Name = "AddRoleForm";
            this.Text = "AddRelationForm";
            this.Load += new System.EventHandler(this.AddRoleForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox FirstMember;
        private System.Windows.Forms.ComboBox SecondMember;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}