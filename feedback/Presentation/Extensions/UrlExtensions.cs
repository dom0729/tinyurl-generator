public static class UrlExtensions
{
    public const string DefaultDomain = "https://feedback.ly/";
    public static string? RemoveDefaultDomain(this string? url)
    {
        if (url?.StartsWith(DefaultDomain) ?? false)
        {
            return url.Substring(DefaultDomain.Length);
        }
        return url; // Return the original URL if it doesn't start with DefaultDomain
    }
    public static string? AddDefaultDomain(this string? url)
    {
        if (url?.StartsWith(DefaultDomain) ?? false)
        {
            return url;
        }
        return DefaultDomain + url;
    }
}