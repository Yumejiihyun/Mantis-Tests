using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mantis_Tests
{
    public class ProjectData : IComparable<ProjectData>, IEquatable<ProjectData>
    {
        public ProjectData(string name)
        {
            Name = name;
        }
        public string Name { get; set; }

        public int CompareTo(ProjectData other)
        {
            return Name.CompareTo(other.Name);
        }

        public bool Equals(ProjectData other)
        {
            return Name.Equals(other.Name);
        }
    }
}
