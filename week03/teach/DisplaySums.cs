public static class DisplaySums {
    public static void Run() {
        DisplaySumPairs([1, 2, 3, 4, 5, 6, 7, 8, 9, 10]);
        Console.WriteLine("------------");
        DisplaySumPairs([-20, -15, -10, -5, 0, 5, 10, 15, 20]);
        Console.WriteLine("------------");
        DisplaySumPairs([5, 11, 2, -4, 6, 8, -1]);
    }

    private static void DisplaySumPairs(int[] numbers) {
        var seen = new HashSet<int>();

        foreach (var n in numbers)
        {
            int complement = 10 - n;

            if (seen.Contains(complement))
            {
                Console.WriteLine($"{complement} {n}");
            }

            seen.Add(n);
        }
    }
}