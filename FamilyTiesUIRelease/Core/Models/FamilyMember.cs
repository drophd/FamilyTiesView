using FamilyTiesUIRelease.Core.Enums;
using System.Collections.Generic;
using FamilyTiesUIRelease.Core.Roles;


namespace FamilyTiesUIRelease.Core.Models
{
    public class FamilyMember
    {
        private Dictionary<RoleType, Role> roleInstances;

        public FamilyMember(Person person)
        {
            Person = person;
            roleInstances = new Dictionary<RoleType, Role>();
        }

        public Person Person { get; }

        public bool HasRole(RoleType role)
        {
            return roleInstances.ContainsKey(role);
        }

        public Role GetRole(RoleType roleType)
        {
            roleInstances.TryGetValue(roleType, out Role role);
            return role;
        }

        public void AssignRoleInstance(Role role)
        {
            if (role != null)
            {
                roleInstances[role.Type] = role;
            }
        }

        public void RemoveRole(RoleType role)
        {
            roleInstances.Remove(role);
        }
    }
}
