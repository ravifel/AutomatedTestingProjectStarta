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
        public static readonly By MenuAboutButton = By.XPath("//a[@class='styles_link__ngTSz'][normalize-space()='Sobre']");


        // Methods
        public string GetTitle()
        {
            return driver.Title;
        }

        public void ClickMethod(By component)
        {
            driver.Click(component);
        }

        public void ClickMenu(By MenuButton)
        {

        }

    }
}