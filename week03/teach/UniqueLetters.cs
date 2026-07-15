public static class UniqueLetters {
    public static void Run() {
        var test1 = "abcdefghjiklmnopqrstuvwxyz"; // Expect True because all letters unique
        Console.WriteLine(AreUniqueLetters(test1));
        var test2 = "abcdefghjiklanopqrstuvwxyz"; // Expect False because 'a' is repeated
        Console.WriteLine(AreUniqueLetters(test2));
        var test3 = "";
        Console.WriteLine(AreUniqueLetters(test3)); // Expect True because its an empty string
    }

    private static bool AreUniqueLetters(string text) {
        var seen = new HashSet<char>();

        foreach (var letter in text)
        {
            if (seen.Contains(letter))
                return false;

            seen.Add(letter);
        }

        return true;
    }
}