using NUnit.Framework;
using System;
using System.Text;

namespace MantisTests
{
    public class TestBase
    {
        protected ApplicationManager app;

        [SetUp]
        public virtual void SetUp()
        {
            app = ApplicationManager.GetInstance();
            app.driver.Manage().Window.Size = new System.Drawing.Size(1920, 1036);
            app.LoginAsAdmin();
        }

        [TearDown]
        public void TearDown() => app.LoginHelper.OpenHomePage();
    }
}