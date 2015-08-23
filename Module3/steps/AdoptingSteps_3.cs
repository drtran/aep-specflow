using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;

namespace Module3
{
    class AdoptingSteps_3
    {
        private IWebDriver driver;
        private String homePageUrl;
        private HomePage_3 homePage;
        private PaymentPage_3 paymentPage_3;

        public AdoptingSteps_3(IWebDriver driver) {
            this.driver = driver;
            homePage = new HomePage_3(driver);
            paymentPage_3 = new PaymentPage_3(driver);
        }

        public void visit_the_adoption_puppies_page(String homePageUrl)
        {
            this.homePageUrl = homePageUrl;
            homePage.visit(homePageUrl);
            Assert.AreEqual("Sally's Puppy Adoption Agency", homePage.Title);
        }

        public void adopt_a_pet(String petName, Boolean lastAdoptingPet) 
        {
            homePage.select_a_pet(petName, lastAdoptingPet);
        }

        public void pay_for_the_adoption(PaymentInfo_3 paymentInfo)
        {
            paymentPage_3.pay(paymentInfo);
        }

        public void verify_successful_adoption(String thankyouMsg)
        {
            Assert.AreEqual(thankyouMsg, homePage.getNotice());
        }
    }
}
