using System;
using System.Collections.Generic;
using System.Diagnostics;

public static class Arrays
{
    // Plan for MultiplesOf:
    // 1. Understand inputs: 'number' is the base value (double), 'count' is how many multiples we need (int).
    // 2. Need to create a new array of doubles with exactly 'count' elements.
    // 3. For each position i in the array (from 0 to count-1), the value should be number * (i + 1).
    // 4. Edge cases to consider: count == 0 (empty array?), count == 1 (just {number}), negative count? (probably not per tests).
    // 5. Return the completed array.

    public static double[] MultiplesOf(double number, int count)
    {
        // Create a new array of the required size
        double[] result = new double[count];

        // Fill the array with multiples of 'number'
        for (int i = 0; i < count; i++)
        {
            result[i] = number * (i + 1);
        }

        return result;
    }

    // Plan for RotateListRight:
    // 1. Understand: We are shifting elements to the right. The last 'amount' elements move to the front.
    // 2. One clear way: Use slicing (GetRange) + RemoveRange + InsertRange (or AddRange).
    //    - Take the last 'amount' elements.
    //    - Remove them from the end.
    //    - Insert them at the beginning (index 0).
    // 3. Alternative (good for learning): Use modulo (%) to calculate new positions in a temp list, then copy back.
    // 4. Edge cases: amount == data.Count (should be unchanged), amount == 1, amount == data.Count-1.
    // 5. Since it's in-place, we modify the original list.

    public static void RotateListRight(List<int> data, int amount)
    {
        // Handle edge cases safely
        if (data == null || data.Count == 0 || amount == 0)
        {
            return;
        }

        // Normalize amount (handles amount == data.Count and amount > data.Count safely)
        amount = amount % data.Count;

        if (amount == 0)
        {
            return;
        }

        // Index where the "right part" starts
        int splitIndex = data.Count - amount;

        // Get the last 'amount' elements into a temporary list
        List<int> rightPart = data.GetRange(splitIndex, amount);

        // Remove those elements from the end of the original list
        data.RemoveRange(splitIndex, amount);

        // Insert the saved elements at the beginning of the list
        data.InsertRange(0, rightPart);
    }

    public static void RunManualTests()
    {
        // Test MultiplesOf
        double[] multiples = MultiplesOf(3, 5);
        Debug.WriteLine("MultiplesOf(3, 5): " + string.Join(", ", multiples));

        // Test RotateListRight
        List<int> data = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        Debug.WriteLine("Before rotation: " + string.Join(", ", data));
        RotateListRight(data, 5);
        Debug.WriteLine("After rotation by 5: " + string.Join(", ", data));

        // Additional test
        data = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        RotateListRight(data, 3);
        Debug.WriteLine("After rotation by 3: " + string.Join(", ", data));
    }
}
