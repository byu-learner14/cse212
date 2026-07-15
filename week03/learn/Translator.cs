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
        _words[fromWord] = toWord;   // This will overwrite if the word already exists
    }

    /// <summary>
    /// Translates the from word into the word that this stores as the translation
    /// </summary>
    public string Translate(string fromWord)
    {
        if (_words.ContainsKey(fromWord))
        {
            return _words[fromWord];
        }

        return "???";   // No translation found
    }
}