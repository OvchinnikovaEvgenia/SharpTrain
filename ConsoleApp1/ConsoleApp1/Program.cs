class Program {
    static void Main(string[] args)
    {
        Console.WriteLine("Enter path to folder");
        string pathToFolder = Console.ReadLine();
        Console.WriteLine("Enter file extension");
        string extension = Console.ReadLine();

        Console.WriteLine("Fresh files: ");
        ConsoleApp1.FileSearcher.findFreshFiles(pathToFolder, extension)
            .ForEach(file => Console.WriteLine(Path.GetFileName(file)));
    }
 }
