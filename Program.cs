using NUnit.Framework;
using Moq;

namespace SofwareProject
{
    public interface IDiscountService 
    {
        double GetDiscount();
    }

    public class InsuranceService
    {
        public readonly IDiscountService _discountService;

        public InsuranceService(IDiscountService discountService) 
        {
            _discountService = discountService;
        }

        public double CalcPremium(int age, string gameMode)
        {
            double premium;


            if (gameMode == "casual")
            {
                if ((age >= 18) && (age <= 30))
                {
                    premium = 5.0;
                }
                else if (age >= 31)
                {
                    premium = 2.50;
                }
                else
                {
                    premium = 0.0;
                }
            }
            else if (gameMode == "hardcore")
            {
                if ((age >= 18) && (age <= 35))
                {
                    premium = 6.0;
                }
                else if (age >= 36)
                {
                    premium = 5.0;
                }
                else
                {
                    premium = 0.0;
                }
            }
            else
            {
                premium = 0.0;
            }

            
            double discount = _discountService.GetDiscount();
            if (age >= 50)
            {
                premium = premium * discount;

            }
            return premium;
        }
    }
    public class DiscountService : IDiscountService
    {
        public double GetDiscount()
        {
            return 0.9; // 10% discount 
        }
    }
}
