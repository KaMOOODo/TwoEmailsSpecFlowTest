using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TwoEmailsSpecFlowTest.Drivers;

namespace TwoEmailsSpecFlowTest.Pages
{
    public class BasePage
    {
        protected string TitleXPath;
        public string currentUrl => DriverManager.Instance().Url;
        public BasePage()
        {

        }

        private static BasePage basePage;
        public static BasePage Instance => basePage ?? (basePage = new BasePage());

        public IWebElement FindElement(By locator)
        {
            return DriverManager.Instance().FindElement(locator);
        }

        public IReadOnlyCollection<IWebElement> FindElements(By locator)
        {
            return DriverManager.Instance().FindElements(locator);
        }

        public bool isDisplayed(By locator, int timeout = 30)
        {
            var wait = new WebDriverWait(DriverManager.Instance(), TimeSpan.FromSeconds(timeout));
            return wait.Until(d => DriverManager.Instance().FindElement(locator).Displayed);
        }

        public virtual bool isPageTitleDisplayed(string pageTitle)
        {
            return isDisplayed(By.XPath(string.Format(TitleXPath, pageTitle)));
        }

        public void ClearWebField(IWebElement element)
        {
            while (!element.GetAttribute("value").Equals(""))
            {
                element.SendKeys(Keys.Backspace);
                element.SendKeys(Keys.Delete);
            }
        }
    }
}
