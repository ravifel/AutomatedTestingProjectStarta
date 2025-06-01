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
        public TestContext TestContext { get; set; } // Para acessar o nome do teste, status e etc.
        [TestInitialize]

        public void Init()
        {
            KillDriverProcesses(); // (Opcional) Finaliza processos travados do ChromeDriver

            var options = new ChromeOptions();
            options.AddArgument("--start-maximized"); // Inicia com a janela maximizada

            driver = new ChromeDriver(options);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(90); // Tempo máximo de carregamento da página
            driver.Navigate().GoToUrl("https://starta.site/");
            driver.Manage().Window.Maximize();

            // Aguarda o carregamento completo da página (document.readyState === "complete")
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
                    driver.Quit(); // Encerra a sessão do navegador corretamente
                    driver.Dispose(); // Libera memória e recursos
                }
                catch (Exception e)
                {
                    Console.WriteLine("Erro ao finalizar o WebDriver: " + e.Message);
                }
            }
        }

        // Mata processos zumbis do ChromeDriver entre execuções consecutivas
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