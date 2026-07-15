public class Translator
{
    public static void Run()
    {
        var englishToGerman = new Translator();
        englishToGerman.AddWord("House", "Haus");
        englishToGerman.AddWord("Car", "Auto");
        englishToGerman.AddWord("Plane", "Flugzeug");

        Console.WriteLine(englishToGerman.Translate("Car"));     // Auto
        Console.WriteLine(englishToGerman.Translate("Plane"));   // Flugzeug
        Console.WriteLine(englishToGerman.Translate("Train"));   // ???
    }

    private Dictionary<string, string> _words = new();

    /// <summary>
    /// Add the translation from 'fromWord' to 'toWord'
    /// </summary>
    public void AddWord(string fromWord, string toWord)
    {
        // If the word already exists, this will overwrite it (as expected)
        _words[fromWord] = toWord;
    }

    /// <summary>
    /// Translates the from word into the word that this stores as the translation
    /// </summary>
    public string Translate(string fromWord)
    {
        // If the word exists in our dictionary, return the translation
        if (_words.ContainsKey(fromWord))
        {
            return _words[fromWord];
        }

        // Otherwise return "???"
        return "???";
    }
}