using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Shiphol
{
    class Program
    {
        static void Main(string[] args)
        {
            
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.schiphol.nl/en/at-schiphol/shop");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            
            //
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            IWebElement view = driver.FindElement(By.Id("what-tickles-your-fancy?"));
            js.ExecuteScript("arguments[0].scrollIntoView();", view);

            IWebElement Nex = driver.FindElement(By.XPath("(//button[@class='carousel__button'])[2]"));
            js.ExecuteScript("arguments[0].click();", Nex);

            IWebElement arrow = driver.FindElement(By.XPath("(//a[@class='card__link'])[6]"));
            js.ExecuteScript("arguments[0].click();", arrow);




            Thread.Sleep(3000);
            IWebElement drink = driver.FindElement(By.XPath("(//span[@class='categories__target-text'])[2]"));
            js.ExecuteScript("arguments[0].click();", drink);


            IList<IWebElement> productUrl = driver.FindElements(By.XPath("//div[@class='card__body']/p[@class='card__title']/a"));



            IList<IWebElement> product = driver.FindElements(By.XPath("//span[@class='card__title-text']"));

            IList<IWebElement> prices = driver.FindElements(By.XPath("//p[@class='price-container']"));

             IList<IWebElement> Product1 = driver.FindElements(By.XPath("//span[@class='card__title-text']"));

            IList<IWebElement> price1 = driver.FindElements(By.XPath("//p[@class='price-container']"));

          











            String[] producttext = new String[product.Count];
            String[] pricetext = new String[prices.Count];
            // String[] discounts = new String[discount.Count];






            for (int i = 0; i < product.Count; i++)
            {

                Console.WriteLine(i + 1 + "------------------------Count--------------------------");
                WebDriverWait count = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                count.IgnoreExceptionTypes(typeof(StaleElementReferenceException));


                // IList<IWebElement> Name = product;
                
                IList<IWebElement> product1 = driver.FindElements(By.XPath("//span[@class='card__title-text']"));
                
                WebDriverWait products = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                products.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
                String str = product1[i].Text;
                String[] strr=str.Split();
                foreach (string word in strr)
                {
                    String quantity = string.Empty;
                    //bool firstNum = Regex.IsMatch(word, "^%d");
                    bool endWithl = Regex.IsMatch(word, "^%d|L$|CL$|ML$|l$|cl$|ml$|Ml$|Cl$|mL$|ML$|g$");
                        if (endWithl )
                        {
                            quantity = word;
                            Console.WriteLine(quantity);
                       
                        
                        }
                    Console.WriteLine(word);
                }

               


                // IList<IWebElement> data = prices;
              
                try
                {
                    IList<IWebElement> prices1 = driver.FindElements(By.XPath("//p[@class='price-container']"));
                    String edit = prices1[i].Text.Replace("Price from:", "").Replace("Current price:", "").Replace("Price:", "").Replace("Discount:", "");
                    String n =edit.Replace("\r\n€", "");
                    Console.WriteLine(n);
                    
                    WebDriverWait price12 = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                    price12.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
                }
                catch (Exception e)
                {
                    Console.WriteLine($" {e.Message}, {e.StackTrace}");
                }
                


            }
            IWebElement next = driver.FindElement(By.XPath("//a[text()='2']"));
            js.ExecuteScript("arguments[0].click();", next);

            for (int j = 0; j < Product1.Count; j++)
            {

                Console.WriteLine(j + 31 + "------------------------Count--------------------------");
                WebDriverWait count = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                count.IgnoreExceptionTypes(typeof(StaleElementReferenceException));


                // IList<IWebElement> Name = product;
                IList<IWebElement> product1 = driver.FindElements(By.XPath("//span[@class='card__title-text']"));

                Console.WriteLine("Product " + product1[j].Text);
                WebDriverWait products = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                products.IgnoreExceptionTypes(typeof(StaleElementReferenceException));


                // IList<IWebElement> data = prices;
                try
                {
                    IList<IWebElement> prices1 = driver.FindElements(By.XPath("//p[@class='price-container']"));
                    String edit = prices1[j].Text.Replace("Price from:", "").Replace("Current price:", "").Replace("Discount:", "").Replace("Price:", "");
                    String n = edit.Replace("\r\n€", "");
                    Console.WriteLine(n);
                    WebDriverWait price12 = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                    price12.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
                }
                catch(Exception e)
                {
                    Console.WriteLine($"{e.Message}{e.StackTrace}");
                }

                
              
            }


        }

        public static string volumeExtractor(String name)
        {

            string[] words = name.Split();
            string quantity = string.Empty;
            foreach (string word in words)
            {
                bool firstNum = Regex.IsMatch(word, "^%d");
                if (firstNum == true)
                {
                    bool endWithl = Regex.IsMatch(word, "L$|CL$|ML$|l$|cl$|ml$|Ml$|Cl$|mL$|ML$|g$");
                    if (endWithl)
                    {
                        quantity = word;
                        return quantity;
                    }
                }
            }
            return quantity;
        }




    }
}

