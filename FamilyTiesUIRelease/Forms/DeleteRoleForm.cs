// DeleteRoleForm.cs
using FamilyTiesUIRelease.Core.Models;
using FamilyTiesUIRelease.Core.Roles;
using FamilyTiesUIRelease.Core.Enums;
using System;
using System.Windows.Forms;
using System.Linq;

namespace FamilyTiesUIRelease.Forms
{
    public partial class DeleteRoleForm : Form
    {
        private readonly FamilyTree _familyTree;
        private readonly MainForm _mainForm;

        public DeleteRoleForm(FamilyTree familyTree, MainForm mainForm)
        {
            InitializeComponent();
            _familyTree = familyTree;
            _mainForm = mainForm;

            // Fill dropdowns with family member names
            foreach (var member in _familyTree.Members)
            {
                FirstMember.Items.Add($"{member.Person.Name} {member.Person.Surname}");
                SecondMember.Items.Add($"{member.Person.Name} {member.Person.Surname}");
            }
        }

        private void DeleteParentChildRole(object sender, EventArgs e)
        {
            if (FirstMember.SelectedIndex == -1 || SecondMember.SelectedIndex == -1)
            {
                MessageBox.Show("Пожалуйста, выберите обоих членов семьи.");
                return;
            }

            var parent = _familyTree.Members[FirstMember.SelectedIndex];
            var child = _familyTree.Members[SecondMember.SelectedIndex];

            bool relationshipExists = false;

            if (parent.HasRole(RoleType.Father))
            {
                var fatherRole = (FatherRole)parent.GetRole(RoleType.Father);
                relationshipExists = fatherRole.Children.Contains(child);
            }
            else if (parent.HasRole(RoleType.Mother))
            {
                var motherRole = (MotherRole)parent.GetRole(RoleType.Mother);
                relationshipExists = motherRole.Children.Contains(child);
            }

            if (relationshipExists)
            {

                _familyTree.RemoveParentRelations(parent);

                if (child.HasRole(RoleType.Child))
                {
                    var childRole = (ChildRole)child.GetRole(RoleType.Child);
                    if (childRole.Father == null && childRole.Mother == null)
                    {
                        child.RemoveRole(RoleType.Child);
                    }
                }

                MessageBox.Show("Родительская связь успешно удалена.");
                _mainForm.UpdateUI();
            }
            else
            {
                MessageBox.Show("Между выбранными членами семьи нет родительской связи.");
            }
        }

        private void DeleteSpouseRole(object sender, EventArgs e)
        {
            if (FirstMember.SelectedIndex == -1 || SecondMember.SelectedIndex == -1)
            {
                MessageBox.Show("Пожалуйста, выберите обоих членов семьи.");
                return;
            }

            var spouse1 = _familyTree.Members[FirstMember.SelectedIndex];
            var spouse2 = _familyTree.Members[SecondMember.SelectedIndex];

 
            bool relationshipExists = spouse1.HasRole(RoleType.Spouse) &&
                                    ((SpouseRole)spouse1.GetRole(RoleType.Spouse)).Spouse == spouse2;

            if (relationshipExists)
            {
       
                _familyTree.RemoveSpouseRelation(spouse1);

                MessageBox.Show("Супружеская связь успешно удалена.");
                _mainForm.UpdateUI();
            }
            else
            {
                MessageBox.Show("Между выбранными членами семьи нет супружеской связи.");
            }
        }

        private void DeleteSiblingsRole(object sender, EventArgs e)
        {
            if (FirstMember.SelectedIndex == -1 || SecondMember.SelectedIndex == -1)
            {
                MessageBox.Show("Пожалуйста, выберите обоих членов семьи.");
                return;
            }

            var sibling1 = _familyTree.Members[FirstMember.SelectedIndex];
            var sibling2 = _familyTree.Members[SecondMember.SelectedIndex];

            // Проверяем существование родственной связи
            bool relationshipExists = sibling1.HasRole(RoleType.Sibling) &&
                                    ((SiblingRole)sibling1.GetRole(RoleType.Sibling)).Siblings.Contains(sibling2);

            if (relationshipExists)
            {
                // Используем метод RemoveSiblingRelations из FamilyTree
                _familyTree.RemoveSiblingRelations(sibling1);

                // Если у sibling2 больше нет братьев/сестер, удаляем SiblingRole
                if (sibling2.HasRole(RoleType.Sibling))
                {
                    var siblingRole = (SiblingRole)sibling2.GetRole(RoleType.Sibling);
                    if (siblingRole.Siblings.Count == 0)
                    {
                        sibling2.RemoveRole(RoleType.Sibling);
                    }
                }

                MessageBox.Show("Родственная связь успешно удалена.");
                _mainForm.UpdateUI();
            }
            else
            {
                MessageBox.Show("Между выбранными членами семьи нет родственной связи.");
            }
        }

        void DeleteRoleForm_Load(object sender, EventArgs e)
        {
        }

        private void FirstMember_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}