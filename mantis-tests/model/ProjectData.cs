﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class ProjectData
    {
        public ProjectData(string projectTitle)
        {
            ProjectName = projectTitle;
        }

        public string ProjectName { get; set; }
        public string  Description { get; set; }
    }
}
