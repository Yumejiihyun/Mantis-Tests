using OpenQA.Selenium;
using System;

namespace MantisTests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager application) : base(application)
        {
        }

        public LoginHelper OpenHomePage()
        {
            application.driver.Navigate().GoToUrl("http://localhost/mantisbt-2.25.2/");
            return this;
        }
        public LoginHelper Login(AccountData accountData)
        {
            if(IsLoggedIn())
            {
                if(IsLoggedIn(accountData))
                {
                    return this;
                }

                LogOut();
            }
            Type(By.Name("username"), accountData.Username);
            application.driver.FindElement(By.XPath("//input[@type='submit']")).Click();
            Type(By.Name("password"), accountData.Password);
            application.driver.FindElement(By.XPath("//input[@type='submit']")).Click();
            return this;
        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.XPath("//i[@class='fa fa-user ace-icon fa-2x white']"));
        }

        public void LogOut()
        {
            if(IsLoggedIn()) application.driver.Url = "http://localhost/mantisbt-2.25.2/logout_page.php";
        }

        public bool IsLoggedIn(AccountData accountData)
        {
            return IsLoggedIn()
                && GetLoggedUserName() == accountData.Username;
        }

        private string GetLoggedUserName()
        {
            return application.driver.FindElement(By.XPath("//span[@class='user-info']")).Text;
        }
    }
}