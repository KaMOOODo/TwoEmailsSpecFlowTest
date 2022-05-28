using TwoEmailsSpecFlowTest.Pages;

namespace TwoEmailsSpecFlowTest.StepDefinitions
{
    [Binding]
    public class SendingMailStepDefinitions
    {
        [Given(@"I open Tutanota main webpage")]
        public void IOpenTutanotaMainWebpage()
        {
            TutanotaLoginPage.Instance.OpenLoginPage();
            TutanotaLoginPage.Instance.EnterEmail("youremail@tutanota.com");
            TutanotaLoginPage.Instance.EnterPassword("yourpassword");
            TutanotaLoginPage.Instance.ClickLogin();
            TutanotaMain.Instance.isPageTitleDisplayed("youremail@tutanota.com");
        }

        [When(@"I open Proton main webpage")]
        public void IOpenProtonMainWebpage()
        {
            ProtonLoginPage.Instance.OpenLoginPage();
            ProtonLoginPage.Instance.EnterEmail("youremail@proton.me");
            ProtonLoginPage.Instance.EnterPassword("yourpassword@umQ7e\"W=af");
            ProtonLoginPage.Instance.ClickLogin();
            Thread.Sleep(20000);//Captcha
            ProtonMain.Instance.isPageTitleDisplayed("youremail@proton.me");
        }

        [When(@"I send email to ""([^""]*)"" with text ""([^""]*)""")]
        public void WhenISendEmailToWithText(string email, string message)
        {
            TutanotaMain.Instance.SendEmail(email, message);
        }

        [Then(@"The unread email from ""([^""]*)"" exists in the conversation list")]
        public void ThenTheEmailFromExistsInTheConversationList(string sender)
        {
            ProtonMain.Instance.FindUnreadEmailFrom(sender).Should().NotBeNull();
        }

    }
}
