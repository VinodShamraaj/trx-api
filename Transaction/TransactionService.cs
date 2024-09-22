namespace TransactionAPI.Transaction;

using TransactionAPI.Helpers;
using TransactionAPI.Models;

public static class TransactionService
{
    public static TransactionSuccessResponseDto HandleTransaction(TransactionRequestDto transactionRequest)
    {

        // Handle Discounts
        long totalAmount = transactionRequest.totalamount ?? 0;

        int discountPercentage = DiscountHelpers.CalculateDiscountPercentage(totalAmount);
        LogsHelper.InfoLog($"Discount Percentage Calculated: {discountPercentage} %", "TransactionService - HandleTransaction");

        long discountAmount = totalAmount * discountPercentage / 100;
        LogsHelper.InfoLog($"Discount Amount Calculated: RM {(double)discountAmount / 100}", "TransactionService - HandleTransaction");

        long finalAmount = totalAmount - discountAmount;
        LogsHelper.InfoLog($"Final Amount Calculated: RM {(double)finalAmount / 100}", "TransactionService - HandleTransaction");

        return new TransactionSuccessResponseDto(1, totalAmount, discountAmount, finalAmount);
    }
}