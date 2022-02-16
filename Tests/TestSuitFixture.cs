using NUnit.Framework;

namespace MantisTests
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
