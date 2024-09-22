namespace TransactionAPI.Transaction;

using System.ComponentModel.DataAnnotations;
using TransactionAPI.Helpers;
using TransactionAPI.Models;

public static class TransactionRouter
{

    public static void Map(WebApplication app)
    {
        app.MapPost("api/submittrxmessage", (TransactionRequestDto newTransaction) =>
        {
            LogsHelper.InfoLog($"Transaction Received: \n{newTransaction.GetObject()}", "TransactionRouter - api/submittrxmessage");
            // Perform Validation on Request Body
            List<ValidationResult> validationResults = new List<ValidationResult>();
            ValidationContext vc = new ValidationContext(newTransaction, null, null);

            bool isValidRequest = Validator.TryValidateObject(newTransaction, vc, validationResults, true);

            if (isValidRequest)
            {
                LogsHelper.InfoLog("Transaction Validated", "TransactionRouter - api/submittrxmessage");

                // Perform calculation and return success message
                TransactionSuccessResponseDto response = TransactionService.HandleTransaction(newTransaction);
                LogsHelper.InfoLog($"Transaction Success: \n{response.GetObject()}", "TransactionRouter - api/submittrxmessage");

                return Results.Ok(response.GetObject());
            }
            else
            {
                // Return error message
                ValidationResult vr = validationResults.First();
                string errorMessage = vr.ErrorMessage ?? "";

                TransactionFailedResponseDto response = new TransactionFailedResponseDto(0, errorMessage);
                LogsHelper.ErrorLog($"Transaction Failed: \n{response.GetObject()}", "TransactionRouter - api/submittrxmessage");

                return Results.BadRequest(response.GetObject());
            }
        });
    }
}