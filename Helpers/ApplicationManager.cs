using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System.Threading;
using NUnit.Framework;

namespace Mantis_Tests
{
    public class ApplicationManager
    {
        public IWebDriver driver;
        private readonly AccountData admin = new AccountData("administrator", "root");
        private static readonly ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        public ApplicationManager()
        {
            driver = new EdgeDriver();
            LoginHelper = new LoginHelper(this);
            NavigationHelper = new NavigationHelper(this);
            ProjectHelper = new ProjectHelper(this);
            APIHelper = new APIHelper(this);
        }

        public static ApplicationManager GetInstance()
        {
            if (!app.IsValueCreated)
            {
                app.Value = new ApplicationManager();
                app.Value.LoginHelper.OpenHomePage();
            }
            return app.Value;
        }

        public LoginHelper LoginHelper { get; set; }
        public NavigationHelper NavigationHelper { get; set; }
        public ProjectHelper ProjectHelper { get; set; }
        public APIHelper APIHelper { get; private set; }

        public void LoginAsAdmin() => LoginHelper.OpenHomePage().Login(admin);
    }
}