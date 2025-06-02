using AutomatedTestingProjectStarta.BasePage;
using AutomatedTestingProjectStarta.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;


namespace AutomatedTestingProjectStarta.Tests
{
    [TestClass]
    public class HomeTest : BaseClass
    {
        public HomePage homePage;
        public ProductsPage productsPage;

        [TestInitialize]
        public void SetUp()
        {
            homePage = new HomePage(driver);
            productsPage = new ProductsPage(driver);
        }

        [TestMethod]
        [TestCategory("Validating the operation of selecting a sub-option in the Menu")]
        [Description("Validating the operation of selecting a sub-option in the Menu")]
        public void ValidatingTheOperationOfSelectingSubOptionInTheMenu()
        {
            homePage.ClickMenuSubMenuButton(homePage.MenuSolutionsButton);

            string MainPageTitle = driver.FindElement(productsPage.MainPageTitle).Text;
            Assert.IsTrue(MainPageTitle.Contains("Veja alguns dos produtos desenvolvidos pela Starta"), "O texto esperado não foi encontrado.");
        }

        [TestMethod]
        [TestCategory("Validation of the attempt to send an empty form.")]
        [Description("Validation of the attempt to send an empty form.")]
        public void ValidationOfTheAttemptToSendAnEmptyForm()
        {
            homePage.AttemptedToSubmitAnEmptyForm();

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            IWebElement nameFieldElement = driver.FindElement(homePage.NameField); // Get the actual element using the selector
            string messageValidation = (string)js.ExecuteScript("return arguments[0].validationMessage;", nameFieldElement);

            Assert.IsTrue(messageValidation.Contains("Preencha este campo."),$"Mensagem inválida: {messageValidation}"); // Asserts whether the error message contains the expected text
        }

        [TestMethod]
        [TestCategory("Validation of the attempt to send an invalid form.")]
        [Description("Validation of the attempt to send an invalid form.")]
        public void ValidationOfTheAttemptToSendAnInvalidForm()
        {
            homePage.AttemptedToSubmitAnInvalidForm();

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            IWebElement emailFieldElement = driver.FindElement(homePage.EmailField);
            string messageValidation = (string)js.ExecuteScript("return arguments[0].validationMessage;", emailFieldElement);

            Assert.IsTrue(messageValidation.Contains("no endereço de e-mail"), $"Mensagem inválida: {messageValidation}");
        }

        [TestMethod]
        [TestCategory("Validation of the attempt to submit the form without checking the Recaptcha.")]
        [Description("Validation of the attempt to submit the form without checking the Recaptcha.")]
        public void ValidationOfTheAttemptToSubmitTheFormWithoutCheckingTheRecaptcha()
        {
            homePage.FormSubmittedSuccessfully();

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            IWebElement ErrorMessageRecaptchaElement = driver.FindElement(homePage.ErrorMessageRecaptcha);
            string messageValidation = ErrorMessageRecaptchaElement.Text;

            Assert.IsTrue(messageValidation.Contains("Atenção! É obrigatório o preenchimento do Captcha!"), $"Mensagem inválida: {messageValidation}");
        }
    }
}