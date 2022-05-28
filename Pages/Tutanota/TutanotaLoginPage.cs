using OpenQA.Selenium;

namespace TwoEmailsSpecFlowTest.Pages
{
    internal class TutanotaLoginPage : LoginPage
    {
        private string modalPopupXpath = "//*[@id='modal']";
        private string errorMessageXpath = "//form//small[@aria-live='polite']";

        private static TutanotaLoginPage tutanotaLoginPage;
        public static TutanotaLoginPage Instance => tutanotaLoginPage ?? (tutanotaLoginPage = new TutanotaLoginPage());

        public TutanotaLoginPage() : base()
        {
            base.URL = "https://mail.tutanota.com/login";
            base.emailInputXpath = "//input[@type='email']";
            base.passwordInputXpath = "//input[@type='password']";
            base.loginButtonXpath = "//button[@title='Log in']";
        }

        public override bool ErrorMessageIsDisplayed(string message)
        {
            if (isDisplayed(By.XPath(modalPopupXpath)))
            {
                Thread.Sleep(1000);
            }

            if (isDisplayed(By.XPath(errorMessageXpath)))
            {
                var errorElementText = FindElement(By.XPath(errorMessageXpath)).Text;
                Console.WriteLine(errorElementText);
                return errorElementText == message;
            }
            else
            {
                return false;
            }
        }
    }
}
