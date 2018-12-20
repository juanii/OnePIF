using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

static internal class UriExt
{
    private static readonly Regex QUERY_STRING_FIELD = new Regex(@"[\?&](([^&=]+)=([^&=#]*))", RegexOptions.Compiled);

    public static Dictionary<string, string> GetParams(string queryString)
    {
        MatchCollection matches = QUERY_STRING_FIELD.Matches(queryString);
        Dictionary<string, string> keyValues = new Dictionary<string, string>(matches.Count);

        foreach (Match match in matches)
            keyValues.Add(Uri.UnescapeDataString(match.Groups[2].Value), Uri.UnescapeDataString(match.Groups[3].Value));

        return keyValues;
    }
}