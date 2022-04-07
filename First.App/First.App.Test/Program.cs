using First.App.Core.Extensions;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace First.App.Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string bootcamp = "İkinci Hafta";
            string nullValue = null;
            string emptyValue = string.Empty;
            int number = 4;

            bool isGreaterThan = number.IsGreaterThan();
            var result = nullValue.NullCheck();

            var text = InvoiceType.Customer.GetDisplayName();
            var people = InvoiceType.People.GetDescription();

            var test = InvoiceType.Company.ToString();

            

            Console.WriteLine(test);
        }

        public enum InvoiceType
        {
            [Display(Name = "Müşteri")]
            Customer,
            [Description("Kişiler")]
            People,
            Company
        }
    }
}
