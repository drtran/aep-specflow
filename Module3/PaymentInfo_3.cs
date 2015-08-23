using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Module3
{
    public class PaymentInfo_3
    {
        public string paymentType { get; set; }
        public string orderName { get; set; }
        public string orderAddress { get; set; }
        public string orderEmail { get; set; }

        public List<PaymentInfo_3> Transform(Table table)
        {
            List<PaymentInfo_3> paymentInfos = new List<PaymentInfo_3>();
            foreach (TableRow row in table.Rows)
            {
                PaymentInfo_3 paymentInfo = new PaymentInfo_3();
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
