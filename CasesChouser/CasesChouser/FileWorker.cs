using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CasesChouser
{
    internal class FileWorker
    {
        private static List<string> fileLines;
        private static Random random = new Random();

        public static string readAndParseFile(string pathToFile, int numberOfLines = 10) {

            using (StreamReader reader = new StreamReader(pathToFile)) {
                string line;
                fileLines = new List<string>();
                while ((line = reader.ReadLine()) != null) { 
                    fileLines.Add(line);
                }
            }

            if (fileLines.Count < numberOfLines)  
                numberOfLines = fileLines.Count;

            const string pattern = ".txt";
            const string target = "_res.txt";
            Regex regex = new Regex(pattern);
            string pathToNewFile = regex.Replace(pathToFile, target);

            int allLines = fileLines.Count;

            using (StreamWriter writer = new StreamWriter(pathToNewFile)) {
                writer.WriteLine(fileLines[0]);
                while (fileLines.Count != allLines - numberOfLines) { 
                    int randomLine = random.Next(1, fileLines.Count);
                    writer.WriteLine(fileLines[randomLine]);
                    fileLines.RemoveAt(randomLine);
                }
            }

            using (StreamWriter writer = new StreamWriter(pathToFile, false))
            {
                fileLines.ForEach(line => writer.WriteLine(line));
            }

            return pathToNewFile;
        }
    }
}
