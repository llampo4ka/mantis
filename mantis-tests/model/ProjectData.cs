using LinqToDB.Mapping;
using System.Linq;
using System.Collections.Generic;
using System;

namespace mantis_tests
{
    [Table(Name = "mantis_project_table")]
    public class ProjectData : IEquatable<ProjectData>, IComparable<ProjectData>
    {
        public ProjectData() { }
        public ProjectData(string projectTitle)
        {
            ProjectName = projectTitle;
        }

        [Column(Name = "name")]
        public string ProjectName { get; set; }

        [Column(Name = "description")]
        public string  Description { get; set; }

        [Column(Name = "id"), PrimaryKey, Identity]
        public string Id { get; set; }

        public static List<ProjectData> GetAll()
        {
            using (MantisDB db = new MantisDB())
            {
                return (from p in db.Projects select p).ToList();
            }
        }

        public int CompareTo(ProjectData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return ProjectName.CompareTo(other.ProjectName);
        }

        public bool Equals(ProjectData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }

            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            return ProjectName == other.ProjectName;
        }

        public override string ToString()
        {
            return "name= " + ProjectName;
        }
    }
    
}
