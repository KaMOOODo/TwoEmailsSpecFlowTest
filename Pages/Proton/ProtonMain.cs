using OpenQA.Selenium;

namespace TwoEmailsSpecFlowTest.Pages
{
    public class ProtonMain : BasePage
    {
        private string emailTitleXpath = "//span[contains(@class, 'user-dropdown-email')]";
        private string conversationXpath = "//span[@title='']";
        private string unreadContainerXpath = "//div[contains(@class, 'item-container unread')]";

        private static ProtonMain protonMainPage;
        public static ProtonMain Instance => protonMainPage ?? (protonMainPage = new ProtonMain());

        public override bool isPageTitleDisplayed(string pageTitle)
        {
            if (isDisplayed(By.XPath(emailTitleXpath)))
            {
                var emailElement = FindElements(By.XPath(emailTitleXpath)).First(x => x.Text.ToLower().Equals(pageTitle));
                return emailElement != null;
            }
            return false;
        }

        public IWebElement FindUnreadEmailFrom(string sender)
        {
            var emailXpath = conversationXpath.Insert(conversationXpath.Length - 2, sender);
            isDisplayed(By.XPath(emailXpath));
            var elements = FindElements(By.XPath(unreadContainerXpath));
            var unreadEmail = from e in elements
                              where e.Text.ToLower().Contains(sender.ToLower())
                              select e;
            return unreadEmail.First();
        }
    }
}
