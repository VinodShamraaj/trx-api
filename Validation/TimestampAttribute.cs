namespace TransactionAPI.Validation;

using System.ComponentModel.DataAnnotations;
using System.Globalization;
using TransactionAPI.Models;

public class TimestampAttribute : ValidationAttribute
{
    public string GetErrorMessage() =>
        "Expired.";

    public string GetInvalidErrorMessage() =>
    "Invalid Timestamp.";

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        TransactionRequestDto transactionRequest = (TransactionRequestDto)validationContext.ObjectInstance;
        DateTime serverTime = DateTime.Now;
        DateTime startDate = serverTime.AddMinutes(-5);
        DateTime endDate = serverTime.AddMinutes(5);

        DateTime transactionTime;

        if (DateTime.TryParse(transactionRequest.timestamp ?? "", null, DateTimeStyles.RoundtripKind, out transactionTime))
        {
            if (transactionTime <= startDate || transactionTime >= endDate)
            {
                return new ValidationResult(GetErrorMessage());
            }
        }
        else
        {
            return new ValidationResult(GetInvalidErrorMessage());
        }

        return ValidationResult.Success;
    }
}