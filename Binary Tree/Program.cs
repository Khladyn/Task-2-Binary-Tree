public class Branch
{
    // Declare variables
    public int value;
    public List<Branch> branches; // left and right branches

    // Create constructors
    public Branch(int val)
    {
        value = val;
        branches = new List<Branch>();
    }

    // Create a method to add branch
    public void AddBranch(int val)
    {
        // Start a root branch
        if (branches.Count == 0) branches.Add(new Branch(val));

        // If branch already exists, call compare method
        else CompareBranches(val, branches[0]);
    }

    // Create method to compare branches
    private void CompareBranches(int val, Branch branch)
    {
        // Store values lesser than the branch to the left child branch
        if (val < branch.value)
        {
            // If left branch is empty, create new branch
            if (branch.branches.Count == 0) branch.branches.Add(new Branch(val));

            // If left side has value, continue to child branch
            else CompareBranches(val, branch.branches[0]); 
        }

        // Store values greater than the branch to the right child branch
        else
        {
            // If only the left child is occupied, create new branch
            if (branch.branches.Count < 2) branch.branches.Add(new Branch(val));

            // If right side has value, continue to child branch
            else CompareBranches(val, branch.branches[1]); 
        }
    }

    public int FindDepth()
    {
        int leftDepth = 0; int rightDepth = 0;

        if (branches == null) return 0;

        if (branches.Count > 0) leftDepth = branches[0].FindDepth(); // visits left child branch
        if (branches.Count > 1) rightDepth = branches[1].FindDepth(); // visits right child branch

        // Increment the branch with greater depth
        return Math.Max(leftDepth, rightDepth) + 1;       
    }

    public static void Main()
    {
        Console.WriteLine("Binary Tree App");
        Console.WriteLine("_______________\n");

        Branch binaryTree;
        string[] branchValues;

        // Ask user to enter a list of numbers separated by space
        Console.Write("Enter a list of numbers: ");
        branchValues = Console.ReadLine().Split(' ');

        // Instantiate object with first element of the list
        binaryTree = new Branch(int.Parse(branchValues[0]));

        // Add remaining elements to the Branch object
        for (int i = 1; i < branchValues.Length; i++)
        {
            binaryTree.AddBranch(int.Parse(branchValues[i]));
        }

        // Print tree depth
        int treeDepth = binaryTree.FindDepth();
        Console.WriteLine($"The tree depth is {treeDepth}.");
    }
}
