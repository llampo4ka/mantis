using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using NUnit.Framework;
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


        public ProjectHelper Remove(int p)
        {
            OpenProjectPage(p);
            PressDeleteButton();
            SubmitRemoval();
            return this;
        }

        public ProjectHelper Remove(ProjectData project)
        {
            manager.Navigate.GoToManagmentTab();
            manager.Navigate.GoToProjectManagment();
            OpenProjectPage(project.Id);
            PressDeleteButton();
            SubmitRemoval();
            return this;
        }

        

        private void SubmitRemoval()
        {
            driver.FindElement(By.XPath("(//input[@value='Удалить проект'])")).Click();
        }

        private void PressDeleteButton()
        {
            driver.FindElement(By.XPath("(//input[@value='Удалить проект'])")).Click();
        }

        private void OpenProjectPage(int p)
        {
            manager.Navigate.GoToManagmentTab();
            manager.Navigate.GoToProjectManagment();
            driver.FindElement(By.XPath("//div[@class='table-responsive']/table/tbody/tr[" + (p+1) + "]/td/a")).Click();
        }

        private void OpenProjectPage(string id)
        {
            driver.FindElement(By.XPath("//div[@class='table-responsive']/table/tbody/tr/td/a[contains(@href,'project_id=" + id +"')]")).Click();
            System.Console.Out.WriteLine(id);
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

        internal void CheckExistingProject()
        {
            List<ProjectData> projList = ProjectData.GetAll();
            if (projList.Count == 0)
            {
                Create(new ProjectData("proj name") { 
                    Description = "gjhshfg jhgjhf hfjhff"
                });
            }
        }

        public ProjectData CheckProjectName(ProjectData project)
        {

            List<ProjectData> projList = ProjectData.GetAll();

            for (int i = 0; i < projList.Count; i++)
            {
                if (project.ProjectName == projList[i].ProjectName)
                {
                    project.ProjectName += "1";
                }
            }
            return project;
        }
    }
}
