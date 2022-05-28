using OpenQA.Selenium;

namespace TwoEmailsSpecFlowTest.Pages
{
    public class TutanotaMain : BasePage
    {
        private string emailTitleXpath = "//*[@id='mail']//*[@role='navigation']//small";
        private string newEmailXpath = "//button[@title='New email']";
        private string sendToXpath = "//div[@role='dialog']//input[@aria-label='To']";
        private string passwordXpath = "//input[contains(@aria-label, 'Password')]";
        private string subjectXpath = "//div[@role='dialog']//input[@aria-label='Subject']";
        private string messageXpath = "//div[@role='dialog']//div[@role='textbox']/div";
        private string buttonSendXpath = "//button[@title='Send']";


        private static TutanotaMain tutanotaMainPage;
        public static TutanotaMain Instance => tutanotaMainPage ?? (tutanotaMainPage = new TutanotaMain());

        public TutanotaMain() : base()
        {
            base.TitleXPath = emailTitleXpath;
        }
        public override bool isPageTitleDisplayed(string pageTitle)
        {
            if (isDisplayed(By.XPath(emailTitleXpath)))
            {
                var emailElement = FindElements(By.XPath(emailTitleXpath)).First(x => x.Text.ToLower().Equals(pageTitle));
                return emailElement != null;
            }
            return false;
        }
        public void SendEmail(string email, string message)
        {
            FindElement(By.XPath(newEmailXpath)).Click();
            FindElement(By.XPath(sendToXpath)).SendKeys(email);
            FindElement(By.XPath(subjectXpath)).SendKeys("This email was created by SpecFlow test");
            isDisplayed(By.XPath("//div[contains(@class, 'external-recipients')]"));
            FindElement(By.XPath("//div[contains(@class, 'external-recipients')]")).Click();
            ClearWebField(FindElement(By.XPath(passwordXpath)));
            FindElement(By.XPath(passwordXpath)).SendKeys("Passwdsf8aswe7548923");
            FindElement(By.XPath(messageXpath)).SendKeys(message);
            FindElement(By.XPath(buttonSendXpath)).Click();
            Thread.Sleep(1500);
        }
    }
}
