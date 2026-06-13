public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        Data = data;
    }

    // Insert a value into the binary search tree
    public void Insert(int value)
    {
        if (value == Data)
        {
            return;
        }
        if (value < Data)
        {
            if (Left == null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            if (Right == null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    // Search for a value in the tree
    public bool Contains(int value)
    {
        if (value == Data)
        {
            return true;
        }

        if (value < Data)
        {
            if (Left == null)
                return false;

            return Left.Contains(value);
        }
        else
        {
            if (Right == null)
                return false;

            return Right.Contains(value);
        }
    }

    // Get the height of the tree
    // Get the height of the tree
    public int GetHeight()
    {
        int leftHeight = Left?.GetHeight() ?? 0;
        int rightHeight = Right?.GetHeight() ?? 0;

        return Math.Max(leftHeight, rightHeight) + 1;
    }
}