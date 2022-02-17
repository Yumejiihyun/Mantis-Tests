using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Mantis_Tests
{
    public class ProjectHelper : HelperBase
    {
        public ProjectHelper(ApplicationManager application) : base(application)
        {
        }

        public List<ProjectData> GetProjectsList()
        {
            List<ProjectData> list = new List<ProjectData>();
            var elements = application.driver.FindElements(By.XPath("(//table)[1]/descendant::tbody/tr"));
            for (int i = 0; i < elements.Count; i++)
            {
                string name = elements[i].FindElement(By.XPath("td[1]//a")).Text;
                list.Add(new ProjectData(name));
            }
            return list;
        }

        public void CreateNewProject(string projectName)
        {
            application.driver.FindElements(By.XPath("//button[contains(text(),'Создать новый проект')]"))[0].Click();
            application.driver.FindElement(By.Name("name")).SendKeys(projectName);
            application.driver.FindElement(By.XPath("//*[@type='submit']")).Click();
            application.NavigationHelper.GoToProjectsPage();
        }

        internal void DeleteProject(ProjectData project)
        {
            application.driver.FindElement(By.XPath($"(//table)[1]/descendant::a[contains(text(),'{project.Name}')]")).Click();
            application.driver.FindElement(By.XPath("//input[@value='Удалить проект']")).Click();
            application.driver.FindElement(By.XPath("//input[@value='Удалить проект']")).Click();
        }
    }
}
