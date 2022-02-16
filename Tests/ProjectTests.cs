using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace MantisTests
{
    [TestFixture]
    public class ProjectTests : TestBase
    {
        [Test]
        public void NewProjectTest()
        {
            app.NavigationHelper.GoToProjectsPage();

            List<ProjectData> oldList = app.ProjectHelper.GetProjectsList();
            oldList.Add(new ProjectData("NewProjectTest"));

            app.ProjectHelper.CreateNewProject("NewProjectTest");
            List<ProjectData> newList = app.ProjectHelper.GetProjectsList();

            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);
        }

        [Test]
        public void DeleteProjectTest()
        {
            app.NavigationHelper.GoToProjectsPage();

            List<ProjectData> oldList = app.ProjectHelper.GetProjectsList();
            if (oldList.Count == 0)
            {
                oldList.Add(new ProjectData("DeleteProjectTest"));
                app.ProjectHelper.CreateNewProject("DeleteProjectTest");
            }
            ProjectData toRemove = oldList[0];
            oldList.RemoveAt(0);

            app.ProjectHelper.DeleteProject(toRemove);
            List<ProjectData> newList = app.ProjectHelper.GetProjectsList();

            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}
