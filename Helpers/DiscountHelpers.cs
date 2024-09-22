namespace TransactionAPI.Helpers;

public static class DiscountHelpers
{
    public static int CalculateDiscountPercentage(long totalAmount)
    {
        int discountPercentage = 0;

        /// DEVNOTE: Business Logic doesn't account for the cents between discount tiers

        // Base Discounts
        if (totalAmount >= 20000 && totalAmount <= 50000)
        {
            discountPercentage = 5;
        }

        if (totalAmount >= 50100 && totalAmount <= 80000)
        {
            discountPercentage = 7;
        }

        if (totalAmount >= 80100 && totalAmount <= 120000)
        {
            discountPercentage = 10;
        }

        if (totalAmount > 120000)
        {
            discountPercentage = 15;
        }

        // Conditional Discounts
        if (IsPrime(totalAmount) && totalAmount > 50000)
        {
            discountPercentage += 8;
        }

        if (totalAmount % 10 == 5 && totalAmount > 90000)
        {
            discountPercentage += 10;
        }

        // Checking if discount exceed the cap of 20%
        if (discountPercentage > 20)
        {
            return 20;
        }
        else
        {
            return discountPercentage;
        }
    }

    private static bool IsPrime(long number)
    {
        if (number <= 1) return false;
        if (number == 2) return true;
        if (number % 2 == 0) return false;

        var boundary = (int)Math.Floor(Math.Sqrt(number));

        for (int i = 3; i <= boundary; i += 2)
            if (number % i == 0)
                return false;

        return true;
    }
}