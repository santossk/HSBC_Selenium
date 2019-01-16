using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleApp1
{
    [TestClass]
    public class CreateCallReport
    {
        IWebDriver driver;
        private readonly String _username = "testuser@wiprolimited04.onmicrosoft.com";
        private readonly String _password = "wipro@12345";
        private readonly Uri _xrmUri = new Uri("http://wiprolimited04.crm8.dynamics.com/main.aspx");

        [SetUp]
        public void startBrowser()
        {
            driver = new ChromeDriver("C:\\Users\\ssk\\eclipse-workspace\\Flipkart");
            //driver = new FirefoxDriver("D:\\Tools\\Firefox_driver\\geckodriver-v0.23.0-win64");

        }
        [TearDown]
        public void closeBrowser()
        {
            driver.Quit();
        }
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
        public void TestCreateCallReport()
        {
            driver.Url = "https://wiprolimited04.crm8.dynamics.com/main.aspx";
            Thread.Sleep(1000);
            var login = driver.FindElement(By.Id("i0116"));
            login.SendKeys(_username);
            Thread.Sleep(1000);
            var nextbutton = driver.FindElement(By.Id("idSIButton9"));
            nextbutton.Click();
            Thread.Sleep(1000);
            var password = driver.FindElement(By.Id("i0118"));
            password.SendKeys(_password);
            Thread.Sleep(1000);
            var nextbutton1 = driver.FindElement(By.Id("idSIButton9"));
            nextbutton1.Click();
            Thread.Sleep(2000);
            var yesButton = driver.FindElement(By.Id("idSIButton9"));
            yesButton.Click();
            Thread.Sleep(5000);
            var advFindBtn = driver.FindElement(By.Id("advancedFindImage"));
            advFindBtn.Click();
            Thread.Sleep(2000);
            var allWindows = driver.WindowHandles.ToList();
            foreach (var curWindow in allWindows)
            {
                driver.SwitchTo().Window(curWindow);
            }
            Thread.Sleep(5000);
            driver.SwitchTo().Frame("contentIFrame0");
            //driver.FindElement(By.ClassName("ms-crm-AdvFind-AutoShow")).Click();

            var selectElement = new SelectElement(driver.FindElement(By.Id("slctPrimaryEntity")));
            selectElement.SelectByText("Meetings and Call Reports");

            driver.SwitchTo().DefaultContent();

            var results = driver.FindElement(By.ClassName("ms-crm-ImageStrip-Results_32"));
            results.Click();

            var newMeetingsandCallReports = driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Meetings and Call Reports'])[1]/following::img[1]"));
            newMeetingsandCallReports.Click();

            Thread.Sleep(5000);

            var allWindows1 = driver.WindowHandles.ToList();
            foreach (var curWindow in allWindows1)
            {
                driver.SwitchTo().Window(curWindow);
            }

            Thread.Sleep(5000);

            driver.SwitchTo().Frame("contentIFrame0");

            var name = driver.FindElement(By.Id("hsbc_name"));
            name.Click();

            var name_edit = driver.FindElement(By.Id("hsbc_name_i"));
            name_edit.SendKeys("New Call Report");

            var client = driver.FindElement(By.Id("hsbc_client"));
            client.Click();

            var client_edit = driver.FindElement(By.Id("hsbc_client_ledit"));
            client_edit.SendKeys("TestClient");

            var security = driver.FindElement(By.Id("hsbc_securityclassification"));
            security.Click();

            var securityOption = driver.FindElement(By.XPath("//*[@id=\"hsbc_securityclassification_i\"]/option[1]"));
            securityOption.Click();

            var saveButton = driver.FindElement(By.XPath("//*[@id=\"footer_statuscontrol\"]/div[2]"));
            saveButton.Click();







        }
    }
}


