using AutomatedTestingProjectStarta.WebDriverExtensions;
using OpenQA.Selenium;

namespace AutomatedTestingProjectStarta.Pages
{
    public class ProductsPage
    {
        public static IWebDriver driver;

        public ProductsPage(IWebDriver driver)
        {
            ProductsPage.driver = driver;
        }

        // Components
        public By MainPageTitle = By.XPath("//h1[normalize-space()='Veja alguns dos produtos desenvolvidos pela Starta']");

        // Methods
        public string GetTitle()
        {
            return driver.Title;
        }

        public void ClickMethod(By component)
        {
            driver.Click(component);
        }
    }
}