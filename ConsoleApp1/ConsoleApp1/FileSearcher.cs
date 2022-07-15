using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class FileSearcher
    {
        private static Dictionary<string, DateTime> filesAndDates = new Dictionary<String, DateTime>();
        private static Dictionary<string, DateTime> filesAndDatesSorted = new Dictionary<String, DateTime>();
        private static List<string> freshFiles;
        private static TimeSpan borderTime = new TimeSpan(0, 0, 10);

        public static List<string> findFreshFiles(string pathToFolder, string extension) {
            Directory.GetFiles(pathToFolder, extension)
                         .ToList()
                         .ForEach(file => filesAndDates.Add(file, File.GetCreationTime(file)));


            foreach (KeyValuePair<string, DateTime> keyValuePair in filesAndDates.OrderByDescending(time => time.Value))
            {
                filesAndDatesSorted.Add(keyValuePair.Key, keyValuePair.Value);
            }

            freshFiles = new List<string>();

            freshFiles.Add(filesAndDatesSorted.Keys.ToArray()[0]);

            for (int i = 1; i < filesAndDatesSorted.Count; i++)
            {
                if (filesAndDatesSorted.Values.ToArray()[0]
                    .Subtract(filesAndDatesSorted.Values.ToArray()[i])
                    .CompareTo(borderTime) <= 0)
                {
                    freshFiles.Add((filesAndDatesSorted.Keys.ToArray()[i]));
                }
            }

            return freshFiles;
        }
    }
}
