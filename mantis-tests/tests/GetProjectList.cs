using NUnit.Framework;
using System.Collections.Generic;

namespace mantis_tests
{
    [TestFixture]
    class GetProjectList : TestBase
    {
        [Test]
        public void GetProjListTest()
        {
            AccountData account = new AccountData()
            {
                Username = "administrator",
                Password = "root"
            };
            List<ProjectData> projList = new List<ProjectData>();

            app.API.GetProjectsList(account, projList);

            foreach (ProjectData el in projList)
            {
                System.Console.Out.WriteLine(el.ProjectName);
            }


        }
    }
}
