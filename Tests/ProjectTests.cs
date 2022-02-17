using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Mantis_Tests
{
    [TestFixture]
    public class ProjectTests : TestBase
    {
        [Test]
        public void NewProjectTest()
        {
            var adminData = new AccountData("administrator", "root");
            app.NavigationHelper.GoToProjectsPage();

            List<ProjectData> oldList = app.APIHelper.GetProjectsList(adminData);
            oldList.Add(new ProjectData("NewProjectTest"));

            app.ProjectHelper.CreateNewProject("NewProjectTest");
            List<ProjectData> newList = app.APIHelper.GetProjectsList(adminData);

            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);
        }

        [Test]
        public void DeleteProjectTest()
        {
            var adminData = new AccountData("administrator", "root");
            app.NavigationHelper.GoToProjectsPage();

            List<ProjectData> oldList = app.APIHelper.GetProjectsList(adminData);
            if (oldList.Count == 0)
            {
                var projectToAdd = new ProjectData("DeleteProjectTest");
                oldList.Add(projectToAdd);
                app.APIHelper.CreateNewProject(adminData, projectToAdd);
                app.driver.Navigate().Refresh();
            }
            ProjectData toRemove = oldList[0];
            oldList.RemoveAt(0);

            app.ProjectHelper.DeleteProject(toRemove);
            List<ProjectData> newList = app.APIHelper.GetProjectsList(adminData);

            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}
