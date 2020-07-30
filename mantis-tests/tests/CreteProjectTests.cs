using System;
using NUnit.Framework;
using LinqToDB.Mapping;
using System.Linq;
using System.Collections.Generic;

namespace mantis_tests
{
    [TestFixture]
    public class CreteProjectTests : TestBase
    {
        [Test]
        public void CreteProjectTest()
        {
            List<ProjectData> oldList = ProjectData.GetAll();

            ProjectData project = new ProjectData("project name 2")
            {
                Description = "descr fkdhgkhg"
            };
            app.Project.CheckProjectName(project);            
            app.Project.Create(project);

            oldList.Add(project);
            List<ProjectData> newList = ProjectData.GetAll();

            oldList.Sort();
            newList.Sort();

            Assert.AreEqual(oldList, newList);
        }

        
    }
}
