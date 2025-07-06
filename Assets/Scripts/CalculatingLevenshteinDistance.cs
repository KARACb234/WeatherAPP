using System;
using System.Text.RegularExpressions;

public static class CalculatingLevenshteinDistance
{
    public static int LevenshteinDistance(string cityName, string userInput)
    {
        string s = Regex.Replace(cityName, @"[^a-z0-9а-яё\s]", string.Empty, RegexOptions.IgnoreCase);
        string t = Regex.Replace(userInput, @"[^a-z0-9а-яё\s]", string.Empty, RegexOptions.IgnoreCase);
        int n = s.Length;
        int m = t.Length;
        int[,] d = new int[n + 1, m + 1];

        for (int i = 0; i <= n; i++)
            d[i, 0] = i;
        for (int j = 0; j <= m; j++)
            d[0, j] = j;

        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= m; j++)
            {
                int cost = (s[i - 1] == t[j - 1]) ? 0 : 1;
                d[i, j] = Math.Min(
                    Math.Min(d[i - 1, j] + 1,      // удаление
                             d[i, j - 1] + 1),     // вставка
                    d[i - 1, j - 1] + cost);       // замена
            }
        }
        return d[n, m];
    }
}
