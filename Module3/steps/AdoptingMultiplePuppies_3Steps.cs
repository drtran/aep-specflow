using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using NUnit.Framework;
using System.Collections.Generic;

namespace Module3
{
    [Binding]
    public class AdoptingMultiplePuppies_3Steps
    {
        private AdoptingSteps_3 adoptingSteps;
        private IWebDriver driver;

        [Given(@"that I am at the website ""(.*)""")]
        public void GivenThatIAmAtTheWebsite(String url)
        {
            driver = new FirefoxDriver();
            adoptingSteps = new AdoptingSteps_3(driver);
            adoptingSteps.visit_the_adoption_puppies_page(url);
        }

        [When(@"I adopt for these pets,")]
        public void WhenIAdoptForThesePets(TechTalk.SpecFlow.Table petNames)
        {
            for (int i = 0; i < petNames.RowCount; i++)
            {
                var petName = petNames.Rows[i][0];
                Console.WriteLine("Adopting " + petName);
                adoptingSteps.adopt_a_pet(petName, petNames.RowCount == i + 1);
            }

        }

        [When(@"I pay for the adoption using this type of payment:")]
        public void WhenIPayForTheAdoptionUsingThisTypeOfPayment(Table table)
        {
            List<PaymentInfo_3> paymentInfos = new PaymentInfo_3().Transform(table);
            var paymentInfo = paymentInfos[0];

            adoptingSteps.pay_for_the_adoption(paymentInfo);
        }

        [Then(@"I should be back at the main page with a thank you note, ""(.*)""")]
        public void ThenIShouldBeBackAtTheMainPageWithAThankYouNote(string thankyouMsg)
        {
            adoptingSteps.verify_successful_adoption(thankyouMsg);
            driver.Dispose();
        }

    }
}
