using System;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class CreteProjectTests : TestBase
    {
        [Test]
        public void CreteProjectTest()
        {
            ProjectData project = new ProjectData("project name 1")
            {
                Description = "descr fkdhgkhg"
            };
            app.Project.Create(project);
        }
    }
}
