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
            app.Project.CheckExistingProject();

            List<ProjectData> oldList = ProjectData.GetAll();
            ProjectData toBeDeleted = oldList[0];

            app.Project.Remove(toBeDeleted);
            System.Console.Out.WriteLine(toBeDeleted.Id);

            List<ProjectData> newList = ProjectData.GetAll();
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
