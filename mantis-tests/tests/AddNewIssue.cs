using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    class AddNewIssue : TestBase
    {
        [Test]
        public void AddNewIssueTest()
        {
            AccountData account = new AccountData()
            {
                Username = "administrator",
                Password = "root"
            };
            ProjectData project = new ProjectData()
            {
                Id = "11"
            };
            IssueData issueData = new IssueData()
            {
                Summary = "2some summary text",
                Description = "2some description text",
                Category = "General"
            };
            app.API.CreateNewIssue(account, project, issueData);
        }
    }
}
