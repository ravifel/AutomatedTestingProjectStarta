using AutomatedTestingProjectStarta.WebDriverExtensions;
using OpenQA.Selenium;

namespace AutomatedTestingProjectStarta.Pages
{
    public class HomePage
    {
        public static IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            HomePage.driver = driver;
        }

        // Components
        public By MenuSolutionsButton = By.XPath("//button[normalize-space()='Soluções']");
        public static readonly By ContactButton = By.XPath("//div[contains(@class,'styles_wrapper__MVJqS')]//a[contains(@href,'#contact')]//button[contains(@class,'styles_container__vqOJJ')]//p[contains(text(),'Contato')]");
        public By NameField = By.CssSelector("input[placeholder='Informe seu nome']");
        public By EmailField = By.CssSelector("input[placeholder='Seu e-mail']");
        public By PhoneNumberField = By.CssSelector("input[placeholder='Número de telefone']");
        public By ContactMessageField = By.CssSelector("textarea[placeholder='Deixe aqui a sua mensagem']");
        public By ErrorMessageRecaptcha = By.CssSelector(".styles_error__EDpT3");
        public By SubmitFormButton = By.CssSelector("button[type='submit']");

        // Methods
        public string GetTitle()
        {
            return driver.Title;
        }

        public void ClickMethod(By component)
        {
            driver.Click(component);
        }

        public void ClickMenuSubMenuButton(By component)
        {
            ClickMethod(component);
            ClickMethod(By.CssSelector("body div[id='root'] li li:nth-child(1) a:nth-child(1)"));
        }

        public void FillField(By component, string value)
        {
            driver.EnterText(component, value);
        }

        public void AttemptedToSubmitAnEmptyForm()
        {
            ClickMethod(ContactButton);
            ClickMethod(SubmitFormButton);
        }

        public void AttemptedToSubmitAnInvalidForm()
        {
            ClickMethod(ContactButton);
            FillField(NameField, "Name Test");
            FillField(EmailField, "email-invalid");
            FillField(PhoneNumberField, "21999996666");
            FillField(ContactMessageField, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam efficitur lacinia mi in mollis. Sed tincidunt nibh eu turpis dapibus auctor. Praesent a sagittis ipsum. Vestibulum ut mattis nisi.");
            ClickMethod(SubmitFormButton);
        }

        public void FormSubmittedSuccessfully()
        {
            ClickMethod(ContactButton);
            FillField(NameField, "Name Test");
            FillField(EmailField, "email.test@example.com.br");
            FillField(PhoneNumberField, "21999996666");
            FillField(ContactMessageField, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam efficitur lacinia mi in mollis. Sed tincidunt nibh eu turpis dapibus auctor. Praesent a sagittis ipsum. Vestibulum ut mattis nisi.");
            ClickMethod(SubmitFormButton);
        }
    }
}