using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingLibrary
{
    public class ParsingWebClass
    {
        private readonly IWebDriver Driver;
        private readonly TimeSpan Timeout = TimeSpan.FromSeconds(5);

        private readonly By Logotip = By.TagName("h1");
        private readonly By A = By.XPath("//input[@ng-model='a']");
        private readonly By APlus = By.XPath("//button[@ng-click='inca()']");
        private readonly By AMinus = By.XPath("//button[@ng-click='deca()']");
        private readonly By B = By.XPath("//input[@ng-model='b']");
        private readonly By BPlus = By.XPath("//button[@ng-click='incb()']");
        private readonly By BMinus = By.XPath("//button[@ng-click='decb()']");
        private readonly By Operation = By.TagName("select");
        private readonly By Result = By.TagName("b");

        public ParsingWebClass(IWebDriver webDriver)
        {
            Driver = webDriver;
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            try
            {
                new WebDriverWait(Driver, Timeout).Until(drv => drv.FindElement(Logotip));
            }
            catch
            {
                Console.WriteLine("Не удалось загрузить страницу");
            }
        }
        public ParsingWebClass SetA(string _a)
        {
            Driver.FindElement(A).Clear();
            Driver.FindElement(A).SendKeys(_a);
            return this;
        }
        public ParsingWebClass SetB(string b)
        {
            Driver.FindElement(B).Clear();
            Driver.FindElement(B).SendKeys(b);
            return this;
        }
        public ParsingWebClass ClickPlusA()
        {
            Driver.FindElement(APlus).Click();
            return this;
        }
        public string GetA()
        {
            IWebElement element = Driver.FindElement(By.XPath("//input[@ng-model='a']"));
            return element.GetAttribute("value");
        }
        public string GetB()
        {
            IWebElement element = Driver.FindElement(By.XPath("//input[@ng-model='b']"));
            return element.GetAttribute("value");
        }
        public ParsingWebClass ClickMinusA()
        {
            Driver.FindElement(AMinus).Click();
            return this;
        }
        public ParsingWebClass ClickPlusB()
        {
            Driver.FindElement(BPlus).Click();
            return this;
        }
        public ParsingWebClass ClickMinusB()
        {
            Driver.FindElement(BMinus).Click();
            return this;
        }
        public ParsingWebClass ClickOperation(string operation)
        {
            Driver.FindElement(Operation).Click();
            Driver.FindElement(By.XPath($".//option[@value='{operation}']")).Click();
            return this;
        }
        public string GetResult()
        {
            return Driver.FindElement(Result).Text;
        }

    }
}
