public static class ArraySelector
{
    public static void Run()
    {
        var l1 = new[] { 1, 2, 3, 4, 5 };
        var l2 = new[] { 2, 4, 6, 8, 10};
        var select = new[] { 1, 1, 1, 2, 2, 1, 2, 2, 2, 1};
        var intResult = ListSelector(l1, l2, select);
        Console.WriteLine("<int[]>{" + string.Join(", ", intResult) + "}"); 
        // Expected: <int[]>{1, 2, 3, 2, 4, 4, 6, 8, 10, 5}
    }

    private static int[] ListSelector(int[] list1, int[] list2, int[] select)
    {
        // Plan for ListSelector:
        // 1. Create a new result array with the same length as the select array
        // 2. Use two index trackers: idx1 for list1 and idx2 for list2, both start at 0
        // 3. Loop through every element in the select array
        // 4. If select[i] == 1, take the next element from list1 and increment idx1
        // 5. If select[i] == 2, take the next element from list2 and increment idx2
        // 6. Store the selected value in the result array at the current position
        // 7. After processing all selectors, return the result array

        int[] result = new int[select.Length];
        int idx1 = 0;
        int idx2 = 0;

        for (int i = 0; i < select.Length; i++)
        {
            if (select[i] == 1)
            {
                result[i] = list1[idx1];
                idx1++;
            }
            else if (select[i] == 2)
            {
                result[i] = list2[idx2];
                idx2++;
            }
        }

        return result;
    }
}