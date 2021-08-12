using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul3HW5
{
    public class Starter
    {
        private string _pathToFiles = @"E:\A-Level\YurecGusar\Modul3HW5\Modul3HW5\Modul3HW5\Modul3HW5\";
        public void Run()
        {
            Console.WriteLine(GetRes().Result);
        }

        private async Task<string> GetRes()
        {
            Func<string, Task<string>> read = async (path) => await File.ReadAllTextAsync(path);

            var wordList = new List<Task<string>>();

            wordList.Add(read.Invoke($"{_pathToFiles}Hallo.txt"));
            wordList.Add(read.Invoke($"{_pathToFiles}World.txt"));

            return string.Join(" ", await Task.WhenAll(wordList));
        }
    }
}
