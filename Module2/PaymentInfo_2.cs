using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Module2
{
    public class PaymentInfo_2
    {
        public string paymentType { get; set; }
        public string orderName { get; set; }
        public string orderAddress { get; set; }
        public string orderEmail { get; set; }

        public List<PaymentInfo_2> Transform(Table table)
        {
            List<PaymentInfo_2> paymentInfos = new List<PaymentInfo_2>();
            foreach (TableRow row in table.Rows)
            {
                PaymentInfo_2 paymentInfo = new PaymentInfo_2();
                paymentInfo.paymentType = row["paymentType"];
                paymentInfo.orderName = row["orderName"];
                paymentInfo.orderAddress = row["orderAddress"];
                paymentInfo.orderEmail = row["orderEmail"];
                paymentInfos.Add(paymentInfo);
            }
            return paymentInfos;
        }
    }
}
