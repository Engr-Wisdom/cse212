public static class Trees
{
    /// <summary>
    /// Given a sorted list (sorted_list), create a balanced BST.
    /// </summary>
    public static BinarySearchTree CreateTreeFromSortedList(int[] sortedNumbers)
    {
        var bst = new BinarySearchTree();
        InsertMiddle(sortedNumbers, 0, sortedNumbers.Length - 1, bst);
        return bst;
    }

    /// <summary>
    /// Inserts the middle element first, then recursively builds left and right subtrees.
    /// </summary>
    private static void InsertMiddle(int[] sortedNumbers, int first, int last, BinarySearchTree bst)
    {
        // Base case
        if (first > last)
        {
            return;
        }

        // IMPORTANT: use this midpoint formula (prevents subtle test mismatches)
        int middle = first + (last - first) / 2;

        // Insert middle first
        bst.Insert(sortedNumbers[middle]);

        // Build left subtree
        InsertMiddle(sortedNumbers, first, middle - 1, bst);

        // Build right subtree
        InsertMiddle(sortedNumbers, middle + 1, last, bst);
    }
}