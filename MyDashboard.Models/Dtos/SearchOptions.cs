public class SearchOptions
{
    public string FirstName { get; set; } = "";
    public Gender Gender { get; set; }
}

/*
: IParsable<SearchOptions>
{
    public string? FirstName { get; set; }
    public Gender Gender { get; set; }

    public static SearchOptions Parse(string s, IFormatProvider? provider)
        => TryParse(s, provider, out var result) ? result : throw new FormatException();

    public static bool TryParse(string? s, IFormatProvider? provider, out SearchOptions result)
    {
        result = new SearchOptions();
        if (string.IsNullOrEmpty(s))
            return true;

        // Example: s = "FirstName=John&Gender=1"
        var pairs = s.Split('&', StringSplitOptions.RemoveEmptyEntries);
        foreach (var pair in pairs)
        {
            var kv = pair.Split('=', 2);
            if (kv.Length != 2) continue;
            var key = kv[0];
            var value = kv[1];

            if (key.Equals(nameof(FirstName), StringComparison.OrdinalIgnoreCase))
                result.FirstName = Uri.UnescapeDataString(value);
            else if (key.Equals(nameof(Gender), StringComparison.OrdinalIgnoreCase) && int.TryParse(value, out var g))
                result.Gender = (Gender)g;
        }
        return true;
    }
}

*/