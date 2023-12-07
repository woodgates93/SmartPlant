using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;


namespace UISeleniumTest
{
    [TestClass]
    public class UISelenium
    {
        private IWebDriver driver;

        [TestInitialize]
        public void Initialize()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("file:///C:/Users/sarah/OneDrive/Documents/GitHub/SmartPlant/SmartPlant_Web/HTML/Index.html");
        }
        [TestCleanup]
        public void Cleanup()
        {
            driver.Quit();
        }
        [TestMethod]
        public void TestHeader()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            //Vent på at header-elenemt bliver synligt
            IWebElement header = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(".header")));
            //Assertion: kontroller om header-teksten er som forventet
            Assert.AreEqual("SMARTPLANT", header.FindElement(By.TagName("h2")).Text);
            //Assertion: Kontroller om der er tekst i header
            Assert.IsTrue(!string.IsNullOrEmpty(header.FindElement(By.TagName("p")).Text.Trim()));
        }
        [TestMethod]
        public void TestNavbarLinks()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Vent på, at navbar-elementet bliver synligt
            IWebElement navbar = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(".topnav")));

            // Assertion: Kontroller, om der er mindst fire links i navbar
            Assert.IsTrue(navbar.FindElements(By.TagName("a")).Count >= 4);
        }

        [TestMethod]
        public void TestCard()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Vent på, at card-elementet bliver synligt
            IWebElement card = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(".card")));

            // Assertion: Kontroller, om card-elementet har en titel
            Assert.IsTrue(!string.IsNullOrEmpty(card.FindElement(By.TagName("h2")).Text.Trim()));

            // Assertion: Kontroller, om card-elementet har en undertitel
            Assert.IsTrue(!string.IsNullOrEmpty(card.FindElement(By.TagName("h5")).Text.Trim()));

            // Assertion: Kontroller, om card-elementet har indhold i contentbox
            Assert.IsTrue(!string.IsNullOrEmpty(card.FindElement(By.CssSelector(".contentbox")).Text.Trim()));

            // Assertion: Kontroller, om card-elementet har tekst
            Assert.IsTrue(!string.IsNullOrEmpty(card.FindElement(By.TagName("p")).Text.Trim()));
        }

    }
}