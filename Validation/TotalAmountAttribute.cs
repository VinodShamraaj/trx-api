namespace TransactionAPI.Validation;

using System.ComponentModel.DataAnnotations;
using TransactionAPI.Models;

public class TotalAmountAttribute : ValidationAttribute
{
    public string GetErrorMessage() =>
        "Invalid Total Amount.";

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        TransactionRequestDto transactionRequest = (TransactionRequestDto)validationContext.ObjectInstance;

        if (transactionRequest.totalamount < 0)
        {
            return new ValidationResult(GetErrorMessage());
        }

        return ValidationResult.Success;
    }
}