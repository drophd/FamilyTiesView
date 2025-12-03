using FamilyTiesUIRelease.Core.Enums;
using FamilyTiesUIRelease.Core.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FamilyTiesUIRelease.Core.Models
{
    public class FamilyTree
    {
        private readonly List<FamilyMember> _members = new List<FamilyMember>();

        public IReadOnlyList<FamilyMember> Members => _members.AsReadOnly();



        public int GetCount()
        {
            return Members.Count;
        }

        public void CreateSpouseRelation(FamilyMember member1, FamilyMember member2)
        {
            var spouseRole1 = new SpouseRole(member1) { Spouse = member2 };
            var spouseRole2 = new SpouseRole(member2) { Spouse = member1 };

            member1.AssignRoleInstance(spouseRole1);
            member2.AssignRoleInstance(spouseRole2);
        }

        public void CreateSiblingRelation(FamilyMember member1, FamilyMember member2)
        {
            var siblingRole1 = new SiblingRole(member1);
            var siblingRole2 = new SiblingRole(member2);

            siblingRole1.AddSibling(member2);
            siblingRole2.AddSibling(member1);

            member1.AssignRoleInstance(siblingRole1);
            member2.AssignRoleInstance(siblingRole2);
        }

        public void RemovePerson(FamilyMember memberToRemove)
        {
            // Проверка входных параметров
            if (memberToRemove == null)
                throw new ArgumentNullException(nameof(memberToRemove));

            if (!_members.Contains(memberToRemove))
                return;

            RemoveAllRelations(memberToRemove);

            _members.Remove(memberToRemove);
        }

        private void RemoveAllRelations(FamilyMember member)
        {
            RemoveChildRelations(member);
            RemoveParentRelations(member);
            RemoveSpouseRelation(member);
            RemoveSiblingRelations(member);
        }

        public void RemoveChildRelations(FamilyMember member)
        {
            if (!member.HasRole(RoleType.Child)) return;

            var childRole = (ChildRole)member.GetRole(RoleType.Child);

            // Удаление связи с отцом
            if (childRole.Father != null)
            {
                var father = childRole.Father;
                if (father.HasRole(RoleType.Father))
                {
                    var fatherRole = (FatherRole)father.GetRole(RoleType.Father);
                    fatherRole.RemoveChild(member);
                }
                childRole.SetFather(null); 
            }

            // Удаление связи с матерью
            if (childRole.Mother != null)
            {
                var mother = childRole.Mother;
                if (mother.HasRole(RoleType.Mother))
                {
                    var motherRole = (MotherRole)mother.GetRole(RoleType.Mother);
                    motherRole.RemoveChild(member);
                }
                childRole.SetMother(null); 
            }

            member.RemoveRole(RoleType.Child);
        }

        public void RemoveParentRelations(FamilyMember member)
        {
            // Обработка отцовства
            if (member.HasRole(RoleType.Father))
            {
                var fatherRole = (FatherRole)member.GetRole(RoleType.Father);
                foreach (var child in fatherRole.Children.ToList())
                {
                    if (child.HasRole(RoleType.Child))
                    {
                        var childRole = (ChildRole)child.GetRole(RoleType.Child);
                        if (childRole.Father == member)
                        {
                            childRole.SetFather(null);
                        }
                    }
                }
                member.RemoveRole(RoleType.Father);
            }


            if (member.HasRole(RoleType.Mother))
            {
                var motherRole = (MotherRole)member.GetRole(RoleType.Mother);
                foreach (var child in motherRole.Children.ToList())
                {
                    if (child.HasRole(RoleType.Child))
                    {
                        var childRole = (ChildRole)child.GetRole(RoleType.Child);
                        if (childRole.Mother == member)
                        {
                            childRole.SetMother(null);
                        }
                    }
                }
                member.RemoveRole(RoleType.Mother);
            }
        }

        public void RemoveSpouseRelation(FamilyMember member)
        {
            if (member == null)
                throw new ArgumentNullException(nameof(member));

            if (!member.HasRole(RoleType.Spouse))
                return;

            var spouseRole = member.GetRole(RoleType.Spouse) as SpouseRole;
            if (spouseRole == null)
                return;

    
            var spouse = spouseRole.Spouse;

    
            member.RemoveRole(RoleType.Spouse);

           
            if (spouse != null && spouse.HasRole(RoleType.Spouse))
            {
                var otherSpouseRole = spouse.GetRole(RoleType.Spouse) as SpouseRole;

        
                if (otherSpouseRole != null && otherSpouseRole.Spouse == member)
                {
                    // Удаляем роль Spouse у супруга
                    spouse.RemoveRole(RoleType.Spouse);
                }
            }
        }

        public void RemoveSiblingRelations(FamilyMember member)
        {
            if (!member.HasRole(RoleType.Sibling)) return;

            var siblingRole = (SiblingRole)member.GetRole(RoleType.Sibling);
            foreach (var sibling in siblingRole.Siblings.ToList())
            {
                if (sibling.HasRole(RoleType.Sibling))
                {
                    var otherSiblingRole = (SiblingRole)sibling.GetRole(RoleType.Sibling);
                    otherSiblingRole.RemoveSibling(member);
                }
            }

            member.RemoveRole(RoleType.Sibling);
        }


        public void AddMember(FamilyMember member)
        {
            _members.Add(member);
        }

        public void CreateParentChildRelation(FamilyMember child, FamilyMember parent)
        {
            ChildRole childRole = child.HasRole(RoleType.Child)
                ? (ChildRole)child.GetRole(RoleType.Child)
                : new ChildRole(child);

            if (parent.Person.Gender == Gender.Male)
            {
                if (!parent.HasRole(RoleType.Father))
                {
                    parent.AssignRoleInstance(new FatherRole(parent));
                }

                childRole.SetFather(parent);
                var fatherRole = (FatherRole)parent.GetRole(RoleType.Father);
                fatherRole.AddChild(child);
            }
            else if (parent.Person.Gender == Gender.Female)
            {
                if (!parent.HasRole(RoleType.Mother))
                {
                    parent.AssignRoleInstance(new MotherRole(parent));
                }

                childRole.SetMother(parent);
                var motherRole = (MotherRole)parent.GetRole(RoleType.Mother);
                motherRole.AddChild(child);
            }

            child.AssignRoleInstance(childRole);
        }


        public string GenerateDotCode()
        {
            var dotBuilder = new StringBuilder();
            dotBuilder.AppendLine("digraph family_tree {");
            dotBuilder.AppendLine("    node [shape=box, style=filled, fillcolor=lightblue];");
            dotBuilder.AppendLine("    edge [dir=forward];");
            dotBuilder.AppendLine("    rankdir=TB;");
            dotBuilder.AppendLine();

            foreach (var member in Members)
            {
                string genderColor = member.Person.Gender == Gender.Male ? "lightblue" : "pink";
                dotBuilder.AppendLine($"    \"{member.Person.Id}\" [label=\"{member.Person.Name} {member.Person.Surname}\\n{member.Person.Age} лет\", fillcolor={genderColor}];");
            }

            dotBuilder.AppendLine();


            var generations = CalculateGenerations();

            foreach (var generation in generations.OrderBy(g => g.Key))
            {
                dotBuilder.AppendLine($"    {{ rank=same; {string.Join("; ", generation.Value)} }}");
            }

            foreach (var member in Members)
            {
                if (member.HasRole(RoleType.Child))
                {
                    var childRole = (ChildRole)member.GetRole(RoleType.Child);
                    if (childRole.Father != null)
                    {
                        dotBuilder.AppendLine($"    \"{childRole.Father.Person.Id}\" -> \"{member.Person.Id}\"");
                    }
                    if (childRole.Mother != null)
                    {
                        dotBuilder.AppendLine($"    \"{childRole.Mother.Person.Id}\" -> \"{member.Person.Id}\"");
                    }
                }
            }


            foreach (var member in Members)
            {
                if (member.HasRole(RoleType.Spouse))
                {
                    var spouseRole = (SpouseRole)member.GetRole(RoleType.Spouse);
                    if (string.Compare(member.Person.Id, spouseRole.Spouse.Person.Id) < 0)
                    {
                        dotBuilder.AppendLine($"    \"{member.Person.Id}\" -> \"{spouseRole.Spouse.Person.Id}\" [dir=none, color=red];");
                    }
                }
            }


            var processedPairs = new HashSet<(string, string)>();

            foreach (var member in Members)
            {
                if (member.HasRole(RoleType.Sibling))
                {
                    var siblingRole = (SiblingRole)member.GetRole(RoleType.Sibling);
                    foreach (var sibling in siblingRole.Siblings)
                    {
              
                        if (sibling == member) continue;

                        var id1 = member.Person.Id;
                        var id2 = sibling.Person.Id;
                        var pair = string.Compare(id1, id2) < 0 ? (id1, id2) : (id2, id1);

                        if (processedPairs.Add(pair))
                        {
                            dotBuilder.AppendLine($"    \"{pair.Item1}\" -> \"{pair.Item2}\" " +
                                "[dir=none, color=green, style=dashed];");
                        }
                    }
                }
            }

            dotBuilder.AppendLine("}");
            return dotBuilder.ToString();
        }
        private Dictionary<int, List<string>> CalculateGenerations()
        {
            var generations = new Dictionary<int, List<string>>();
            var visited = new Dictionary<string, int>();
            var queue = new Queue<FamilyMember>();

            var rootMembers = Members.Where(m => !m.HasRole(RoleType.Child) ||
                                               ((ChildRole)m.GetRole(RoleType.Child)).Father == null &&
                                               ((ChildRole)m.GetRole(RoleType.Child)).Mother == null).ToList();


            if (!rootMembers.Any())
            {
                rootMembers = Members.ToList();
            }

            foreach (var member in rootMembers)
            {
                queue.Enqueue(member);
                visited[member.Person.Id] = 0;
            }

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                int currentGeneration = visited[current.Person.Id];

                if (!generations.ContainsKey(currentGeneration))
                {
                    generations[currentGeneration] = new List<string>();
                }
                generations[currentGeneration].Add($"\"{current.Person.Id}\"");

                if (current.HasRole(RoleType.Child))
                {
                    var childRole = (ChildRole)current.GetRole(RoleType.Child);
                    if (childRole.Father != null && (!visited.ContainsKey(childRole.Father.Person.Id) ||
                                                   visited[childRole.Father.Person.Id] < currentGeneration + 1))
                    {
                        visited[childRole.Father.Person.Id] = currentGeneration + 1;
                        queue.Enqueue(childRole.Father);
                    }
                    if (childRole.Mother != null && (!visited.ContainsKey(childRole.Mother.Person.Id) ||
                                                   visited[childRole.Mother.Person.Id] < currentGeneration + 1))
                    {
                        visited[childRole.Mother.Person.Id] = currentGeneration + 1;
                        queue.Enqueue(childRole.Mother);
                    }
                }

                if (current.HasRole(RoleType.Father))
                {
                    var fatherRole = (FatherRole)current.GetRole(RoleType.Father);
                    foreach (var child in fatherRole.Children)
                    {
                        if (!visited.ContainsKey(child.Person.Id) || visited[child.Person.Id] > currentGeneration - 1)
                        {
                            visited[child.Person.Id] = currentGeneration - 1;
                            queue.Enqueue(child);
                        }
                    }
                }
                if (current.HasRole(RoleType.Mother))
                {
                    var motherRole = (MotherRole)current.GetRole(RoleType.Mother);
                    foreach (var child in motherRole.Children)
                    {
                        if (!visited.ContainsKey(child.Person.Id) || visited[child.Person.Id] > currentGeneration - 1)
                        {
                            visited[child.Person.Id] = currentGeneration - 1;
                            queue.Enqueue(child);
                        }
                    }
                }
            }

            foreach (var member in Members)
            {
                if (!visited.ContainsKey(member.Person.Id))
                {

                    if (member.HasRole(RoleType.Spouse))
                    {
                        var spouseRole = (SpouseRole)member.GetRole(RoleType.Spouse);
                        if (visited.ContainsKey(spouseRole.Spouse.Person.Id))
                        {
                            int spouseGeneration = visited[spouseRole.Spouse.Person.Id];
                            if (!generations.ContainsKey(spouseGeneration))
                            {
                                generations[spouseGeneration] = new List<string>();
                            }
                            generations[spouseGeneration].Add($"\"{member.Person.Id}\"");
                            continue;
                        }
                    }

                    if (!generations.ContainsKey(0))
                    {
                        generations[0] = new List<string>();
                    }
                    generations[0].Add($"\"{member.Person.Id}\"");
                }
            }

            return generations;
        }

        public string VisualizeFamilyTree(string outputFilePath = "family_tree", bool openImage = true)
        {
            string dotCode = GenerateDotCode();
            string dotFilePath = $"{outputFilePath}.dot";
            string imageFilePath = $"{outputFilePath}.png";

            // Save the DOT file
            File.WriteAllText(dotFilePath, dotCode);

            // Run Graphviz to generate the image
            try
            {
                var process = new System.Diagnostics.Process();
                process.StartInfo = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = "dot",
                    Arguments = $"-Tpng \"{dotFilePath}\" -o \"{imageFilePath}\"",
                    UseShellExecute = false,
                    CreateNoWindow = true
                };
                process.Start();
                process.WaitForExit();
                Console.WriteLine($"Graph successfully generated: {imageFilePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error generating graph: {ex.Message}");
                Console.WriteLine("Make sure Graphviz is installed and available in PATH.");
                Console.WriteLine("DOT code saved to file: " + dotFilePath);
            }

            return imageFilePath;
        }

    }

}
