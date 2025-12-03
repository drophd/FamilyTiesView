using FamilyTiesUIRelease.Core.Enums;
using FamilyTiesUIRelease.Core.Models;
using System;
using System.Windows.Forms;


namespace FamilyTiesUIRelease.Forms
{
    public partial class AddPersonForm : Form
    {
        private readonly FamilyTree _familyTree;

        public AddPersonForm(FamilyTree familyTree)
        {
            InitializeComponent();
            _familyTree = familyTree;
            t.Value = DateTime.Now;

            radioButtonMale.Checked = true;
        }

        private void buttonAddPerson_Click(object sender, EventArgs e)
        {
            try
            {
         
                if (string.IsNullOrWhiteSpace(textBoxName.Text))
                {
                    MessageBox.Show("Введите имя!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


     
                string name = textBoxName.Text.Trim();
                string surname = textBoxSurname.Text.Trim();
                DateTime birthDate = t.Value;
                int age = DateTime.Now.Year - birthDate.Year;
                if (birthDate.Date > DateTime.Now.AddYears(-age)) age--;

                Gender gender = radioButtonMale.Checked ? Gender.Male : Gender.Female;

           
                string id = Guid.NewGuid().ToString();
                var person = new Person(id, name, surname, age, gender);
                var familyMember = new FamilyMember(person);

               
                _familyTree.AddMember(familyMember);

             
                MessageBox.Show($"{name} {surname} успешно добавлен(а) в семейное дерево!",
                    "Успех",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

              
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void AddPersonForm_Load_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void radioButtonFemale_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButtonMale_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}

