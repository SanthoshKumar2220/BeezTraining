using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoopDuty
{
    class Program
    {
        static void Main(string[] args)
        {
            String filename = @"C:\Schiphol\NewOne.csv";
            String tests = ",";
            String Producturl = null;
            String Product = null;
            String Quantity = null;
            //String tests = ",";
            String price = null;
            //div[@class='b-product__product-name g-text-center']
            //div[@class='b-product__product-name g-text-center']/a
            //div[@class='b-price__sales-price']
            using (StreamWriter write = System.IO.File.CreateText(filename))
            {
                write.WriteLine($"ProductURL{tests}ProductName{tests}Quantity{tests}Price{tests}");
              

                IWebDriver driver = new ChromeDriver();
                driver.Navigate().GoToUrl("https://www.theloopdutyfree.co.nz/spirits-and-wine/");
                driver.Manage().Window.Maximize();
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

                for (int i = 0; i <= 7; i++)

                {
                    
                    IList<IWebElement> product = driver.FindElements(By.XPath("//div[@class='b-product__product-name g-text-center']")).ToList();



                    IList<IWebElement> productUrl = driver.FindElements(By.XPath(" //div[@class='b-product__product-name g-text-center']/a")).ToList();


                    IList<IWebElement> prices = driver.FindElements(By.XPath(" //div[@class='b-price__sales-price']")).ToList();

                    List<string> quant = new List<string>();
                   
                        for (int j = 0; j < product.Count; j++)
                        {

                            Console.WriteLine(j + 1 + " Count");
                            IList<IWebElement> productUrl1 = driver.FindElements(By.XPath(" //div[@class='b-product__product-name g-text-center']/a")).ToList();
                            Producturl = productUrl1[j].GetAttribute("href");
                            Console.WriteLine(Producturl);

                            IList<IWebElement> product1 = driver.FindElements(By.XPath("//div[@class='b-product__product-name g-text-center']")).ToList();
                            Product = product1[j].Text.Replace(",", "").Replace("\r\n", " "); 
                            Console.WriteLine(Product);

                            IList<IWebElement> prices1 = driver.FindElements(By.XPath(" //div[@class='b-price__sales-price']")).ToList();

                            price = prices1[j].Text.Replace(",","").Replace("NZ$", "");
                        //Convert.ToDouble(price);
                        Console.WriteLine(price);

                            quant.Add(Product);

                            String[] quantity = Product.Split(new String[] { }, StringSplitOptions.None);
                            for (int l = 0; l < quantity.Count(); l++)
                            {
                                String quan = quantity[l];
                                bool containsInt = quan.Any(char.IsDigit);
                                //bool endWithl = Regex.IsMatch(quantity[l], "^%d|L$|CL$|ML$|l$|cl$|ml$|Ml$|Cl$|mL$|ML$|g$");
                                if (containsInt == true)
                                {
                                    if (quan.Contains("cL") || quan.Contains("CL") || quan.Contains("L") || quan.Contains("cl") || quan.Contains("ml") || quan.Contains("ltr"))
                                    {
                                        Quantity = quan;
                                        Console.WriteLine(quan);
                                    }
                                    else
                                    {
                                        quan = null;
                                        Console.WriteLine(quan);
                                    }
                                }

                            }

                        write.WriteLine($"{Producturl}{tests}{ Product}{tests}{Quantity}{tests}{price}{tests}");
                    }

                    if (i < 7)
                    {

                        IWebElement next = driver.FindElement(By.XPath("//a[@class='b-pagination__page-link-next']"));
                        js.ExecuteScript("arguments[0].click();", next);
                    }
                  //  write.WriteLine($"{Producturl}{tests}{ Product}{tests}{Quantity}{tests}{price}{tests}");
                }
                
            }
        }
    }

}
