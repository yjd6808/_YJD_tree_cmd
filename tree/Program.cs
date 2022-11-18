using CTree;

string dir = Environment.CurrentDirectory;

if (args.Length >= 1)
{
    dir = args[0];

    if (!Directory.Exists(dir))
    {
        Console.WriteLine("올바른 디렉토리 명을 입력해주세요.");
        Environment.Exit(-1);
    }
}

ConsoleTree tree = new()
{
    ItemForegroundColor = ConsoleColor.White,
    BridgeForegroundColor = ConsoleColor.Red
};

ConstructFileTree(tree.Root, dir);
tree.Print();

void ConstructFileTree(ConsoleTreeItem parent, string curDir)
{
    foreach (string subDir in Directory.GetDirectories(curDir))
    {
        var child = parent.AddReturnChild(new ConsoleTreeItem(Path.GetFileName(subDir)) 
            { ForegroundColor = ConsoleColor.Cyan });
        ConstructFileTree(child, subDir);
    }

    foreach (string file in Directory.GetFiles(curDir))
        parent.Add(Path.GetFileName(file));
}





