public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // Problem 1: Only allow unique values
        if (value == Data)
        {
            // Duplicate found — do nothing
            return;
        }

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // Problem 2: Search for the value
        if (value == Data)
            return true;

        if (value < Data)
        {
            // Search left subtree
            return Left != null && Left.Contains(value);
        }
        else
        {
            // Search right subtree
            return Right != null && Right.Contains(value);
        }
    }

    public int GetHeight()
    {
        // Problem 4: Calculate height
        int leftHeight = Left?.GetHeight() ?? 0;
        int rightHeight = Right?.GetHeight() ?? 0;

        // Height is 1 + the taller subtree
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}