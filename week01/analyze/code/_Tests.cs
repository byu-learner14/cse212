using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Test MultiplesOf
        double[] multiples = Arrays.MultiplesOf(3, 5);
        Console.WriteLine("MultiplesOf(3, 5):");
        Console.WriteLine(string.Join(", ", multiples));
        // Expected: 3, 6, 9, 12, 15

        // Test RotateListRight
        List<int> data = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        Console.WriteLine("\nBefore rotation: " + string.Join(", ", data));

        Arrays.RotateListRight(data, 5);

        Console.WriteLine("After RotateListRight(data, 5):");
        Console.WriteLine(string.Join(", ", data));
        // Expected: 5, 6, 7, 8, 9, 1, 2, 3, 4
    }
}