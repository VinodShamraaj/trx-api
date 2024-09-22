namespace TransactionAPI.Helpers;

using System.Text;
using System.Security.Cryptography;

public static class StringHelpers
{
    public static string StringToBase64(string inputString)
    {
        if (inputString != null)
        {
            byte[] data = System.Text.Encoding.UTF8.GetBytes(inputString);
            return Convert.ToBase64String(data);
        }
        return "";
    }

    public static string StringToSHA256(string inputString)
    {
        using (SHA256 sha256Hash = SHA256.Create())
        {
            // ComputeHash - returns byte array
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(inputString));

            // Convert byte array to a string
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }
}