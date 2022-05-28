using OpenQA.Selenium;

namespace TwoEmailsSpecFlowTest.Pages
{
    internal class ProtonLoginPage : LoginPage
    {
        private string modalPopupXpath = "//div[contains(@class, 'notifications-container')]/div";
        private string errorMessageXpath = "//div[contains(@class, 'inputform-assist')]/span";

        private static ProtonLoginPage protonLoginPage;
        public static ProtonLoginPage Instance => protonLoginPage ?? (protonLoginPage = new ProtonLoginPage());

        public ProtonLoginPage() : base()
        {
            base.URL = "https://account.proton.me/login";
            base.emailInputXpath = "//input[@id='username']";
            base.passwordInputXpath = "//input[@id='password']";
            base.loginButtonXpath = "//button[@type='submit']";
        }
        public override bool ErrorMessageIsDisplayed(string message)
        {
            try
            {
                return message == FindElement(By.XPath(errorMessageXpath)).Text;
            }
            catch (NoSuchElementException)
            {
                if (isDisplayed(By.XPath(modalPopupXpath)))
                {
                    return message == FindElement(By.XPath(modalPopupXpath)).Text;
                }
            }

            return false;

        }
    }
}
