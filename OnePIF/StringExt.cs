using System;

static internal class StringExt
{
    public static string FixNewLines(string str)
    {
        if (string.IsNullOrEmpty(str))
            return str;

        return str.Replace("\r\n", Environment.NewLine).Replace("\r", Environment.NewLine).Replace("\n", Environment.NewLine);
    }
}