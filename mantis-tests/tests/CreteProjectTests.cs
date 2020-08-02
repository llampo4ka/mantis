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
            //List<ProjectData> oldList = ProjectData.GetAll();
            AccountData account = new AccountData()
            {
                Username = "administrator",
                Password = "root"
            };
            List<ProjectData> oldList = new List<ProjectData>();
            app.API.GetProjectsList(account, oldList);

            ProjectData project = new ProjectData("project name api")
            {
                Description = "descr-api fkdhgkhg"
            };
            app.Project.CheckProjectName(project);
            app.API.CreateNewProject(account, project);
            //app.Project.Create(project);

            oldList.Add(project);
            //List<ProjectData> newList = ProjectData.GetAll();
            List<ProjectData> newList = new List<ProjectData>();
            app.API.GetProjectsList(account, newList);

            oldList.Sort();
            newList.Sort();

            Assert.AreEqual(oldList, newList);
        }

        
    }
}
