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

namespace ConsoleApp1
{
    class CreateDeal
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
        [Test]
        public void TestCreateDeal()
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
            Thread.Sleep(1000);
            var openMenu = driver.FindElement(By.XPath("//*[@id=\"TabSFA\"]/a"));
            openMenu.Click();

            Thread.Sleep(2000);

            var nextPage = driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Training'])[1]/following::img[2]"));
            nextPage.Click();
            Console.WriteLine("hello");

            Thread.Sleep(5000);
            var deal = driver.FindElement(By.Id("hsbc_deal"));
            deal.Click();
            Thread.Sleep(5000);

            var newButton = driver.FindElement(By.XPath("/html[1]/body[1]/div[6]/div[2]/div[1]/ul[1]/li[1]/span[1]/a[1]/span[1]"));
            newButton.Click();

            Thread.Sleep(5000);

            driver.SwitchTo().Frame("contentIFrame0");


            var name = driver.FindElement(By.Id("hsbc_name"));
            name.Click();

            var name_edit = driver.FindElement(By.Id("hsbc_name_i"));
            name_edit.SendKeys("New Deal");

            var security = driver.FindElement(By.Id("hsbc_securityclassification"));
            security.Click();

            var securityOption = driver.FindElement(By.XPath("//*[@id=\"hsbc_securityclassification_i\"]/option[2]"));
            securityOption.Click();

            var client = driver.FindElement(By.Id("hsbc_clientname"));
            client.Click();

            var client_edit = driver.FindElement(By.Id("hsbc_clientname_ledit"));
            client_edit.SendKeys("TestClient");

            var country = driver.FindElement(By.Id("hsbc_originatingcountry"));
            client.Click();

            var country_edit = driver.FindElement(By.Id("hsbc_originatingcountry_ledit"));
            client_edit.SendKeys("India");

            var dealTemplate = driver.FindElement(By.Id("hsbc_dealtemplate"));
            client.Click();

            var dealTemplate_edit = driver.FindElement(By.Id("hsbc_dealtemplate_ledit"));
            client_edit.SendKeys("Deal Template 1");

            var selectDealType = new SelectElement(driver.FindElement(By.Id("hsbc_dealtype")));
            selectDealType.SelectByText("DEAL_TYPE_BUY");

            var selectSecurity = new SelectElement(driver.FindElement(By.Id("hsbc_securityclassification")));
            selectSecurity.SelectByText("Class A");

            var saveButton = driver.FindElement(By.XPath("//*[@id=\"footer_statuscontrol\"]/div[2]"));
            saveButton.Click();







        }
    }
}


