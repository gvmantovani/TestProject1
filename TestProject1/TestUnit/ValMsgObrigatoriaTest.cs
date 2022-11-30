using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace TestUnit
{
    [TestFixture]
    public class CT02ValidarCamposObrigatorios
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void TheCT02ValidarCamposObrigatoriosTest()
        {
            // Acessa o site
            driver.Navigate().GoToUrl(baseURL + "/");
            // Acessa o menu Contato
            driver.FindElement(By.CssSelector("em.fa.fa-bars")).Click();
            driver.FindElement(By.CssSelector("div.sidr-inner > #nav-wrap > #primary_menu > #menu-item-80 > a > span")).Click();
            // Clica no botão Salvar sem preencher os campos obrigatórios
            driver.FindElement(By.CssSelector("input.wpcf7-form-control.wpcf7-submit")).Click();
            // Valida as mensagens de crítica dos campos obrigatórios
            Assert.AreEqual("O campo é obrigatório.", driver.FindElement(By.CssSelector("span.wpcf7-not-valid-tip")).Text);
            Assert.AreEqual("O campo é obrigatório.", driver.FindElement(By.CssSelector("span.wpcf7-form-control-wrap.your-email > span.wpcf7-not-valid-tip")).Text);
            Assert.AreEqual("O campo é obrigatório.", driver.FindElement(By.CssSelector("span.wpcf7-form-control-wrap.your-message > span.wpcf7-not-valid-tip")).Text);
            Assert.AreEqual("O campo é obrigatório.", driver.FindElement(By.CssSelector("span.wpcf7-form-control-wrap.your-subject > span.wpcf7-not-valid-tip")).Text);
            Assert.AreEqual("Um ou mais campos possuem um erro. Verifique e tente novamente.", driver.FindElement(By.XPath("//div[@id='wpcf7-f372-p24-o1']/form/div[2]")).Text);
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}

