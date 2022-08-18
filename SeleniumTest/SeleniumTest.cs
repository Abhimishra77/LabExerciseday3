using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Firefox;

namespace LabExercise
{
    [TestClass]
    public class SeleniumTest
    {
        IWebDriver driver;
        [DataTestMethod]
        // [DataRow("Firefox", "Customer service")]
        [DataRow("Chrome", "WebMaster","abh@gmail.com","abc"," heyiamusingthissite")]
        public void TestMethod4(string browser, string subjectHeading,string email,string ordernum,string messages)
        {

            string url="http://automationpractice.com/index.php";
            if (browser == "Firefox")
            {

            // driver = new FirefoxDriver(@"C:\RootFolder\driver104");
               
            //      driver.Navigate().GoToUrl(url);
            //      Thread.Sleep(2000);
            //      driver.Quit();
            }
            else if(browser == "Chrome")
            {
            driver =new ChromeDriver(@"C:\RootFolder\driver104");
                driver.Navigate().GoToUrl(url);
                Thread.Sleep(2000);
                  IWebElement contactus = driver.FindElement(By.Id("contact-link"));
                  contactus.Click();
                  IWebElement subjectHead = driver.FindElement(By.Id("id_contact"));
                  ScrollByElement(By.Id("id_contact"));
                  subjectHead.Click();
                 driver.FindElement(By.XPath("//select/option[2]")).Click();
                 IWebElement emailid = driver.FindElement(By.Id("email"));
                  emailid.SendKeys(email);
                  IWebElement orderref = driver.FindElement(By.Id("id_order"));
                  orderref.SendKeys(ordernum);
                  IWebElement message = driver.FindElement(By.Id("message"));
                  message.SendKeys(messages);
                  driver.Quit();
                 
                 
            } 

        }
        public void ScrollByElement(By element)
        {
            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("arguments[0].scrollIntoView();", driver.FindElement(element));
            
            }
            catch
            {
                throw;
            }
        }
    }
}
