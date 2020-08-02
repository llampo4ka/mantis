using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace mantis_tests
{
    public class RemovalProjectTests : TestBase
    {
        [Test]
        public void RemovalProjectTest()
        {
            //app.Project.CheckExistingProject();
            AccountData account = new AccountData()
            {
                Username = "administrator",
                Password = "root"
            };
            app.API.CheckExistingProject(account);

            //List<ProjectData> oldList = ProjectData.GetAll();
            List<ProjectData> oldList = new List<ProjectData>();
            app.API.GetProjectsList(account, oldList);
            ProjectData toBeDeleted = oldList[0];

            app.Project.Remove(toBeDeleted);
            System.Console.Out.WriteLine(toBeDeleted.Id);

            //List<ProjectData> newList = ProjectData.GetAll();
            List<ProjectData> newList = new List<ProjectData>();
            app.API.GetProjectsList(account, newList);
            oldList.RemoveAt(0);
            oldList.Sort();
            newList.Sort();

            Assert.AreEqual(oldList, newList);

            foreach (ProjectData proj in newList)
            {
                Assert.AreNotEqual(proj.Id, toBeDeleted.Id);
            }
        }
    }
}
