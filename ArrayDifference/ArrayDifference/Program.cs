class Program {

    static void Main(string[] args) {
        Console.WriteLine("Enter first array");
        string[] firstArray = Console.ReadLine().Split(new char[] { ' ', '\n', '\t', ',' });
        Console.WriteLine("Enter second array");
        string[] secondArray = Console.ReadLine().Split(new char[] { ' ', '\n', '\t', ',' });

        string[] newArray = ArrayDifference
            .ArrayUtils
            .DifferenceWithoutCollections(firstArray, secondArray);

        List<string> newList = ArrayDifference
            .ArrayUtils
            .DifferenceWithCollections(firstArray, secondArray);

        Console.WriteLine("Result array (without collections)");
        newArray.ToList().ForEach(element => Console.Write(element + " "));
      
        Console.WriteLine("\nResult array (with collections)");
        newList.ForEach(element => Console.Write(element + " "));

    }
}
