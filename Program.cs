using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Schiphol
{
    class Program
    {
        static void Main(string[] args)
        {
            String filename = @"C:\Schiphol\NewOne.csv";
            String tests = ",";
            String Producturl = null;
            String Product = null;
            String price1 = null;
            String from = null;
            String DisCount = null;
            String Current = null;
            String Quantity = null;
            String pricee = null;

            using (StreamWriter write = System.IO.File.CreateText(filename))
            {
                write.WriteLine($"PageURL{tests}ProductName{tests}Quantity{tests}Price{tests}Discount{tests}CurrentPrice{tests}");


                IWebDriver driver = new ChromeDriver();
                driver.Navigate().GoToUrl("https://www.schiphol.nl/en/at-schiphol/shop");
                driver.Manage().Window.Maximize();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);

                //
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                IWebElement view = driver.FindElement(By.Id("what-tickles-your-fancy?"));
                js.ExecuteScript("arguments[0].scrollIntoView();", view);

                IWebElement Nex = driver.FindElement(By.XPath("(//button[@class='carousel__button'])[2]"));
                js.ExecuteScript("arguments[0].click();", Nex);

                IWebElement arrow = driver.FindElement(By.XPath("(//a[@class='card__link'])[6]"));
                js.ExecuteScript("arguments[0].click();", arrow);

                //IList<IWebElement> Product1 = driver.FindElements(By.XPath("//span[@class='card__title-text']")).ToList();

                //IList<IWebElement> price1 = driver.FindElements(By.XPath("//p[@class='price-container']")).ToList();

                //String[] producttext = new String[product.Count];
                //    String[] pricetext = new String[prices.Count];




                for (int i = 0; i <= 1; i++)

                {
                    Thread.Sleep(3000);
                    IWebElement drink = driver.FindElement(By.XPath("(//span[@class='categories__target-text'])[2]"));
                    js.ExecuteScript("arguments[0].click();", drink);


                    IList<IWebElement> productUrl = driver.FindElements(By.XPath("//div[@class='card__body']/p[@class='card__title']/a")).ToList();

                    IList<IWebElement> product = driver.FindElements(By.XPath("//span[@class='card__title-text']")).ToList();

                    IList<IWebElement> prices = driver.FindElements(By.XPath("//p[@class='price-container']")).ToList();
                    IWebElement next = driver.FindElement(By.XPath("//a[text()='2']"));
                    js.ExecuteScript("arguments[0].click();", next);



                    List<string> quant = new List<string>();
                    for (int j = 0; j < product.Count; j++)
                    {
                        Console.WriteLine(j + 1);
                        IList<IWebElement> productUrl1 = driver.FindElements(By.XPath("//div[@class='card__body']/p[@class='card__title']/a")).ToList();
                        Producturl = productUrl1[j].GetAttribute("href");
                        WebDriverWait three = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                        three.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
                        Console.WriteLine(Producturl);



                        IList<IWebElement> product2 = driver.FindElements(By.XPath("//span[@class='card__title-text']")).ToList();
                        Product = product2[j].Text.Replace(",", "");
                        WebDriverWait one = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                        one.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
                        // Console.WriteLine(Product);


                        IList<IWebElement> prices12 = driver.FindElements(By.XPath("//p[@class='price-container']")).ToList();
                        price1 = prices12[j].Text;
                        WebDriverWait two = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                        two.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
                        //   Console.WriteLine(price);

                        quant.Add(Product);




                        String[] quantity = Product.Split(new String[] { }, StringSplitOptions.None);
                        for (int l = 0; l < quantity.Count(); l++)
                        {
                            String quan = quantity[l];
                            bool containsInt = quan.Any(char.IsDigit);
                            //bool endWithl = Regex.IsMatch(quantity[l], "^%d|L$|CL$|ML$|l$|cl$|ml$|Ml$|Cl$|mL$|ML$|g$");
                            if (containsInt == true)
                            {
                                if (quan.Contains("cL") || quan.Contains("CL") || quan.Contains("L") || quan.Contains("cl") || quan.Contains("g"))
                                {
                                    Quantity = quan;
                                    Console.WriteLine(quan);
                                }
                            }

                        }
                        //€
                        IList<IWebElement> pricess1 = driver.FindElements(By.XPath("//p[@class='price-container']")).ToList();
                        String pricevalue = pricess1[j].Text;
                        WebDriverWait four = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                        four.IgnoreExceptionTypes(typeof(StaleElementReferenceException));

                        String[] prices3 = pricevalue.Split(new String[] { }, StringSplitOptions.None);
                        from = prices3[0].Replace("Price", "");
                        from= prices3[0].Replace("from:", "");
                        Current = prices3[1].Replace("Current price:", "");
                        DisCount = prices3[2].Replace("Discount:", "");
                        Console.WriteLine(Current);


                        Console.WriteLine(DisCount);
                        Console.WriteLine(from);
                        

                        write.WriteLine($"{Producturl}{tests}{ Product}{tests} {Quantity}{tests}{pricee}{tests}{Current}{tests}{DisCount}{tests}{from}");


                    }



                }
            }
        }
    }
}
