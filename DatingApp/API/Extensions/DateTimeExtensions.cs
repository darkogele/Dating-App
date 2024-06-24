namespace API.Extensions;

public static class DateTimeExtensions
{
    public static int CalculateAge(this DateOnly dob)
    {
        var today = DateOnly.FromDateTime(DateTime.UtcNow);
        var age = today.Year - dob.Year;

        // If the user hasn't had their birthday yet this year, subtract one year from their age calculation
        if (dob > today.AddYears(-age)) age--;

        return age;
    }
}