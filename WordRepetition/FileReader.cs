using System;
using System.IO;
using System.Text;

namespace WordRepetition
{
    public static class FileReader
    {
        private static string _fileName;

        public static string ReadFileAsString()
        {
            return File.ReadAllText("TestFile.txt", Encoding.UTF8);
        }
    }
}
