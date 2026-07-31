using System.Collections;

public static class Recursion
{
    /// <summary>
    /// #############
    /// # Problem 1 #
    /// #############
    /// Using recursion, find the sum of 1^2 + 2^2 + 3^2 + ... + n^2
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        // Base case
        if (n <= 0)
            return 0;

        // Recursive case: n² + SumSquares(n-1)
        return (n * n) + SumSquaresRecursive(n - 1);
    }

    /// <summary>
    /// #############
    /// # Problem 2 #
    /// #############
    /// Using recursion, insert permutations of length 'size'
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        // Base case: we have built a word of the desired length
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        // Try each remaining letter
        for (int i = 0; i < letters.Length; i++)
        {
            // Remove the chosen letter and recurse
            string remaining = letters.Remove(i, 1);
            PermutationsChoose(results, remaining, size, word + letters[i]);
        }
    }

    /// <summary>
    /// #############
    /// # Problem 3 #
    /// #############
    /// Count ways to climb stairs (with memoization)
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        // Create the dictionary on the first call
        if (remember == null)
            remember = new Dictionary<int, decimal>();

        // Base Cases
        if (s == 0)
            return 0;
        if (s == 1)
            return 1;
        if (s == 2)
            return 2;
        if (s == 3)
            return 4;

        // Check if we already solved this
        if (remember.ContainsKey(s))
            return remember[s];

        // Recursive case with memoization
        decimal ways = CountWaysToClimb(s - 1, remember) +
                       CountWaysToClimb(s - 2, remember) +
                       CountWaysToClimb(s - 3, remember);

        // Remember the result
        remember[s] = ways;
        return ways;
    }

    /// <summary>
    /// #############
    /// # Problem 4 #
    /// #############
    /// Generate all binary strings from a pattern with wildcards (*)
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    {
        // Base case: no more wildcards left
        int starIndex = pattern.IndexOf('*');
        if (starIndex == -1)
        {
            results.Add(pattern);
            return;
        }

        // Replace the first * with 0 and recurse
        string withZero = pattern[..starIndex] + "0" + pattern[(starIndex + 1)..];
        WildcardBinary(withZero, results);

        // Replace the first * with 1 and recurse
        string withOne = pattern[..starIndex] + "1" + pattern[(starIndex + 1)..];
        WildcardBinary(withOne, results);
    }

    /// <summary>
    /// #############
    /// # Problem 5 #
    /// #############
    /// Find all paths through the maze
    /// </summary>
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
        // Initialize the path on the first call
        if (currPath == null)
        {
            currPath = new List<ValueTuple<int, int>>();
        }

        // Add current position to the path
        currPath.Add((x, y));

        // Base case: we reached the end
        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());
            currPath.RemoveAt(currPath.Count - 1); // backtrack
            return;
        }

        // Try moving in all four directions: right, down, left, up
        int[] dx = { 1, 0, -1, 0 };
        int[] dy = { 0, 1, 0, -1 };

        for (int i = 0; i < 4; i++)
        {
            int newX = x + dx[i];
            int newY = y + dy[i];

            if (maze.IsValidMove(currPath, newX, newY))
            {
                SolveMaze(results, maze, newX, newY, currPath);
            }
        }

        // Backtrack
        currPath.RemoveAt(currPath.Count - 1);
    }
}