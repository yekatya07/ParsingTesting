using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ParsingLibrary;

namespace ParsingTesting
{
    public class Tests
    {
        public IWebDriver Driver;
        [SetUp]
        public void Setup()
        {
            ChromeOptions options = new ChromeOptions();
            Driver = new ChromeDriver(options);
            Driver.Navigate().GoToUrl("https://www.globalsqa.com/angularJs-protractor/SimpleCalculator/");
        }

        [Test]
        public void SetATest()
        {
            ParsingWebClass pars = new ParsingWebClass(Driver);
            pars.SetA("41");
            string actual = pars.GetA();
            Assert.That(actual, Is.EqualTo("41"));
        }
        [Test]
        public void SetBTest()
        {
            ParsingWebClass pars = new ParsingWebClass(Driver);
            pars.SetB("41");
            string actual = pars.GetB();
            Assert.That(actual, Is.EqualTo("41"));
        }
        [Test]
        public void PlusATest()
        {
            ParsingWebClass pars = new ParsingWebClass(Driver);
            pars.SetA("41");
            pars.ClickPlusA();
            string actual = pars.GetResult();
            Assert.That(actual, Is.EqualTo("42 + 0 = 42"));
        }
        [Test]
        public void PlusBTest()
        {
            ParsingWebClass pars = new ParsingWebClass(Driver);
            pars.SetB("41");
            pars.ClickPlusB();
            string actual = pars.GetResult();
            Assert.That(actual, Is.EqualTo("0 + 42 = 42"));
        }
        [Test]
        public void MinusATest()
        {
            ParsingWebClass pars = new ParsingWebClass(Driver);
            pars.SetA("41");
            pars.ClickMinusA();
            string actual = pars.GetResult();
            Assert.That(actual, Is.EqualTo("40 + 0 = 40"));
        }
        [Test]
        public void MinusBTest()
        {
            ParsingWebClass pars = new ParsingWebClass(Driver);
            pars.SetB("41");
            pars.ClickMinusB();
            string actual = pars.GetResult();
            Assert.That(actual, Is.EqualTo("0 + 40 = 40"));
        }
        [Test]
        public void PlusADoubleTest()
        {
            ParsingWebClass pars = new ParsingWebClass(Driver);
            pars.SetA("41");
            pars.ClickPlusA();
            pars.ClickPlusA();
            string actual = pars.GetResult();
            Assert.That(actual, Is.EqualTo("43 + 0 = 43"));
        }
        [Test]
        public void MinusADoubleTest()
        {
            ParsingWebClass pars = new ParsingWebClass(Driver);
            pars.SetA("41");
            pars.ClickMinusA();
            pars.ClickMinusA();
            string actual = pars.GetResult();
            Assert.That(actual, Is.EqualTo("39 + 0 = 39"));
        }
        [Test]
        public void OperatorMinusTest()
        {
            ParsingWebClass pars = new ParsingWebClass(Driver);
            pars.SetA("41");
            pars.SetB("40");
            pars.ClickOperation("-");
            string actual = pars.GetResult();
            Assert.That(actual, Is.EqualTo("41 - 40 = 1"));
        }
        [Test]
        public void OperatorMultiplyTest()
        {
            ParsingWebClass pars = new ParsingWebClass(Driver);
            pars.SetA("12");
            pars.SetB("12");
            pars.ClickOperation("*");
            string actual = pars.GetResult();
            Assert.That(actual, Is.EqualTo("12 * 12 = 144"));
        }
        [Test]
        public void OperatorDivideTest()
        {
            ParsingWebClass pars = new ParsingWebClass(Driver);
            pars.SetA("18");
            pars.SetB("9");
            pars.ClickOperation("/");
            string actual = pars.GetResult();
            Assert.That(actual, Is.EqualTo("18 / 9 = 2"));
        }
        [Test]
        public void OperatorPlusTest()
        {
            ParsingWebClass pars = new ParsingWebClass(Driver);
            pars.SetA("41");
            pars.SetB("41");
            pars.ClickOperation("+");
            string actual = pars.GetResult();
            Assert.That(actual, Is.EqualTo("41 + 41 = 82"));
        }

        [Test]
        public void OperationDivideByNullTest()
        {
            ParsingWebClass pars = new ParsingWebClass(Driver);
            pars.SetA("18");
            pars.SetB("0");
            pars.ClickOperation("/");
            string actual = pars.GetResult();
            Assert.That(actual, Is.EqualTo("18 / 0 = null"));
        }

        [Test]
        public void SetAStringTest()
        {

            ParsingWebClass pars = new ParsingWebClass(Driver);
            pars.SetA("a");
            pars.SetB("2");
            string actual = pars.GetResult();
            Assert.That(actual, Is.EqualTo("null + 2 = null"));
        }

        [Test]
        public void SetBStringTest()
        {

            ParsingWebClass pars = new ParsingWebClass(Driver);
            pars.SetA("1");
            pars.SetB("d");
            string actual = pars.GetResult();
            Assert.That(actual, Is.EqualTo("1 + null = null"));
        }

        [Test]
        public void SetBothStringTest()
        {

            ParsingWebClass pars = new ParsingWebClass(Driver);
            pars.SetA("abc");
            pars.SetB("bca");
            string actual = pars.GetResult();
            Assert.That(actual, Is.EqualTo("null + null = null"));
        }

        [TestCase("0", "")]
        [TestCase("", "")]
        [TestCase("", "0")]
        public void SetEmptyString(string a, string b)
        {
            ParsingWebClass pars = new ParsingWebClass(Driver);
            pars.SetA(a);
            pars.SetB(b);
            string actual = pars.GetResult();
            Assert.That(actual, Is.EqualTo("0 + 0 = 0"));
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}