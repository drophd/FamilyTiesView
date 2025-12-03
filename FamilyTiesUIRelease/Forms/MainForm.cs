using FamilyTiesUIRelease.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;
using FamilyTiesUIRelease.Core.Models;
using System.IO;

namespace FamilyTiesUIRelease
{
    public partial class MainForm : Form
    {

        readonly FamilyTree familyTree;

        public MainForm()
        {
            InitializeComponent();
            familyTree = new FamilyTree();
            familyTree.VisualizeFamilyTree();
            UpdateUI();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void OpenAddPersonForm(object sender, EventArgs e)
        {
            AddPersonForm addPersonForm = new AddPersonForm(familyTree);

            DialogResult result = addPersonForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                UpdateUI();
            }
        }

        private void OpenAddRelationForm(object sender, EventArgs e)
        {
            if (familyTree.GetCount() < 2)
            {
                MessageBox.Show("Для создания связи вам нужно как минимум 2 человека",
                               "Ошибка",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                return;
            }

            AddRoleForm addRelationForm = new AddRoleForm(familyTree, this);

            DialogResult result = addRelationForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                UpdateUI();
            }
        }
        public void UpdateUI()
        {
            if (pictureBox.Image != null)
            {
                pictureBox.Image.Dispose();
                pictureBox.Image = null; 
            }

            string imagePath = familyTree.VisualizeFamilyTree();
            if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
            {
                try
                {
               
                    pictureBox.Image = Image.FromFile(imagePath);
                    pictureBox.Refresh(); 
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка загрузки изображения: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Файл изображения не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {

        }

        private void OpenRemovePersonForm(object sender, EventArgs e)
        {
            RemovePersonForm removePersonForm = new RemovePersonForm(familyTree, this);

  
            DialogResult result = removePersonForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                UpdateUI();
            }
        }

        private void OpenDeleteRoleForm(object sender, EventArgs e)
        {
            DeleteRoleForm deleteRoleForm = new DeleteRoleForm(familyTree, this);

            DialogResult result = deleteRoleForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                UpdateUI();
            }
        }
    }
}
