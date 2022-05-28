using TwoEmailsSpecFlowTest.Drivers;
using TwoEmailsSpecFlowTest.Pages;

namespace TwoEmailsSpecFlowTest.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions
    {
        private LoginPage loginPageInstance;

        [Given(@"I open Tutanota login webpage")]
        public void IOpenWebpage()
        {
            loginPageInstance = new TutanotaLoginPage();
            loginPageInstance.OpenLoginPage();
        }

        [Given(@"I open Proton login webpage")]
        public void IOpenProtonLoginWebpage()
        {
            loginPageInstance = new ProtonLoginPage();
            loginPageInstance.OpenLoginPage();
        }

        [When(@"I enter ""([^""]*)"" in login input")]
        public void WhenIEnterInLoginInput(string login)
        {

            loginPageInstance.EnterEmail(login);
        }

        [When(@"I enter '([^']*)' in password input")]
        public void WhenIEnterInPasswordInput(string password)
        {
            loginPageInstance.EnterPassword(password);
        }

        [When(@"I click Login button")]
        public void WhenIClickButton()
        {
            loginPageInstance.ClickLogin();
        }

        [Then(@"the tutanota main page with ""([^""]*)"" title should be opened")]
        public void ThenTheTutanotaMainPageWithTitleShouldBeOpened(string title)
        {
            TutanotaMain.Instance.isPageTitleDisplayed(title).Should().BeTrue();
        }

        [Then(@"the proton main page with ""([^""]*)"" title should be opened")]
        public void ThenTheProtonMainPageWithTitleShouldBeOpened(string title)
        {
            ProtonMain.Instance.isPageTitleDisplayed(title).Should().BeTrue();
        }

        [Then(@"the error message should be ""([^""]*)""")]
        public void ThenTheErrorMessageShouldBe(string message)
        {
            loginPageInstance.ErrorMessageIsDisplayed(message).Should().BeTrue();
        }

        [AfterScenario]
        public static void AfterScenario()
        {
            DriverManager.QuitDriver();
        }
    }
}
