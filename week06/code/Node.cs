using static System.Console;

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
    if (value < Data)
    {
        // Insert to the left
        if (Left is null)
            Left = new Node(value);
        else
            Left.Insert(value);
    }
    else if (value > Data)
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
        if (value < Data)
        {
            return Left?.Contains(value) ?? false;  // Recurse left
        }
        else if (value > Data)
        {
            return Right?.Contains(value) ?? false; // Recurse right
        }
        return true;  // Found the value
        
    }

    public int GetHeight()
    {
        int leftHeight = Left?.GetHeight() ?? 0;
    int rightHeight = Right?.GetHeight() ?? 0;

    // The height is the maximum height of either subtree + 1 (for the current node)
    return Math.Max(leftHeight, rightHeight) + 1;
    }
}
