using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace mantis_tests
{
    public class ProjectHelper : HelperBase
    {
        public ProjectHelper(ApplicationManager manager)
            : base(manager)
        {
        }

        public ProjectHelper Create(ProjectData project)
        {
            manager.Navigate.GoToManagmentTab();
            manager.Navigate.GoToProjectManagment();
            PressCreateNewProjectButton();
            FillProjectForm(project);
            SubmitProjectButton();
            return this;
        }

        private void PressCreateNewProjectButton()
        {
            driver.FindElement(By.XPath("//fieldset/button")).Click();
        }
        
        private void FillProjectForm(ProjectData project)
        {
            Type(By.Name("name"), project.ProjectName);
            Type(By.Name("description"), project.Description);
        }

        private void SubmitProjectButton()
        {
            driver.FindElement(By.XPath("(//input[@value='Добавить проект'])")).Click();
        }

    }
}
