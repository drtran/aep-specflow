using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3
{
    class HomePage_3
    {
        [FindsBy(How = How.XPath, Using = "//div[@class='name']")]
        private ReadOnlyCollection<IWebElement> petNameElmts;

        [FindsBy(How = How.XPath, Using = "//input[@value='View Details']")]
        private ReadOnlyCollection<IWebElement> viewDetailsButtons;

	    [FindsBy (How = How.XPath, Using = "//p[@id='notice']")]
	    private IWebElement noticeElmt;

        private IWebDriver driver;
        
        public HomePage_3(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void visit(String homePageUrl)
        {
            driver.Navigate().GoToUrl(homePageUrl);
            Title = driver.Title;
        }

        public void select_a_pet(String petName, Boolean lastAdoptingPet)
        {
            int index = 0;
            for (int j = 0; j < petNameElmts.Count; j++)
            {
                if (petNameElmts[j].Text == petName)
                {
                    Console.WriteLine("FOUND: " + petName);
                    viewDetailsButtons[j].Click();
                    IWebElement adoptMeButton = driver.FindElement(By.XPath("//input[@value='Adopt Me!']"));
                    adoptMeButton.Click();
                    if (lastAdoptingPet)
                    {
                        IWebElement completeTheAdoptionButton = driver.FindElement(By.XPath("//input[@value='Complete the Adoption']"));
                        completeTheAdoptionButton.Click();
                    }
                    else
                    {
                        IWebElement adoptAnotherButton = driver.FindElement(By.XPath("//input[@value='Adopt Another Puppy']"));
                        adoptAnotherButton.Click();
                    }
                    break;
                }
                index++;
            }
        }

        public String Title { get; private set;  }

        public String getNotice()
        {
            return noticeElmt.Text;
        }
    }
}
