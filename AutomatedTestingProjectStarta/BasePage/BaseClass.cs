using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace AutomatedTestingProjectStarta.BasePage
{
    public class BaseClass
    {
        public static IWebDriver driver;
        public TestContext TestContext { get; set; } // To access the test name, status, etc.
        [TestInitialize]

        public void Init()
        {
            KillDriverProcesses(); // (Optional) Terminates stuck ChromeDriver processes

            var options = new ChromeOptions();
            options.AddArgument("--start-maximized"); // Starts with the window maximized

            driver = new ChromeDriver(options);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(90); // Maximum page load time
            driver.Navigate().GoToUrl("https://starta.site/");
            driver.Manage().Window.Maximize();

            // Wait for the page to load completely (document.readyState === "complete")
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(d =>
                ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (driver != null)
            {
                try
                {
                    driver.Quit(); // Closes the browser session correctly
                    driver.Dispose(); // Frees memory and resources
                }
                catch (Exception e)
                {
                    Console.WriteLine("Erro ao finalizar o WebDriver: " + e.Message);
                }
            }
        }

        // Kill ChromeDriver zombie processes between consecutive runs
        private void KillDriverProcesses()
        {
            foreach (var process in Process.GetProcessesByName("chromedriver"))
            {
                try
                {
                    process.Kill();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao matar processo do ChromeDriver: " + ex.Message);
                }
            }

        }

    }
}