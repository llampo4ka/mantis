using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace mantis_tests
{
    public class NavigatorHelper : HelperBase
    {
        public string baseURL;
        public NavigatorHelper(ApplicationManager manager)
           : base(manager)
        {
            this.baseURL = baseURL;
        }

        public void OpenMainPage()
        {
            if (driver.Url == baseURL)
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL);
        }

        public void GoToManagmentTab()
        {
            driver.FindElement(By.XPath("//button[@id='menu-toggler']")).Click();
            driver.FindElement(By.XPath("//div[@id='main-container']/div[@id='sidebar']/ul/li[7]/a"))
                .Click();
        }

        public void GoToProjectManagment()
        {
            if (driver.Url == baseURL + "manage_proj_page.php"
               && IsElementPresent(By.XPath("(//button[contains(@text,'Создать новый проект')])")))
            {
                return;
            }
            driver.FindElement(By.LinkText("Управление проектами")).Click();
        }
    }
}
