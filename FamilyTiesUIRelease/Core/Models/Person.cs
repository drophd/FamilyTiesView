using FamilyTiesUIRelease.Core.Enums;

namespace FamilyTiesUIRelease.Core.Models
{
    public class Person
    {
        public Person(string id, string name, string surname, int age, Gender gender)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Age = age;
            Gender = gender;
        }
        public string Id { get; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
    }
}

