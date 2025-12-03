using FamilyTiesUIRelease.Core.Enums;
using FamilyTiesUIRelease.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FamilyTiesUIRelease.Core.Roles
{
    public abstract class Role
    {
        public Role(FamilyMember familyMember, RoleType type)
        {
            FamilyMember = familyMember;
            Type = type;
        }

        public RoleType Type { get; }
        public FamilyMember FamilyMember { get; }
    }

    public class SpouseRole : Role
    {
        public SpouseRole(FamilyMember familyMember) : base(familyMember, RoleType.Spouse)
        {
        }

        public FamilyMember Spouse { get; set; }
    }

    public class ChildRole : Role
    {
        public ChildRole(FamilyMember familyMember) : base(familyMember, RoleType.Child)
        {
        }

        public FamilyMember Father { get; private set; }
        public FamilyMember Mother { get; private set; }

        public void SetFather(FamilyMember father)
        {
            if (father == this.FamilyMember)
                throw new ArgumentException("Cannot set self as father");
            if (father != null && father.Person.Gender != Gender.Male)
                throw new ArgumentException("Father must be male");
            Father = father;
        }

        public void SetMother(FamilyMember mother)
        {
            if (mother == this.FamilyMember)
                throw new ArgumentException("Cannot set self as mother");
            if (mother != null && mother.Person.Gender != Gender.Female)
                throw new ArgumentException("Mother must be female");
            Mother = mother;
        }
    }

    public class SiblingRole : Role
    {
        private readonly List<FamilyMember> _siblings = new List<FamilyMember>();

        public SiblingRole(FamilyMember familyMember) : base(familyMember, RoleType.Sibling) { }

        public IReadOnlyList<FamilyMember> Siblings => _siblings.AsReadOnly();

        public int GetBrothersCount() => _siblings.Count(s => s.Person.Gender == Gender.Male);
        public int GetSistersCount() => _siblings.Count(s => s.Person.Gender == Gender.Female);

        public void AddSibling(FamilyMember sibling)
        {
            if (sibling == null) throw new ArgumentNullException(nameof(sibling));
            if (sibling == FamilyMember) throw new ArgumentException("Cannot add self as sibling");

            _siblings.Add(sibling);
        }

        public void RemoveSibling(FamilyMember sibling)
        {
            _siblings.Remove(sibling);
        }
        public int GetTotalSiblingsCount()
        {
            return Siblings.Count;
        }
    }

    public abstract class ParentRole : Role
    {
        public ParentRole(FamilyMember familyMember, RoleType type) : base(familyMember, type)
        {
            _children = new List<FamilyMember>();
        }

        private readonly List<FamilyMember> _children = new List<FamilyMember>();
        public IReadOnlyList<FamilyMember> Children => _children.AsReadOnly();

        public void AddChild(FamilyMember child)
        {
            if (child == null) throw new ArgumentNullException(nameof(child));
            if (_children.Contains(child)) return;

            _children.Add(child);
        }
        public void RemoveChild(FamilyMember child) {  _children.Remove(child); }

        public IReadOnlyList<FamilyMember> GetChildren() 
        {
            return _children.AsReadOnly();
        }
    }

    public class FatherRole : ParentRole
    {
        public FatherRole(FamilyMember familyMember) : base(familyMember, RoleType.Father)
        {
        }
    }

    public class MotherRole : ParentRole
    {
        public MotherRole(FamilyMember familyMember) : base(familyMember, RoleType.Mother)
        {
        }
    }
}
