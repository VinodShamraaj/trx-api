namespace TransactionAPI.Validation;

using System.ComponentModel.DataAnnotations;
using System.Globalization;
using TransactionAPI.Models;
using TransactionAPI.Helpers;

public class MessageSignatureAttribute : ValidationAttribute
{
    public string GetErrorMessage() =>
        "Invalid Message Signature.";

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        TransactionRequestDto transactionRequest = (TransactionRequestDto)validationContext.ObjectInstance;

        DateTime transactionTime;

        if (DateTime.TryParse(transactionRequest.timestamp ?? "", null, DateTimeStyles.RoundtripKind, out transactionTime))
        {
            string timestampString = transactionTime.ToString("yyyyMMddHHmmss");

            string derivedSignature = timestampString + transactionRequest.partnerkey + transactionRequest.partnerrefno + transactionRequest.totalamount.ToString() + transactionRequest.partnerpassword;
            string hashedSignature = StringHelpers.StringToSHA256(derivedSignature);
            string encryptedSignature = StringHelpers.StringToBase64(hashedSignature);

            if (transactionRequest.sig != encryptedSignature)
            {
                return new ValidationResult(GetErrorMessage());
            }
        }

        return ValidationResult.Success;
    }
}