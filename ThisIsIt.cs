using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp2
{
    public class Program
    {
        static void Main()
        {
            var fvd1 = new Fvd
            {
                State = "ON",
                ModelCode = "abc",
                RpoCode = "123"
            };
            var fvd2 = new Fvd
            {
                State = "ON",
                ModelCode = "abc",
                RpoCode = "124"
            };
            var fvd3 = new Fvd
            {
                State = "ON",
                ModelCode = "abc",
                RpoCode = "125"
            };
            var fvd4 = new Fvd
            {
                State = "ON",
                ModelCode = "xyz",
                RpoCode = "126"
            };
            var fvd5 = new Fvd
            {
                State = "ON",
                ModelCode = "xyz",
                RpoCode = "127"
            };
            var fvd6 = new Fvd
            {
                State = "ON",
                ModelCode = "pbz",
                RpoCode = "128"
            };

            var all = new List<Fvd>
            {
                fvd1,
                fvd2,
                fvd3,
                fvd4,
                fvd5,
                fvd6
            };

            var incentives = new List<Incentive>();

            foreach (var fvd in all)
            {
                var duplicateIncentive = incentives.FirstOrDefault(x => x.ModelCode == fvd.ModelCode);

                if (duplicateIncentive == null)
                {
                    var incentive = new Incentive { ModelCode = fvd.ModelCode, State = fvd.State };

                    incentive.ProductRules.Add(new ProductRule { RpoCode = fvd.RpoCode });
                    incentives.Add(incentive);
                }
                else
                    duplicateIncentive.ProductRules.Add(new ProductRule { RpoCode = fvd.RpoCode });
            }

            Console.WriteLine(JsonConvert.SerializeObject(incentives));
        }
    }

    public class Fvd
    {
        public string State { get; set; }
        public string ModelCode { get; set; }
        public string RpoCode { get; set; }
    }

    public class Incentive
    {
        public int IncentiveId { get; set; }
        public string State { get; set; }
        public string ModelCode { get; set; }
        public IList<ProductRule> ProductRules { get; set; } = new List<ProductRule>();
    }

    public class ProductRule
    {
        public string RpoCode { get; set; }
    }
}
