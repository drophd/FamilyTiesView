using FamilyTiesUIRelease.Core.Models;
using System;
using System.Windows.Forms;

namespace FamilyTiesUIRelease.Forms
{
    public partial class AddRoleForm : Form
    {
        private readonly FamilyTree _familyTree;
        private readonly MainForm _mainForm;

        public AddRoleForm(FamilyTree familyTree, MainForm mainForm)
        {
            InitializeComponent();
            _familyTree = familyTree;
            _mainForm = mainForm;

         
           foreach (var member in _familyTree.Members)
            {
                FirstMember.Items.Add($"{member.Person.Name} {member.Person.Surname}");
                SecondMember.Items.Add($"{member.Person.Name} {member.Person.Surname}");
            }
        }

        private void CreateSpouseRole_Click(object sender, EventArgs e)
        {
            if (FirstMember.SelectedIndex == -1 || SecondMember.SelectedIndex == -1)
            {
                MessageBox.Show("Пожалуйста, выберите обоих членов семьи", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var member1 = _familyTree.Members[FirstMember.SelectedIndex];
            var member2 = _familyTree.Members[SecondMember.SelectedIndex];

            try
            {
                _familyTree.CreateSpouseRelation(member1, member2);
                MessageBox.Show("Отношения супругов успешно созданы!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании отношений: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            _mainForm.UpdateUI();
        }


        private void CreateSiblingsRole_Click(object sender, EventArgs e)
        {
            if (FirstMember.SelectedIndex == -1 || SecondMember.SelectedIndex == -1)
            {
                MessageBox.Show("Пожалуйста, выберите обоих членов семьи", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var member1 = _familyTree.Members[FirstMember.SelectedIndex];
            var member2 = _familyTree.Members[SecondMember.SelectedIndex];

            try
            {
                _familyTree.CreateSiblingRelation(member1, member2);
                MessageBox.Show("Родственные отношения успешно созданы!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании отношений: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            _mainForm.UpdateUI();
        }

        private void CreateParentRole_Click(object sender, EventArgs e)
        {
            if (FirstMember.SelectedIndex == -1 || SecondMember.SelectedIndex == -1)
            {
                MessageBox.Show("Пожалуйста, выберите обоих членов семьи", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var parent = _familyTree.Members[FirstMember.SelectedIndex];
            var child = _familyTree.Members[SecondMember.SelectedIndex];

            try
            {
                _familyTree.CreateParentChildRelation(child, parent);
                MessageBox.Show("Отношения родитель-ребенок успешно созданы!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании отношений: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            _mainForm.UpdateUI();
        }


        private void AddRoleForm_Load(object sender, EventArgs e)
        {
            Text = "Добавление семейных отношений";
        }

        private void SecondMember_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FirstMember_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
