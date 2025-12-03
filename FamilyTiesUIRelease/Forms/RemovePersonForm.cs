using FamilyTiesUIRelease.Core.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace FamilyTiesUIRelease.Forms
{
    public partial class RemovePersonForm : Form
    {
        private readonly FamilyTree _familyTree;
        private readonly MainForm _mainForm;

        public RemovePersonForm(FamilyTree familyTree, MainForm mainForm)
        {
            InitializeComponent();
            _familyTree = familyTree;
            _mainForm = mainForm;
            InitializeComboBox();
        }

        private void InitializeComboBox()
        {
            comboBox.Items.Clear();
            comboBox.DisplayMember = "FullName";

            var items = _familyTree.Members.Select(m => new
            {
                Id = m.Person.Id,
                FullName = $"{m.Person.Name} {m.Person.Surname}"
            }).ToList();

            comboBox.DataSource = items;

            if (comboBox.Items.Count > 0)
                comboBox.SelectedIndex = 0;
            else
                DeletePersonButton.Enabled = false;
        }

        private void DeletePerson(object sender, EventArgs e)
        {
            if (comboBox.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите человека для удаления.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dynamic selectedItem = comboBox.SelectedItem;
            string selectedId = selectedItem.Id;

            var memberToRemove = _familyTree.Members.FirstOrDefault(m => m.Person.Id == selectedId);

            if (memberToRemove == null)
            {
                MessageBox.Show("Выбранный человек не найден в дереве.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var confirmResult = MessageBox.Show(
                $"Вы уверены, что хотите удалить {memberToRemove.Person.Name} {memberToRemove.Person.Surname} и все связанные с ним связи?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
              
                    _familyTree.RemovePerson(memberToRemove);

               
                    _mainForm.UpdateUI();

         
                    var newItems = _familyTree.Members.Select(m => new
                    {
                        Id = m.Person.Id,
                        FullName = $"{m.Person.Name} {m.Person.Surname}"
                    }).ToList();

               
                    comboBox.DataSource = null;

                    if (newItems.Count > 0)
                    {
                      
                        comboBox.DataSource = newItems;
                        comboBox.DisplayMember = "FullName";
                        comboBox.SelectedIndex = 0;
                    }
                    else
                    {
                        
                        MessageBox.Show("Все люди удалены из дерева.", "Информация",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }

                    MessageBox.Show("Человек успешно удален из семейного дерева.", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла ошибка при удалении: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void RemovePersonForm_Load(object sender, EventArgs e)
        {
            this.Text = "Удаление человека из семейного дерева";
            label1.Text = "Выберите человека для удаления:";
            DeletePersonButton.Text = "Удалить";
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
