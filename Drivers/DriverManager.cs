using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TwoEmailsSpecFlowTest.Drivers
{
    public class DriverManager
    {
        private static ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();

        public static IWebDriver Instance()
        {
            if (driver.Value == null)
            {
                driver.Value = new ChromeDriver();
                driver.Value.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(30));
                driver.Value.Manage().Window.Maximize();
            }
            return driver.Value;
        }

        public static void QuitDriver()
        {
            Instance().Quit();
            driver.Value = null;
        }
    }
}
