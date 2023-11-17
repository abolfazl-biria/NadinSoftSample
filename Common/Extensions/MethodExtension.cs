namespace Common.Extensions;

public static class MethodExtension
{

    public static int ToInt(this object? s)
    {
        var data = s?.ToString();
        if (string.IsNullOrWhiteSpace(data))
            return 0;

        var valid = int.TryParse(data.RemoveComma(), out var result);

        return valid ? result : 0;
    }

    public static int? ToIntNull(this object? s)
    {
        var data = s?.ToString();
        if (string.IsNullOrWhiteSpace(data))
            return null;

        var valid = int.TryParse(data.RemoveComma(), out var result);
        return valid ? result : null;
    }

    public static long ToLong(this object? s)
    {
        var data = s?.ToString();
        if (string.IsNullOrWhiteSpace(data))
            return 0;

        var valid = long.TryParse(data.RemoveComma(), out var result);
        return valid ? result : 0;
    }

    public static long? ToLongNull(this object? s)
    {
        var data = s?.ToString();
        if (string.IsNullOrWhiteSpace(data))
            return null;

        var valid = long.TryParse(data.RemoveComma(), out var result);
        return valid ? result : null;
    }

    public static byte ToByte(this object? s)
    {
        var data = s?.ToString();
        if (string.IsNullOrWhiteSpace(data))
            return 0;

        var valid = byte.TryParse(data.RemoveComma(), out var result);
        return valid ? result : (byte)0;
    }

    public static byte? ToByteNull(this object? s)
    {
        var data = s?.ToString();
        if (string.IsNullOrWhiteSpace(data))
            return null;

        var valid = byte.TryParse(data.RemoveComma(), out var result);
        return valid ? result : null;
    }

    public static decimal ToDecimal(this object? s)
    {
        var data = s?.ToString();
        if (string.IsNullOrWhiteSpace(data))
            return 0;

        var valid = decimal.TryParse(data.RemoveComma(), out var result);
        return valid ? result : 0;
    }

    public static decimal? ToDecimalNull(this object? s)
    {
        var data = s?.ToString();
        if (string.IsNullOrWhiteSpace(data))
            return null;

        var valid = decimal.TryParse(data.RemoveComma(), out var result);
        return valid ? result : null;
    }

    public static double ToDouble(this object? s)
    {
        var data = s?.ToString();

        if (string.IsNullOrWhiteSpace(data))
            return 0;

        var valid = double.TryParse(data.RemoveComma(), out var result);
        return valid ? result : 0;
    }

    public static double? ToDoubleNull(this object? s)
    {
        var data = s?.ToString();
        if (string.IsNullOrWhiteSpace(data))
            return null;

        var valid = double.TryParse(data.RemoveComma(), out var result);
        return valid ? result : null;
    }

    public static bool ToBool(this object? s)
    {
        var data = s?.ToString();
        if (string.IsNullOrWhiteSpace(data))
            return false;

        var valid = bool.TryParse(data, out var result);
        return valid && result;
    }

    public static bool? ToBoolNull(this object? s)
    {
        var data = s?.ToString();
        if (string.IsNullOrWhiteSpace(data))
            return null;

        var valid = bool.TryParse(data, out var result);
        return valid ? result : null;
    }

    public static string? RemoveComma(this string? s)
    {
        if (string.IsNullOrWhiteSpace(s))
            return s;

        return s
            .Replace(",", "")
            .Replace("-", "");
    }
}