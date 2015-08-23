using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace Module3
{
    class PaymentPage_3
    {
        private IWebDriver driver;
        public PaymentPage_3(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//*[@id='content']/div[2]/fieldset/legend")]
        private IWebElement paymentPageLabelElmt;

        [FindsBy(How = How.XPath, Using = "//input[@id='order_name']")]
        private IWebElement orderNameElmt;

        [FindsBy(How = How.XPath, Using = "//textarea[@id='order_address']")]
        private IWebElement orderAddressElmt;

        [FindsBy(How = How.XPath, Using = "//input[@id='order_email']")]
        private IWebElement orderEmailElmt;

        [FindsBy(How = How.XPath, Using = "//select[@id='order_pay_type']")]
        private IWebElement payTypeElmt;

        [FindsBy(How = How.XPath, Using = "//input[@name='commit']")]
        private IWebElement placeOrderButtonElmt;

        public Object getPageLabel()
        {
            return paymentPageLabelElmt.Text;
        }

        public void pay(PaymentInfo_3 paymentInfo) {
		orderNameElmt.SendKeys("William Shakespeare");
		orderAddressElmt.SendKeys("Stratford-upon-Avon, England");
		orderEmailElmt.SendKeys("william_shakespeare@england.com");
        SelectElement select = new SelectElement(payTypeElmt);
		IEnumerable<IWebElement> options = select.Options;
		foreach (IWebElement option in options) {
			if (option.Text.Equals("Check")) {
				option.Click();
				break;
			}
		}
		
		placeOrderButtonElmt.Click();
	}
    }
}
