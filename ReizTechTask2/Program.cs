using ReizTechTask2;

var branchHead = CreateExampleTree();

var depth = branchHead.Depth;

Console.WriteLine("Depth of the tree is: {0}", depth);

Branch CreateExampleTree()
{
    var root = new Branch();

    var secondLayerFirst = root.AddChild();
    var secondLayerSecond = root.AddChild();

    var thirdLayerFirst = secondLayerFirst.AddChild();
    var thirdLayerSecond = secondLayerSecond.AddChild();
    var thirdLayerThird = secondLayerSecond.AddChild();
    var thirdLayerForth = secondLayerSecond.AddChild();

    var forthLayerFirst = thirdLayerSecond.AddChild();
    var forthLayerSecond = thirdLayerThird.AddChild();
    var forthLayerThird = thirdLayerThird.AddChild();

    var fifthLayerFirst = forthLayerSecond.AddChild();
    return root;
}