using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3.pages
{
    class AdoptingPetsPage_3
    {
        private IWebDriver driver;
        public AdoptingPetsPage_3(IWebDriver driver)
        {
            this.driver = driver;
        }
        [FindsBy(How = How.XPath, Using = "//input[@value='Complete the Adoption']")]
        private IEnumerable<IWebElement> itemPriceElmts;

        [FindsBy(How = How.ClassName, Using = "item_price")]
        private IWebElement completeTheAdoptionButtonElmt;

        public IEnumerable<String> getPrices()
        {
            List<String> itemPrices = new List<String>();
            foreach (IWebElement itemPriceElmt in itemPriceElmts) 
            {
                itemPrices.Add(itemPriceElmt.Text);
            }
            return itemPrices;
        }

        public void complete_the_adoption()
        {
            completeTheAdoptionButtonElmt.Click();
        }
    }
}
