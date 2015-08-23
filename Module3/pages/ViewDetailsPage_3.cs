using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3
{
 
    class ViewDetailsPage_3
    {
        [FindsBy (How = How.XPath, Using = "//*[@id='content']/div[2]/img")]
	    private IWebElement imageElmt;
	
	    [FindsBy (How = How.XPath, Using = "//input[@value='Adopt Me!']")]
	    private IWebElement adoptMeButtonElmt;
        private IWebDriver driver;
        
        public ViewDetailsPage_3()
        {
            this.driver = new FirefoxDriver();
            PageFactory.InitElements(driver, this);
        }
        public String getPetImageName()
        {
            return imageElmt.GetAttribute("src");
        }

        public void adopt_the_pet()
        {
            adoptMeButtonElmt.Click();
        }
    }
}
