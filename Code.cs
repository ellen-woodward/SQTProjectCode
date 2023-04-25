namespace SQTCode
{
    public interface DiscountService
    {
        double GetDiscount();
    }

    public class InsuranceService
    {
        private readonly DiscountService discountService;

        public InsuranceService(DiscountService discountService)
        {
            this.discountService = discountService;
        }

        public double CalculatePremium(int age, string location)
        {
            double premium = 0.0;

            if (location == "rural")
            {
                if (age >= 18 && age < 30)
                    premium = 5.0;
                else if (age >= 31)
                    premium = 2.50;
            }
            else if (location == "urban")
            {
                if (age >= 18 && age <= 35)
                    premium = 6.0;
                else if (age >= 36)
                    premium = 5.0;
            }

            double discount = discountService.GetDiscount();
            if (age >= 50)
                premium *= discount;
            return premium;
        }
    }
}