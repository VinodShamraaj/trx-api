namespace TransactionAPI.Validation;

using System.ComponentModel.DataAnnotations;
using TransactionAPI.Models;

public class ItemsAttribute : ValidationAttribute
{
    public string GetInvalidQuantityError() =>
        "Invalid Item Quantity.";

    public string GetInvalidItemPriceError() =>
        "Invalid Item Price.";

    public string GetRequiredFieldError(string field) =>
        $"{field} cannot be null or empty";

    public string GetStringLengthError(string field, int length) =>
        $"{field} length can't be more than {length}";



    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        TransactionRequestDto transactionRequest = (TransactionRequestDto)validationContext.ObjectInstance;

        if (transactionRequest.items != null)
        {
            foreach (ItemDto item in transactionRequest.items)
            {
                // PartnerItemRef Validation
                if (string.IsNullOrEmpty(item.partneritemref))
                {
                    return new ValidationResult(GetRequiredFieldError("items.partneritemref"));
                }

                if (item.partneritemref.Length > 50)
                {
                    return new ValidationResult(GetStringLengthError("items.partneritemref", 50));
                }

                // Item Name Validation
                if (string.IsNullOrEmpty(item.name))
                {
                    return new ValidationResult(GetRequiredFieldError("items.name"));
                }

                if (item.name.Length > 100)
                {
                    return new ValidationResult(GetStringLengthError("item.name", 100));
                }

                // Item Qty Validation
                if (item.qty != null)
                {
                    if (item.qty < 1 || item.qty > 5)
                    {
                        return new ValidationResult(GetInvalidQuantityError());
                    }
                }

                // Item Price Validation
                if (item.unitprice != null)
                {
                    if (item.unitprice < 0)
                    {
                        return new ValidationResult(GetInvalidItemPriceError());
                    }
                }
            }
        }

        return ValidationResult.Success;
    }
}