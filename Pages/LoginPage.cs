using OpenQA.Selenium;
using TwoEmailsSpecFlowTest.Drivers;

namespace TwoEmailsSpecFlowTest.Pages
{
    internal class LoginPage : BasePage
    {
        protected string URL;
        protected string emailInputXpath;
        protected string passwordInputXpath;
        protected string loginButtonXpath;
        protected string modalPopupXpath;
        protected string errorMessageXpath;

        private static LoginPage homePage;
        public static LoginPage Instance => homePage ?? (homePage = new LoginPage());

        public void OpenLoginPage()
        {
            DriverManager.Instance().Navigate().GoToUrl(URL);
        }

        public void EnterEmail(string item)
        {
            isDisplayed(By.XPath(loginButtonXpath));
            var emailItem = FindElement(By.XPath(emailInputXpath));
            emailItem.SendKeys(item);
        }

        public void EnterPassword(string item)
        {
            var passwordItem = FindElement(By.XPath(passwordInputXpath));
            passwordItem.SendKeys(item);
        }

        public void ClickLogin()
        {
            var loginItem = FindElement(By.XPath(loginButtonXpath));
            loginItem.Click();
        }

        public virtual bool ErrorMessageIsDisplayed(string message)
        {

            if (isDisplayed(By.XPath(errorMessageXpath)))
            {
                var errorElementText = FindElement(By.XPath(errorMessageXpath)).Text;
                return errorElementText == message;
            }

            return false;
        }
    }
}
