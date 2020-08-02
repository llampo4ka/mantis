using mantis_tests.mantisapi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class APIHelper : HelperBase
    {
        public APIHelper(ApplicationManager manager) : base(manager) { }

        public void CreateNewIssue(AccountData account, ProjectData project, IssueData issueData)
        {
            mantisapi.MantisConnectPortTypeClient client = new mantisapi.MantisConnectPortTypeClient();
            mantisapi.IssueData issue = new mantisapi.IssueData();
            issue.summary = issueData.Summary;
            issue.description = issueData.Description;
            issue.category = issueData.Category;
            issue.project = new mantisapi.ObjectRef();
            issue.project.id = project.Id;
            client.mc_issue_add(account.Username, account.Password, issue);
        }

        public void CreateNewProject(AccountData account, ProjectData projectData)
        {
            mantisapi.MantisConnectPortTypeClient client = new mantisapi.MantisConnectPortTypeClient();
            mantisapi.ProjectData newproject = new mantisapi.ProjectData();
            newproject.name = projectData.ProjectName;
            newproject.description = projectData.ProjectName;

            client.mc_project_add(account.Username, account.Password, newproject);
        }

        public void GetProjectsList(AccountData account,  List<ProjectData> projList)
        {
            mantisapi.MantisConnectPortTypeClient client = new mantisapi.MantisConnectPortTypeClient();
            
            int count = client.mc_projects_get_user_accessible(account.Username, account.Password).Count();
            for (int j = 0; j < count; j++)
            {
                ProjectData projectData = new ProjectData();
                mantisapi.ProjectData proj = new mantisapi.ProjectData();
                proj.name = projectData.ProjectName;
                proj.id = projectData.Id;

                projectData.ProjectName = client.mc_projects_get_user_accessible(account.Username, account.Password)[j].name.ToString();
                projectData.Id = client.mc_projects_get_user_accessible(account.Username, account.Password)[j].id.ToString();
                
                projList.Add(projectData);
            }
        }

        public void CheckExistingProject(AccountData account)
        {
            mantisapi.MantisConnectPortTypeClient client = new mantisapi.MantisConnectPortTypeClient();

            int count = client.mc_projects_get_user_accessible(account.Username, account.Password).Count();
            if (count == 0)
            {
                ProjectData project = new ProjectData("exist project name api")
                {
                    Description = "exist descr-api fkdhgkhg"
                };
                CreateNewProject(account, project);
            }
        }


    }
}
