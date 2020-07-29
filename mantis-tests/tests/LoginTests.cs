using System;
using NUnit.Framework;
using System.IO;

namespace mantis_tests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void LoginWithValidCreds()
        {
            app.Auth.Logout();

            

            //Assert.IsTrue(app.Auth.IsLoggedIn(account));
        }
    }
}
