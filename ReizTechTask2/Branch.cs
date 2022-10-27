namespace ReizTechTask2;

public class Branch
{
    private readonly List<Branch> _branches;

    public Branch()
    {
        _branches = new List<Branch>();
    }

    public int Depth => GetDepth(this);

    public Branch AddChild()
    {
        var newBranch = new Branch();
        _branches.Add(newBranch);
        return newBranch;
    }

    private static int GetDepth(Branch root)
    {
        const int depth = 1;
        return root._branches.Count == 0
            ? depth
            : root._branches.Select(branch => GetDepth(branch) + 1).Prepend(depth).Max();
    }
}