using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character
    /// words (lower case, no duplicates). Using sets, find an O(n)
    /// solution for returning all symmetric pairs of words.
    /// </summary>
    public static string[] FindPairs(string[] words)
    {
        var seen = new HashSet<string>();
        var pairs = new List<string>();

        foreach (var word in words)
        {
            char[] chars = word.ToCharArray();
            Array.Reverse(chars);
            string reversed = new string(chars);

            if (seen.Contains(reversed))
            {
                string pair = string.Compare(word, reversed) < 0 
                    ? $"{word} & {reversed}" 
                    : $"{reversed} & {word}";
                pairs.Add(pair);
            }
            else
            {
                seen.Add(word);
            }
        }

        return pairs.ToArray();
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file. The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that
    /// have earned that degree.
    /// </summary>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            string degree = fields[4];

            if (degrees.ContainsKey(degree))
                degrees[degree]++;
            else
                degrees[degree] = 1;
        }

        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        word1 = word1.ToLower().Replace(" ", "");
        word2 = word2.ToLower().Replace(" ", "");

        if (word1.Length != word2.Length)
            return false;

        var count1 = new Dictionary<char, int>();
        var count2 = new Dictionary<char, int>();

        foreach (var c in word1)
        {
            if (count1.ContainsKey(c))
                count1[c]++;
            else
                count1[c] = 1;
        }

        foreach (var c in word2)
        {
            if (count2.ContainsKey(c))
                count2[c]++;
            else
                count2[c] = 1;
        }

        return count1.Count == count2.Count && !count1.Except(count2).Any();
    }

    /// <summary>
    /// This function will read JSON data from the
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        var json = client.GetStringAsync(uri).Result;

        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        var result = new List<string>();

        foreach (var feature in featureCollection.Features)
        {
            string place = feature.Properties.Place;
            double mag = feature.Properties.Mag;
            result.Add($"{place} - Mag {mag}");
        }

        return result.ToArray();
    }
}