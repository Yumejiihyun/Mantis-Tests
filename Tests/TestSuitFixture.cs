using NUnit.Framework;

namespace Mantis_Tests
{
    [SetUpFixture]
    public class TestSuitFixture
    {
        private ApplicationManager app;

        [OneTimeTearDown]
        public void TearDown()
        {
            app = ApplicationManager.GetInstance();
            app.driver.Close();
        }
    }
}
