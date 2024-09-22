namespace TransactionAPI.Models;

using System.ComponentModel.DataAnnotations;
using TransactionAPI.Validation;
using TimestampAttribute = TransactionAPI.Validation.TimestampAttribute;

public class TransactionRequestDto
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "partnerkey is a required field")]
    [StringLength(50, ErrorMessage = "partnerkey length can't be more than 50.")]
    [PartnerKey]
    public string? partnerkey { get; set; }


    [Required(AllowEmptyStrings = false, ErrorMessage = "partnerrefno is a required field")]
    [StringLength(50, ErrorMessage = "partnerrefno length can't be more than 50.")]
    public string? partnerrefno { get; set; }


    [Required(AllowEmptyStrings = false, ErrorMessage = "partnerpassword is a required field")]
    [StringLength(50, ErrorMessage = "partnerpassword length can't be more than 50.")]
    public string? partnerpassword { get; set; }

    [Required(ErrorMessage = "totalamount is a required field")]
    [TotalAmount]
    public long? totalamount { get; set; }

    [Items]
    public List<ItemDto>? items { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "timestamp is a required field")]
    [Timestamp]
    public string? timestamp { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "sig is a required field")]
    [MessageSignature]
    public string? sig { get; set; }

    public object GetObject()
    {
        return new { partnerkey, partnerrefno, partnerpassword, totalamount, items, timestamp, sig };
    }
}



public class TransactionSuccessResponseDto
{
    public int result { get; set; }
    public long totalamount { get; set; }
    public long totaldiscount { get; set; }
    public long finalamount { get; set; }

    public TransactionSuccessResponseDto(int _result, long _totalamount, long _totaldiscount, long _finalamount)
    {
        result = _result;
        totalamount = _totalamount;
        totaldiscount = _totaldiscount;
        finalamount = _finalamount;
    }

    public object GetObject()
    {
        return new { result, totalamount, totaldiscount, finalamount };
    }
}

public class TransactionFailedResponseDto
{
    public int result;
    public string resultmessage;

    public TransactionFailedResponseDto(int _result, string _resultmessage)
    {
        result = _result;
        resultmessage = _resultmessage;
    }

    public object GetObject()
    {
        return new { result, resultmessage };
    }
}