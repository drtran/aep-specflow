using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;

namespace Module2
{
    class AdoptingSteps
    {
        private IWebDriver driver;
        private String homePage;

        public AdoptingSteps(IWebDriver driver) {
            this.driver = driver;
        }

        public void visit_the_adoption_puppies_page(String url)
        {
            driver.Navigate().GoToUrl(url);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            homePage = driver.Url;
            Assert.AreEqual("Sally's Puppy Adoption Agency", driver.Title);
        }

        public void adopt_a_pet(String petName, Boolean lastAdoptingPet) 
        {
            ReadOnlyCollection<IWebElement> nameLabels = driver.FindElements(By.ClassName("name"));
            ReadOnlyCollection<IWebElement> viewDetailsButtons = driver.FindElements(By.XPath("//input[@value='View Details']"));

            for (int j = 0; j < nameLabels.Count; j++)
            {
                if (nameLabels[j].Text == petName)
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
            }
        }

        public void pay_for_the_adoption(PaymentInfo_2 paymentInfo)
        {
            IWebElement orderNameField = driver.FindElement(By.Id("order_name"));
            IWebElement orderAddressField = driver.FindElement(By.Id("order_address"));
            IWebElement orderEmailField = driver.FindElement(By.Id("order_email"));
            IWebElement orderPayTypeElement = driver.FindElement(By.Id("order_pay_type"));
            IWebElement placeOrderButton = driver.FindElement(By.XPath("//input[@value='Place Order']"));
            orderNameField.SendKeys(paymentInfo.orderName);
            orderAddressField.SendKeys(paymentInfo.orderAddress);
            orderEmailField.SendKeys(paymentInfo.orderEmail);
            SelectElement select = new SelectElement(orderPayTypeElement);
            foreach (IWebElement option in select.Options)
            {
                if (option.Text == paymentInfo.paymentType)
                {
                    option.Click();
                    break;
                }
            }
            placeOrderButton.Click();
        }

        public void verify_successful_adoption(String thankyouMsg)
        {
            IWebElement noticeLabel = driver.FindElement(By.Id("notice"));
            Assert.AreEqual(thankyouMsg, noticeLabel.Text);
        }
    }
}
