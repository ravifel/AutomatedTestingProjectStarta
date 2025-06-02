# AutomatedTestingProjectStarta

1. Create New Project: 
"Unit Test Project (.NET Framework)
A project that contains MSTest unit tests. (C#, Windows, Test)
.NET Framework Version: 4.7.2


2. NuGet Packages:

![image](https://github.com/user-attachments/assets/a84e6ce9-041e-45cf-9877-70e0c6425239)

- MSTest.TestAdapter (2.2.10)
- MSTest.TestFramework (2.2.10)
- Selenium.RC (3.1.0)
- Selenium.Support (4.8.0)
- Selenium.WebDriver (4.8.0)
- Selenium.WebDriver.ChromeDriver (137.0.7151.5500)
- Selenium.WebDriver.GeckoDriver (0.36.0)
- DotNetSeleniumExtras.WaitHelpers (3.11.0)
- Selenium.WebDriver.IEDriver (4.14.0)

3. Criação das Pastas

![image](https://github.com/user-attachments/assets/cdfa125d-a79b-4c8e-826d-49fc41c602c7)

- "BasePage": Pasta base do projeto, onde contém a URL
- "Pages": Pasta onde ficarão organizadas as páginas da aplicação. (Com componentes e métodos)
- "Tests": Pasta onde ficarão os testes. (Validações)


4. Configurar a "BaseClass" com a URL base.
5. Mapear os componentes na "Page" e criar os métodos/lógica que serão usados nas validações.
6. Realizar a criação dos testes na página de testes.
7. Criação da página "WebDriverElements" para concentrar métodos que serão utilizados em toda a aplicão.
8. Os teste automatizados foram executados 10 vezes consecutivas e todos os testes foram bem sucedidos.

![image](https://github.com/user-attachments/assets/3234a091-4500-44ac-8f50-3b2f2371ab86)

4.Casos de Teste:
- TC01 - Validating the operation of selecting a sub-option in the Menu
- TC02 - Validation of the attempt to send an empty form.
- TC03 - Validation of the attempt to send an invalid form.
- TC04 - Validation of the attempt to submit the form without checking the Recaptcha.
