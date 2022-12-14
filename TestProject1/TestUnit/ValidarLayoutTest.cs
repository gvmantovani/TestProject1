using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace TestProject1 
{
    [TestFixture]
    public class ValidarLayoutTest
    {
        private IWebDriver driver;
        public IDictionary<string, object> vars { get; private set; }
        private IJavaScriptExecutor js;
        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            js = (IJavaScriptExecutor)driver;
            vars = new Dictionary<string, object>();
        }
        [TearDown]
        protected void TearDown()
        {
            driver.Quit();
        }
        [Test]
        public void validarLayout()
        {
            driver.Navigate().GoToUrl("https://livros.inoveteste.com.br/contato/");
            driver.Manage().Window.Size = new System.Drawing.Size(1552, 840);
            Assert.That(driver.FindElement(By.CssSelector(".wpb_column:nth-child(1) h1")).Text, Is.EqualTo("Envie uma mensagem"));
            Assert.That(driver.FindElement(By.CssSelector("p:nth-child(2) > label")).Text, Is.EqualTo("Nome"));
            Assert.That(driver.FindElement(By.CssSelector("p:nth-child(4) > label")).Text, Is.EqualTo("Assunto"));
            Assert.That(driver.FindElement(By.CssSelector("p:nth-child(5) > label")).Text, Is.EqualTo("Mensagem"));
            driver.FindElement(By.CssSelector(".wpcf7-submit")).Click();
        }
    }
}
