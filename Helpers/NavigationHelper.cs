using OpenQA.Selenium;
using System;

namespace Mantis_Tests
{
    public class NavigationHelper : HelperBase
    {
        public NavigationHelper(ApplicationManager application) : base(application)
        {
        }
        public void GoToHomePage()
        {
            application.driver.Url = "http://localhost/mantisbt-2.25.2";
            application.driver.Manage().Window.Size = new System.Drawing.Size(1920, 1036);
        }

        public void GoToProjectsPage()
        {
            application.driver.Url = "http://localhost/mantisbt-2.25.2/manage_proj_page.php";
        }
    }
}