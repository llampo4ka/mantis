using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Google.Protobuf.WellKnownTypes;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using static System.Net.WebRequestMethods;

namespace mantis_tests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        //private StringBuilder verificationErrors;
        protected string baseURL;


        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            driver = new ChromeDriver();
            baseURL = "http://localhost";
            //Registration = new RegistrationHelper(this);
            //Ftp = new FtpHelper(this);
            //James = new JameHelper(this);

            Auth = new LoginHelper(this);
            Navigate = new NavigatorHelper(this);
            Project = new ProjectHelper(this);
            API= new APIHelper(this);

        }

        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }

        }

        public static ApplicationManager GetInstance()
        {
            if(! app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.driver.Url = "http://localhost/mantisbt/login_page.php";
                app.Value = newInstance;
            }
            return app.Value;
        }

        public IWebDriver Driver 
        {
            get
            {
                return driver;
            }
        
        }


        //public RegistrationHelper Registration { get; set; }
        //public FtpHelper Ftp { get; set; }
        //public JameHelper James { get; set; }

        public LoginHelper Auth  { get; }
        public NavigatorHelper Navigate { get; set; }
        public ProjectHelper Project { get; set; }
        public APIHelper API { get; private set; }
    }
}
