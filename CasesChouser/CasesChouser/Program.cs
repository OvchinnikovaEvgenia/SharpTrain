class Program {
    static void Main(string[] args) {


        Console.WriteLine("Enter path to file");
        string pathToFile = Console.ReadLine();
        Console.WriteLine("Enter number of lines");
        int numberOfLines;
        try
        {
            numberOfLines = int.Parse(Console.ReadLine());
            Console.WriteLine(CasesChouser.FileWorker.readAndParseFile(pathToFile, numberOfLines));
        }
        catch (Exception ex){
            Console.WriteLine(CasesChouser.FileWorker.readAndParseFile(pathToFile));
        }
        
    }
}
