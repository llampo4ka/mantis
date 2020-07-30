using LinqToDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests 
{
    public class MantisDB : LinqToDB.Data.DataConnection
    {
        public MantisDB() : base("bugtracker") { }

        public ITable<ProjectData> Projects { get { return GetTable<ProjectData>(); } }
    }
}
