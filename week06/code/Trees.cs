public static class Trees
{
    /// <summary>
    /// Given a sorted list (sorted_list), create a balanced BST.
    /// </summary>
    public static BinarySearchTree CreateTreeFromSortedList(int[] sortedNumbers)
    {
        var bst = new BinarySearchTree(); // Create an empty BST to start with
        InsertMiddle(sortedNumbers, 0, sortedNumbers.Length - 1, bst);
        return bst;
    }

    /// <summary>
    /// This function will attempt to insert the item in the middle of 'sortedNumbers' into
    /// the 'bst' tree.
    /// </summary>
    private static void InsertMiddle(int[] sortedNumbers, int first, int last, BinarySearchTree bst)
    {
        // Problem 5: Create a balanced tree from a sorted list
        if (first > last)
            return; // Base case: empty range

        // Find the middle index
        int mid = (first + last) / 2;

        // Insert the middle value
        bst.Insert(sortedNumbers[mid]);

        // Recursively insert left half
        InsertMiddle(sortedNumbers, first, mid - 1, bst);

        // Recursively insert right half
        InsertMiddle(sortedNumbers, mid + 1, last, bst);
    }
}