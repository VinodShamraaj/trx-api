namespace TransactionAPI.Validation;

using System.ComponentModel.DataAnnotations;
using TransactionAPI.Constants;
using TransactionAPI.Helpers;
using TransactionAPI.Models;

public class PartnerKeyAttribute : ValidationAttribute
{

    public string GetErrorMessage() =>
        "Access Denied!";

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        TransactionRequestDto transactionRequest = (TransactionRequestDto)validationContext.ObjectInstance;
        bool isPartnerDetailsValid = false;

        // Loop through all partners in the system
        foreach (PartnerStruct partner in PartnersConfig.partners)
        {
            // Ignore if PartnerKey doesn't match
            if (partner.allowedPartner != transactionRequest.partnerkey)
            {
                continue;
            }

            // Ignore if PartnerRefNo doesn't match
            if (partner.partnerNo != transactionRequest.partnerrefno)
            {
                continue;
            }

            // Ignore if PartnerPassword doesn't exist
            if (transactionRequest.partnerpassword == null)
            {
                continue;
            }

            // Decode Base64 Password
            string encodedPassword = StringHelpers.StringToBase64(partner.partnerPassword);

            // Check if password matches
            if (transactionRequest.partnerpassword == encodedPassword)
            {
                isPartnerDetailsValid = true;
            }
        }

        if (!isPartnerDetailsValid)
        {
            return new ValidationResult(GetErrorMessage());
        }

        return ValidationResult.Success;
    }
}