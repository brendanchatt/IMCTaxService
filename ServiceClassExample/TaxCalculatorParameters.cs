using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceClassExample
{
    public enum TaxCalculator
    {
        TaxJar, OtherTaxCalculator
    }

    public static class TaxCalculatorConstants
    {
        public static Dictionary<string, Dictionary<TaxCalculator, string>> Parameters = new Dictionary<string, Dictionary<TaxCalculator, string>>
        {
           { 
                "OrderAmount", 
                new Dictionary<TaxCalculator,string>
                { 
                    { TaxCalculator.TaxJar, "amount" }, 
                    { TaxCalculator.OtherTaxCalculator, "order_amount" } 
                } 
           },
           {
                "OrderShipping",
                new Dictionary<TaxCalculator, string>
                {
                    { TaxCalculator.TaxJar, "shipping" },
                    { TaxCalculator.OtherTaxCalculator, "shipping_amount" }
                }
           },
           {
                "CustomerCountry",
                new Dictionary<TaxCalculator, string>
                {
                    { TaxCalculator.TaxJar, "to_country" },
                    { TaxCalculator.OtherTaxCalculator, "destination_country" }
                }
           },
           {
                "CustomerZip",
                new Dictionary<TaxCalculator, string>
                {
                    { TaxCalculator.TaxJar, "to_zip" },
                    { TaxCalculator.OtherTaxCalculator, "destination_zip" }
                }
           },
           {
                "CustomerState",
                new Dictionary<TaxCalculator, string>
                {
                    { TaxCalculator.TaxJar, "to_zip" },
                    { TaxCalculator.OtherTaxCalculator, "destination_zip" }
                }
           },
        };
    }
}
